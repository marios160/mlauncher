namespace MLauncher
{
    partial class Rejestracja
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
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblPass1 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPass2 = new System.Windows.Forms.Label();
            this.txtPass2 = new System.Windows.Forms.TextBox();
            this.lblEmailWrong = new System.Windows.Forms.Label();
            this.lblPassWrong = new System.Windows.Forms.Label();
            this.lblPassWrong2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(119, 137);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(202, 47);
            this.btnRegister.TabIndex = 12;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblPass1
            // 
            this.lblPass1.AutoSize = true;
            this.lblPass1.Location = new System.Drawing.Point(8, 62);
            this.lblPass1.Name = "lblPass1";
            this.lblPass1.Size = new System.Drawing.Size(56, 13);
            this.lblPass1.TabIndex = 9;
            this.lblPass1.Text = "Password:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(8, 23);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtPass1
            // 
            this.txtPass1.Location = new System.Drawing.Point(119, 59);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.Size = new System.Drawing.Size(202, 20);
            this.txtPass1.TabIndex = 7;
            this.txtPass1.Leave += new System.EventHandler(this.txtPass1_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(119, 20);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(202, 20);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // lblPass2
            // 
            this.lblPass2.AutoSize = true;
            this.lblPass2.Location = new System.Drawing.Point(8, 102);
            this.lblPass2.Name = "lblPass2";
            this.lblPass2.Size = new System.Drawing.Size(93, 13);
            this.lblPass2.TabIndex = 13;
            this.lblPass2.Text = "Repeat password:";
            this.lblPass2.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtPass2
            // 
            this.txtPass2.Location = new System.Drawing.Point(120, 99);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.Size = new System.Drawing.Size(202, 20);
            this.txtPass2.TabIndex = 11;
            this.txtPass2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass2_KeyPress);
            // 
            // lblEmailWrong
            // 
            this.lblEmailWrong.AutoSize = true;
            this.lblEmailWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEmailWrong.ForeColor = System.Drawing.Color.Red;
            this.lblEmailWrong.Location = new System.Drawing.Point(116, 43);
            this.lblEmailWrong.Name = "lblEmailWrong";
            this.lblEmailWrong.Size = new System.Drawing.Size(67, 13);
            this.lblEmailWrong.TabIndex = 14;
            this.lblEmailWrong.Text = "Wrong email!";
            this.lblEmailWrong.Visible = false;
            // 
            // lblPassWrong
            // 
            this.lblPassWrong.AutoSize = true;
            this.lblPassWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPassWrong.ForeColor = System.Drawing.Color.Red;
            this.lblPassWrong.Location = new System.Drawing.Point(116, 81);
            this.lblPassWrong.Name = "lblPassWrong";
            this.lblPassWrong.Size = new System.Drawing.Size(167, 13);
            this.lblPassWrong.TabIndex = 15;
            this.lblPassWrong.Text = "8 Characters, 1 Uppercase, 1 Digit";
            this.lblPassWrong.Visible = false;
            // 
            // lblPassWrong2
            // 
            this.lblPassWrong2.AutoSize = true;
            this.lblPassWrong2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPassWrong2.ForeColor = System.Drawing.Color.Red;
            this.lblPassWrong2.Location = new System.Drawing.Point(116, 121);
            this.lblPassWrong2.Name = "lblPassWrong2";
            this.lblPassWrong2.Size = new System.Drawing.Size(113, 13);
            this.lblPassWrong2.TabIndex = 16;
            this.lblPassWrong2.Text = "Passwords not equals!";
            this.lblPassWrong2.Visible = false;
            // 
            // Rejestracja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 208);
            this.Controls.Add(this.lblPassWrong2);
            this.Controls.Add(this.lblPassWrong);
            this.Controls.Add(this.lblEmailWrong);
            this.Controls.Add(this.lblPass2);
            this.Controls.Add(this.txtPass2);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblPass1);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPass1);
            this.Controls.Add(this.txtEmail);
            this.Name = "Rejestracja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MLauncher / Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblPass1;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPass1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPass2;
        private System.Windows.Forms.TextBox txtPass2;
        private System.Windows.Forms.Label lblEmailWrong;
        private System.Windows.Forms.Label lblPassWrong;
        private System.Windows.Forms.Label lblPassWrong2;
    }
}