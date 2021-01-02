namespace Burner
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Frame = new System.Windows.Forms.ToolStripContainer();
            this.NavigationBar = new System.Windows.Forms.ToolStrip();
            this.BackButton = new System.Windows.Forms.ToolStripButton();
            this.ForwardButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.AddressBar = new System.Windows.Forms.ToolStripTextBox();
            this.SettingsButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SearchEngineOption = new System.Windows.Forms.ToolStripMenuItem();
            this.NewInstanceOption = new System.Windows.Forms.ToolStripMenuItem();
            this.DisableJavaScriptOption = new System.Windows.Forms.ToolStripMenuItem();
            this.ExternalBrowserButton = new System.Windows.Forms.ToolStripButton();
            this.HistoryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HistoryContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Frame.TopToolStripPanel.SuspendLayout();
            this.Frame.SuspendLayout();
            this.NavigationBar.SuspendLayout();
            this.HistoryMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Frame
            // 
            this.Frame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Frame.BottomToolStripPanelVisible = false;
            // 
            // Frame.ContentPanel
            // 
            this.Frame.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Frame.ContentPanel.Size = new System.Drawing.Size(570, 285);
            this.Frame.LeftToolStripPanelVisible = false;
            this.Frame.Location = new System.Drawing.Point(0, 0);
            this.Frame.Name = "Frame";
            this.Frame.RightToolStripPanelVisible = false;
            this.Frame.Size = new System.Drawing.Size(570, 310);
            this.Frame.TabIndex = 0;
            this.Frame.Text = "toolStripContainer1";
            // 
            // Frame.TopToolStripPanel
            // 
            this.Frame.TopToolStripPanel.Controls.Add(this.NavigationBar);
            // 
            // NavigationBar
            // 
            this.NavigationBar.AllowMerge = false;
            this.NavigationBar.CanOverflow = false;
            this.NavigationBar.Dock = System.Windows.Forms.DockStyle.None;
            this.NavigationBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.NavigationBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackButton,
            this.ForwardButton,
            this.RefreshButton,
            this.AddressBar,
            this.SettingsButton,
            this.ExternalBrowserButton});
            this.NavigationBar.Location = new System.Drawing.Point(0, 0);
            this.NavigationBar.Name = "NavigationBar";
            this.NavigationBar.Size = new System.Drawing.Size(570, 25);
            this.NavigationBar.Stretch = true;
            this.NavigationBar.TabIndex = 0;
            // 
            // BackButton
            // 
            this.BackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BackButton.Image = global::Burner.Properties.Resources.back;
            this.BackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(23, 22);
            this.BackButton.Text = "Left click to go back, right click to see history";
            this.BackButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackButton_MouseDown);
            // 
            // ForwardButton
            // 
            this.ForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ForwardButton.Image = global::Burner.Properties.Resources.forward;
            this.ForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(23, 22);
            this.ForwardButton.Text = "Left click to go forward, right click to see history";
            this.ForwardButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ForwardButton_MouseDown);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshButton.Image = global::Burner.Properties.Resources.refresh;
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshButton.Text = "Reload this page";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AddressBar
            // 
            this.AddressBar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddressBar.Name = "AddressBar";
            this.AddressBar.Size = new System.Drawing.Size(400, 25);
            this.AddressBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressBar_KeyPress);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchEngineOption,
            this.DisableJavaScriptOption,
            this.NewInstanceOption});
            this.SettingsButton.Image = global::Burner.Properties.Resources.settings;
            this.SettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(29, 22);
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.ToolTipText = "Settings";
            // 
            // SearchEngineOption
            // 
            this.SearchEngineOption.Name = "SearchEngineOption";
            this.SearchEngineOption.Size = new System.Drawing.Size(180, 22);
            this.SearchEngineOption.Text = "Search Engine";
            // 
            // NewInstanceOption
            // 
            this.NewInstanceOption.Name = "NewInstanceOption";
            this.NewInstanceOption.Size = new System.Drawing.Size(180, 22);
            this.NewInstanceOption.Text = "Start new instance";
            this.NewInstanceOption.Click += new System.EventHandler(this.NewInstanceOption_Click);
            // 
            // DisableJavaScriptOption
            // 
            this.DisableJavaScriptOption.Name = "DisableJavaScriptOption";
            this.DisableJavaScriptOption.Size = new System.Drawing.Size(180, 22);
            this.DisableJavaScriptOption.Text = "Disable JavaScript";
            this.DisableJavaScriptOption.Click += new System.EventHandler(this.DisableJavaScriptOption_Click);
            // 
            // ExternalBrowserButton
            // 
            this.ExternalBrowserButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ExternalBrowserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExternalBrowserButton.Image = global::Burner.Properties.Resources.open_in_new;
            this.ExternalBrowserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExternalBrowserButton.Name = "ExternalBrowserButton";
            this.ExternalBrowserButton.Size = new System.Drawing.Size(23, 22);
            this.ExternalBrowserButton.Text = "Open this page in default browser";
            this.ExternalBrowserButton.Click += new System.EventHandler(this.ExternalBrowserButton_Click);
            // 
            // HistoryMenu
            // 
            this.HistoryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HistoryContextMenu});
            this.HistoryMenu.Name = "contextMenuStrip1";
            this.HistoryMenu.Size = new System.Drawing.Size(113, 26);
            // 
            // HistoryContextMenu
            // 
            this.HistoryContextMenu.Name = "HistoryContextMenu";
            this.HistoryContextMenu.Size = new System.Drawing.Size(112, 22);
            this.HistoryContextMenu.Text = "History";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 310);
            this.Controls.Add(this.Frame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(200, 65);
            this.Name = "MainWindow";
            this.Text = "Burner";
            this.Resize += new System.EventHandler(this.Resize_AddressBar);
            this.Frame.TopToolStripPanel.ResumeLayout(false);
            this.Frame.TopToolStripPanel.PerformLayout();
            this.Frame.ResumeLayout(false);
            this.Frame.PerformLayout();
            this.NavigationBar.ResumeLayout(false);
            this.NavigationBar.PerformLayout();
            this.HistoryMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer Frame;
        private System.Windows.Forms.ToolStrip NavigationBar;
        private System.Windows.Forms.ToolStripButton BackButton;
        private System.Windows.Forms.ToolStripButton ForwardButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripTextBox AddressBar;
        private System.Windows.Forms.ToolStripDropDownButton SettingsButton;
        private System.Windows.Forms.ToolStripMenuItem SearchEngineOption;
        private System.Windows.Forms.ContextMenuStrip HistoryMenu;
        private System.Windows.Forms.ToolStripMenuItem HistoryContextMenu;
        private System.Windows.Forms.ToolStripButton ExternalBrowserButton;
        private System.Windows.Forms.ToolStripMenuItem NewInstanceOption;
        private System.Windows.Forms.ToolStripMenuItem DisableJavaScriptOption;
    }
}

