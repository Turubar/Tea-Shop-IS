namespace ИС_для_чайного_магазина
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.SeePassword1CB = new System.Windows.Forms.CheckBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.LoginTB = new System.Windows.Forms.TextBox();
            this.ConfirmPanel = new System.Windows.Forms.Panel();
            this.SeePassword2CB = new System.Windows.Forms.CheckBox();
            this.ConfirmLabel = new System.Windows.Forms.Label();
            this.RegistrButton = new System.Windows.Forms.Button();
            this.ConfirmPasswordTB = new System.Windows.Forms.TextBox();
            this.RegistrLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.ConfirmPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainPanel.BackgroundImage")));
            this.MainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.ExitButton);
            this.MainPanel.Controls.Add(this.MessageLabel);
            this.MainPanel.Controls.Add(this.SeePassword1CB);
            this.MainPanel.Controls.Add(this.ConfirmButton);
            this.MainPanel.Controls.Add(this.PasswordLabel);
            this.MainPanel.Controls.Add(this.PasswordTB);
            this.MainPanel.Controls.Add(this.LoginLabel);
            this.MainPanel.Controls.Add(this.LoginTB);
            this.MainPanel.Location = new System.Drawing.Point(92, 71);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(300, 338);
            this.MainPanel.TabIndex = 1;
            // 
            // MessageLabel
            // 
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.ForeColor = System.Drawing.Color.White;
            this.MessageLabel.Location = new System.Drawing.Point(3, 175);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(292, 44);
            this.MessageLabel.TabIndex = 5;
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MessageLabel.Visible = false;
            // 
            // SeePassword1CB
            // 
            this.SeePassword1CB.BackColor = System.Drawing.Color.Transparent;
            this.SeePassword1CB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SeePassword1CB.ForeColor = System.Drawing.Color.White;
            this.SeePassword1CB.Location = new System.Drawing.Point(10, 149);
            this.SeePassword1CB.Name = "SeePassword1CB";
            this.SeePassword1CB.Size = new System.Drawing.Size(278, 25);
            this.SeePassword1CB.TabIndex = 7;
            this.SeePassword1CB.Text = "Показать";
            this.SeePassword1CB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SeePassword1CB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SeePassword1CB.UseVisualStyleBackColor = false;
            this.SeePassword1CB.CheckedChanged += new System.EventHandler(this.SeePassword1CB_CheckedChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.Black;
            this.ConfirmButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConfirmButton.FlatAppearance.BorderSize = 0;
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmButton.Location = new System.Drawing.Point(10, 228);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(278, 46);
            this.ConfirmButton.TabIndex = 6;
            this.ConfirmButton.Text = "Подтвердить";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            this.ConfirmButton.MouseEnter += new System.EventHandler(this.ConfirmButton_MouseEnter);
            this.ConfirmButton.MouseLeave += new System.EventHandler(this.ConfirmButton_MouseLeave);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(10, 82);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(278, 23);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Пароль";
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(10, 112);
            this.PasswordTB.MaxLength = 24;
            this.PasswordTB.Multiline = true;
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(278, 35);
            this.PasswordTB.TabIndex = 2;
            this.PasswordTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTB_KeyPress);
            // 
            // LoginLabel
            // 
            this.LoginLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoginLabel.ForeColor = System.Drawing.Color.White;
            this.LoginLabel.Location = new System.Drawing.Point(10, 10);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(285, 23);
            this.LoginLabel.TabIndex = 1;
            this.LoginLabel.Text = "Логин";
            // 
            // LoginTB
            // 
            this.LoginTB.Location = new System.Drawing.Point(10, 40);
            this.LoginTB.MaxLength = 16;
            this.LoginTB.Multiline = true;
            this.LoginTB.Name = "LoginTB";
            this.LoginTB.Size = new System.Drawing.Size(278, 35);
            this.LoginTB.TabIndex = 0;
            this.LoginTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LoginTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginTB_KeyPress);
            // 
            // ConfirmPanel
            // 
            this.ConfirmPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ConfirmPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConfirmPanel.BackgroundImage")));
            this.ConfirmPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConfirmPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfirmPanel.Controls.Add(this.SeePassword2CB);
            this.ConfirmPanel.Controls.Add(this.ConfirmLabel);
            this.ConfirmPanel.Controls.Add(this.RegistrButton);
            this.ConfirmPanel.Controls.Add(this.ConfirmPasswordTB);
            this.ConfirmPanel.Location = new System.Drawing.Point(92, 424);
            this.ConfirmPanel.Name = "ConfirmPanel";
            this.ConfirmPanel.Size = new System.Drawing.Size(300, 171);
            this.ConfirmPanel.TabIndex = 3;
            this.ConfirmPanel.Visible = false;
            // 
            // SeePassword2CB
            // 
            this.SeePassword2CB.BackColor = System.Drawing.Color.Transparent;
            this.SeePassword2CB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SeePassword2CB.ForeColor = System.Drawing.Color.White;
            this.SeePassword2CB.Location = new System.Drawing.Point(11, 76);
            this.SeePassword2CB.Name = "SeePassword2CB";
            this.SeePassword2CB.Size = new System.Drawing.Size(278, 25);
            this.SeePassword2CB.TabIndex = 8;
            this.SeePassword2CB.Text = "Показать";
            this.SeePassword2CB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SeePassword2CB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SeePassword2CB.UseVisualStyleBackColor = false;
            this.SeePassword2CB.CheckedChanged += new System.EventHandler(this.SeePassword2CB_CheckedChanged);
            // 
            // ConfirmLabel
            // 
            this.ConfirmLabel.BackColor = System.Drawing.Color.Transparent;
            this.ConfirmLabel.ForeColor = System.Drawing.Color.White;
            this.ConfirmLabel.Location = new System.Drawing.Point(11, 11);
            this.ConfirmLabel.Name = "ConfirmLabel";
            this.ConfirmLabel.Size = new System.Drawing.Size(278, 23);
            this.ConfirmLabel.TabIndex = 8;
            this.ConfirmLabel.Text = "Подтвердите пароль";
            // 
            // RegistrButton
            // 
            this.RegistrButton.BackColor = System.Drawing.Color.Black;
            this.RegistrButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RegistrButton.FlatAppearance.BorderSize = 0;
            this.RegistrButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegistrButton.ForeColor = System.Drawing.Color.White;
            this.RegistrButton.Location = new System.Drawing.Point(11, 109);
            this.RegistrButton.Name = "RegistrButton";
            this.RegistrButton.Size = new System.Drawing.Size(278, 46);
            this.RegistrButton.TabIndex = 7;
            this.RegistrButton.Text = "Зарегистрироваться";
            this.RegistrButton.UseVisualStyleBackColor = false;
            this.RegistrButton.Click += new System.EventHandler(this.RegistrButton_Click);
            this.RegistrButton.MouseEnter += new System.EventHandler(this.RegistrButton_MouseEnter);
            this.RegistrButton.MouseLeave += new System.EventHandler(this.RegistrButton_MouseLeave);
            // 
            // ConfirmPasswordTB
            // 
            this.ConfirmPasswordTB.Location = new System.Drawing.Point(11, 39);
            this.ConfirmPasswordTB.MaxLength = 24;
            this.ConfirmPasswordTB.Multiline = true;
            this.ConfirmPasswordTB.Name = "ConfirmPasswordTB";
            this.ConfirmPasswordTB.Size = new System.Drawing.Size(278, 35);
            this.ConfirmPasswordTB.TabIndex = 3;
            this.ConfirmPasswordTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ConfirmPasswordTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfirmPasswordTB_KeyPress);
            // 
            // RegistrLabel
            // 
            this.RegistrLabel.BackColor = System.Drawing.Color.Transparent;
            this.RegistrLabel.ForeColor = System.Drawing.Color.White;
            this.RegistrLabel.Location = new System.Drawing.Point(12, 11);
            this.RegistrLabel.Name = "RegistrLabel";
            this.RegistrLabel.Size = new System.Drawing.Size(460, 42);
            this.RegistrLabel.TabIndex = 4;
            this.RegistrLabel.Text = "Регистрация";
            this.RegistrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Black;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(10, 279);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(278, 46);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // RegistrationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 436);
            this.Controls.Add(this.RegistrLabel);
            this.Controls.Add(this.ConfirmPanel);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ConfirmPanel.ResumeLayout(false);
            this.ConfirmPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox LoginTB;
        private System.Windows.Forms.Panel ConfirmPanel;
        private System.Windows.Forms.Label ConfirmLabel;
        private System.Windows.Forms.Button RegistrButton;
        private System.Windows.Forms.TextBox ConfirmPasswordTB;
        private System.Windows.Forms.CheckBox SeePassword1CB;
        private System.Windows.Forms.CheckBox SeePassword2CB;
        private System.Windows.Forms.Label RegistrLabel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button ExitButton;
    }
}