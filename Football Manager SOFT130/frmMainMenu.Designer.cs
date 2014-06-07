namespace Football_Manager_SOFT130
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.btnAddLeague = new System.Windows.Forms.Button();
            this.btnAddTeam = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lstLeagues = new System.Windows.Forms.ListBox();
            this.btnEditLeague = new System.Windows.Forms.Button();
            this.imgLstIcons = new System.Windows.Forms.ImageList(this.components);
            this.cboTargetLeague = new System.Windows.Forms.ComboBox();
            this.btnEditTeam = new System.Windows.Forms.Button();
            this.lstViewTeams = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchAll = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnViewLeagueTable = new System.Windows.Forms.Button();
            this.lblPending = new System.Windows.Forms.Label();
            this.btnPendingResult = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteTeam = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDeleteFixture = new System.Windows.Forms.Button();
            this.btnDeleteLeague = new System.Windows.Forms.Button();
            this.btnEditFixture = new System.Windows.Forms.Button();
            this.txtSearchFixtures = new System.Windows.Forms.TextBox();
            this.lblOut = new System.Windows.Forms.Label();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.btnAddFixture = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddLeague
            // 
            this.btnAddLeague.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnAddLeague.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLeague.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnAddLeague.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnAddLeague.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLeague.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLeague.ForeColor = System.Drawing.Color.White;
            this.btnAddLeague.Location = new System.Drawing.Point(10, 499);
            this.btnAddLeague.Name = "btnAddLeague";
            this.btnAddLeague.Size = new System.Drawing.Size(121, 42);
            this.btnAddLeague.TabIndex = 2;
            this.btnAddLeague.Text = "Add League";
            this.btnAddLeague.UseVisualStyleBackColor = false;
            this.btnAddLeague.Click += new System.EventHandler(this.btnAddLeague_Click);
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnAddTeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTeam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnAddTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnAddTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTeam.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTeam.ForeColor = System.Drawing.Color.White;
            this.btnAddTeam.Location = new System.Drawing.Point(119, 506);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(115, 37);
            this.btnAddTeam.TabIndex = 3;
            this.btnAddTeam.Text = "Add Team";
            this.btnAddTeam.UseVisualStyleBackColor = false;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1146, 667);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 37);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lstLeagues
            // 
            this.lstLeagues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(108)))), ((int)(((byte)(168)))));
            this.lstLeagues.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLeagues.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeagues.ForeColor = System.Drawing.Color.White;
            this.lstLeagues.FormattingEnabled = true;
            this.lstLeagues.ItemHeight = 19;
            this.lstLeagues.Location = new System.Drawing.Point(4, 55);
            this.lstLeagues.Name = "lstLeagues";
            this.lstLeagues.Size = new System.Drawing.Size(795, 437);
            this.lstLeagues.TabIndex = 1;
            this.lstLeagues.Click += new System.EventHandler(this.lstLeagues_Click);
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
            this.btnEditLeague.Location = new System.Drawing.Point(136, 499);
            this.btnEditLeague.Name = "btnEditLeague";
            this.btnEditLeague.Size = new System.Drawing.Size(135, 42);
            this.btnEditLeague.TabIndex = 8;
            this.btnEditLeague.Text = "Edit League";
            this.btnEditLeague.UseVisualStyleBackColor = false;
            this.btnEditLeague.Click += new System.EventHandler(this.btnEditLeague_Click);
            // 
            // imgLstIcons
            // 
            this.imgLstIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgLstIcons.ImageSize = new System.Drawing.Size(85, 88);
            this.imgLstIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cboTargetLeague
            // 
            this.cboTargetLeague.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(44)))), ((int)(((byte)(66)))));
            this.cboTargetLeague.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetLeague.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTargetLeague.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTargetLeague.ForeColor = System.Drawing.Color.White;
            this.cboTargetLeague.FormattingEnabled = true;
            this.cboTargetLeague.Location = new System.Drawing.Point(12, 80);
            this.cboTargetLeague.Name = "cboTargetLeague";
            this.cboTargetLeague.Size = new System.Drawing.Size(415, 31);
            this.cboTargetLeague.TabIndex = 63;
            this.cboTargetLeague.SelectedIndexChanged += new System.EventHandler(this.cboSelectedLeague_SelectedIndexChanged);
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
            this.btnEditTeam.Location = new System.Drawing.Point(240, 506);
            this.btnEditTeam.Name = "btnEditTeam";
            this.btnEditTeam.Size = new System.Drawing.Size(112, 37);
            this.btnEditTeam.TabIndex = 64;
            this.btnEditTeam.Text = "Edit Team";
            this.btnEditTeam.UseVisualStyleBackColor = false;
            this.btnEditTeam.Click += new System.EventHandler(this.btnEditTeam_Click);
            // 
            // lstViewTeams
            // 
            this.lstViewTeams.BackColor = System.Drawing.Color.White;
            this.lstViewTeams.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.logosBack;
            this.lstViewTeams.BackgroundImageTiled = true;
            this.lstViewTeams.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstViewTeams.ForeColor = System.Drawing.Color.White;
            this.lstViewTeams.LargeImageList = this.imgLstIcons;
            this.lstViewTeams.Location = new System.Drawing.Point(12, 112);
            this.lstViewTeams.MultiSelect = false;
            this.lstViewTeams.Name = "lstViewTeams";
            this.lstViewTeams.Size = new System.Drawing.Size(415, 464);
            this.lstViewTeams.TabIndex = 62;
            this.lstViewTeams.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.menuBar;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearchAll);
            this.panel1.Location = new System.Drawing.Point(-8, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1301, 59);
            this.panel1.TabIndex = 61;
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
            this.btnSearch.Location = new System.Drawing.Point(1164, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 33);
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
            this.txtSearchAll.Location = new System.Drawing.Point(839, 13);
            this.txtSearchAll.Name = "txtSearchAll";
            this.txtSearchAll.Size = new System.Drawing.Size(321, 31);
            this.txtSearchAll.TabIndex = 61;
            this.txtSearchAll.Enter += new System.EventHandler(this.txtSearchAll_Enter);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.footerBar;
            this.panel3.Controls.Add(this.btnViewLeagueTable);
            this.panel3.Controls.Add(this.lblPending);
            this.panel3.Controls.Add(this.btnPendingResult);
            this.panel3.Location = new System.Drawing.Point(-11, 660);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1287, 104);
            this.panel3.TabIndex = 86;
            // 
            // btnViewLeagueTable
            // 
            this.btnViewLeagueTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnViewLeagueTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewLeagueTable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnViewLeagueTable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnViewLeagueTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLeagueTable.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewLeagueTable.ForeColor = System.Drawing.Color.White;
            this.btnViewLeagueTable.Location = new System.Drawing.Point(25, 6);
            this.btnViewLeagueTable.Name = "btnViewLeagueTable";
            this.btnViewLeagueTable.Size = new System.Drawing.Size(133, 38);
            this.btnViewLeagueTable.TabIndex = 2;
            this.btnViewLeagueTable.Text = "League Table";
            this.btnViewLeagueTable.UseVisualStyleBackColor = false;
            this.btnViewLeagueTable.Click += new System.EventHandler(this.btnViewLeagueTable_Click);
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.BackColor = System.Drawing.Color.Transparent;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.ForeColor = System.Drawing.Color.White;
            this.lblPending.Location = new System.Drawing.Point(544, 14);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(404, 23);
            this.lblPending.TabIndex = 1;
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
            this.btnPendingResult.Location = new System.Drawing.Point(954, 7);
            this.btnPendingResult.Name = "btnPendingResult";
            this.btnPendingResult.Size = new System.Drawing.Size(197, 37);
            this.btnPendingResult.TabIndex = 0;
            this.btnPendingResult.Text = "View Pending Results";
            this.btnPendingResult.UseVisualStyleBackColor = false;
            this.btnPendingResult.Click += new System.EventHandler(this.btnPendingResult_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.panelBack;
            this.panel2.Controls.Add(this.btnDeleteTeam);
            this.panel2.Controls.Add(this.btnEditTeam);
            this.panel2.Controls.Add(this.btnAddTeam);
            this.panel2.Location = new System.Drawing.Point(8, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(423, 556);
            this.panel2.TabIndex = 87;
            // 
            // btnDeleteTeam
            // 
            this.btnDeleteTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnDeleteTeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteTeam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnDeleteTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnDeleteTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTeam.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTeam.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTeam.Location = new System.Drawing.Point(358, 506);
            this.btnDeleteTeam.Name = "btnDeleteTeam";
            this.btnDeleteTeam.Size = new System.Drawing.Size(54, 37);
            this.btnDeleteTeam.TabIndex = 65;
            this.btnDeleteTeam.Text = "Del.";
            this.btnDeleteTeam.UseVisualStyleBackColor = false;
            this.btnDeleteTeam.Click += new System.EventHandler(this.btnDeleteTeam_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.panelList;
            this.panel4.Controls.Add(this.btnDeleteFixture);
            this.panel4.Controls.Add(this.btnDeleteLeague);
            this.panel4.Controls.Add(this.btnEditFixture);
            this.panel4.Controls.Add(this.txtSearchFixtures);
            this.panel4.Controls.Add(this.lblOut);
            this.panel4.Controls.Add(this.btnEditLeague);
            this.panel4.Controls.Add(this.lstLeagues);
            this.panel4.Controls.Add(this.btnAddLeague);
            this.panel4.Controls.Add(this.lblDisplay);
            this.panel4.Controls.Add(this.btnAddFixture);
            this.panel4.Location = new System.Drawing.Point(457, 79);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(802, 551);
            this.panel4.TabIndex = 88;
            // 
            // btnDeleteFixture
            // 
            this.btnDeleteFixture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnDeleteFixture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteFixture.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnDeleteFixture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnDeleteFixture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFixture.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFixture.ForeColor = System.Drawing.Color.White;
            this.btnDeleteFixture.Location = new System.Drawing.Point(731, 500);
            this.btnDeleteFixture.Name = "btnDeleteFixture";
            this.btnDeleteFixture.Size = new System.Drawing.Size(60, 42);
            this.btnDeleteFixture.TabIndex = 9;
            this.btnDeleteFixture.Text = "Del.";
            this.btnDeleteFixture.UseVisualStyleBackColor = false;
            this.btnDeleteFixture.Click += new System.EventHandler(this.btnDeleteFixture_Click);
            // 
            // btnDeleteLeague
            // 
            this.btnDeleteLeague.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnDeleteLeague.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteLeague.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnDeleteLeague.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnDeleteLeague.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteLeague.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLeague.ForeColor = System.Drawing.Color.White;
            this.btnDeleteLeague.Location = new System.Drawing.Point(276, 499);
            this.btnDeleteLeague.Name = "btnDeleteLeague";
            this.btnDeleteLeague.Size = new System.Drawing.Size(54, 42);
            this.btnDeleteLeague.TabIndex = 9;
            this.btnDeleteLeague.Text = "Del.";
            this.btnDeleteLeague.UseVisualStyleBackColor = false;
            this.btnDeleteLeague.Click += new System.EventHandler(this.btnDeleteLeague_Click);
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
            this.btnEditFixture.Location = new System.Drawing.Point(606, 500);
            this.btnEditFixture.Name = "btnEditFixture";
            this.btnEditFixture.Size = new System.Drawing.Size(119, 42);
            this.btnEditFixture.TabIndex = 8;
            this.btnEditFixture.Text = "Edit Fixture";
            this.btnEditFixture.UseVisualStyleBackColor = false;
            this.btnEditFixture.Click += new System.EventHandler(this.btnEditFixture_Click);
            // 
            // txtSearchFixtures
            // 
            this.txtSearchFixtures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(44)))), ((int)(((byte)(66)))));
            this.txtSearchFixtures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchFixtures.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchFixtures.ForeColor = System.Drawing.Color.White;
            this.txtSearchFixtures.Location = new System.Drawing.Point(393, 13);
            this.txtSearchFixtures.Name = "txtSearchFixtures";
            this.txtSearchFixtures.Size = new System.Drawing.Size(396, 31);
            this.txtSearchFixtures.TabIndex = 7;
            this.txtSearchFixtures.TextChanged += new System.EventHandler(this.txtSearchFixtures_TextChanged);
            this.txtSearchFixtures.Enter += new System.EventHandler(this.txtSearchFixtures_Enter);
            this.txtSearchFixtures.Leave += new System.EventHandler(this.txtSearchFixtures_Leave);
            // 
            // lblOut
            // 
            this.lblOut.AutoSize = true;
            this.lblOut.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOut.ForeColor = System.Drawing.Color.White;
            this.lblOut.Location = new System.Drawing.Point(180, 18);
            this.lblOut.Name = "lblOut";
            this.lblOut.Size = new System.Drawing.Size(40, 23);
            this.lblOut.TabIndex = 6;
            this.lblOut.Text = "null";
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.ForeColor = System.Drawing.Color.White;
            this.lblDisplay.Location = new System.Drawing.Point(11, 18);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(174, 23);
            this.lblDisplay.TabIndex = 5;
            this.lblDisplay.Text = "Displaying fixtures in:";
            // 
            // btnAddFixture
            // 
            this.btnAddFixture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(114)))), ((int)(((byte)(154)))));
            this.btnAddFixture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFixture.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.btnAddFixture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(119)))));
            this.btnAddFixture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFixture.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFixture.ForeColor = System.Drawing.Color.White;
            this.btnAddFixture.Location = new System.Drawing.Point(486, 500);
            this.btnAddFixture.Name = "btnAddFixture";
            this.btnAddFixture.Size = new System.Drawing.Size(115, 42);
            this.btnAddFixture.TabIndex = 4;
            this.btnAddFixture.Text = "Add Fixture";
            this.btnAddFixture.UseVisualStyleBackColor = false;
            this.btnAddFixture.Click += new System.EventHandler(this.btnAddFixture_Click_1);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Football_Manager_SOFT130.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1270, 710);
            this.Controls.Add(this.cboTargetLeague);
            this.Controls.Add(this.lstViewTeams);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1286, 749);
            this.MinimumSize = new System.Drawing.Size(1286, 749);
            this.Name = "frmMainMenu";
            this.Text = "Football Manager - Main Menu";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.Shown += new System.EventHandler(this.frmMainMenu_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmMainMenu_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddLeague;
        private System.Windows.Forms.Button btnAddTeam;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lstLeagues;
        private System.Windows.Forms.Button btnEditLeague;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchAll;
        private System.Windows.Forms.ListView lstViewTeams;
        private System.Windows.Forms.ComboBox cboTargetLeague;
        private System.Windows.Forms.ImageList imgLstIcons;
        private System.Windows.Forms.Button btnEditTeam;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddFixture;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblOut;
        private System.Windows.Forms.TextBox txtSearchFixtures;
        private System.Windows.Forms.Button btnEditFixture;
        private System.Windows.Forms.Button btnDeleteFixture;
        private System.Windows.Forms.Button btnDeleteTeam;
        private System.Windows.Forms.Button btnDeleteLeague;
        private System.Windows.Forms.Button btnPendingResult;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Button btnViewLeagueTable;
    }
}

