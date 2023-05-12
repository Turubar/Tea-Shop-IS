using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Drawing.Text;

namespace ИС_для_чайного_магазина
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        int selectedType = -1;
        List<string> arrayTypes;

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataClass.work.LoadBasicLibr();// Dызов метода LoadBasicLibr

            this.Font = DataClass.fontForm;
            UserNameLabel.Font = DataClass.fontBasic1Label;
            this.CenterToScreen();// Переместить MainForm в центр 

            //Цвет кнопок
            LoginButton.BackColor = DataClass.colorButton;
            LoginButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            ExitAccountButton.BackColor = DataClass.colorButton;
            ExitAccountButton.FlatAppearance.MouseOverBackColor = Color.Red;
            OrderButton.BackColor = DataClass.colorButton;
            OrderButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            ModificationDataButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;

            //Цвет панелей
            ToolPanel.BackColor = DataClass.colorButton;
            TypesProductPanel.BackColor = Color.Transparent;
            ProductsPanel.BackColor = DataClass.colorBackground;

            arrayTypes = DataClass.work.GetListName("Types");
            arrayTypes.Insert(0, "Типы чая");

            for(int i = 0; i < arrayTypes.Count; i++)
            {
                DataClass.work.DrawLabel(TypesProductPanel, "Types" + i, arrayTypes[i], DataClass.fontBasic1Label, new Size(125, 25), Color.White, new Point(10, (i * 35) + 5));
                (TypesProductPanel.Controls["Types" + i] as Label).Tag = i;
                (TypesProductPanel.Controls["Types" + i] as Label).MouseEnter += new EventHandler(LabelTypes_Enter);
                (TypesProductPanel.Controls["Types" + i] as Label).MouseLeave += new EventHandler(LabelTypes_Leave);
                (TypesProductPanel.Controls["Types" + i] as Label).Click += new EventHandler(LabelTypes_Click);
            }

            LabelTypes_Click(TypesProductPanel.Controls["Types0"] as Label, null);
        }

        public void LabelTypes_Enter(object sender, EventArgs e)
        {
            Label label = sender as Label;

            for(int i = 0; i < arrayTypes.Count; i++)
            {
                if(i != selectedType)
                {
                    (TypesProductPanel.Controls["Types" + i] as Label).ForeColor = Color.White;
                }
            }

            if(selectedType != Convert.ToInt32(label.Tag))
            {
                label.ForeColor = DataClass.colorButton;
            }
        }

        public void LabelTypes_Leave(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if(selectedType != Convert.ToInt32(label.Tag))
            {
                label.ForeColor = Color.White;
            }

        }

        public void LabelTypes_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            selectedType = Convert.ToInt32(label.Tag);
            label.ForeColor = Color.Yellow;

            for (int i = 0; i < arrayTypes.Count; i++)
            {
                if(i != selectedType)
                {
                    (TypesProductPanel.Controls["Types" + i] as Label).ForeColor = Color.White;
                }
            }
            //---------------------------------------------------------------------------------

            ProductsPanel.Controls.Clear();

            if (label.Text == "Типы чая")
            {
                DataTable tableTypes = DataClass.work.GetTable("Types");

                DataGridView DGV = new DataGridView();
                DGV.DataSource = tableTypes;
                DGV.Parent = ProductsPanel;

                List<List<Image>> arrayImage = new List<List<Image>>();
                List<string> arrayName = new List<string>();
                List<string> arrayDescription = new List<string>();

                for(int i = 0; i < DGV.RowCount - 1; i++)
                {
                    byte[] byteImg = null;
                    Image img = null;

                    arrayImage.Add(new List<Image>());

                    for(int j = 0; j < 5; j++)
                    {
                        if (DGV.Rows[i].Cells[j + 4].Value != DBNull.Value)
                        {
                            byteImg = (byte[])DGV.Rows[i].Cells[j + 4].Value;
                            img = DataClass.work.ConvertByteToImage(byteImg);
                        }

                        arrayImage[i].Add(img);
                    }

                    
                    arrayName.Add(DGV.Rows[i].Cells[1].Value.ToString());
                    arrayDescription.Add(DGV.Rows[i].Cells[2].Value.ToString());
                }

                if (this.WindowState == FormWindowState.Normal)
                {

                    for (int i = 0; i < DGV.RowCount - 1; i++)
                    {
                        DataClass.work.DrawLabel(ProductsPanel, "LabelTypeName" + i, arrayName[i], DataClass.fontBasic1Label, Color.White, new Point(10, (i * 290) + 10));

                        DataClass.work.DrawPictureBox(ProductsPanel, "PBType1_" + i, arrayImage[i][0], new Size(325, 250), new Point(10, (i * 290) + 40));
                        DataClass.work.DrawPictureBox(ProductsPanel, "PBType2_" + i, arrayImage[i][1], new Size(155, 120), new Point(345, (i * 290) + 170));
                        DataClass.work.DrawPictureBox(ProductsPanel, "PBType3_" + i, arrayImage[i][2], new Size(155, 120), new Point(510, (i * 290) + 170));
                        DataClass.work.DrawPictureBox(ProductsPanel, "PBType4_" + i, arrayImage[i][3], new Size(155, 120), new Point(675, (i * 290) + 170));
                        DataClass.work.DrawPictureBox(ProductsPanel, "PBType5_" + i, arrayImage[i][4], new Size(155, 120), new Point(840, (i * 290) + 170));

                        DataClass.work.DrawLabel(ProductsPanel, "LabelTypeDescription" + i, arrayDescription[i], DataClass.fontBasic2Label, new Size(625, 120), Color.White, new Point(345, (i * 290) + 40));
                    }
                }
                else
                {
                    for (int i = 0; i < DGV.RowCount - 1; i++)
                    {
                        DataClass.work.DrawLabel(ProductsPanel, "LabelTypeName" + i, arrayName[i], DataClass.fontBasic1Label, Color.White, new Point(10, (i * 322) + 10));

                        DataClass.work.DrawPictureBox(ProductsPanel, "PBType1_" + i, arrayImage[i][0], new Size(365, 282), new Point(10, (i * 322) + 40));
                        DataClass.work.DrawPictureBox(ProductsPanel, "PBType2_" + i, arrayImage[i][1], new Size(200, 186), new Point(540, (i * 322) + 136));
                        DataClass.work.DrawPictureBox(ProductsPanel, "PBType3_" + i, arrayImage[i][2], new Size(200, 186), new Point(825, (i * 322) + 136));
                        DataClass.work.DrawPictureBox(ProductsPanel, "PBType4_" + i, arrayImage[i][3], new Size(200, 186), new Point(1100, (i * 322) + 136));
                        DataClass.work.DrawPictureBox(ProductsPanel, "PBType5_" + i, arrayImage[i][4], new Size(200, 186), new Point(1400, (i * 322) + 136));

                        DataClass.work.DrawLabel(ProductsPanel, "LabelTypeDescription" + i, arrayDescription[i], DataClass.fontBasic2Label, new Size(1070, 120), Color.White, new Point(540, (i * 322) + 40));

                        (ProductsPanel.Controls["LabelTypeDescription" + i] as Label).Location = new Point(ProductsPanel.Width/2 - (ProductsPanel.Controls["LabelTypeDescription" + i] as Label).Width/2 + (ProductsPanel.Controls["PBType1_" + i] as PictureBox).Width/2, (i * 322) + 40);

                        (ProductsPanel.Controls["PBType2_" + i] as PictureBox).Location = new Point((ProductsPanel.Controls["LabelTypeDescription" + i] as Label).Location.X, (i * 322) + 136);
                        (ProductsPanel.Controls["PBType3_" + i] as PictureBox).Location = new Point((ProductsPanel.Controls["PBType2_" + i] as PictureBox).Location.X + (ProductsPanel.Controls["PBType2_" + i] as PictureBox).Width + 85, (i * 322) + 136);
                        (ProductsPanel.Controls["PBType4_" + i] as PictureBox).Location = new Point((ProductsPanel.Controls["PBType3_" + i] as PictureBox).Location.X + (ProductsPanel.Controls["PBType3_" + i] as PictureBox).Width + 85, (i * 322) + 136);
                        (ProductsPanel.Controls["PBType5_" + i] as PictureBox).Location = new Point((ProductsPanel.Controls["PBType4_" + i] as PictureBox).Location.X + (ProductsPanel.Controls["PBType4_" + i] as PictureBox).Width + 85, (i * 322) + 136);
                    }
                }

                DGV.Dispose();
            }
            else if (label.Text == "Пуэр" || label.Text == "Улун" || label.Text == "Зеленый чай" || label.Text == "Красный чай" || label.Text == "Белый чай" || label.Text == "Хэй ча")
            {
                string nameTable = "";

                if(label.Text == "Пуэр")
                {
                    nameTable = "PuerTable";
                }
                else if (label.Text == "Улун")
                {
                    nameTable = "OolongTable";
                }
                else if (label.Text == "Зеленый чай")
                {
                    nameTable = "GreenTeaTable";
                }
                else if (label.Text == "Красный чай")
                {
                    nameTable = "RedTeaTable";
                }
                else if (label.Text == "Белый чай")
                {
                    nameTable = "WhiteTeaTable";
                }
                else if (label.Text == "Хэй ча")
                {
                    nameTable = "DarkTeaTable";
                }

                DataTable tableInfo = DataClass.work.GetTable(nameTable, "SELECT [ID product], [Product set], Price FROM " + nameTable);

                DataGridView DGV = new DataGridView();
                DGV.DataSource = tableInfo;
                DGV.Parent = ProductsPanel;

                List<int> arrayIDProduct = new List<int>();
                List<string> arrayNameProduct = new List<string>();
                List<Image> arrayImageProduct = new List<Image>();
                List<List<string>> arrayProductSet = new List<List<string>>();
                List<List<double>> arrayPriceProduct = new List<List<double>>();

                for(int i = 0; i < DGV.RowCount - 1; i++)
                {
                    arrayIDProduct.Add(Convert.ToInt32(DGV.Rows[i].Cells[0].Value));

                    string[] set = DGV.Rows[i].Cells[1].Value.ToString().Split('|');

                    arrayProductSet.Add(new List<string>());
                    arrayPriceProduct.Add(new List<double>());

                    string[] pancake = set[0].Split('/');
                    string[] tun = set[1].Split('/');
                    string[] element = set[2].Split('/');
                    double price = Convert.ToDouble(DGV.Rows[i].Cells[2].Value);

                    if(tun[0] != "0")
                    {
                        arrayProductSet[i].Add("Тун (" + tun[1] + " блин.)");
                        arrayPriceProduct[i].Add(Convert.ToInt32(tun[1]) * Convert.ToInt32(pancake[1]) * price);
                    }

                    if (pancake[0] != "0")
                    {
                        arrayProductSet[i].Add("Целый блин (" + pancake[1] + " г.)");
                        arrayPriceProduct[i].Add(Convert.ToInt32(pancake[1]) * price);
                    }

                    if(element.Length >= 1)
                    {
                        for (int j = 0; j < element.Length; j++)
                        {
                            if(element[j] == "0")
                            {
                                continue;
                            }
                            arrayProductSet[i].Add(element[j]);
                            string[] elementPart = element[j].Split(' ');
                            arrayPriceProduct[i].Add(Convert.ToInt32(elementPart[0]) * price);
                        }
                    }
                }

                DataTable Products = DataClass.work.GetTable("Products", "SELECT ID, Name, [Image 1] FROM Products");
                DGV.DataSource = Products;

                for(int i = 0; i < DGV.RowCount - 1; i++)
                {
                    for(int j = 0; j < arrayIDProduct.Count; j++)
                    {
                        if(Convert.ToInt32(DGV.Rows[i].Cells[0].Value) == arrayIDProduct[j])
                        {
                            arrayNameProduct.Add(DGV.Rows[i].Cells[1].Value.ToString());

                            byte[] arrayByte = null;
                            Image img = null;

                            if(DGV.Rows[i].Cells[2].Value != DBNull.Value)
                            {
                                arrayByte = (byte[])DGV.Rows[i].Cells[2].Value;
                                img = DataClass.work.ConvertByteToImage(arrayByte);
                            }

                            arrayImageProduct.Add(img);
                        }
                    }
                }

                DGV.Dispose();

                DataClass.work.DrawProducts(ProductsPanel, arrayIDProduct, arrayNameProduct, arrayImageProduct, arrayPriceProduct, arrayProductSet, DataClass.userRoleID);
            }
        }
   
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            LabelTypes_Click(TypesProductPanel.Controls["Types" + selectedType] as Label, null);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(DataClass.userID < 0)
            {
                this.Hide();
                Form IF = new IdentificationForm();// Открыть форму IdentificationForm
                IF.ShowDialog();
                this.Show();
            }
            else
            {
                return;
            }

            if(DataClass.userID>=0)
            {
                DataClass.userLogin = DataClass.work.GetUserLoginByID(DataClass.userID);
                UserNameLabel.Text = "Приветствуем, " + DataClass.userLogin;
                UserNameLabel.Visible = true;

                LoginButton.BackColor = DataClass.colorButtonEnterMouse;
                LoginButton.FlatAppearance.MouseOverBackColor = DataClass.colorButton;

                ExitAccountButton.Visible = true;

                DataClass.userRoleID = DataClass.work.GetUserRoleIDByUserID(DataClass.userID);

                if (DataClass.userRoleID == 1 || DataClass.userRoleID == 2)
                {
                    ModificationDataButton.Visible = true;
                    OrderButton.Visible = true;
                }

                LabelTypes_Click(TypesProductPanel.Controls["Types" + selectedType] as Label, null);
            }
        }

        private void ExitAccountButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из аккаунта?", "Уведомление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UserNameLabel.Text = "";
                UserNameLabel.Visible = false;

                OrderButton.Visible = false;
                ExitAccountButton.Visible = false;
                ModificationDataButton.Visible = false;

                LoginButton.BackColor = Color.Transparent;
                LoginButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;

                DataClass.userID = -1;
                DataClass.userRoleID = -1;
                DataClass.userLogin = "";

                DataClass.nameProductOrder.Clear();
                DataClass.setProductOrder.Clear();
                DataClass.priceProductOrder.Clear();
                DataClass.priceDiscountProductOrder.Clear();

                LabelTypes_Click(TypesProductPanel.Controls["Types" + selectedType] as Label, null);
            }
            else
            {
                return;
            }
        }

        private void ModificationDataButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form MDF = new ModificationDataForm();
            MDF.ShowDialog();
            this.Show();
        }

        private void OrderButton_MouseEnter(object sender, EventArgs e)
        {
            if (DataClass.nameProductOrder.Count < 10)
            {
                OrderButton.BackgroundImage = null;
                OrderButton.Text = DataClass.nameProductOrder.Count.ToString();
            }
            else
            {
                OrderButton.BackgroundImage = Image.FromFile("../../Resources/Images/BasketImage1.png");
                OrderButton.Text = "";
            }
        }

        private void OrderButton_MouseLeave(object sender, EventArgs e)
        {
            OrderButton.BackgroundImage = Image.FromFile("../../Resources/Images/BasketImage.png");
            OrderButton.Text = "";
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form OF = new OrdersForm();
            OF.ShowDialog();
            this.Show();
        }
    }
}
