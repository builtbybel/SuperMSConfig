namespace MSCleanupCompanion
{
    partial class MSCCPluginControl
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.checkedListBoxApps = new System.Windows.Forms.CheckedListBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.mdlMenu = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.scanAgainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.BackColor = System.Drawing.Color.PaleGreen;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(3, 97);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(418, 21);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.AutoEllipsis = true;
            this.btnRemoveSelected.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRemoveSelected.FlatAppearance.BorderSize = 0;
            this.btnRemoveSelected.Font = new System.Drawing.Font("Segoe UI Variable Small", 10.75F);
            this.btnRemoveSelected.Location = new System.Drawing.Point(0, 464);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(423, 28);
            this.btnRemoveSelected.TabIndex = 198;
            this.btnRemoveSelected.TabStop = false;
            this.btnRemoveSelected.Text = "Remove selected apps";
            this.btnRemoveSelected.UseCompatibleTextRendering = true;
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // checkedListBoxApps
            // 
            this.checkedListBoxApps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxApps.CheckOnClick = true;
            this.checkedListBoxApps.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F);
            this.checkedListBoxApps.FormattingEnabled = true;
            this.checkedListBoxApps.Location = new System.Drawing.Point(0, 121);
            this.checkedListBoxApps.Name = "checkedListBoxApps";
            this.checkedListBoxApps.Size = new System.Drawing.Size(422, 340);
            this.checkedListBoxApps.Sorted = true;
            this.checkedListBoxApps.TabIndex = 199;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.White;
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(18, 54);
            this.textBoxSearch.Multiline = true;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(95, 21);
            this.textBoxSearch.TabIndex = 204;
            this.textBoxSearch.Text = "Search";
            this.textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSearch.Click += new System.EventHandler(this.textBoxSearch_Click);
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // mdlMenu
            // 
            this.mdlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mdlMenu.AutoSize = true;
            this.mdlMenu.BackColor = System.Drawing.Color.Transparent;
            this.mdlMenu.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.mdlMenu.FlatAppearance.BorderSize = 0;
            this.mdlMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mdlMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F, System.Drawing.FontStyle.Bold);
            this.mdlMenu.ForeColor = System.Drawing.Color.Black;
            this.mdlMenu.Location = new System.Drawing.Point(390, 12);
            this.mdlMenu.Name = "mdlMenu";
            this.mdlMenu.Size = new System.Drawing.Size(30, 28);
            this.mdlMenu.TabIndex = 247;
            this.mdlMenu.Text = "...";
            this.mdlMenu.UseVisualStyleBackColor = false;
            this.mdlMenu.Click += new System.EventHandler(this.mdlMenu_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanAgainToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.installedToolStripMenuItem,
            this.customDatabaseToolStripMenuItem,
            this.pluginInfoToolStripMenuItem});
            this.contextMenu.Name = "contextManualMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.Size = new System.Drawing.Size(175, 114);
            // 
            // scanAgainToolStripMenuItem
            // 
            this.scanAgainToolStripMenuItem.Name = "scanAgainToolStripMenuItem";
            this.scanAgainToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.scanAgainToolStripMenuItem.Text = "Scan again";
            this.scanAgainToolStripMenuItem.Click += new System.EventHandler(this.scanAgainToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllStripMenuItem_Click);
            // 
            // installedToolStripMenuItem
            // 
            this.installedToolStripMenuItem.Name = "installedToolStripMenuItem";
            this.installedToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.installedToolStripMenuItem.Text = "Show all installed";
            this.installedToolStripMenuItem.Click += new System.EventHandler(this.installedToolStripMenuItem_Click);
            // 
            // customDatabaseToolStripMenuItem
            // 
            this.customDatabaseToolStripMenuItem.Name = "customDatabaseToolStripMenuItem";
            this.customDatabaseToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.customDatabaseToolStripMenuItem.Text = "Select custom db...";
            this.customDatabaseToolStripMenuItem.Click += new System.EventHandler(this.customDatabaseToolStripMenuItem_Click);
            // 
            // pluginInfoToolStripMenuItem
            // 
            this.pluginInfoToolStripMenuItem.Name = "pluginInfoToolStripMenuItem";
            this.pluginInfoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pluginInfoToolStripMenuItem.Text = "Plugin info...";
            this.pluginInfoToolStripMenuItem.Click += new System.EventHandler(this.pluginInfoToolStripMenuItem_Click);
            // 
            // lblHeaderInfo
            // 
            this.lblHeaderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderInfo.AutoEllipsis = true;
            this.lblHeaderInfo.Font = new System.Drawing.Font("Segoe UI Variable Text", 16.25F, System.Drawing.FontStyle.Bold);
            this.lblHeaderInfo.Location = new System.Drawing.Point(7, 14);
            this.lblHeaderInfo.Name = "lblHeaderInfo";
            this.lblHeaderInfo.Size = new System.Drawing.Size(327, 30);
            this.lblHeaderInfo.TabIndex = 248;
            this.lblHeaderInfo.Text = "Microsoft Cleanup Companion";
            // 
            // MSCCPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblHeaderInfo);
            this.Controls.Add(this.mdlMenu);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.checkedListBoxApps);
            this.Controls.Add(this.lblStatus);
            this.Name = "MSCCPluginControl";
            this.Size = new System.Drawing.Size(423, 492);
            this.Load += new System.EventHandler(this.toolDebloaterPageView_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.CheckedListBox checkedListBoxApps;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button mdlMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanAgainToolStripMenuItem;
        private System.Windows.Forms.Label lblHeaderInfo;
    }
}
