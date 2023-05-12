namespace ИС_для_чайного_магазина
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.NameProductLabel = new System.Windows.Forms.Label();
            this.PriceProductLabel = new System.Windows.Forms.Label();
            this.PBImage = new System.Windows.Forms.PictureBox();
            this.PBImageProduct1 = new System.Windows.Forms.PictureBox();
            this.PBImageProduct3 = new System.Windows.Forms.PictureBox();
            this.PBImageProduct2 = new System.Windows.Forms.PictureBox();
            this.PBImageProduct4 = new System.Windows.Forms.PictureBox();
            this.CBSetProduct = new System.Windows.Forms.ComboBox();
            this.DescriptionProductTB = new System.Windows.Forms.TextBox();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.PBImageProduct5 = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PBImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImageProduct1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImageProduct3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImageProduct2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImageProduct4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImageProduct5)).BeginInit();
            this.SuspendLayout();
            // 
            // NameProductLabel
            // 
            this.NameProductLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NameProductLabel.Location = new System.Drawing.Point(12, 9);
            this.NameProductLabel.Name = "NameProductLabel";
            this.NameProductLabel.Size = new System.Drawing.Size(420, 85);
            this.NameProductLabel.TabIndex = 0;
            this.NameProductLabel.Text = "Название товара";
            this.NameProductLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PriceProductLabel
            // 
            this.PriceProductLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PriceProductLabel.Location = new System.Drawing.Point(233, 133);
            this.PriceProductLabel.Name = "PriceProductLabel";
            this.PriceProductLabel.Size = new System.Drawing.Size(199, 28);
            this.PriceProductLabel.TabIndex = 1;
            this.PriceProductLabel.Text = "Цена товара";
            this.PriceProductLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PBImage
            // 
            this.PBImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBImage.Location = new System.Drawing.Point(12, 97);
            this.PBImage.Name = "PBImage";
            this.PBImage.Size = new System.Drawing.Size(215, 150);
            this.PBImage.TabIndex = 2;
            this.PBImage.TabStop = false;
            // 
            // PBImageProduct1
            // 
            this.PBImageProduct1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBImageProduct1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBImageProduct1.Location = new System.Drawing.Point(12, 253);
            this.PBImageProduct1.Name = "PBImageProduct1";
            this.PBImageProduct1.Size = new System.Drawing.Size(80, 65);
            this.PBImageProduct1.TabIndex = 3;
            this.PBImageProduct1.TabStop = false;
            this.PBImageProduct1.Click += new System.EventHandler(this.PB_Click);
            // 
            // PBImageProduct3
            // 
            this.PBImageProduct3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBImageProduct3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBImageProduct3.Location = new System.Drawing.Point(182, 253);
            this.PBImageProduct3.Name = "PBImageProduct3";
            this.PBImageProduct3.Size = new System.Drawing.Size(80, 65);
            this.PBImageProduct3.TabIndex = 4;
            this.PBImageProduct3.TabStop = false;
            this.PBImageProduct3.Click += new System.EventHandler(this.PB_Click);
            // 
            // PBImageProduct2
            // 
            this.PBImageProduct2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBImageProduct2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBImageProduct2.Location = new System.Drawing.Point(97, 253);
            this.PBImageProduct2.Name = "PBImageProduct2";
            this.PBImageProduct2.Size = new System.Drawing.Size(80, 65);
            this.PBImageProduct2.TabIndex = 5;
            this.PBImageProduct2.TabStop = false;
            this.PBImageProduct2.Click += new System.EventHandler(this.PB_Click);
            // 
            // PBImageProduct4
            // 
            this.PBImageProduct4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBImageProduct4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBImageProduct4.Location = new System.Drawing.Point(267, 253);
            this.PBImageProduct4.Name = "PBImageProduct4";
            this.PBImageProduct4.Size = new System.Drawing.Size(80, 65);
            this.PBImageProduct4.TabIndex = 6;
            this.PBImageProduct4.TabStop = false;
            this.PBImageProduct4.Click += new System.EventHandler(this.PB_Click);
            // 
            // CBSetProduct
            // 
            this.CBSetProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSetProduct.FormattingEnabled = true;
            this.CBSetProduct.Location = new System.Drawing.Point(233, 97);
            this.CBSetProduct.Name = "CBSetProduct";
            this.CBSetProduct.Size = new System.Drawing.Size(199, 21);
            this.CBSetProduct.TabIndex = 7;
            // 
            // DescriptionProductTB
            // 
            this.DescriptionProductTB.Location = new System.Drawing.Point(12, 323);
            this.DescriptionProductTB.Multiline = true;
            this.DescriptionProductTB.Name = "DescriptionProductTB";
            this.DescriptionProductTB.ReadOnly = true;
            this.DescriptionProductTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionProductTB.Size = new System.Drawing.Size(420, 216);
            this.DescriptionProductTB.TabIndex = 8;
            // 
            // AddProductButton
            // 
            this.AddProductButton.FlatAppearance.BorderSize = 0;
            this.AddProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProductButton.Location = new System.Drawing.Point(182, 545);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(250, 55);
            this.AddProductButton.TabIndex = 9;
            this.AddProductButton.Text = "Добавить в заказ";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // PBImageProduct5
            // 
            this.PBImageProduct5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBImageProduct5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBImageProduct5.Location = new System.Drawing.Point(352, 253);
            this.PBImageProduct5.Name = "PBImageProduct5";
            this.PBImageProduct5.Size = new System.Drawing.Size(80, 65);
            this.PBImageProduct5.TabIndex = 10;
            this.PBImageProduct5.TabStop = false;
            this.PBImageProduct5.Click += new System.EventHandler(this.PB_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(12, 545);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(164, 55);
            this.ExitButton.TabIndex = 11;
            this.ExitButton.Text = "Вернуться";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(444, 614);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PBImageProduct5);
            this.Controls.Add(this.AddProductButton);
            this.Controls.Add(this.DescriptionProductTB);
            this.Controls.Add(this.CBSetProduct);
            this.Controls.Add(this.PBImageProduct4);
            this.Controls.Add(this.PBImageProduct2);
            this.Controls.Add(this.PBImageProduct3);
            this.Controls.Add(this.PBImageProduct1);
            this.Controls.Add(this.PBImage);
            this.Controls.Add(this.PriceProductLabel);
            this.Controls.Add(this.NameProductLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Товар";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImageProduct1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImageProduct3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImageProduct2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImageProduct4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImageProduct5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameProductLabel;
        private System.Windows.Forms.Label PriceProductLabel;
        private System.Windows.Forms.PictureBox PBImage;
        private System.Windows.Forms.PictureBox PBImageProduct1;
        private System.Windows.Forms.PictureBox PBImageProduct3;
        private System.Windows.Forms.PictureBox PBImageProduct2;
        private System.Windows.Forms.PictureBox PBImageProduct4;
        private System.Windows.Forms.TextBox DescriptionProductTB;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.PictureBox PBImageProduct5;
        private System.Windows.Forms.Button ExitButton;
        public System.Windows.Forms.ComboBox CBSetProduct;
    }
}