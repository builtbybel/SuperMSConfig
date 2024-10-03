namespace SuperMSConfig
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label4 = new System.Windows.Forms.Label();
            this.linkGitHub = new System.Windows.Forms.LinkLabel();
            this.assetMenuExtensions = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMSConfig = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbCheckNote = new System.Windows.Forms.RichTextBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.cbShowOnlyBadHabits = new System.Windows.Forms.CheckBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.rbBad = new System.Windows.Forms.RadioButton();
            this.rbGood = new System.Windows.Forms.RadioButton();
            this.rbNotConfigured = new System.Windows.Forms.RadioButton();
            this.lblRestore = new System.Windows.Forms.LinkLabel();
            this.lblFix = new System.Windows.Forms.LinkLabel();
            this.habitListView = new System.Windows.Forms.ListView();
            this.extensionsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.appInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkRandomPlugin = new System.Windows.Forms.LinkLabel();
            this.border = new System.Windows.Forms.Label();
            this.btnFooter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.assetMenuSettings = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboTemplates = new System.Windows.Forms.ToolStripComboBox();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectBadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNotConfiguredOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assetMenu = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelSplitter = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.extensionsMenuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(288, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 15);
            this.label4.TabIndex = 280;
            this.label4.Text = "|";
            // 
            // linkGitHub
            // 
            this.linkGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkGitHub.AutoSize = true;
            this.linkGitHub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.linkGitHub.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkGitHub.LinkColor = System.Drawing.Color.Blue;
            this.linkGitHub.Location = new System.Drawing.Point(238, 533);
            this.linkGitHub.Name = "linkGitHub";
            this.linkGitHub.Size = new System.Drawing.Size(45, 15);
            this.linkGitHub.TabIndex = 279;
            this.linkGitHub.TabStop = true;
            this.linkGitHub.Text = "GitHub";
            this.linkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGitHub_LinkClicked);
            // 
            // assetMenuExtensions
            // 
            this.assetMenuExtensions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.assetMenuExtensions.BackColor = System.Drawing.Color.Transparent;
            this.assetMenuExtensions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetMenuExtensions.FlatAppearance.BorderColor = System.Drawing.Color.LavenderBlush;
            this.assetMenuExtensions.FlatAppearance.BorderSize = 0;
            this.assetMenuExtensions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.assetMenuExtensions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assetMenuExtensions.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold);
            this.assetMenuExtensions.Image = ((System.Drawing.Image)(resources.GetObject("assetMenuExtensions.Image")));
            this.assetMenuExtensions.Location = new System.Drawing.Point(307, 25);
            this.assetMenuExtensions.Name = "assetMenuExtensions";
            this.assetMenuExtensions.Size = new System.Drawing.Size(48, 48);
            this.assetMenuExtensions.TabIndex = 283;
            this.assetMenuExtensions.UseVisualStyleBackColor = false;
            this.assetMenuExtensions.Click += new System.EventHandler(this.assetMenuExtensions_Click);
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.comboBoxMSConfig);
            this.panelMain.Controls.Add(this.lblDescription);
            this.panelMain.Controls.Add(this.rtbCheckNote);
            this.panelMain.Controls.Add(this.panelSettings);
            this.panelMain.Controls.Add(this.habitListView);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(661, 440);
            this.panelMain.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Small", 11.5F);
            this.label2.Location = new System.Drawing.Point(212, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 21);
            this.label2.TabIndex = 306;
            this.label2.Text = "Let\'s get started with your check";
            // 
            // comboBoxMSConfig
            // 
            this.comboBoxMSConfig.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxMSConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMSConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxMSConfig.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 14.25F);
            this.comboBoxMSConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBoxMSConfig.FormattingEnabled = true;
            this.comboBoxMSConfig.Location = new System.Drawing.Point(239, 259);
            this.comboBoxMSConfig.Name = "comboBoxMSConfig";
            this.comboBoxMSConfig.Size = new System.Drawing.Size(170, 34);
            this.comboBoxMSConfig.TabIndex = 304;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(19, 7);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(624, 33);
            this.lblDescription.TabIndex = 302;
            // 
            // rtbCheckNote
            // 
            this.rtbCheckNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCheckNote.BackColor = System.Drawing.SystemColors.Control;
            this.rtbCheckNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbCheckNote.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCheckNote.ForeColor = System.Drawing.Color.Black;
            this.rtbCheckNote.Location = new System.Drawing.Point(150, 132);
            this.rtbCheckNote.Name = "rtbCheckNote";
            this.rtbCheckNote.ReadOnly = true;
            this.rtbCheckNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbCheckNote.Size = new System.Drawing.Size(358, 88);
            this.rtbCheckNote.TabIndex = 294;
            this.rtbCheckNote.TabStop = false;
            this.rtbCheckNote.Text = "Hello";
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSettings.BackColor = System.Drawing.Color.Transparent;
            this.panelSettings.Controls.Add(this.cbShowOnlyBadHabits);
            this.panelSettings.Controls.Add(this.rtbLog);
            this.panelSettings.Controls.Add(this.searchTextBox);
            this.panelSettings.Controls.Add(this.rbBad);
            this.panelSettings.Controls.Add(this.rbGood);
            this.panelSettings.Controls.Add(this.rbNotConfigured);
            this.panelSettings.Controls.Add(this.lblRestore);
            this.panelSettings.Controls.Add(this.lblFix);
            this.panelSettings.Location = new System.Drawing.Point(19, 317);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(624, 120);
            this.panelSettings.TabIndex = 297;
            this.panelSettings.Visible = false;
            // 
            // cbShowOnlyBadHabits
            // 
            this.cbShowOnlyBadHabits.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbShowOnlyBadHabits.AutoSize = true;
            this.cbShowOnlyBadHabits.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowOnlyBadHabits.ForeColor = System.Drawing.Color.Black;
            this.cbShowOnlyBadHabits.Location = new System.Drawing.Point(4, 65);
            this.cbShowOnlyBadHabits.Name = "cbShowOnlyBadHabits";
            this.cbShowOnlyBadHabits.Size = new System.Drawing.Size(136, 19);
            this.cbShowOnlyBadHabits.TabIndex = 8;
            this.cbShowOnlyBadHabits.TabStop = false;
            this.cbShowOnlyBadHabits.Text = "Show only bad config";
            this.cbShowOnlyBadHabits.UseVisualStyleBackColor = true;
            this.cbShowOnlyBadHabits.CheckedChanged += new System.EventHandler(this.cbShowOnlyBadHabits_CheckedChanged);
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.BackColor = System.Drawing.SystemColors.Control;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Font = new System.Drawing.Font("Segoe UI Variable Small Light", 8.25F);
            this.rtbLog.Location = new System.Drawing.Point(3, 6);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(618, 53);
            this.rtbLog.TabIndex = 305;
            this.rtbLog.Text = "";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.searchTextBox.BackColor = System.Drawing.Color.White;
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchTextBox.Location = new System.Drawing.Point(239, 65);
            this.searchTextBox.Multiline = true;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(116, 25);
            this.searchTextBox.TabIndex = 7;
            this.searchTextBox.TabStop = false;
            this.searchTextBox.Text = "Filter";
            this.searchTextBox.Click += new System.EventHandler(this.searchTextBox_Click);
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // rbBad
            // 
            this.rbBad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rbBad.AutoSize = true;
            this.rbBad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbBad.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBad.ForeColor = System.Drawing.Color.DimGray;
            this.rbBad.Location = new System.Drawing.Point(344, 98);
            this.rbBad.Name = "rbBad";
            this.rbBad.Size = new System.Drawing.Size(46, 21);
            this.rbBad.TabIndex = 256;
            this.rbBad.Text = "Bad";
            this.rbBad.UseVisualStyleBackColor = true;
            this.rbBad.CheckedChanged += new System.EventHandler(this.rbBad_CheckedChanged);
            // 
            // rbGood
            // 
            this.rbGood.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rbGood.AutoSize = true;
            this.rbGood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbGood.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGood.ForeColor = System.Drawing.Color.DimGray;
            this.rbGood.Location = new System.Drawing.Point(267, 98);
            this.rbGood.Name = "rbGood";
            this.rbGood.Size = new System.Drawing.Size(55, 21);
            this.rbGood.TabIndex = 255;
            this.rbGood.Text = "Good";
            this.rbGood.UseVisualStyleBackColor = true;
            this.rbGood.CheckedChanged += new System.EventHandler(this.rbGood_CheckedChanged);
            // 
            // rbNotConfigured
            // 
            this.rbNotConfigured.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rbNotConfigured.AutoSize = true;
            this.rbNotConfigured.Checked = true;
            this.rbNotConfigured.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbNotConfigured.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNotConfigured.ForeColor = System.Drawing.Color.DimGray;
            this.rbNotConfigured.Location = new System.Drawing.Point(150, 98);
            this.rbNotConfigured.Name = "rbNotConfigured";
            this.rbNotConfigured.Size = new System.Drawing.Size(108, 21);
            this.rbNotConfigured.TabIndex = 277;
            this.rbNotConfigured.TabStop = true;
            this.rbNotConfigured.Text = "Not configured";
            this.rbNotConfigured.UseVisualStyleBackColor = true;
            // 
            // lblRestore
            // 
            this.lblRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRestore.AutoSize = true;
            this.lblRestore.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestore.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblRestore.LinkColor = System.Drawing.Color.DimGray;
            this.lblRestore.Location = new System.Drawing.Point(417, 73);
            this.lblRestore.Name = "lblRestore";
            this.lblRestore.Size = new System.Drawing.Size(100, 17);
            this.lblRestore.TabIndex = 299;
            this.lblRestore.TabStop = true;
            this.lblRestore.Text = "Restore default";
            this.lblRestore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRestore_LinkClicked);
            // 
            // lblFix
            // 
            this.lblFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFix.AutoSize = true;
            this.lblFix.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFix.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblFix.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblFix.Location = new System.Drawing.Point(541, 73);
            this.lblFix.Name = "lblFix";
            this.lblFix.Size = new System.Drawing.Size(80, 17);
            this.lblFix.TabIndex = 298;
            this.lblFix.TabStop = true;
            this.lblFix.Text = "Fix selected";
            this.lblFix.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFix_LinkClicked);
            // 
            // habitListView
            // 
            this.habitListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.habitListView.BackColor = System.Drawing.SystemColors.Control;
            this.habitListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.habitListView.CheckBoxes = true;
            this.habitListView.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F);
            this.habitListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.habitListView.HideSelection = false;
            this.habitListView.Location = new System.Drawing.Point(19, 43);
            this.habitListView.Name = "habitListView";
            this.habitListView.ShowItemToolTips = true;
            this.habitListView.Size = new System.Drawing.Size(624, 181);
            this.habitListView.TabIndex = 303;
            this.habitListView.UseCompatibleStateImageBehavior = false;
            this.habitListView.View = System.Windows.Forms.View.Details;
            this.habitListView.Visible = false;
            this.habitListView.Click += new System.EventHandler(this.habitListView_Click);
            // 
            // extensionsMenuStrip
            // 
            this.extensionsMenuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.extensionsMenuStrip.Font = new System.Drawing.Font("Segoe UI Variable Small", 10.25F);
            this.extensionsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appInfoToolStripMenuItem});
            this.extensionsMenuStrip.Name = "contextMenuStrip";
            this.extensionsMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.extensionsMenuStrip.Size = new System.Drawing.Size(122, 26);
            // 
            // appInfoToolStripMenuItem
            // 
            this.appInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appInfoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.appInfoToolStripMenuItem.Name = "appInfoToolStripMenuItem";
            this.appInfoToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.appInfoToolStripMenuItem.Text = "App-Info";
            // 
            // linkRandomPlugin
            // 
            this.linkRandomPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkRandomPlugin.AutoEllipsis = true;
            this.linkRandomPlugin.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.5F);
            this.linkRandomPlugin.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkRandomPlugin.LinkColor = System.Drawing.Color.DimGray;
            this.linkRandomPlugin.Location = new System.Drawing.Point(309, 533);
            this.linkRandomPlugin.Name = "linkRandomPlugin";
            this.linkRandomPlugin.Size = new System.Drawing.Size(324, 20);
            this.linkRandomPlugin.TabIndex = 288;
            this.linkRandomPlugin.TabStop = true;
            this.linkRandomPlugin.Text = "Plugin";
            // 
            // border
            // 
            this.border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.border.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.border.Location = new System.Drawing.Point(0, 1);
            this.border.Name = "border";
            this.border.Size = new System.Drawing.Size(685, 1);
            this.border.TabIndex = 289;
            // 
            // btnFooter
            // 
            this.btnFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFooter.AutoEllipsis = true;
            this.btnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFooter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFooter.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnFooter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnFooter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFooter.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFooter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFooter.Location = new System.Drawing.Point(97, 528);
            this.btnFooter.Name = "btnFooter";
            this.btnFooter.Size = new System.Drawing.Size(103, 22);
            this.btnFooter.TabIndex = 290;
            this.btnFooter.Text = "AI-Perfected Windows";
            this.btnFooter.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFooter.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Small", 7.25F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(217, 531);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 14);
            this.label1.TabIndex = 292;
            this.label1.Text = "|";
            // 
            // assetMenuSettings
            // 
            this.assetMenuSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.assetMenuSettings.AutoSize = true;
            this.assetMenuSettings.BackColor = System.Drawing.Color.Transparent;
            this.assetMenuSettings.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.assetMenuSettings.FlatAppearance.BorderSize = 0;
            this.assetMenuSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.assetMenuSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assetMenuSettings.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold);
            this.assetMenuSettings.Location = new System.Drawing.Point(551, 3);
            this.assetMenuSettings.Name = "assetMenuSettings";
            this.assetMenuSettings.Size = new System.Drawing.Size(35, 30);
            this.assetMenuSettings.TabIndex = 278;
            this.assetMenuSettings.Text = "...";
            this.assetMenuSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.assetMenuSettings.UseVisualStyleBackColor = false;
            this.assetMenuSettings.Click += new System.EventHandler(this.assetMenuSettings_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.AutoEllipsis = true;
            this.btnCheck.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI Variable Small", 10F);
            this.btnCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(539, 33);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(116, 30);
            this.btnCheck.TabIndex = 207;
            this.btnCheck.Text = "Check";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.contextMenuStrip.Font = new System.Drawing.Font("Segoe UI Variable Small", 10.25F);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox,
            this.toolStripComboTemplates,
            this.selectToolStripMenuItem,
            this.selectBadConfigToolStripMenuItem,
            this.selectNotConfiguredOnlyToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip.Size = new System.Drawing.Size(261, 149);
            // 
            // toolStripTextBox
            // 
            this.toolStripTextBox.AutoSize = false;
            this.toolStripTextBox.AutoToolTip = true;
            this.toolStripTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox.Margin = new System.Windows.Forms.Padding(1, 5, 1, 1);
            this.toolStripTextBox.Name = "toolStripTextBox";
            this.toolStripTextBox.Size = new System.Drawing.Size(200, 20);
            this.toolStripTextBox.Text = "Load config from source:";
            // 
            // toolStripComboTemplates
            // 
            this.toolStripComboTemplates.BackColor = System.Drawing.Color.White;
            this.toolStripComboTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboTemplates.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 11.25F);
            this.toolStripComboTemplates.Name = "toolStripComboTemplates";
            this.toolStripComboTemplates.Size = new System.Drawing.Size(200, 28);
            this.toolStripComboTemplates.SelectedIndexChanged += new System.EventHandler(this.toolStripComboTemplates_SelectedIndexChanged);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(260, 24);
            this.selectToolStripMenuItem.Text = "Select/Unselect all";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // selectBadConfigToolStripMenuItem
            // 
            this.selectBadConfigToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.selectBadConfigToolStripMenuItem.Name = "selectBadConfigToolStripMenuItem";
            this.selectBadConfigToolStripMenuItem.Size = new System.Drawing.Size(260, 24);
            this.selectBadConfigToolStripMenuItem.Text = "Select Bad only";
            this.selectBadConfigToolStripMenuItem.Click += new System.EventHandler(this.selectBadConfigToolStripMenuItem_Click);
            // 
            // selectNotConfiguredOnlyToolStripMenuItem
            // 
            this.selectNotConfiguredOnlyToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.selectNotConfiguredOnlyToolStripMenuItem.Name = "selectNotConfiguredOnlyToolStripMenuItem";
            this.selectNotConfiguredOnlyToolStripMenuItem.Size = new System.Drawing.Size(260, 24);
            this.selectNotConfiguredOnlyToolStripMenuItem.Text = "Select Not Configured only";
            this.selectNotConfiguredOnlyToolStripMenuItem.Click += new System.EventHandler(this.selectNotConfiguredOnlyToolStripMenuItem_Click);
            // 
            // assetMenu
            // 
            this.assetMenu.AutoSize = true;
            this.assetMenu.BackColor = System.Drawing.Color.Transparent;
            this.assetMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetMenu.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.assetMenu.FlatAppearance.BorderSize = 0;
            this.assetMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.assetMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assetMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 19F, System.Drawing.FontStyle.Bold);
            this.assetMenu.Location = new System.Drawing.Point(17, 12);
            this.assetMenu.Name = "assetMenu";
            this.assetMenu.Size = new System.Drawing.Size(40, 36);
            this.assetMenu.TabIndex = 293;
            this.assetMenu.Text = "...";
            this.assetMenu.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.assetMenu.UseVisualStyleBackColor = false;
            this.assetMenu.Click += new System.EventHandler(this.assetMenu_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 69);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelSplitter);
            this.splitContainer.Panel1Collapsed = true;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelMain);
            this.splitContainer.Size = new System.Drawing.Size(661, 440);
            this.splitContainer.SplitterDistance = 253;
            this.splitContainer.SplitterWidth = 10;
            this.splitContainer.TabIndex = 294;
            // 
            // panelSplitter
            // 
            this.panelSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitter.Location = new System.Drawing.Point(0, 0);
            this.panelSplitter.Name = "panelSplitter";
            this.panelSplitter.Size = new System.Drawing.Size(253, 100);
            this.panelSplitter.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI Variable Small", 10.5F);
            this.lblInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblInfo.Location = new System.Drawing.Point(60, 25);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(69, 19);
            this.lblInfo.TabIndex = 307;
            this.lblInfo.Text = "/ How-to";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(685, 557);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.assetMenu);
            this.Controls.Add(this.assetMenuSettings);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFooter);
            this.Controls.Add(this.border);
            this.Controls.Add(this.linkRandomPlugin);
            this.Controls.Add(this.assetMenuExtensions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkGitHub);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SuperMSConfig";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.extensionsMenuStrip.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkGitHub;
        private System.Windows.Forms.Button assetMenuExtensions;
        private System.Windows.Forms.ContextMenuStrip extensionsMenuStrip;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.LinkLabel linkRandomPlugin;
        private System.Windows.Forms.Label border;
        private System.Windows.Forms.ToolStripMenuItem appInfoToolStripMenuItem;
        private System.Windows.Forms.Button btnFooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbCheckNote;
        private System.Windows.Forms.LinkLabel lblRestore;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.CheckBox cbShowOnlyBadHabits;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.RadioButton rbBad;
        private System.Windows.Forms.RadioButton rbGood;
        private System.Windows.Forms.RadioButton rbNotConfigured;
        private System.Windows.Forms.LinkLabel lblFix;
        private System.Windows.Forms.Button assetMenuSettings;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox;
        private System.Windows.Forms.ToolStripComboBox toolStripComboTemplates;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectBadConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNotConfiguredOnlyToolStripMenuItem;
        private System.Windows.Forms.Button assetMenu;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelSplitter;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.ComboBox comboBoxMSConfig;
        private System.Windows.Forms.ListView habitListView;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfo;
    }
}

