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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        List<string> nameElements;
        List<double> priceElements;

        bool nameState = false;
        bool numberState = false;

        double resultPrice = 0;

        bool reconfirm = false;
        int numberOrder = -1;

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            this.Font = DataClass.fontForm;
            this.BackColor = DataClass.colorBackground;
            this.CenterToScreen();// Переместить форму в центр 

            DGVProductsOrder.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            DGVProducts.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            DGVConfirmOrders.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            SetProductLB.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);

            ProductsLabel.ForeColor = Color.White;
            ConfirmOrderLabel.ForeColor = Color.White;
            SearchOrderLabel.ForeColor = Color.White;
            MagazineProductLabel.ForeColor = Color.White;
            SearchProductLabel.ForeColor = Color.White;
            SetProductLabel.ForeColor = Color.White;
            NameClientLabel.ForeColor = Color.White;
            NumberClientLabel.ForeColor = Color.White;
            DiscountCB.ForeColor = Color.White;

            ProductsLabel.Font = DataClass.fontBasic1Label;
            ConfirmOrderLabel.Font = DataClass.fontBasic1Label;
            SearchOrderLabel.Font = DataClass.fontBasic1Label;
            MagazineProductLabel.Font = DataClass.fontBasic1Label;
            SearchProductLabel.Font = DataClass.fontBasic1Label;
            SetProductLabel.Font = DataClass.fontBasic1Label;

            ToolTip tt = new ToolTip();
            tt.SetToolTip(NameClientLabel, "Поле [Имя клиента] должно содержать от 4 до 20 букв");
            NameClientLabel.Font = DataClass.fontBasic1Label;
            tt.SetToolTip(NumberClientLabel, "Поле [Номер телефона] должно содержать 10 цифр абонента");
            NumberClientLabel.Font = DataClass.fontBasic1Label;
            DiscountCB.Font = DataClass.fontBasic1Label;

            SearchOrderTB.Font = DataClass.fontBasic2Label;
            SearchProductTB.Font = DataClass.fontBasic2Label;
            
            NameClientTB.Font = DataClass.fontBasic2Label;
            NumberClientTB.Font = DataClass.fontBasic2Label;

            ReconfirmOrderButton.Font = DataClass.fontBasic1Label;
            ReconfirmOrderButton.ForeColor = Color.White;
            ReconfirmOrderButton.BackColor = DataClass.colorButton;
            ReconfirmOrderButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse1;
            DeleteOrderButton.Font = DataClass.fontBasic1Label;
            DeleteOrderButton.ForeColor = Color.White;
            DeleteOrderButton.BackColor = DataClass.colorButton;
            DeleteOrderButton.FlatAppearance.MouseOverBackColor = Color.Red;
            ClearProductsButton.Font = DataClass.fontBasic1Label;
            ClearProductsButton.ForeColor = Color.White;
            ClearProductsButton.BackColor = DataClass.colorButton;
            ClearProductsButton.FlatAppearance.MouseOverBackColor = Color.Red;
            DeleteProductButton.Font = DataClass.fontBasic1Label;
            DeleteProductButton.ForeColor = Color.White;
            DeleteProductButton.BackColor = DataClass.colorButton;
            DeleteProductButton.FlatAppearance.MouseOverBackColor = Color.Red;
            AddProductButton.Font = DataClass.fontBasic1Label;
            AddProductButton.ForeColor = Color.White;
            AddProductButton.BackColor = DataClass.colorButton;
            AddProductButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            ConfirmOrderButton.Font = DataClass.fontButton;
            ConfirmOrderButton.ForeColor = Color.White;
            ConfirmOrderButton.BackColor = DataClass.colorButton;
            ConfirmOrderButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;


            foreach (DataGridViewColumn column in DGVProductsOrder.Columns)
            {
                if(column.Name == "NumColumn")
                {
                    column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    continue;
                }

                column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < DataClass.nameProductOrder.Count; i++)
            {
                DGVProductsOrder.Rows.Add();
                DGVProductsOrder.Rows[i].Cells[0].Value = i + 1;
                DGVProductsOrder.Rows[i].Cells[1].Value = DataClass.nameProductOrder[i];
                DGVProductsOrder.Rows[i].Cells[2].Value = DataClass.setProductOrder[i];

                if(DiscountCB.Checked)
                {
                    DGVProductsOrder.Rows[i].Cells[3].Value = DataClass.priceDiscountProductOrder[i] + " ₽";
                    resultPrice += DataClass.priceDiscountProductOrder[i];
                }
                else
                {
                    DGVProductsOrder.Rows[i].Cells[3].Value = DataClass.priceProductOrder[i] + " ₽";
                    resultPrice += DataClass.priceProductOrder[i];
                }
            }

            if(DGVProductsOrder.RowCount >= 1)
            {
                ConfirmOrderButton.Text = "Оформить заказ" + Environment.NewLine + resultPrice.ToString("F") + " ₽";
            }

            DGVProductsOrder.AutoResizeColumns();

            DataClass.work.SearchProduct(DGVProducts, SearchProductTB);
            DataClass.work.SearchOrder(DGVConfirmOrders, SearchOrderTB);
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            if(DGVProductsOrder.RowCount >= 1)
            {
                if(DGVProductsOrder.SelectedRows.Count >= 1)
                {
                    int index = DGVProductsOrder.SelectedRows[0].Index;
                    resultPrice = 0;

                    DGVProductsOrder.Rows.RemoveAt(index);
                    DataClass.nameProductOrder.RemoveAt(index);
                    DataClass.setProductOrder.RemoveAt(index);
                    DataClass.priceProductOrder.RemoveAt(index);
                    DataClass.priceDiscountProductOrder.RemoveAt(index);

                    for(int i = 0; i < DGVProductsOrder.RowCount; i++)
                    {
                        DGVProductsOrder.Rows[i].Cells[0].Value = i + 1;
                        if(DiscountCB.Checked)
                        {
                            resultPrice += DataClass.priceDiscountProductOrder[i];
                        }
                        else
                        {
                            resultPrice += DataClass.priceProductOrder[i];
                        }
                    }

                    if (reconfirm == false)
                    {
                        if (DGVProductsOrder.RowCount >= 1)
                        {
                            ConfirmOrderButton.Text = "Оформить заказ" + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                        }
                        else
                        {
                            ConfirmOrderButton.Text = "Оформить заказ";
                        }
                    }
                    else
                    {
                        if (DGVProductsOrder.RowCount >= 1)
                        {
                            ConfirmOrderButton.Text = "Переоформить заказ [№" + numberOrder + "]" + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                        }
                        else
                        {
                            ConfirmOrderButton.Text = "Переоформить заказ";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран товар!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Заказ пуст!");
                return;
            }
        }

        private void ClearProductsButton_Click(object sender, EventArgs e)
        {
            if (DGVProductsOrder.RowCount >= 1)
            {
                if (MessageBox.Show("Удалить все товары из заказа?", "Уведомление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DGVProductsOrder.Rows.Clear();

                    DataClass.nameProductOrder.Clear();
                    DataClass.setProductOrder.Clear();
                    DataClass.priceProductOrder.Clear();
                    DataClass.priceDiscountProductOrder.Clear();

                    resultPrice = 0;

                    if (reconfirm == false)
                    {
                        ConfirmOrderButton.Text = "Оформить заказ";
                    }
                    else
                    {
                        ConfirmOrderButton.Text = "Переформить заказ";
                    }
                }
            }
            else
            {
                MessageBox.Show("Заказ пуст!");
                return;
            }
        }

        private void SearchProductTB_KeyUp(object sender, KeyEventArgs e)
        {
            DataClass.work.SearchProduct(DGVProducts, SearchProductTB);
        }

        private void SearchOrderTB_KeyUp(object sender, KeyEventArgs e)
        {
            DataClass.work.SearchOrder(DGVConfirmOrders, SearchOrderTB);
        }

        private void DGVProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVProducts.Rows.Count >= 1)
            {
                if (DGVProducts.SelectedRows.Count >= 1)
                {
                    if (SetProductLB.Items.Count >= 1)
                    {
                        SetProductLB.Items.Clear();
                    }

                    string nameProduct = DGVProducts.Rows[DGVProducts.SelectedRows[0].Index].Cells[0].Value.ToString();
                    int idProduct = DataClass.work.GetProduct(nameProduct);
                    string productSet = DataClass.work.GetProductSetString(idProduct);
                    double priceProduct = DataClass.work.GetPriceProductByID(idProduct);

                    nameElements = new List<string>();
                    priceElements = new List<double>();

                    string[] part = productSet.Split('|');

                    string[] pancake = part[0].Split('/');
                    string[] tun = part[1].Split('/');
                    string[] set = part[2].Split('/');

                    if(pancake[0] != "0")
                    {
                        nameElements.Add("Целый блин (" + pancake[1] + " г.)");
                        priceElements.Add(Convert.ToInt32(pancake[1]) * priceProduct);
                    }

                    if (tun[0] != "0")
                    {
                        nameElements.Insert(0, "Тун (" + tun[1] + " блин.)");
                        priceElements.Insert(0, Convert.ToInt32(tun[1]) * Convert.ToInt32(pancake[1]) * priceProduct);
                    }

                    if (set[0] != "0")
                    {
                        for (int i = 0; i < set.Count(); i++)
                        {
                            nameElements.Add(set[i]);
                            priceElements.Add(Convert.ToInt32(set[i].Replace(" г.", "")) * priceProduct);
                        }
                    }

                    for(int i = 0; i < nameElements.Count; i++)
                    {
                        SetProductLB.Items.Add(nameElements[i]);
                    }
                }
                else
                {
                    if (SetProductLB.Items.Count >= 1)
                    {
                        SetProductLB.Items.Clear();
                    }
                }
            }
            else
            {
                if(SetProductLB.Items.Count >= 1)
                {
                    SetProductLB.Items.Clear();
                }
            }
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            if(SetProductLB.Items.Count >= 1)
            {
                if(SetProductLB.SelectedIndex >= 0)
                {
                    DataClass.nameProductOrder.Add(DGVProducts.Rows[DGVProducts.SelectedRows[0].Index].Cells[0].Value.ToString());
                    DataClass.setProductOrder.Add(SetProductLB.SelectedItem.ToString());
                    DataClass.priceProductOrder.Add(priceElements[SetProductLB.SelectedIndex]);
                    DataClass.priceDiscountProductOrder.Add(DataClass.work.GetPriceDiscountProduct(DGVProducts.Rows[DGVProducts.SelectedRows[0].Index].Cells[0].Value.ToString(), SetProductLB.SelectedItem.ToString()));

                    DGVProductsOrder.Rows.Add();
                    DGVProductsOrder.Rows[DGVProductsOrder.RowCount - 1].Cells[0].Value = DGVProductsOrder.RowCount;
                    DGVProductsOrder.Rows[DGVProductsOrder.RowCount - 1].Cells[1].Value = DataClass.nameProductOrder[DataClass.nameProductOrder.Count - 1];
                    DGVProductsOrder.Rows[DGVProductsOrder.RowCount - 1].Cells[2].Value = DataClass.setProductOrder[DataClass.setProductOrder.Count - 1];

                    if (DiscountCB.Checked)
                    {
                        DGVProductsOrder.Rows[DGVProductsOrder.RowCount - 1].Cells[3].Value = DataClass.priceDiscountProductOrder[DataClass.priceDiscountProductOrder.Count - 1] + " ₽";
                        resultPrice += DataClass.priceDiscountProductOrder[DataClass.priceDiscountProductOrder.Count - 1];
                    }
                    else
                    {
                        DGVProductsOrder.Rows[DGVProductsOrder.RowCount - 1].Cells[3].Value = DataClass.priceProductOrder[DataClass.priceProductOrder.Count - 1] + " ₽";
                        resultPrice += DataClass.priceProductOrder[DataClass.priceProductOrder.Count - 1];
                    }

                    if (reconfirm == false)
                    {
                        ConfirmOrderButton.Text = "Оформить заказ " + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                    }
                    else
                    {
                        ConfirmOrderButton.Text = "Переоформить заказ [№" + numberOrder + "]" + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                    }
                }
                else
                {
                    MessageBox.Show("Для добавления товара нужно выбрать элемент из комплектации!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Комплектация товара пуста, выберите товар из каталога!");
                return;
            }
        }

        private void DiscountCB_CheckedChanged(object sender, EventArgs e)
        {
            if (nameState && numberState && DiscountCB.Checked)
            {
                resultPrice = 0;

                for (int i = 0; i < DGVProductsOrder.RowCount; i++)
                {
                    DGVProductsOrder.Rows[i].Cells[3].Value = DataClass.priceDiscountProductOrder[i] + " ₽";
                    resultPrice += DataClass.priceDiscountProductOrder[i];
                }

                if (reconfirm == false)
                {
                    if (DGVProductsOrder.RowCount >= 1)
                    {
                        ConfirmOrderButton.Text = "Оформить заказ" + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                    }
                    else
                    {
                        ConfirmOrderButton.Text = "Оформить заказ";
                    }
                }
                else
                {
                    if (DGVProductsOrder.RowCount >= 1)
                    {
                        ConfirmOrderButton.Text = "Переоформить заказ [№" + numberOrder + "]" + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                    }
                    else
                    {
                        ConfirmOrderButton.Text = "Переоформить заказ";
                    }
                }
            }
            else if (nameState && numberState && DiscountCB.Checked == false)
            {
                resultPrice = 0;

                for (int i = 0; i < DGVProductsOrder.RowCount; i++)
                {
                    DGVProductsOrder.Rows[i].Cells[3].Value = DataClass.priceProductOrder[i] + " ₽";
                    resultPrice += DataClass.priceProductOrder[i];
                }

                if (reconfirm == false)
                {
                    if (DGVProductsOrder.RowCount >= 1)
                    {
                        ConfirmOrderButton.Text = "Оформить заказ " + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                    }
                    else
                    {
                        ConfirmOrderButton.Text = "Оформить заказ";
                    }
                }
                else
                {
                    if (DGVProductsOrder.RowCount >= 1)
                    {
                        ConfirmOrderButton.Text = "Переоформить заказ " + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                    }
                    else
                    {
                        ConfirmOrderButton.Text = "Переоформить заказ";
                    }
                }
            }
            else
            {
                DiscountCB.CheckedChanged -= DiscountCB_CheckedChanged;
                DiscountCB.Checked = false;
                DiscountCB.CheckedChanged += DiscountCB_CheckedChanged;
                MessageBox.Show("Для применения скидки нужно заполнить поля:" + Environment.NewLine + "1) [Имя покупателя]" + Environment.NewLine + "2) [Номер телефона]");
            }
        }

        private void NameClientTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32)
            {
                if(NameClientTB.SelectionLength > 0 && e.KeyChar == 8)
                {
                    e.Handled = true;
                    return;
                }

                if(NameClientTB.Text.Length == 0 && e.KeyChar == 8)
                {
                    e.Handled = true;
                    return;
                }

                while (NameClientTB.Text.IndexOf("  ") >= 0)
                {
                    NameClientTB.Text = NameClientTB.Text.Replace("  ", " ");
                    NameClientTB.SelectionStart = NameClientTB.Text.Length;
                }

                if (NameClientTB.Text.Length == 3 && e.KeyChar != 8)
                {
                    nameState = true;
                }
                else if(NameClientTB.Text.Length == 4 && e.KeyChar == 8)
                {
                    nameState = false;

                    resultPrice = 0;

                    for (int i = 0; i < DGVProductsOrder.RowCount; i++)
                    {
                        DGVProductsOrder.Rows[i].Cells[3].Value = DataClass.priceProductOrder[i] + " ₽";
                        resultPrice += DataClass.priceProductOrder[i];
                    }

                    if(reconfirm == false)
                    {
                        if (DGVProductsOrder.RowCount >= 1)
                        {
                            ConfirmOrderButton.Text = "Оформить заказ " + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                        }
                        else
                        {
                            ConfirmOrderButton.Text = "Оформить заказ";
                        }
                    }
                    else
                    {
                        if (DGVProductsOrder.RowCount >= 1)
                        {
                            ConfirmOrderButton.Text = "Переоформить заказ [№" + numberOrder + "]" + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                        }
                        else
                        {
                            ConfirmOrderButton.Text = "Переоформить заказ";
                        }
                    } 

                    DiscountCB.CheckedChanged -= DiscountCB_CheckedChanged;
                    DiscountCB.Checked = false;
                    DiscountCB.CheckedChanged += DiscountCB_CheckedChanged;
                }

                if (nameState)
                {
                    NameClientLabel.ForeColor = DataClass.colorButtonEnterMouse;
                }
                else if(nameState == false)
                {
                    NameClientLabel.ForeColor = Color.Red;
                }

                if(NameClientTB.Text.Length == 1 && e.KeyChar == 8)
                {
                    NameClientLabel.ForeColor = Color.White;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void NumberClientTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                if (NumberClientTB.SelectionLength > 0 && e.KeyChar == 8)
                {
                    e.Handled = true;
                    return;
                }

                if (NumberClientTB.Text.Length == 0 && e.KeyChar != 8)
                {
                    NumberClientTB.Text = "+7";
                    NumberClientTB.SelectionStart = NumberClientTB.Text.Length;
                }

                if(NumberClientTB.Text.Length == 3 && e.KeyChar == 8)
                {
                    NumberClientTB.Text = "";
                }

                if((NumberClientTB.SelectionStart == 1 || NumberClientTB.SelectionStart == 2) && e.KeyChar == 8)
                {
                    e.Handled = true;
                }

                if ((NumberClientTB.Text.Length == 11 || NumberClientTB.Text.Length == 12) && e.KeyChar != 8)
                {
                    numberState = true;
                }
                else
                {
                    numberState = false;

                    resultPrice = 0;

                    for (int i = 0; i < DGVProductsOrder.RowCount; i++)
                    {
                        DGVProductsOrder.Rows[i].Cells[3].Value = DataClass.priceProductOrder[i] + " ₽";
                        resultPrice += DataClass.priceProductOrder[i];
                    }

                    if (reconfirm == false)
                    {
                        if (DGVProductsOrder.RowCount >= 1)
                        {
                            ConfirmOrderButton.Text = "Оформить заказ " + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                        }
                        else
                        {
                            ConfirmOrderButton.Text = "Оформить заказ";
                        }
                    }
                    else
                    {
                        if (DGVProductsOrder.RowCount >= 1)
                        {
                            ConfirmOrderButton.Text = "Переоформить заказ [№" + numberOrder + "]" + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                        }
                        else
                        {
                            ConfirmOrderButton.Text = "Переоформить заказ";
                        }
                    }

                    DiscountCB.CheckedChanged -= DiscountCB_CheckedChanged;
                    DiscountCB.Checked = false;
                    DiscountCB.CheckedChanged += DiscountCB_CheckedChanged;
                }

                if(numberState)
                {
                    NumberClientLabel.ForeColor = DataClass.colorButtonEnterMouse;
                }
                else
                {
                    NumberClientLabel.ForeColor = Color.Red;
                }

                if(NumberClientTB.Text == "")
                {
                    NumberClientLabel.ForeColor = Color.White;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            if(DGVProductsOrder.RowCount <= 0)
            {
                MessageBox.Show("Вы не добавили товары в заказ!");
                return;
            }

            if(NameClientLabel.ForeColor == Color.Red)
            {
                MessageBox.Show("Поле [Имя покупателя] заполнено неверно!");
                return;
            }

            if (NumberClientLabel.ForeColor == Color.Red)
            {
                MessageBox.Show("Поле [Номер телефона] заполнено неверно!");
                return;
            }

            if (reconfirm == false)
            {
                try
                {
                    if (MessageBox.Show("Оформить заказ ?" + Environment.NewLine + "Итого к оплате: " + resultPrice.ToString("F") + " ₽", "Формирование заказа", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int discount = 0;

                        if (DiscountCB.Checked)
                        {
                            discount = 1;
                        }

                        string dateColumn = DateTime.Now.ToString();

                        int numberOrder = DataClass.work.ConfirmOrder(DataClass.nameProductOrder, DataClass.setProductOrder, discount, DataClass.priceProductOrder, DataClass.priceDiscountProductOrder, resultPrice, DataClass.work.FixString(NameClientTB.Text), NumberClientTB.Text, dateColumn);

                        if (numberOrder > 0)
                        {
                            MessageBox.Show("Заказ успешно сформирован!" + Environment.NewLine + "Номер заказа - [" + numberOrder + "]" + Environment.NewLine + "Дата - [" + dateColumn + "]");

                            DGVProductsOrder.Rows.Clear();

                            DataClass.nameProductOrder.Clear();
                            DataClass.setProductOrder.Clear();
                            DataClass.priceProductOrder.Clear();
                            DataClass.priceDiscountProductOrder.Clear();

                            nameState = false;
                            numberState = false;

                            NameClientTB.Text = "";
                            NameClientLabel.ForeColor = Color.White;
                            NumberClientTB.Text = "";
                            NumberClientLabel.ForeColor = Color.White;
                            DiscountCB.CheckedChanged -= DiscountCB_CheckedChanged;
                            DiscountCB.Checked = false;
                            DiscountCB.CheckedChanged += DiscountCB_CheckedChanged;
                            DiscountCB.ForeColor = Color.White;

                            resultPrice = 0;
                            ConfirmOrderButton.Text = "Оформить заказ";

                            DataClass.work.SearchOrder(DGVConfirmOrders, SearchOrderTB);

                            return;
                        }
                        else
                        {
                            MessageBox.Show("Что-то полшло не так!");
                            return;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                    return;
                }
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Переоформить заказ [№" + numberOrder + "] ?" + Environment.NewLine + "Итого к оплате: " + resultPrice.ToString("F") + " ₽", "Переоформление заказа", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int discount = 0;

                        if (DiscountCB.Checked)
                        {
                            discount = 1;
                        }

                        string dateColumn = DateTime.Now.ToString();

                        int number = DataClass.work.ReconfirmOrderDatabase(numberOrder, DataClass.nameProductOrder, DataClass.setProductOrder, discount, DataClass.priceProductOrder, DataClass.priceDiscountProductOrder, resultPrice, DataClass.work.FixString(NameClientTB.Text), NumberClientTB.Text, dateColumn);

                        if (number > 0)
                        {
                            MessageBox.Show("Заказ успешно переоформлен!" + Environment.NewLine + "Номер заказа - [" + number + "]" + Environment.NewLine + "Дата - [" + dateColumn + "]");

                            reconfirm = false;
                            DGVProductsOrder.Rows.Clear();

                            DataClass.nameProductOrder.Clear();
                            DataClass.setProductOrder.Clear();
                            DataClass.priceProductOrder.Clear();
                            DataClass.priceDiscountProductOrder.Clear();

                            resultPrice = 0;

                            nameState = false;
                            numberState = false;

                            NameClientTB.Text = "";
                            NameClientLabel.ForeColor = Color.White;
                            NumberClientTB.Text = "";
                            NumberClientLabel.ForeColor = Color.White;
                            DiscountCB.CheckedChanged -= DiscountCB_CheckedChanged;
                            DiscountCB.Checked = false;
                            DiscountCB.CheckedChanged += DiscountCB_CheckedChanged;
                            DiscountCB.ForeColor = Color.White;
                            ReconfirmOrderButton.Text = "Переоформить заказ";
                            ReconfirmOrderButton.Enabled = true;
                            ConfirmOrderButton.Text = "Оформить заказ";

                            DeleteOrderButton.Enabled = true;
                            DGVConfirmOrders.Enabled = true;

                            DataClass.work.SearchOrder(DGVConfirmOrders, SearchOrderTB);

                            return;
                        }
                        else
                        {
                            MessageBox.Show("Что-то полшло не так!");
                            return;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                    return;
                }
            }
        }

        private void DeleteOrderButton_Click(object sender, EventArgs e)
        {
            if(DGVConfirmOrders.RowCount >= 1)
            {
                if(DGVConfirmOrders.SelectedRows.Count >= 1)
                {
                    int index = DGVConfirmOrders.SelectedRows[0].Index;
                    int orderNumber = Convert.ToInt32(DGVConfirmOrders.Rows[index].Cells[0].Value);

                    if(MessageBox.Show("Удалить заказ [№ " + orderNumber + "] ?", "Удаление заказа", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DataClass.work.DeleteOrder(orderNumber);

                        DGVConfirmOrders.Rows.RemoveAt(index);
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали заказ!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали заказ!");
                return;
            }
        }

        private void ReconfirmOrderButton_Click(object sender, EventArgs e)
        {
            if(DGVConfirmOrders.RowCount >= 1)
            {
                if(DGVConfirmOrders.SelectedRows.Count >= 1)
                {
                    if (reconfirm == false)
                    {
                        int index = DGVConfirmOrders.SelectedRows[0].Index;
                        numberOrder = Convert.ToInt32(DGVConfirmOrders.Rows[index].Cells[0].Value);

                        if (MessageBox.Show("Переоформить заказ [№" + numberOrder + "] ?", "Переоформление заказа", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            reconfirm = true;
                            DGVProductsOrder.Rows.Clear();

                            DataClass.nameProductOrder.Clear();
                            DataClass.setProductOrder.Clear();
                            DataClass.priceProductOrder.Clear();
                            DataClass.priceDiscountProductOrder.Clear();

                            NameClientTB.Text = "";
                            NameClientLabel.ForeColor = Color.White;
                            NumberClientTB.Text = "";
                            NumberClientLabel.ForeColor = Color.White;
                            DiscountCB.CheckedChanged -= DiscountCB_CheckedChanged;
                            DiscountCB.Checked = false;
                            DiscountCB.ForeColor = Color.White;

                            DataClass.work.ReConfirmOrder(numberOrder, DGVProductsOrder, NameClientLabel, NameClientTB, NumberClientLabel, NumberClientTB, DiscountCB);

                            if (NameClientLabel.ForeColor == DataClass.colorButtonEnterMouse)
                            {
                                nameState = true;
                            }

                            if (NumberClientLabel.ForeColor == DataClass.colorButtonEnterMouse)
                            {
                                numberState = true;
                            }

                            DiscountCB.CheckedChanged += DiscountCB_CheckedChanged;
                            resultPrice = 0;

                            for (int i = 0; i < DataClass.nameProductOrder.Count; i++)
                            {
                                if (DiscountCB.Checked)
                                {
                                    resultPrice += DataClass.priceDiscountProductOrder[i];
                                }
                                else
                                {
                                    resultPrice += DataClass.priceProductOrder[i];
                                }
                            }

                            ConfirmOrderButton.Text = "Переоформить заказ [№" + numberOrder + "]" + Environment.NewLine + resultPrice.ToString("F") + " ₽";
                            ReconfirmOrderButton.Text = "Остановить переоформление";
                            DGVConfirmOrders.Enabled = false;
                            DeleteOrderButton.Enabled = false;
                        }
                    }
                    else
                    {
                        reconfirm = false;
                        DGVProductsOrder.Rows.Clear();

                        DataClass.nameProductOrder.Clear();
                        DataClass.setProductOrder.Clear();
                        DataClass.priceProductOrder.Clear();
                        DataClass.priceDiscountProductOrder.Clear();

                        resultPrice = 0;

                        nameState = false;
                        numberState = false;

                        NameClientTB.Text = "";
                        NameClientLabel.ForeColor = Color.White;
                        NumberClientTB.Text = "";
                        NumberClientLabel.ForeColor = Color.White;
                        DiscountCB.CheckedChanged -= DiscountCB_CheckedChanged;
                        DiscountCB.Checked = false;
                        DiscountCB.CheckedChanged += DiscountCB_CheckedChanged;
                        DiscountCB.ForeColor = Color.White;
                        ReconfirmOrderButton.Text = "Переоформить заказ";
                        ReconfirmOrderButton.Enabled = true;
                        ConfirmOrderButton.Text = "Оформить заказ";

                        DeleteOrderButton.Enabled = true;
                        DGVConfirmOrders.Enabled = true;

                        DataClass.work.SearchOrder(DGVConfirmOrders, SearchOrderTB);
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали заказ!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали заказ!");
                return;
            }
        }
    }
}
