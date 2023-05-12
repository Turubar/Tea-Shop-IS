namespace ИС_для_чайного_магазина
{
    partial class IdentificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdentificationForm));
            this.EnterLabel = new System.Windows.Forms.Label();
            this.LoginTB = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            this.AccountLabel = new System.Windows.Forms.Label();
            this.RegistrButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnterLabel
            // 
            this.EnterLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterLabel.BackColor = System.Drawing.Color.Transparent;
            this.EnterLabel.ForeColor = System.Drawing.Color.White;
            this.EnterLabel.Location = new System.Drawing.Point(12, 23);
            this.EnterLabel.Name = "EnterLabel";
            this.EnterLabel.Size = new System.Drawing.Size(410, 56);
            this.EnterLabel.TabIndex = 1;
            this.EnterLabel.Text = "С возвращением!";
            this.EnterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginTB
            // 
            this.LoginTB.Location = new System.Drawing.Point(10, 36);
            this.LoginTB.MaxLength = 16;
            this.LoginTB.Multiline = true;
            this.LoginTB.Name = "LoginTB";
            this.LoginTB.Size = new System.Drawing.Size(278, 35);
            this.LoginTB.TabIndex = 0;
            this.LoginTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LoginTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginTB_KeyPress);
            // 
            // LoginLabel
            // 
            this.LoginLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoginLabel.ForeColor = System.Drawing.Color.White;
            this.LoginLabel.Location = new System.Drawing.Point(7, 10);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(278, 23);
            this.LoginLabel.TabIndex = 1;
            this.LoginLabel.Text = "Логин";
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(10, 104);
            this.PasswordTB.MaxLength = 24;
            this.PasswordTB.Multiline = true;
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(278, 35);
            this.PasswordTB.TabIndex = 2;
            this.PasswordTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTB_KeyPress);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(10, 78);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(278, 23);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Пароль";
            // 
            // EnterButton
            // 
            this.EnterButton.BackColor = System.Drawing.Color.Black;
            this.EnterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnterButton.FlatAppearance.BorderSize = 0;
            this.EnterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LawnGreen;
            this.EnterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterButton.ForeColor = System.Drawing.Color.White;
            this.EnterButton.Location = new System.Drawing.Point(10, 150);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(278, 46);
            this.EnterButton.TabIndex = 4;
            this.EnterButton.Text = "Войти";
            this.EnterButton.UseVisualStyleBackColor = false;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            this.EnterButton.MouseEnter += new System.EventHandler(this.EnterButton_MouseEnter);
            this.EnterButton.MouseLeave += new System.EventHandler(this.EnterButton_MouseLeave);
            // 
            // AccountLabel
            // 
            this.AccountLabel.BackColor = System.Drawing.Color.Transparent;
            this.AccountLabel.ForeColor = System.Drawing.Color.White;
            this.AccountLabel.Location = new System.Drawing.Point(10, 260);
            this.AccountLabel.Name = "AccountLabel";
            this.AccountLabel.Size = new System.Drawing.Size(278, 23);
            this.AccountLabel.TabIndex = 5;
            this.AccountLabel.Text = "Нет учетной записи?";
            // 
            // RegistrButton
            // 
            this.RegistrButton.BackColor = System.Drawing.Color.Black;
            this.RegistrButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RegistrButton.FlatAppearance.BorderSize = 0;
            this.RegistrButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegistrButton.ForeColor = System.Drawing.Color.White;
            this.RegistrButton.Location = new System.Drawing.Point(10, 286);
            this.RegistrButton.Name = "RegistrButton";
            this.RegistrButton.Size = new System.Drawing.Size(278, 46);
            this.RegistrButton.TabIndex = 6;
            this.RegistrButton.Text = "Регистрация";
            this.RegistrButton.UseVisualStyleBackColor = false;
            this.RegistrButton.Click += new System.EventHandler(this.RegistrButton_Click);
            this.RegistrButton.MouseEnter += new System.EventHandler(this.RegistrButton_MouseEnter);
            this.RegistrButton.MouseLeave += new System.EventHandler(this.RegistrButton_MouseLeave);
            // 
            // MainPanel
            // 
            this.MainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainPanel.BackgroundImage")));
            this.MainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.ExitButton);
            this.MainPanel.Controls.Add(this.ErrorLabel);
            this.MainPanel.Controls.Add(this.RegistrButton);
            this.MainPanel.Controls.Add(this.AccountLabel);
            this.MainPanel.Controls.Add(this.EnterButton);
            this.MainPanel.Controls.Add(this.PasswordLabel);
            this.MainPanel.Controls.Add(this.PasswordTB);
            this.MainPanel.Controls.Add(this.LoginLabel);
            this.MainPanel.Controls.Add(this.LoginTB);
            this.MainPanel.Location = new System.Drawing.Point(69, 71);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(300, 396);
            this.MainPanel.TabIndex = 0;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.ErrorLabel.ForeColor = System.Drawing.Color.White;
            this.ErrorLabel.Location = new System.Drawing.Point(-1, 199);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(300, 61);
            this.ErrorLabel.TabIndex = 7;
            this.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorLabel.Visible = false;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Black;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(10, 338);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(278, 46);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // IdentificationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(434, 495);
            this.Controls.Add(this.EnterLabel);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IdentificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.IdentificationForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label EnterLabel;
        private System.Windows.Forms.TextBox LoginTB;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label AccountLabel;
        private System.Windows.Forms.Button RegistrButton;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Button ExitButton;
    }
}