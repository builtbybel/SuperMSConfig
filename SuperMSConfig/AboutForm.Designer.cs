namespace SuperMSConfig
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnDonate = new System.Windows.Forms.Button();
            this.btnWebsite = new System.Windows.Forms.Button();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.linkVersion = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Gainsboro;
            this.panelBottom.Controls.Add(this.btnDonate);
            this.panelBottom.Controls.Add(this.btnWebsite);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 379);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(451, 76);
            this.panelBottom.TabIndex = 0;
            // 
            // btnDonate
            // 
            this.btnDonate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDonate.AutoEllipsis = true;
            this.btnDonate.BackColor = System.Drawing.Color.White;
            this.btnDonate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDonate.FlatAppearance.BorderSize = 0;
            this.btnDonate.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonate.ForeColor = System.Drawing.Color.Black;
            this.btnDonate.Location = new System.Drawing.Point(227, 23);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(203, 32);
            this.btnDonate.TabIndex = 247;
            this.btnDonate.TabStop = false;
            this.btnDonate.Text = "Donate";
            this.btnDonate.UseVisualStyleBackColor = true;
            this.btnDonate.Click += new System.EventHandler(this.btnDonate_Click);
            // 
            // btnWebsite
            // 
            this.btnWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebsite.AutoEllipsis = true;
            this.btnWebsite.BackColor = System.Drawing.Color.White;
            this.btnWebsite.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnWebsite.FlatAppearance.BorderSize = 0;
            this.btnWebsite.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebsite.ForeColor = System.Drawing.Color.Black;
            this.btnWebsite.Location = new System.Drawing.Point(19, 23);
            this.btnWebsite.Name = "btnWebsite";
            this.btnWebsite.Size = new System.Drawing.Size(203, 32);
            this.btnWebsite.TabIndex = 246;
            this.btnWebsite.TabStop = false;
            this.btnWebsite.Text = "GitHub";
            this.btnWebsite.UseVisualStyleBackColor = true;
            this.btnWebsite.Click += new System.EventHandler(this.btnWebsite_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAbout.AutoEllipsis = true;
            this.lblAbout.BackColor = System.Drawing.Color.Transparent;
            this.lblAbout.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.Location = new System.Drawing.Point(14, 88);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(425, 91);
            this.lblAbout.TabIndex = 233;
            this.lblAbout.Text = resources.GetString("lblAbout.Text");
            // 
            // lblHeaderInfo
            // 
            this.lblHeaderInfo.AutoSize = true;
            this.lblHeaderInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderInfo.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeaderInfo.Location = new System.Drawing.Point(10, 14);
            this.lblHeaderInfo.Name = "lblHeaderInfo";
            this.lblHeaderInfo.Size = new System.Drawing.Size(188, 32);
            this.lblHeaderInfo.TabIndex = 235;
            this.lblHeaderInfo.Text = "SuperMSConfig";
            // 
            // linkVersion
            // 
            this.linkVersion.AutoEllipsis = true;
            this.linkVersion.BackColor = System.Drawing.Color.Transparent;
            this.linkVersion.Font = new System.Drawing.Font("Segoe UI Variable Small", 10.75F);
            this.linkVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkVersion.LinkColor = System.Drawing.Color.Black;
            this.linkVersion.Location = new System.Drawing.Point(12, 59);
            this.linkVersion.Name = "linkVersion";
            this.linkVersion.Size = new System.Drawing.Size(427, 20);
            this.linkVersion.TabIndex = 237;
            this.linkVersion.TabStop = true;
            this.linkVersion.Text = "Version";
            this.linkVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAbout_LinkClicked);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoEllipsis = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Small Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 46);
            this.label2.TabIndex = 239;
            this.label2.Text = "Microsoft 365 Copilot is a registered trademark of Microsoft Corporation. ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(314, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 240;
            this.label3.Text = "A Belim app creation (2024)";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 455);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkVersion);
            this.Controls.Add(this.lblHeaderInfo);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.Button btnDonate;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.LinkLabel linkVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}