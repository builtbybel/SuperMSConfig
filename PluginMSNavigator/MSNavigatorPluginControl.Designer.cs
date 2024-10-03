namespace MSNavigator
{
    partial class MSNavigatorPluginControl
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.resultsListBox = new System.Windows.Forms.ListBox();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pluginInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainStrip = new System.Windows.Forms.MenuStrip();
            this.newChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clippy95ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.contextMenu.SuspendLayout();
            this.menuMainStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9.25F, System.Drawing.FontStyle.Bold);
            this.searchTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.searchTextBox.Location = new System.Drawing.Point(23, 323);
            this.searchTextBox.Multiline = true;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(357, 29);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Text = "Type your question";
            this.searchTextBox.Click += new System.EventHandler(this.searchTextBox_Click);
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // resultsListBox
            // 
            this.resultsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultsListBox.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.25F);
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.ItemHeight = 16;
            this.resultsListBox.Location = new System.Drawing.Point(12, 59);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(443, 144);
            this.resultsListBox.TabIndex = 4;
            this.resultsListBox.SelectedIndexChanged += new System.EventHandler(this.resultsListBox_SelectedIndexChanged);
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.resultsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultsTextBox.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.25F);
            this.resultsTextBox.Location = new System.Drawing.Point(12, 220);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultsTextBox.Size = new System.Drawing.Size(443, 76);
            this.resultsTextBox.TabIndex = 6;
            this.resultsTextBox.Text = "Here\'s a tip! To get popular apps, just use the command \'install\'. Easy, right?";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginInfoToolStripMenuItem});
            this.contextMenu.Name = "contextManualMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.Size = new System.Drawing.Size(142, 26);
            // 
            // pluginInfoToolStripMenuItem
            // 
            this.pluginInfoToolStripMenuItem.Name = "pluginInfoToolStripMenuItem";
            this.pluginInfoToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.pluginInfoToolStripMenuItem.Text = "Plugin info...";
            // 
            // menuMainStrip
            // 
            this.menuMainStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuMainStrip.AutoSize = false;
            this.menuMainStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuMainStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newChatToolStripMenuItem,
            this.modelToolStripMenuItem});
            this.menuMainStrip.Location = new System.Drawing.Point(201, 17);
            this.menuMainStrip.Name = "menuMainStrip";
            this.menuMainStrip.Size = new System.Drawing.Size(254, 24);
            this.menuMainStrip.TabIndex = 252;
            this.menuMainStrip.Text = "menuStrip1";
            // 
            // newChatToolStripMenuItem
            // 
            this.newChatToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.newChatToolStripMenuItem.Name = "newChatToolStripMenuItem";
            this.newChatToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.newChatToolStripMenuItem.Text = "New Chat";
            this.newChatToolStripMenuItem.Click += new System.EventHandler(this.newChatToolStripMenuItem_Click);
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clippy95ToolStripMenuItem});
            this.modelToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            this.modelToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.modelToolStripMenuItem.Text = "Model";
            // 
            // clippy95ToolStripMenuItem
            // 
            this.clippy95ToolStripMenuItem.Checked = true;
            this.clippy95ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clippy95ToolStripMenuItem.Name = "clippy95ToolStripMenuItem";
            this.clippy95ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.clippy95ToolStripMenuItem.Text = "ClippyCompanion";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(380, 323);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 29);
            this.btnSend.TabIndex = 253;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // lblHeaderInfo
            // 
            this.lblHeaderInfo.AutoEllipsis = true;
            this.lblHeaderInfo.Font = new System.Drawing.Font("Segoe UI Variable Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeaderInfo.Location = new System.Drawing.Point(7, 14);
            this.lblHeaderInfo.Name = "lblHeaderInfo";
            this.lblHeaderInfo.Size = new System.Drawing.Size(191, 26);
            this.lblHeaderInfo.TabIndex = 254;
            this.lblHeaderInfo.Text = "Clippy Companion  |";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoEllipsis = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI Variable Small", 8.25F);
            this.lblInfo.Location = new System.Drawing.Point(49, 436);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(363, 43);
            this.lblInfo.TabIndex = 255;
            this.lblInfo.Text = "...";
            // 
            // MSNavigatorPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblHeaderInfo);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.menuMainStrip);
            this.Controls.Add(this.resultsTextBox);
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.searchTextBox);
            this.Name = "MSNavigatorPluginControl";
            this.Size = new System.Drawing.Size(467, 492);
            this.contextMenu.ResumeLayout(false);
            this.menuMainStrip.ResumeLayout(false);
            this.menuMainStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ListBox resultsListBox;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem pluginInfoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuMainStrip;
        private System.Windows.Forms.ToolStripMenuItem newChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clippy95ToolStripMenuItem;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Label lblInfo;
    }
}
