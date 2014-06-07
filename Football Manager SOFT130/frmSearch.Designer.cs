namespace Football_Manager_SOFT130
{
    partial class frmSearch
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
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.lblSearchFilter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPending = new System.Windows.Forms.Label();
            this.btnPendingResult = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearchForm = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchAll = new System.Windows.Forms.TextBox();
            this.lblSearchResult = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDynamicSearch = new System.Windows.Forms.TextBox();
            this.btnEditFixture = new System.Windows.Forms.Button();
            this.btnEditLeague = new System.Windows.Forms.Button();
            this.btnEditTeam = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(108)))), ((int)(((byte)(168)))));
            this.lstSearchResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSearchResults.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSearchResults.ForeColor = System.Drawing.Color.White;
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.ItemHeight = 19;
            this.lstSearchResults.Location = new System.Drawing.Point(4, 45);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(1236, 475);
            this.lstSearchResults.TabIndex = 64;
            this.lstSearchResults.Click += new System.EventHandler(this.lstSearchResults_Click);
            // 
            // lblSearchFilter
            // 
            this.lblSearchFilter.AutoSize = true;
            this.lblSearchFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchFilter.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchFilter.ForeColor = System.Drawing.Color.White;
            this.lblSearchFilter.Location = new System.Drawing.Point(10, 11);
            this.lblSearchFilter.Name = "lblSearchFilter";
            this.lblSearchFilter.Size = new System.Drawing.Size(154, 23);
            this.lblSearchFilter.TabIndex = 65;
            this.lblSearchFilter.Text = "Results Found for: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 66;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnMainMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMainMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnMainMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.ForeColor = System.Drawing.Color.White;
            this.btnMainMenu.Location = new System.Drawing.Point(1102, 7);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(162, 42);
            this.btnMainMenu.TabIndex = 67;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.footerBar;
            this.panel3.Controls.Add(this.lblPending);
            this.panel3.Controls.Add(this.btnMainMenu);
            this.panel3.Controls.Add(this.btnPendingResult);
            this.panel3.Location = new System.Drawing.Point(-4, 651);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1287, 104);
            this.panel3.TabIndex = 85;
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.BackColor = System.Drawing.Color.Transparent;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.ForeColor = System.Drawing.Color.White;
            this.lblPending.Location = new System.Drawing.Point(489, 17);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(404, 23);
            this.lblPending.TabIndex = 91;
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
            this.btnPendingResult.Location = new System.Drawing.Point(899, 7);
            this.btnPendingResult.Name = "btnPendingResult";
            this.btnPendingResult.Size = new System.Drawing.Size(192, 42);
            this.btnPendingResult.TabIndex = 90;
            this.btnPendingResult.Text = "View Pending Results";
            this.btnPendingResult.UseVisualStyleBackColor = false;
            this.btnPendingResult.Click += new System.EventHandler(this.btnPendingResult_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.menuBar;
            this.panel2.Controls.Add(this.btnSearchForm);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(-1, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1299, 59);
            this.panel2.TabIndex = 63;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnSearchForm
            // 
            this.btnSearchForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnSearchForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearchForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnSearchForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnSearchForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchForm.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchForm.ForeColor = System.Drawing.Color.White;
            this.btnSearchForm.Location = new System.Drawing.Point(1162, 13);
            this.btnSearchForm.Name = "btnSearchForm";
            this.btnSearchForm.Size = new System.Drawing.Size(93, 33);
            this.btnSearchForm.TabIndex = 62;
            this.btnSearchForm.Text = "Search";
            this.btnSearchForm.UseVisualStyleBackColor = false;
            this.btnSearchForm.Click += new System.EventHandler(this.btnSearchForm_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(835, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(321, 31);
            this.textBox1.TabIndex = 61;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.menuBar;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearchAll);
            this.panel1.Location = new System.Drawing.Point(-102, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 62;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Location = new System.Drawing.Point(1181, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 33);
            this.btnSearch.TabIndex = 62;
            this.btnSearch.Text = "Search...";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchAll
            // 
            this.txtSearchAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSearchAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchAll.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAll.Location = new System.Drawing.Point(858, 14);
            this.txtSearchAll.Name = "txtSearchAll";
            this.txtSearchAll.Size = new System.Drawing.Size(321, 31);
            this.txtSearchAll.TabIndex = 61;
            // 
            // lblSearchResult
            // 
            this.lblSearchResult.AutoSize = true;
            this.lblSearchResult.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchResult.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResult.ForeColor = System.Drawing.Color.White;
            this.lblSearchResult.Location = new System.Drawing.Point(159, 11);
            this.lblSearchResult.Name = "lblSearchResult";
            this.lblSearchResult.Size = new System.Drawing.Size(40, 23);
            this.lblSearchResult.TabIndex = 86;
            this.lblSearchResult.Text = "null";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.searchBack;
            this.panel4.Controls.Add(this.txtDynamicSearch);
            this.panel4.Controls.Add(this.btnEditFixture);
            this.panel4.Controls.Add(this.btnEditLeague);
            this.panel4.Controls.Add(this.btnEditTeam);
            this.panel4.Controls.Add(this.lblSearchResult);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.lblSearchFilter);
            this.panel4.Controls.Add(this.lstSearchResults);
            this.panel4.Location = new System.Drawing.Point(15, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1243, 571);
            this.panel4.TabIndex = 87;
            // 
            // txtDynamicSearch
            // 
            this.txtDynamicSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(44)))), ((int)(((byte)(66)))));
            this.txtDynamicSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDynamicSearch.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDynamicSearch.ForeColor = System.Drawing.Color.White;
            this.txtDynamicSearch.Location = new System.Drawing.Point(835, 8);
            this.txtDynamicSearch.Name = "txtDynamicSearch";
            this.txtDynamicSearch.Size = new System.Drawing.Size(396, 31);
            this.txtDynamicSearch.TabIndex = 90;
            this.txtDynamicSearch.TextChanged += new System.EventHandler(this.txtDynamicSearch_TextChanged);
            this.txtDynamicSearch.Enter += new System.EventHandler(this.txtDynamicSearch_Enter);
            this.txtDynamicSearch.Leave += new System.EventHandler(this.txtDynamicSearch_Leave);
            // 
            // btnEditFixture
            // 
            this.btnEditFixture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnEditFixture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditFixture.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnEditFixture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnEditFixture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditFixture.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditFixture.ForeColor = System.Drawing.Color.White;
            this.btnEditFixture.Location = new System.Drawing.Point(758, 526);
            this.btnEditFixture.Name = "btnEditFixture";
            this.btnEditFixture.Size = new System.Drawing.Size(154, 38);
            this.btnEditFixture.TabIndex = 89;
            this.btnEditFixture.Text = "Edit Fixture";
            this.btnEditFixture.UseVisualStyleBackColor = false;
            this.btnEditFixture.Click += new System.EventHandler(this.btnEditFixture_Click);
            // 
            // btnEditLeague
            // 
            this.btnEditLeague.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnEditLeague.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditLeague.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnEditLeague.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnEditLeague.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditLeague.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditLeague.ForeColor = System.Drawing.Color.White;
            this.btnEditLeague.Location = new System.Drawing.Point(919, 526);
            this.btnEditLeague.Name = "btnEditLeague";
            this.btnEditLeague.Size = new System.Drawing.Size(154, 38);
            this.btnEditLeague.TabIndex = 88;
            this.btnEditLeague.Text = "Edit League";
            this.btnEditLeague.UseVisualStyleBackColor = false;
            this.btnEditLeague.Click += new System.EventHandler(this.btnEditLeague_Click);
            // 
            // btnEditTeam
            // 
            this.btnEditTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnEditTeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditTeam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnEditTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnEditTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTeam.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTeam.ForeColor = System.Drawing.Color.White;
            this.btnEditTeam.Location = new System.Drawing.Point(1080, 526);
            this.btnEditTeam.Name = "btnEditTeam";
            this.btnEditTeam.Size = new System.Drawing.Size(154, 38);
            this.btnEditTeam.TabIndex = 87;
            this.btnEditTeam.Text = "Edit Team";
            this.btnEditTeam.UseVisualStyleBackColor = false;
            this.btnEditTeam.Click += new System.EventHandler(this.btnEditTeam_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1270, 710);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1286, 749);
            this.MinimumSize = new System.Drawing.Size(1286, 749);
            this.Name = "frmSearch";
            this.Text = "Football Manager - Search";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearchForm;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.Label lblSearchFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSearchResult;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnEditFixture;
        private System.Windows.Forms.Button btnEditLeague;
        private System.Windows.Forms.Button btnEditTeam;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Button btnPendingResult;
        private System.Windows.Forms.TextBox txtDynamicSearch;
    }
}