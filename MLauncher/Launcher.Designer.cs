namespace MLauncher
{
    partial class Launcher
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstPlayers = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nick = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kills = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deaths = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ping = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.team = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTimeleft = new System.Windows.Forms.Label();
            this.lblSlash = new System.Windows.Forms.Label();
            this.lblMaxplayers = new System.Windows.Forms.Label();
            this.lblNumplayers = new System.Windows.Forms.Label();
            this.lblMapname = new System.Windows.Forms.Label();
            this.lblHostport = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.chbNofity = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEmail.Location = new System.Drawing.Point(55, 9);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(80, 17);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "useremail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nick:";
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(57, 42);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(178, 20);
            this.txtNick.TabIndex = 5;
            this.txtNick.Text = "MJones";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(246, 42);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 20);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(16, 68);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(160, 41);
            this.btnJoin.TabIndex = 7;
            this.btnJoin.Text = "Join game";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(182, 68);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(144, 41);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstPlayers);
            this.groupBox1.Controls.Add(this.lblTimeleft);
            this.groupBox1.Controls.Add(this.lblSlash);
            this.groupBox1.Controls.Add(this.lblMaxplayers);
            this.groupBox1.Controls.Add(this.lblNumplayers);
            this.groupBox1.Controls.Add(this.lblMapname);
            this.groupBox1.Controls.Add(this.lblHostport);
            this.groupBox1.Controls.Add(this.lblHostname);
            this.groupBox1.Location = new System.Drawing.Point(12, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 211);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // lstPlayers
            // 
            this.lstPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.nick,
            this.kills,
            this.deaths,
            this.ping,
            this.team});
            this.lstPlayers.Location = new System.Drawing.Point(8, 50);
            this.lstPlayers.MultiSelect = false;
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(299, 155);
            this.lstPlayers.TabIndex = 7;
            this.lstPlayers.UseCompatibleStateImageBehavior = false;
            this.lstPlayers.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "Id";
            this.id.Width = 22;
            // 
            // nick
            // 
            this.nick.Text = "Nick";
            this.nick.Width = 115;
            // 
            // kills
            // 
            this.kills.Text = "Kills";
            this.kills.Width = 36;
            // 
            // deaths
            // 
            this.deaths.Text = "Deaths";
            this.deaths.Width = 46;
            // 
            // ping
            // 
            this.ping.Text = "Ping";
            this.ping.Width = 34;
            // 
            // team
            // 
            this.team.Text = "Team";
            this.team.Width = 42;
            // 
            // lblTimeleft
            // 
            this.lblTimeleft.AutoSize = true;
            this.lblTimeleft.Location = new System.Drawing.Point(231, 34);
            this.lblTimeleft.Name = "lblTimeleft";
            this.lblTimeleft.Size = new System.Drawing.Size(34, 13);
            this.lblTimeleft.TabIndex = 6;
            this.lblTimeleft.Text = "00:00";
            // 
            // lblSlash
            // 
            this.lblSlash.AutoSize = true;
            this.lblSlash.Location = new System.Drawing.Point(195, 34);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 13);
            this.lblSlash.TabIndex = 5;
            this.lblSlash.Text = "/";
            // 
            // lblMaxplayers
            // 
            this.lblMaxplayers.AutoSize = true;
            this.lblMaxplayers.Location = new System.Drawing.Point(204, 34);
            this.lblMaxplayers.Name = "lblMaxplayers";
            this.lblMaxplayers.Size = new System.Drawing.Size(19, 13);
            this.lblMaxplayers.TabIndex = 4;
            this.lblMaxplayers.Text = "16";
            // 
            // lblNumplayers
            // 
            this.lblNumplayers.AutoSize = true;
            this.lblNumplayers.Location = new System.Drawing.Point(185, 34);
            this.lblNumplayers.Name = "lblNumplayers";
            this.lblNumplayers.Size = new System.Drawing.Size(13, 13);
            this.lblNumplayers.TabIndex = 3;
            this.lblNumplayers.Text = "8";
            // 
            // lblMapname
            // 
            this.lblMapname.AutoSize = true;
            this.lblMapname.Location = new System.Drawing.Point(57, 34);
            this.lblMapname.Name = "lblMapname";
            this.lblMapname.Size = new System.Drawing.Size(57, 13);
            this.lblMapname.TabIndex = 2;
            this.lblMapname.Text = "Sandstorm";
            // 
            // lblHostport
            // 
            this.lblHostport.AutoSize = true;
            this.lblHostport.Location = new System.Drawing.Point(14, 34);
            this.lblHostport.Name = "lblHostport";
            this.lblHostport.Size = new System.Drawing.Size(37, 13);
            this.lblHostport.TabIndex = 1;
            this.lblHostport.Text = "26001";
            // 
            // lblHostname
            // 
            this.lblHostname.AutoSize = true;
            this.lblHostname.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHostname.Location = new System.Drawing.Point(13, 15);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(180, 19);
            this.lblHostname.TabIndex = 0;
            this.lblHostname.Text = "Polski Serwer IGI 2";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(13, 358);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(68, 13);
            this.lblVersion.TabIndex = 10;
            this.lblVersion.Text = "version 1.0.0";
            // 
            // chbNofity
            // 
            this.chbNofity.AutoSize = true;
            this.chbNofity.Location = new System.Drawing.Point(20, 115);
            this.chbNofity.Name = "chbNofity";
            this.chbNofity.Size = new System.Drawing.Size(133, 17);
            this.chbNofity.TabIndex = 11;
            this.chbNofity.Text = "Notify me if players join";
            this.chbNofity.UseVisualStyleBackColor = true;
            this.chbNofity.CheckedChanged += new System.EventHandler(this.chbNofity_CheckedChanged);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 388);
            this.Controls.Add(this.chbNofity);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEmail);
            this.Name = "Launcher";
            this.Text = "Launcher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHostport;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.Label lblMapname;
        private System.Windows.Forms.Label lblMaxplayers;
        private System.Windows.Forms.Label lblNumplayers;
        private System.Windows.Forms.Label lblSlash;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.CheckBox chbNofity;
        private System.Windows.Forms.Label lblTimeleft;
        private System.Windows.Forms.ListView lstPlayers;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader nick;
        private System.Windows.Forms.ColumnHeader kills;
        private System.Windows.Forms.ColumnHeader deaths;
        private System.Windows.Forms.ColumnHeader ping;
        private System.Windows.Forms.ColumnHeader team;
    }
}