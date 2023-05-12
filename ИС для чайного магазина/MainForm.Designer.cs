namespace ИС_для_чайного_магазина
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ToolPanel = new System.Windows.Forms.Panel();
            this.AccountPanel = new System.Windows.Forms.Panel();
            this.OrderButton = new System.Windows.Forms.Button();
            this.ExitAccountButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.AdminToolsPanel = new System.Windows.Forms.Panel();
            this.ModificationDataButton = new System.Windows.Forms.Button();
            this.TypesProductPanel = new System.Windows.Forms.Panel();
            this.ProductsPanel = new System.Windows.Forms.Panel();
            this.ToolPanel.SuspendLayout();
            this.AccountPanel.SuspendLayout();
            this.AdminToolsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolPanel
            // 
            this.ToolPanel.BackColor = System.Drawing.Color.Transparent;
            this.ToolPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToolPanel.Controls.Add(this.AccountPanel);
            this.ToolPanel.Controls.Add(this.AdminToolsPanel);
            this.ToolPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolPanel.ForeColor = System.Drawing.Color.White;
            this.ToolPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Size = new System.Drawing.Size(1154, 40);
            this.ToolPanel.TabIndex = 2;
            // 
            // AccountPanel
            // 
            this.AccountPanel.BackColor = System.Drawing.Color.Transparent;
            this.AccountPanel.Controls.Add(this.OrderButton);
            this.AccountPanel.Controls.Add(this.ExitAccountButton);
            this.AccountPanel.Controls.Add(this.LoginButton);
            this.AccountPanel.Controls.Add(this.UserNameLabel);
            this.AccountPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.AccountPanel.ForeColor = System.Drawing.Color.Transparent;
            this.AccountPanel.Location = new System.Drawing.Point(749, 0);
            this.AccountPanel.Name = "AccountPanel";
            this.AccountPanel.Size = new System.Drawing.Size(403, 38);
            this.AccountPanel.TabIndex = 4;
            // 
            // OrderButton
            // 
            this.OrderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OrderButton.BackgroundImage")));
            this.OrderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OrderButton.FlatAppearance.BorderSize = 2;
            this.OrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderButton.ForeColor = System.Drawing.Color.Black;
            this.OrderButton.Location = new System.Drawing.Point(297, 3);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(32, 32);
            this.OrderButton.TabIndex = 4;
            this.OrderButton.TabStop = false;
            this.OrderButton.UseVisualStyleBackColor = true;
            this.OrderButton.Visible = false;
            this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click);
            this.OrderButton.MouseEnter += new System.EventHandler(this.OrderButton_MouseEnter);
            this.OrderButton.MouseLeave += new System.EventHandler(this.OrderButton_MouseLeave);
            // 
            // ExitAccountButton
            // 
            this.ExitAccountButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExitAccountButton.BackgroundImage")));
            this.ExitAccountButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitAccountButton.FlatAppearance.BorderSize = 2;
            this.ExitAccountButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ExitAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitAccountButton.ForeColor = System.Drawing.Color.Black;
            this.ExitAccountButton.Location = new System.Drawing.Point(333, 3);
            this.ExitAccountButton.Name = "ExitAccountButton";
            this.ExitAccountButton.Size = new System.Drawing.Size(32, 32);
            this.ExitAccountButton.TabIndex = 3;
            this.ExitAccountButton.TabStop = false;
            this.ExitAccountButton.UseVisualStyleBackColor = true;
            this.ExitAccountButton.Visible = false;
            this.ExitAccountButton.Click += new System.EventHandler(this.ExitAccountButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoginButton.BackgroundImage")));
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginButton.FlatAppearance.BorderSize = 2;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.ForeColor = System.Drawing.Color.Black;
            this.LoginButton.Location = new System.Drawing.Point(368, 3);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(32, 32);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.TabStop = false;
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserNameLabel.Location = new System.Drawing.Point(5, 2);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(286, 32);
            this.UserNameLabel.TabIndex = 1;
            this.UserNameLabel.Text = "Приветствуем, UserLogin";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UserNameLabel.Visible = false;
            // 
            // AdminToolsPanel
            // 
            this.AdminToolsPanel.BackColor = System.Drawing.Color.Transparent;
            this.AdminToolsPanel.Controls.Add(this.ModificationDataButton);
            this.AdminToolsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.AdminToolsPanel.Location = new System.Drawing.Point(0, 0);
            this.AdminToolsPanel.Name = "AdminToolsPanel";
            this.AdminToolsPanel.Size = new System.Drawing.Size(573, 38);
            this.AdminToolsPanel.TabIndex = 2;
            // 
            // ModificationDataButton
            // 
            this.ModificationDataButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ModificationDataButton.BackgroundImage")));
            this.ModificationDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ModificationDataButton.FlatAppearance.BorderSize = 2;
            this.ModificationDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModificationDataButton.ForeColor = System.Drawing.Color.Black;
            this.ModificationDataButton.Location = new System.Drawing.Point(3, 3);
            this.ModificationDataButton.Name = "ModificationDataButton";
            this.ModificationDataButton.Size = new System.Drawing.Size(32, 32);
            this.ModificationDataButton.TabIndex = 5;
            this.ModificationDataButton.TabStop = false;
            this.ModificationDataButton.UseVisualStyleBackColor = true;
            this.ModificationDataButton.Visible = false;
            this.ModificationDataButton.Click += new System.EventHandler(this.ModificationDataButton_Click);
            // 
            // TypesProductPanel
            // 
            this.TypesProductPanel.AutoSize = true;
            this.TypesProductPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TypesProductPanel.BackgroundImage")));
            this.TypesProductPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TypesProductPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TypesProductPanel.Location = new System.Drawing.Point(0, 40);
            this.TypesProductPanel.Name = "TypesProductPanel";
            this.TypesProductPanel.Size = new System.Drawing.Size(2, 591);
            this.TypesProductPanel.TabIndex = 3;
            // 
            // ProductsPanel
            // 
            this.ProductsPanel.AutoScroll = true;
            this.ProductsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsPanel.Location = new System.Drawing.Point(2, 40);
            this.ProductsPanel.Name = "ProductsPanel";
            this.ProductsPanel.Size = new System.Drawing.Size(1152, 591);
            this.ProductsPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1154, 631);
            this.Controls.Add(this.ProductsPanel);
            this.Controls.Add(this.TypesProductPanel);
            this.Controls.Add(this.ToolPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.ToolPanel.ResumeLayout(false);
            this.AccountPanel.ResumeLayout(false);
            this.AdminToolsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel ToolPanel;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Panel AccountPanel;
        private System.Windows.Forms.Panel AdminToolsPanel;
        private System.Windows.Forms.Button ExitAccountButton;
        private System.Windows.Forms.Button OrderButton;
        public System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button ModificationDataButton;
        private System.Windows.Forms.Panel TypesProductPanel;
        private System.Windows.Forms.Panel ProductsPanel;
    }
}

