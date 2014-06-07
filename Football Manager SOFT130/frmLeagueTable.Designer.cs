namespace Football_Manager_SOFT130
{
    partial class frmLeagueTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeagueTable));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchAll = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPending = new System.Windows.Forms.Label();
            this.btnPendingResult = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnEditTeam = new System.Windows.Forms.Button();
            this.lstLeagues = new System.Windows.Forms.ListBox();
            this.cboLeagues = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.menuBar;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearchAll);
            this.panel1.Location = new System.Drawing.Point(-8, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1301, 59);
            this.panel1.TabIndex = 62;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1176, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 33);
            this.btnSearch.TabIndex = 62;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchAll
            // 
            this.txtSearchAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSearchAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchAll.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAll.Location = new System.Drawing.Point(852, 14);
            this.txtSearchAll.Name = "txtSearchAll";
            this.txtSearchAll.Size = new System.Drawing.Size(321, 31);
            this.txtSearchAll.TabIndex = 61;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.footerBar;
            this.panel3.Controls.Add(this.lblPending);
            this.panel3.Controls.Add(this.btnPendingResult);
            this.panel3.Controls.Add(this.btnMainMenu);
            this.panel3.Location = new System.Drawing.Point(-4, 650);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1287, 104);
            this.panel3.TabIndex = 89;
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.BackColor = System.Drawing.Color.Transparent;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.ForeColor = System.Drawing.Color.White;
            this.lblPending.Location = new System.Drawing.Point(492, 17);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(404, 23);
            this.lblPending.TabIndex = 93;
            this.lblPending.Text = "Note: There are results which still need processing :";
            // 
            // btnPendingResult
            // 
            this.btnPendingResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnPendingResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPendingResult.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnPendingResult.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnPendingResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendingResult.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingResult.ForeColor = System.Drawing.Color.White;
            this.btnPendingResult.Location = new System.Drawing.Point(899, 8);
            this.btnPendingResult.Name = "btnPendingResult";
            this.btnPendingResult.Size = new System.Drawing.Size(191, 42);
            this.btnPendingResult.TabIndex = 92;
            this.btnPendingResult.Text = "View Pending Results";
            this.btnPendingResult.UseVisualStyleBackColor = false;
            this.btnPendingResult.Click += new System.EventHandler(this.btnPendingResult_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnMainMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMainMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnMainMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.ForeColor = System.Drawing.Color.White;
            this.btnMainMenu.Location = new System.Drawing.Point(1095, 8);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(164, 42);
            this.btnMainMenu.TabIndex = 32;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnEditTeam
            // 
            this.btnEditTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnEditTeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditTeam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnEditTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnEditTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTeam.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTeam.ForeColor = System.Drawing.Color.White;
            this.btnEditTeam.Location = new System.Drawing.Point(1069, 523);
            this.btnEditTeam.Name = "btnEditTeam";
            this.btnEditTeam.Size = new System.Drawing.Size(164, 38);
            this.btnEditTeam.TabIndex = 17;
            this.btnEditTeam.Text = "Save Changes";
            this.btnEditTeam.UseVisualStyleBackColor = false;
            // 
            // lstLeagues
            // 
            this.lstLeagues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(108)))), ((int)(((byte)(168)))));
            this.lstLeagues.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLeagues.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeagues.ForeColor = System.Drawing.Color.White;
            this.lstLeagues.FormattingEnabled = true;
            this.lstLeagues.ItemHeight = 23;
            this.lstLeagues.Location = new System.Drawing.Point(3, 53);
            this.lstLeagues.Name = "lstLeagues";
            this.lstLeagues.Size = new System.Drawing.Size(1239, 460);
            this.lstLeagues.TabIndex = 90;
            this.lstLeagues.SelectedIndexChanged += new System.EventHandler(this.lstLeagues_SelectedIndexChanged);
            // 
            // cboLeagues
            // 
            this.cboLeagues.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLeagues.FormattingEnabled = true;
            this.cboLeagues.Location = new System.Drawing.Point(796, 11);
            this.cboLeagues.Name = "cboLeagues";
            this.cboLeagues.Size = new System.Drawing.Size(437, 31);
            this.cboLeagues.TabIndex = 91;
            this.cboLeagues.SelectedIndexChanged += new System.EventHandler(this.cboLeagues_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.searchBack;
            this.panel2.Controls.Add(this.cboLeagues);
            this.panel2.Controls.Add(this.btnEditTeam);
            this.panel2.Controls.Add(this.lstLeagues);
            this.panel2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(13, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1245, 571);
            this.panel2.TabIndex = 92;
            // 
            // frmLeagueTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1270, 710);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1286, 749);
            this.MinimumSize = new System.Drawing.Size(1286, 749);
            this.Name = "frmLeagueTable";
            this.Text = "Football Manager - League Table";
            this.Load += new System.EventHandler(this.frmLeagueTable_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Button btnEditTeam;
        private System.Windows.Forms.Button btnPendingResult;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.ListBox lstLeagues;
        private System.Windows.Forms.ComboBox cboLeagues;
        private System.Windows.Forms.Panel panel2;
    }
}