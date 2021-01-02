using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Burner
{
    public partial class MainWindow : Form
    {
        private readonly ChromiumWebBrowser Browser;
        private readonly Stack<string> BackHistory;
        private readonly Stack<string> ForwardHistory;
        private readonly Dictionary<string, string> SearchEngineProviders;
        private string SearchEngineURLPrefix;

        public MainWindow()
        {
            InitializeComponent();
            // Set proper address bar size on start up
            Resize_AddressBar(this, null);

            #region Initialize Browser

            // Global CefSettings
            CefSettings settings = new CefSettings();
            // Disable JavaScript with command line arguments on demand
            if (Properties.Settings.Default.DisableJavaScript)
            {
                settings.CefCommandLineArgs.Add("disable-javascript", "1");
                DisableJavaScriptOption.Checked = true;
            }
            // Disable Logging for release builds
            settings.LogSeverity = CefSharp.LogSeverity.Disable;
            // Apply settings
            CefSharp.Cef.Initialize(settings);
            
            // Browser Initialization
            Browser = new ChromiumWebBrowser("");
            // Subscribe to URL and loading Changes to change UI accordingly
            Browser.AddressChanged += Browser_AddressChanged;
            Browser.LoadingStateChanged += Browser_LoadingStateChanged;
            // Handle pop-up window and file download in one tab
            Browser.LifeSpanHandler = new LifeSpanHandler();
            Browser.DownloadHandler = new DownloadHandler();

            // Show browser
            Frame.ContentPanel.Controls.Add(Browser);

            #endregion

            #region Initialize Search Engine options

            // Initialize search engine options from configuration file
            SearchEngineProviders = new Dictionary<string, string>();
            foreach (string i in Properties.Settings.Default.SearchEngine)
            {
                // One record in a line, name and URL seperated with ','
                string[] data = i.Split(',');
                SearchEngineProviders.Add(data[0], data[1]);
                // Add options to menu
                ToolStripMenuItem Entity = new ToolStripMenuItem {Text = data[0]};
                Entity.Click += Switch_SearchEngine;
                SearchEngineOption.DropDownItems.Add(Entity);
            }
            // Load saved preference
            Switch_SearchEngine((new ToolStripMenuItem() { Text = Properties.Settings.Default.DefaultEngine }), null);

            #endregion

            #region Initialize History

            // History is stored as stack of strings
            BackHistory = new Stack<string>();
            ForwardHistory = new Stack<string>();

            #endregion
        }

        #region Browser UI update callbacks
        // Update refresh button icon
        private void Browser_LoadingStateChanged(object sender, CefSharp.LoadingStateChangedEventArgs e)
        {
            NavigationBar.Invoke(((MethodInvoker)(() => RefreshButton.Image = e.IsLoading ? Properties.Resources.close : Properties.Resources.refresh)));
        }
        // Update address bar URL
        private void Browser_AddressChanged(object sender, EventArgs e)
        {
            string URL = Browser.Address;
            if (BackHistory.Count == 0 || URL != BackHistory.Peek())
                BackHistory.Push(Browser.Address);
            NavigationBar.Invoke((MethodInvoker)(() => AddressBar.Text = URL));
        }
        #endregion

        #region InitializeComponent() event implementations
        private void BackButton_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (BackHistory.Count > 1)
                    {
                        ForwardHistory.Push(BackHistory.Pop());
                        Browser.Load(BackHistory.Peek());
                    }
                    break;
                case MouseButtons.Right:
                    HistoryMenu.Items.Clear();
                    foreach (var i in BackHistory)
                    {
                        ToolStripMenuItem Entity = new ToolStripMenuItem{Text = i};
                        Entity.Click += Load_History;
                        HistoryMenu.Items.Add(Entity);
                    }
                    HistoryMenu.Show(MousePosition);
                    break;
            }
        }
        private void ForwardButton_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (ForwardHistory.Count != 0)
                    {
                        string Target = ForwardHistory.Pop();
                        Browser.Load(Target);
                        BackHistory.Push(Target);
                    }
                    break;
                case MouseButtons.Right:
                    HistoryMenu.Items.Clear();
                    foreach (var i in ForwardHistory)
                    {
                        ToolStripMenuItem Entity = new ToolStripMenuItem { Text = i};
                        Entity.Click += Load_History;
                        HistoryMenu.Items.Add(Entity);
                    }
                    HistoryMenu.Show(MousePosition);
                    break;
            }
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (Browser.IsLoading)
                Browser.Load("about:newtab");
            else if (BackHistory.Count != 0)
                Browser.Load(BackHistory.Peek());
        }
        private void AddressBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string Target = AddressBar.Text;
                if (!IsValidURL(Target))
                {
                    Target.Replace(' ', '+');
                    Target = SearchEngineURLPrefix + Target;
                }
                Browser.Load(Target);
                e.Handled = true;
            }
        }
        private void ExternalBrowserButton_Click(object sender, EventArgs e)
        {
            if (IsValidURL(Browser.Address))
                System.Diagnostics.Process.Start(Browser.Address);
        }
        private void NewInstanceOption_Click(object sender, EventArgs e)
        {
            string Executable = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            System.Diagnostics.Process.Start(Executable);
        }
        private void DisableJavaScriptOption_Click(object sender, EventArgs e)
        {
            DisableJavaScriptOption.Checked ^= true;
            Properties.Settings.Default.DisableJavaScript ^= true;
            Properties.Settings.Default.Save();
            MessageBox.Show("Restart to apply changes.");
        }
        private void Resize_AddressBar(object sender, EventArgs e)
        {
            int WindowWidth = NavigationBar.Size.Width;
            int AvailableWidth = WindowWidth;
            foreach (ToolStripItem i in NavigationBar.Items)
            {
                if (i != AddressBar)
                    AvailableWidth -= i.Size.Width;
            }
            int TargetWidth = (int)(AvailableWidth * 0.85);
            int TargetHorizontalMargin = (int)((AvailableWidth - TargetWidth) * 0.5);

            var TargetSize = AddressBar.Size;
            TargetSize.Width = TargetWidth;
            AddressBar.Size = TargetSize;
            var TargetMargin = AddressBar.Margin;
            TargetMargin.Left = TargetHorizontalMargin;
            TargetMargin.Right = TargetHorizontalMargin;
            AddressBar.Margin = TargetMargin;
        }
        #endregion

        #region Dynamically-generated menus event implementations
        // Jump to history on click
        private void Load_History(object sender, EventArgs e)
        {
            Browser.Load((sender as ToolStripMenuItem).Text);
        }
        // Change search engine on click
        private void Switch_SearchEngine(object sender, EventArgs e)
        {
            string Choice = (sender as ToolStripMenuItem).Text;
            foreach (ToolStripMenuItem i in SearchEngineOption.DropDownItems)
                i.Checked = (i.Text == Choice);
            SearchEngineURLPrefix = SearchEngineProviders[Choice];
            Properties.Settings.Default.DefaultEngine = Choice;
            Properties.Settings.Default.Save();
        }
        #endregion

        private static bool IsValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }
    }
}