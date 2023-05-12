namespace ИС_для_чайного_магазина
{
    partial class OrdersForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersForm));
            this.DGVProductsOrder = new System.Windows.Forms.DataGridView();
            this.NumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductsLabel = new System.Windows.Forms.Label();
            this.ConfirmOrderButton = new System.Windows.Forms.Button();
            this.DGVProducts = new System.Windows.Forms.DataGridView();
            this.MagazineProductLabel = new System.Windows.Forms.Label();
            this.NameClientLabel = new System.Windows.Forms.Label();
            this.NameClientTB = new System.Windows.Forms.TextBox();
            this.NumberClientTB = new System.Windows.Forms.TextBox();
            this.NumberClientLabel = new System.Windows.Forms.Label();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.SetProductLB = new System.Windows.Forms.ListBox();
            this.DeleteProductButton = new System.Windows.Forms.Button();
            this.ConfirmOrderLabel = new System.Windows.Forms.Label();
            this.DGVConfirmOrders = new System.Windows.Forms.DataGridView();
            this.ReconfirmOrderButton = new System.Windows.Forms.Button();
            this.SearchOrderTB = new System.Windows.Forms.TextBox();
            this.SearchOrderLabel = new System.Windows.Forms.Label();
            this.ClearProductsButton = new System.Windows.Forms.Button();
            this.SetProductLabel = new System.Windows.Forms.Label();
            this.SearchProductTB = new System.Windows.Forms.TextBox();
            this.SearchProductLabel = new System.Windows.Forms.Label();
            this.DeleteOrderButton = new System.Windows.Forms.Button();
            this.DiscountCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductsOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVConfirmOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVProductsOrder
            // 
            this.DGVProductsOrder.AllowUserToAddRows = false;
            this.DGVProductsOrder.AllowUserToDeleteRows = false;
            this.DGVProductsOrder.AllowUserToResizeColumns = false;
            this.DGVProductsOrder.AllowUserToResizeRows = false;
            this.DGVProductsOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVProductsOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVProductsOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProductsOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumColumn,
            this.NameColumn,
            this.SetColumn,
            this.PriceColumn});
            this.DGVProductsOrder.Location = new System.Drawing.Point(15, 35);
            this.DGVProductsOrder.MultiSelect = false;
            this.DGVProductsOrder.Name = "DGVProductsOrder";
            this.DGVProductsOrder.ReadOnly = true;
            this.DGVProductsOrder.RowHeadersVisible = false;
            this.DGVProductsOrder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVProductsOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductsOrder.Size = new System.Drawing.Size(500, 350);
            this.DGVProductsOrder.TabIndex = 0;
            // 
            // NumColumn
            // 
            this.NumColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumColumn.HeaderText = "№";
            this.NumColumn.Name = "NumColumn";
            this.NumColumn.ReadOnly = true;
            this.NumColumn.Width = 43;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Название товара";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // SetColumn
            // 
            this.SetColumn.HeaderText = "Комплектация товара";
            this.SetColumn.Name = "SetColumn";
            this.SetColumn.ReadOnly = true;
            // 
            // PriceColumn
            // 
            this.PriceColumn.HeaderText = "Цена товара";
            this.PriceColumn.Name = "PriceColumn";
            this.PriceColumn.ReadOnly = true;
            // 
            // ProductsLabel
            // 
            this.ProductsLabel.AutoSize = true;
            this.ProductsLabel.Location = new System.Drawing.Point(12, 9);
            this.ProductsLabel.Name = "ProductsLabel";
            this.ProductsLabel.Size = new System.Drawing.Size(94, 13);
            this.ProductsLabel.TabIndex = 1;
            this.ProductsLabel.Text = "Товары в заказе";
            this.ProductsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConfirmOrderButton
            // 
            this.ConfirmOrderButton.FlatAppearance.BorderSize = 0;
            this.ConfirmOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmOrderButton.Location = new System.Drawing.Point(521, 600);
            this.ConfirmOrderButton.Name = "ConfirmOrderButton";
            this.ConfirmOrderButton.Size = new System.Drawing.Size(506, 90);
            this.ConfirmOrderButton.TabIndex = 2;
            this.ConfirmOrderButton.Text = "Оформить заказ";
            this.ConfirmOrderButton.UseVisualStyleBackColor = true;
            this.ConfirmOrderButton.Click += new System.EventHandler(this.ConfirmOrderButton_Click);
            // 
            // DGVProducts
            // 
            this.DGVProducts.AllowUserToAddRows = false;
            this.DGVProducts.AllowUserToDeleteRows = false;
            this.DGVProducts.AllowUserToResizeColumns = false;
            this.DGVProducts.AllowUserToResizeRows = false;
            this.DGVProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProducts.Location = new System.Drawing.Point(15, 531);
            this.DGVProducts.MultiSelect = false;
            this.DGVProducts.Name = "DGVProducts";
            this.DGVProducts.ReadOnly = true;
            this.DGVProducts.RowHeadersVisible = false;
            this.DGVProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVProducts.Size = new System.Drawing.Size(319, 159);
            this.DGVProducts.TabIndex = 3;
            this.DGVProducts.SelectionChanged += new System.EventHandler(this.DGVProducts_SelectionChanged);
            // 
            // MagazineProductLabel
            // 
            this.MagazineProductLabel.AutoSize = true;
            this.MagazineProductLabel.Location = new System.Drawing.Point(12, 508);
            this.MagazineProductLabel.Name = "MagazineProductLabel";
            this.MagazineProductLabel.Size = new System.Drawing.Size(92, 13);
            this.MagazineProductLabel.TabIndex = 4;
            this.MagazineProductLabel.Text = "Каталог товаров";
            this.MagazineProductLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NameClientLabel
            // 
            this.NameClientLabel.AutoSize = true;
            this.NameClientLabel.Location = new System.Drawing.Point(518, 508);
            this.NameClientLabel.Name = "NameClientLabel";
            this.NameClientLabel.Size = new System.Drawing.Size(90, 13);
            this.NameClientLabel.TabIndex = 5;
            this.NameClientLabel.Text = "Имя покупателя";
            this.NameClientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NameClientTB
            // 
            this.NameClientTB.Location = new System.Drawing.Point(521, 531);
            this.NameClientTB.MaxLength = 20;
            this.NameClientTB.Name = "NameClientTB";
            this.NameClientTB.Size = new System.Drawing.Size(250, 20);
            this.NameClientTB.TabIndex = 6;
            this.NameClientTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameClientTB_KeyPress);
            // 
            // NumberClientTB
            // 
            this.NumberClientTB.Location = new System.Drawing.Point(777, 531);
            this.NumberClientTB.MaxLength = 12;
            this.NumberClientTB.Name = "NumberClientTB";
            this.NumberClientTB.Size = new System.Drawing.Size(250, 20);
            this.NumberClientTB.TabIndex = 8;
            this.NumberClientTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumberClientTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberClientTB_KeyPress);
            // 
            // NumberClientLabel
            // 
            this.NumberClientLabel.AutoSize = true;
            this.NumberClientLabel.Location = new System.Drawing.Point(774, 508);
            this.NumberClientLabel.Name = "NumberClientLabel";
            this.NumberClientLabel.Size = new System.Drawing.Size(93, 13);
            this.NumberClientLabel.TabIndex = 7;
            this.NumberClientLabel.Text = "Номер телефона";
            this.NumberClientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddProductButton
            // 
            this.AddProductButton.FlatAppearance.BorderSize = 0;
            this.AddProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProductButton.Location = new System.Drawing.Point(340, 645);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(175, 45);
            this.AddProductButton.TabIndex = 10;
            this.AddProductButton.Text = "Добавить товар";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // SetProductLB
            // 
            this.SetProductLB.FormattingEnabled = true;
            this.SetProductLB.Location = new System.Drawing.Point(340, 531);
            this.SetProductLB.Name = "SetProductLB";
            this.SetProductLB.Size = new System.Drawing.Size(175, 121);
            this.SetProductLB.TabIndex = 11;
            // 
            // DeleteProductButton
            // 
            this.DeleteProductButton.FlatAppearance.BorderSize = 0;
            this.DeleteProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteProductButton.Location = new System.Drawing.Point(340, 391);
            this.DeleteProductButton.Name = "DeleteProductButton";
            this.DeleteProductButton.Size = new System.Drawing.Size(175, 45);
            this.DeleteProductButton.TabIndex = 12;
            this.DeleteProductButton.Text = "Удалить товар";
            this.DeleteProductButton.UseVisualStyleBackColor = true;
            this.DeleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
            // 
            // ConfirmOrderLabel
            // 
            this.ConfirmOrderLabel.AutoSize = true;
            this.ConfirmOrderLabel.Location = new System.Drawing.Point(518, 68);
            this.ConfirmOrderLabel.Name = "ConfirmOrderLabel";
            this.ConfirmOrderLabel.Size = new System.Drawing.Size(122, 13);
            this.ConfirmOrderLabel.TabIndex = 13;
            this.ConfirmOrderLabel.Text = "Оформленные заказы";
            this.ConfirmOrderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DGVConfirmOrders
            // 
            this.DGVConfirmOrders.AllowUserToAddRows = false;
            this.DGVConfirmOrders.AllowUserToDeleteRows = false;
            this.DGVConfirmOrders.AllowUserToResizeColumns = false;
            this.DGVConfirmOrders.AllowUserToResizeRows = false;
            this.DGVConfirmOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVConfirmOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVConfirmOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVConfirmOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVConfirmOrders.Location = new System.Drawing.Point(521, 94);
            this.DGVConfirmOrders.MultiSelect = false;
            this.DGVConfirmOrders.Name = "DGVConfirmOrders";
            this.DGVConfirmOrders.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVConfirmOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVConfirmOrders.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGVConfirmOrders.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVConfirmOrders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVConfirmOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVConfirmOrders.Size = new System.Drawing.Size(506, 291);
            this.DGVConfirmOrders.TabIndex = 14;
            // 
            // ReconfirmOrderButton
            // 
            this.ReconfirmOrderButton.FlatAppearance.BorderSize = 0;
            this.ReconfirmOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReconfirmOrderButton.Location = new System.Drawing.Point(521, 391);
            this.ReconfirmOrderButton.Name = "ReconfirmOrderButton";
            this.ReconfirmOrderButton.Size = new System.Drawing.Size(250, 45);
            this.ReconfirmOrderButton.TabIndex = 15;
            this.ReconfirmOrderButton.Text = "Переоформить заказ";
            this.ReconfirmOrderButton.UseVisualStyleBackColor = true;
            this.ReconfirmOrderButton.Click += new System.EventHandler(this.ReconfirmOrderButton_Click);
            // 
            // SearchOrderTB
            // 
            this.SearchOrderTB.Location = new System.Drawing.Point(521, 35);
            this.SearchOrderTB.Name = "SearchOrderTB";
            this.SearchOrderTB.Size = new System.Drawing.Size(506, 20);
            this.SearchOrderTB.TabIndex = 18;
            this.SearchOrderTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchOrderTB_KeyUp);
            // 
            // SearchOrderLabel
            // 
            this.SearchOrderLabel.AutoSize = true;
            this.SearchOrderLabel.Location = new System.Drawing.Point(518, 9);
            this.SearchOrderLabel.Name = "SearchOrderLabel";
            this.SearchOrderLabel.Size = new System.Drawing.Size(125, 13);
            this.SearchOrderLabel.TabIndex = 17;
            this.SearchOrderLabel.Text = "Быстрый поиск заказа";
            this.SearchOrderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClearProductsButton
            // 
            this.ClearProductsButton.FlatAppearance.BorderSize = 0;
            this.ClearProductsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearProductsButton.Location = new System.Drawing.Point(15, 391);
            this.ClearProductsButton.Name = "ClearProductsButton";
            this.ClearProductsButton.Size = new System.Drawing.Size(175, 45);
            this.ClearProductsButton.TabIndex = 19;
            this.ClearProductsButton.Text = "Удалить все товары";
            this.ClearProductsButton.UseVisualStyleBackColor = true;
            this.ClearProductsButton.Click += new System.EventHandler(this.ClearProductsButton_Click);
            // 
            // SetProductLabel
            // 
            this.SetProductLabel.AutoSize = true;
            this.SetProductLabel.Location = new System.Drawing.Point(337, 508);
            this.SetProductLabel.Name = "SetProductLabel";
            this.SetProductLabel.Size = new System.Drawing.Size(81, 13);
            this.SetProductLabel.TabIndex = 20;
            this.SetProductLabel.Text = "Комплектация";
            this.SetProductLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchProductTB
            // 
            this.SearchProductTB.Location = new System.Drawing.Point(15, 475);
            this.SearchProductTB.Name = "SearchProductTB";
            this.SearchProductTB.Size = new System.Drawing.Size(500, 20);
            this.SearchProductTB.TabIndex = 22;
            this.SearchProductTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchProductTB_KeyUp);
            // 
            // SearchProductLabel
            // 
            this.SearchProductLabel.AutoSize = true;
            this.SearchProductLabel.Location = new System.Drawing.Point(12, 449);
            this.SearchProductLabel.Name = "SearchProductLabel";
            this.SearchProductLabel.Size = new System.Drawing.Size(124, 13);
            this.SearchProductLabel.TabIndex = 21;
            this.SearchProductLabel.Text = "Быстрый поиск товара";
            this.SearchProductLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeleteOrderButton
            // 
            this.DeleteOrderButton.FlatAppearance.BorderSize = 0;
            this.DeleteOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteOrderButton.Location = new System.Drawing.Point(777, 391);
            this.DeleteOrderButton.Name = "DeleteOrderButton";
            this.DeleteOrderButton.Size = new System.Drawing.Size(250, 45);
            this.DeleteOrderButton.TabIndex = 23;
            this.DeleteOrderButton.Text = "Удалить заказ";
            this.DeleteOrderButton.UseVisualStyleBackColor = true;
            this.DeleteOrderButton.Click += new System.EventHandler(this.DeleteOrderButton_Click);
            // 
            // DiscountCB
            // 
            this.DiscountCB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DiscountCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DiscountCB.Location = new System.Drawing.Point(776, 557);
            this.DiscountCB.Name = "DiscountCB";
            this.DiscountCB.Size = new System.Drawing.Size(251, 34);
            this.DiscountCB.TabIndex = 25;
            this.DiscountCB.Text = "Использовать скидку";
            this.DiscountCB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DiscountCB.UseVisualStyleBackColor = true;
            this.DiscountCB.CheckedChanged += new System.EventHandler(this.DiscountCB_CheckedChanged);
            // 
            // OrdersForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1042, 704);
            this.Controls.Add(this.DiscountCB);
            this.Controls.Add(this.DeleteOrderButton);
            this.Controls.Add(this.SearchProductTB);
            this.Controls.Add(this.SearchProductLabel);
            this.Controls.Add(this.SetProductLabel);
            this.Controls.Add(this.ClearProductsButton);
            this.Controls.Add(this.SearchOrderTB);
            this.Controls.Add(this.SearchOrderLabel);
            this.Controls.Add(this.ReconfirmOrderButton);
            this.Controls.Add(this.DGVConfirmOrders);
            this.Controls.Add(this.ConfirmOrderLabel);
            this.Controls.Add(this.DeleteProductButton);
            this.Controls.Add(this.SetProductLB);
            this.Controls.Add(this.AddProductButton);
            this.Controls.Add(this.NumberClientTB);
            this.Controls.Add(this.NumberClientLabel);
            this.Controls.Add(this.NameClientTB);
            this.Controls.Add(this.NameClientLabel);
            this.Controls.Add(this.MagazineProductLabel);
            this.Controls.Add(this.DGVProducts);
            this.Controls.Add(this.ConfirmOrderButton);
            this.Controls.Add(this.ProductsLabel);
            this.Controls.Add(this.DGVProductsOrder);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Оформление заказа";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductsOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVConfirmOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVProductsOrder;
        private System.Windows.Forms.Label ProductsLabel;
        private System.Windows.Forms.Button ConfirmOrderButton;
        private System.Windows.Forms.DataGridView DGVProducts;
        private System.Windows.Forms.Label MagazineProductLabel;
        private System.Windows.Forms.Label NameClientLabel;
        private System.Windows.Forms.TextBox NameClientTB;
        private System.Windows.Forms.TextBox NumberClientTB;
        private System.Windows.Forms.Label NumberClientLabel;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.ListBox SetProductLB;
        private System.Windows.Forms.Button DeleteProductButton;
        private System.Windows.Forms.Label ConfirmOrderLabel;
        private System.Windows.Forms.DataGridView DGVConfirmOrders;
        private System.Windows.Forms.Button ReconfirmOrderButton;
        private System.Windows.Forms.TextBox SearchOrderTB;
        private System.Windows.Forms.Label SearchOrderLabel;
        private System.Windows.Forms.Button ClearProductsButton;
        private System.Windows.Forms.Label SetProductLabel;
        private System.Windows.Forms.TextBox SearchProductTB;
        private System.Windows.Forms.Label SearchProductLabel;
        private System.Windows.Forms.Button DeleteOrderButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceColumn;
        private System.Windows.Forms.CheckBox DiscountCB;
    }
}