using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИС_для_чайного_магазина
{
    public partial class ProductForm : Form
    {
        string nameProduct;

        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(string Product)
        {
            InitializeComponent();
            nameProduct = Product;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            //this.Font = DataClass.fontForm;
            this.BackColor = DataClass.colorBackground;

            NameProductLabel.Font = DataClass.fontBasic1Label;
            NameProductLabel.ForeColor = Color.White;
            PriceProductLabel.Font = DataClass.fontBasic1TB;
            PriceProductLabel.ForeColor = Color.White;
            AddProductButton.Font = DataClass.fontButton;
            AddProductButton.ForeColor = Color.White;
            ExitButton.Font = DataClass.fontButton;
            ExitButton.ForeColor = Color.White;
            CBSetProduct.Font = DataClass.fontBasic1Label;
            DescriptionProductTB.Font = DataClass.fontBasic1Label;

            AddProductButton.BackColor = DataClass.colorButton;
            AddProductButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            ExitButton.BackColor = DataClass.colorButton;
            ExitButton.FlatAppearance.MouseOverBackColor = Color.Red;

            if (DataClass.userRoleID == 1 || DataClass.userRoleID == 2)
            {
                AddProductButton.Visible = true;
            }
            else
            {
                AddProductButton.Visible = false;
            }

            DataClass.work.DrawProduct(this, nameProduct);
        }

        private void PB_Click(object sender, EventArgs e)
        {
            PictureBox PB = sender as PictureBox;
            PBImage.BackgroundImage = PB.BackgroundImage;
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            string priceS = PriceProductLabel.Text;
            double price = Convert.ToDouble(priceS.Replace(" ₽", " "));

            DataClass.nameProductOrder.Add(NameProductLabel.Text);
            DataClass.setProductOrder.Add(CBSetProduct.SelectedItem.ToString());
            DataClass.priceProductOrder.Add(price);
            DataClass.priceDiscountProductOrder.Add(DataClass.work.GetPriceDiscountProduct(NameProductLabel.Text, CBSetProduct.SelectedItem.ToString()));

            MessageBox.Show("Название товара - [" + NameProductLabel.Text + "]" + Environment.NewLine + "Комплектация товара - [" + CBSetProduct.SelectedItem.ToString() + "]" + Environment.NewLine + "Цена товара - [" + PriceProductLabel.Text + "]" + Environment.NewLine + "Статус товара - [Добавлен в заказ]");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
