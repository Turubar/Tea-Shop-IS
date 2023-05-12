using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ИС_для_чайного_магазина
{
    public partial class ModificationDataForm : Form
    {
        public ModificationDataForm()
        {
            InitializeComponent();
        }

        List<string> arrayTypes;
        List<string> arrayForms;

        List<Image> arrayImage;
        List<Image> arrayImageEdit;

        int selectedImage = -1;
        int selectedImageEdit = -1;

        Button[] arrayButton;
        Button[] arrayButtonEdit;

        int editID = -1;
        int deleteID = -1;

        private void ModificationDataForm_Load(object sender, EventArgs e)
        {
            // Шрифт MainForm и центровка
            this.Font = DataClass.fontForm;
            this.CenterToScreen();

            //Шрифты элементов
            DataTC.Font = DataClass.fontBasic2Label;
            AddProductButton.Font = DataClass.fontButton;
            SaveProductButton.Font = DataClass.fontButton;
            BasicPriceLabel.Font = DataClass.fontBasic1Label;
            BasicPriceEditLabel.Font = DataClass.fontBasic1Label;
            CountGramPancakeTB.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            CountGramPancakeEditTB.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            CountPancakeTuneTB.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            CountPancakeTuneEditTB.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            ElementGramTB.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            ElementGramEditTB.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            BasicPriceTB.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            BasicPriceEditTB.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            DiscountGramTB.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            DiscountGramEditTB.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            DiscountTB.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            DiscountEditTB.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

            //Цвета элементов
            this.BackColor = DataClass.colorBackground;
            EditProductButton.BackColor = DataClass.colorButton;
            DeleteProductButton.BackColor = DataClass.colorButton;
            GetUsersButton.BackColor = DataClass.colorButton;
            EditUserButton.BackColor = DataClass.colorButton;
            DeleteUserButton.BackColor = DataClass.colorButton;
            AddSetButton.BackColor = DataClass.colorButton;
            AddSetEditButton.BackColor = DataClass.colorButton;
            DeleteSetButton.BackColor = DataClass.colorButton;
            DeleteSetEditButton.BackColor = DataClass.colorButton;
            AddImageButton.BackColor = DataClass.colorButton;
            AddImageEditButton.BackColor = DataClass.colorButton;
            DeleteImageButton.BackColor = DataClass.colorButton;
            DeleteImageEditButton.BackColor = DataClass.colorButton;
            AddProductButton.BackColor = DataClass.colorButton;
            SaveProductButton.BackColor = DataClass.colorButton;

            EditProductButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            DeleteProductButton.FlatAppearance.MouseOverBackColor = Color.Red;
            GetUsersButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            EditUserButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            DeleteUserButton.FlatAppearance.MouseOverBackColor = Color.Red;
            AddSetButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            AddSetEditButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            AddImageButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            AddImageEditButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            AddProductButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            SaveProductButton.FlatAppearance.MouseOverBackColor = DataClass.colorButtonEnterMouse;
            DeleteSetButton.FlatAppearance.MouseOverBackColor = Color.Red;
            DeleteSetEditButton.FlatAppearance.MouseOverBackColor = Color.Red;
            DeleteImageButton.FlatAppearance.MouseOverBackColor = Color.Red;
            DeleteImageEditButton.FlatAppearance.MouseOverBackColor = Color.Red;

            // Заполнение ComboBox
            arrayTypes = DataClass.work.GetListName("Types");
            arrayForms = DataClass.work.GetListName("Forms");

            TableViewCB.Items.AddRange(arrayTypes.ToArray());

            TypeCB.Items.AddRange(arrayTypes.ToArray());
            FormCB.Items.AddRange(arrayForms.ToArray());

            TypeEditCB.Items.AddRange(arrayTypes.ToArray());
            FormEditCB.Items.AddRange(arrayForms.ToArray());

            // Создание массива для Button и Image, для дальнейшей настройки
            arrayImage = new List<Image>();
            arrayImageEdit = new List<Image>();

            arrayButton = new Button[] { Image1Button, Image2Button, Image3Button, Image4Button, Image5Button };
            arrayButtonEdit = new Button[] { Image1EditButton, Image2EditButton, Image3EditButton, Image4EditButton, Image5EditButton };
        }

        private void Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 44)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void DataTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataTC.SelectedIndex == 1)
            {
                if (DataClass.userRoleID == 1)
                {

                }
                else
                {
                    DataTC.SelectedIndex = 0;
                    MessageBox.Show("У вас недостаточно прав!");
                    return;
                }
            }
        }

        private void TableViewCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TableViewCB.SelectedIndex >= 0)
            {
                int tableID = DataClass.work.GetTableIDType(TableViewCB.SelectedItem.ToString());

                if(tableID >= 0)
                {
                    DGV.Columns.Clear();

                    DataTable dataTable = DataClass.work.GetProductByIDType(tableID, new List<string> { "Name", "[Image 1]", "[Image 2]", "[Image 3]", "[Image 4]", "[Image 5]" });
                    DGV.DataSource = dataTable;

                    foreach (DataGridViewColumn column in DGV.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    DGV.Columns[0].MinimumWidth = 180;

                    for (int i = 0; i < DGV.Rows.Count; i++)
                    {
                        for (int j = 1; j < DGV.Columns.Count; j++)
                        {
                            if (DGV.Rows[i].Cells[j].Value == DBNull.Value)
                            {
                                DGV.Rows[i].Cells[j].Value = Image.FromFile("../../Resources/Images/NoPhoto.png");
                            }
                        }
                    }

                    for (int i = 1; i < dataTable.Columns.Count; i++)
                    {
                        DataGridViewImageColumn imgColumn = DGV.Columns[i] as DataGridViewImageColumn;
                        imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }

                    for (int i = 0; i < DGV.Rows.Count; i++)
                    {
                        DGV.Rows[i].Height = 125;
                    }

                    DGV.ClearSelection();
                }
            }
            else
            {
                return;
            }
        }

        private void EditProductButton_Click(object sender, EventArgs e)
        {
            if (DGV.Columns.Count > 0 && DGV.Rows.Count > 0)
            {
                if (DGV.SelectedRows.Count > 0)
                {
                    try
                    {
                        editID = DataClass.work.GetProduct(DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString());

                        if (editID <= 0)
                        {
                            MessageBox.Show("Товар не найден!");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Что-то пошло не так!");
                        return;
                    }

                    DGV.Columns.Clear();
                    ProductsTC.SelectedIndex = 2;

                    EditPanel.Visible = true;
                    MessageEditLabel.Visible = false;

                    PBMainEdit.BackgroundImage = null;
                    for(int i=0; i< arrayButtonEdit.Length; i++)
                    {
                        arrayButtonEdit[i].BackgroundImage = null;
                    }

                    TypeEditCB.SelectedIndex = -1;
                    FormEditCB.SelectedIndex = -1;
                    DiscountGramEditTB.Text = "";
                    DiscountEditTB.Text = "";

                    DataClass.work.FillProduct(editID, NameProductEditTB, PBMainEdit, arrayButtonEdit, TypeEditCB, FormEditCB, PancakeEditCB, CountGramPancakeEditTB, TunEditCB, CountPancakeTuneEditTB, SetEditLB, DescriptionEditTB, BasicPriceEditTB, DiscountEditCB, DiscountGramEditTB, DiscountEditTB);

                    arrayImageEdit.Clear();

                    for(int i = 0; i < arrayButtonEdit.Length; i++)
                    {
                        if(arrayButtonEdit[i].BackgroundImage != null)
                        {
                            arrayImageEdit.Add(arrayButtonEdit[i].BackgroundImage);
                        }
                    }

                    selectedImageEdit = 0;
                }
                else
                {
                    MessageBox.Show("Вы не выбрали товар!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали товар!");
                return;
            }
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            if (DGV.Columns.Count > 0 && DGV.Rows.Count > 0)
            {
                if(DGV.SelectedRows.Count > 0)
                {
                    try
                    {
                        deleteID = DataClass.work.GetProduct(DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString());

                        if (deleteID <= 0)
                        {
                            MessageBox.Show("Товар не найден!");
                            return;
                        }

                        if(MessageBox.Show("Удалить товар [" + DGV.Rows[Convert.ToInt32(DGV.SelectedRows[0].Index.ToString())].Cells[0].Value.ToString() + "] ?", "Окно удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                        }
                        else
                        {
                            deleteID = -1;
                            return;
                        }

                        int result = DataClass.work.DeleteProduct(deleteID);

                        if(result == 1)
                        {
                            MessageBox.Show("Товар успешно удален!");

                            deleteID = -1;
                            TableViewCB_SelectedIndexChanged(null, null);

                            return;
                        }
                        else
                        {
                            MessageBox.Show("Что-то пошло не так!");
                            return;
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
                    MessageBox.Show("Вы не выбрали товар!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали товар!");
                return;
            }
        }

        private void GetUsersButton_Click(object sender, EventArgs e)
        {
            DataTable DataUsers = DataClass.work.GetUsersTable();

            if(DataUsers != null)
            {
                DGVUsers.DataSource = DataUsers;
                DGVUsers.ClearSelection();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так!");
                return;
            }
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            if (DGVUsers.Columns.Count > 0 && DGVUsers.Rows.Count > 0)
            {
                if (DGVUsers.SelectedRows.Count > 0)
                {
                    if(DGVUsers.Rows[Convert.ToInt32(DGVUsers.SelectedRows[0].Index)].Cells[2].Value.ToString() == "User")
                    {
                        if(MessageBox.Show("Назначить пользователю [" + DGVUsers.Rows[Convert.ToInt32(DGVUsers.SelectedRows[0].Index.ToString())].Cells[0].Value.ToString() + "] уровень доступа [Manager] ?", "Окно редактирования", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                int idUser = DataClass.work.GetUserIDByLogin(DGVUsers.Rows[Convert.ToInt32(DGVUsers.SelectedRows[0].Index.ToString())].Cells[0].Value.ToString());
                                DataClass.work.EditRoleUser(idUser, 2);
                                GetUsersButton_Click(null, null);
                            }
                            catch
                            {
                                MessageBox.Show("Что-то пошло не так!");
                                return;
                            }
                        }
                    }
                    else if(DGVUsers.Rows[Convert.ToInt32(DGVUsers.SelectedRows[0].Index)].Cells[2].Value.ToString() == "Manager")
                    {
                        if(MessageBox.Show("Назначить пользователю [" + DGVUsers.Rows[Convert.ToInt32(DGVUsers.SelectedRows[0].Index.ToString())].Cells[0].Value.ToString() + "] уровень доступа [User] ?", "Окно редактирования", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                int idUser = DataClass.work.GetUserIDByLogin(DGVUsers.Rows[Convert.ToInt32(DGVUsers.SelectedRows[0].Index.ToString())].Cells[0].Value.ToString());
                                DataClass.work.EditRoleUser(idUser, 3);
                                GetUsersButton_Click(null, null);
                            }
                            catch
                            {
                                MessageBox.Show("Что-то пошло не так!");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователю с уровнем доступа [Admin] нельзя редактировать уровень доступа!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали пользователя!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали пользователя!");
                return;
            }
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            if (DGVUsers.Columns.Count > 0 && DGVUsers.Rows.Count > 0)
            {
                if (DGVUsers.SelectedRows.Count > 0)
                {
                    if (DGVUsers.Rows[Convert.ToInt32(DGVUsers.SelectedRows[0].Index)].Cells[2].Value.ToString() != "Admin")
                    {
                        if (MessageBox.Show("Удалить пользователя [" + DGVUsers.Rows[Convert.ToInt32(DGVUsers.SelectedRows[0].Index.ToString())].Cells[0].Value.ToString() + "] с уровнем доступа [" + DGVUsers.Rows[Convert.ToInt32(DGVUsers.SelectedRows[0].Index.ToString())].Cells[2].Value.ToString() + "] ?", "Окно удаления пользователя", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                int idUser = DataClass.work.GetUserIDByLogin(DGVUsers.Rows[Convert.ToInt32(DGVUsers.SelectedRows[0].Index.ToString())].Cells[0].Value.ToString());
                                DataClass.work.DeleteUser(idUser);
                                GetUsersButton_Click(null, null);
                            }
                            catch
                            {
                                MessageBox.Show("Что-то пошло не так!");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователя с уровнем доступа [Admin] нельзя удалить!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали пользователя!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали пользователя!");
                return;
            }
        }

        private void PancakeCB_CheckedChanged(object sender, EventArgs e)
        {
            if(PancakeCB.Checked && TunCB.Checked)
            {
                CountGramPancakeTB.Enabled = true;
                CountPancakeTuneTB.Enabled = false;
                TunCB.Checked = false;
            }
            else if (PancakeCB.Checked)
            {
                CountGramPancakeTB.Enabled = true;
            }
            else
            {
                CountGramPancakeTB.Enabled = false;
                CountPancakeTuneTB.Enabled = false;
                TunCB.Checked = false;
            }
        }

        private void PancakeEditCB_CheckedChanged(object sender, EventArgs e)
        {
            if (PancakeEditCB.Checked && TunEditCB.Checked)
            {
                CountGramPancakeEditTB.Enabled = true;
                CountPancakeTuneEditTB.Enabled = false;
                TunEditCB.Checked = false;
            }
            else if (PancakeEditCB.Checked)
            {
                CountGramPancakeEditTB.Enabled = true;
            }
            else
            {
                CountGramPancakeEditTB.Enabled = false;
                CountPancakeTuneEditTB.Enabled = false;
                TunEditCB.Checked = false;
            }
        }

        private void TunCB_CheckedChanged(object sender, EventArgs e)
        {
            if(TunCB.Checked && PancakeCB.Checked)
            {
                CountPancakeTuneTB.Enabled = true;
            }
            else
            {
                CountPancakeTuneTB.Enabled = false;
                TunCB.Checked = false;
            }
        }

        private void TunEditCB_CheckedChanged(object sender, EventArgs e)
        {
            if (TunEditCB.Checked && PancakeEditCB.Checked)
            {
                CountPancakeTuneEditTB.Enabled = true;
            }
            else
            {
                CountPancakeTuneEditTB.Enabled = false;
                TunEditCB.Checked = false;
            }
        }

        private void FormCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(FormCB.SelectedIndex <= -1)
            {
                return;
            }
            if (FormCB.SelectedItem.ToString() == "Прессованная" || FormCB.SelectedItem.ToString() == "Комковая")
            {
                PancakeCB.Checked = false;
                PancakeCB.Enabled = true;
                CountGramPancakeTB.Text = "";
                CountGramPancakeTB.Enabled = false;
                TunCB.Checked = false;
                TunCB.Enabled = true;
                CountPancakeTuneTB.Text = "";
                CountPancakeTuneTB.Enabled = false;
            }
            else
            {
                PancakeCB.Checked = false;
                PancakeCB.Enabled = false;
                CountGramPancakeTB.Text = "";
                CountGramPancakeTB.Enabled = false;
                TunCB.Checked = false;
                TunCB.Enabled = false;
                CountPancakeTuneTB.Text = "";
                CountPancakeTuneTB.Enabled = false;
            }
        }

        private void FormEditCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormEditCB.SelectedIndex <= -1)
            {
                return;
            }
            if (FormEditCB.SelectedItem.ToString() == "Прессованная" || FormEditCB.SelectedItem.ToString() == "Комковая")
            {
                PancakeEditCB.Checked = false;
                PancakeEditCB.Enabled = true;
                CountGramPancakeEditTB.Text = "";
                CountGramPancakeEditTB.Enabled = false;
                TunEditCB.Checked = false;
                TunEditCB.Enabled = true;
                CountPancakeTuneEditTB.Text = "";
                CountPancakeTuneEditTB.Enabled = false;
            }
            else
            {
                PancakeEditCB.Checked = false;
                PancakeEditCB.Enabled = false;
                CountGramPancakeEditTB.Text = "";
                CountGramPancakeEditTB.Enabled = false;
                TunEditCB.Checked = false;
                TunEditCB.Enabled = false;
                CountPancakeTuneEditTB.Text = "";
                CountPancakeTuneEditTB.Enabled = false;
            }
        }

        private void AddImageButton_Click(object sender, EventArgs e)
        {
            if (arrayImage.Count < 5)
            {
                Image img = DataClass.work.GetImage();
                
                if(img != null)
                {
                    arrayImage.Add(img);
                    PBMain.BackgroundImage = arrayImage[arrayImage.Count - 1];

                    for(int i = 0; i < arrayButton.Count(); i++)
                    {
                        if(arrayButton[i].BackgroundImage == null)
                        {
                            arrayButton[i].BackgroundImage = arrayImage[arrayImage.Count - 1];
                            arrayButton[i].Focus();
                            selectedImage = arrayImage.Count;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка, не удалось загрузить изображение!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Загружено максимальное кол-во изображений товара!");
                return;
            }
        }

        private void AddImageEditButton_Click(object sender, EventArgs e)
        {
            if (arrayImageEdit.Count < 5)
            {
                Image img = DataClass.work.GetImage();

                if (img != null)
                {
                    arrayImageEdit.Add(img);
                    PBMainEdit.BackgroundImage = arrayImageEdit[arrayImageEdit.Count - 1];

                    for (int i = 0; i < arrayButtonEdit.Count(); i++)
                    {
                        if (arrayButtonEdit[i].BackgroundImage == null)
                        {
                            arrayButtonEdit[i].BackgroundImage = arrayImageEdit[arrayImageEdit.Count - 1];
                            arrayButtonEdit[i].Focus();
                            selectedImageEdit = arrayImageEdit.Count;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка, не удалось загрузить изображение!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Загружено максимальное кол-во изображений товара!");
                return;
            }
        }

        private void DeleteImageButton_Click(object sender, EventArgs e)
        {
            if (arrayImage.Count >= 1)
            {
                if (arrayButton[selectedImage].BackgroundImage != null)
                {
                    arrayImage.RemoveAt(selectedImage);

                    for (int i = 0; i < arrayButton.Count(); i++)
                    {
                        arrayButton[i].BackgroundImage = null;
                    }

                    for (int i = 0; i < arrayImage.Count; i++)
                    {
                        arrayButton[i].BackgroundImage = arrayImage[i];
                    }

                    if (arrayImage.Count >= 1)
                    {
                        selectedImage = arrayImage.Count - 1;
                        PBMain.BackgroundImage = arrayImage[selectedImage];
                        arrayButton[selectedImage].Focus();
                    }
                    else
                    {
                        selectedImage = -1;
                        PBMain.BackgroundImage = null;
                        arrayButton[0].Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Изображение отсутсвует!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы не добавили ни одного изображения!");
                return;
            }
        }

        private void DeleteImageEditButton_Click(object sender, EventArgs e)
        {
            if (arrayImageEdit.Count >= 1)
            {
                if (arrayButtonEdit[selectedImageEdit].BackgroundImage != null)
                {
                    arrayImageEdit.RemoveAt(selectedImageEdit);

                    for (int i = 0; i < arrayButtonEdit.Count(); i++)
                    {
                        arrayButtonEdit[i].BackgroundImage = null;
                    }

                    for (int i = 0; i < arrayImageEdit.Count; i++)
                    {
                        arrayButtonEdit[i].BackgroundImage = arrayImageEdit[i];
                    }

                    if (arrayImageEdit.Count >= 1)
                    {
                        selectedImageEdit = arrayImageEdit.Count - 1;
                        PBMainEdit.BackgroundImage = arrayImageEdit[selectedImageEdit];
                        arrayButtonEdit[selectedImageEdit].Focus();
                    }
                    else
                    {
                        selectedImageEdit = -1;
                        PBMainEdit.BackgroundImage = null;
                        arrayButtonEdit[0].Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Изображение отсутсвует!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы не добавили ни одного изображения!");
                return;
            }
        }

        private void SelectImage_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            PBMain.BackgroundImage = but.BackgroundImage;
            selectedImage = Convert.ToInt32(but.Tag);
            arrayButton[selectedImage].Focus();
        }

        private void SelectImageEdit_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            PBMainEdit.BackgroundImage = but.BackgroundImage;
            selectedImageEdit = Convert.ToInt32(but.Tag);
            arrayButtonEdit[selectedImageEdit].Focus();
        }

        private void AddSetButton_Click(object sender, EventArgs e)
        {
            if (ElementGramTB.Text != "")
            {
                for (int i = 0; i < SetLB.Items.Count; i++)
                {
                    if (ElementGramTB.Text + " г." == SetLB.Items[i].ToString())
                    {
                        MessageBox.Show("В комплектации товара уже есть элемент [" + ElementGramTB.Text + " г.]");
                        return;
                    }
                }

                if(SetLB.Items.Count > 20)
                {
                    MessageBox.Show("Превышен лимит элементов в комплектации товара");
                    return;
                }

                SetLB.Items.Add(ElementGramTB.Text + " г.");

                int[] arraySet = new int[SetLB.Items.Count];

                for(int i = 0; i < arraySet.Count(); i++)
                {
                    string s = SetLB.Items[i].ToString();
                    string[] arraySplit = s.Split(' ');

                    arraySet[i] = Convert.ToInt32(arraySplit[0]);
                }


                SetLB.Items.Clear();
                arraySet = DataClass.work.SortBubble(arraySet);

                for(int i= arraySet.Count() - 1; i >= 0; i--)
                {
                    SetLB.Items.Add(arraySet[i] + " г.");
                }
            }
            else
            {
                MessageBox.Show("Для добавления элемента в комплектацию товара, заполните поле [Элемент из кол-ва грамм]");
                return;
            }
        }

        private void AddSetEditButton_Click(object sender, EventArgs e)
        {
            if (ElementGramEditTB.Text != "")
            {
                for (int i = 0; i < SetEditLB.Items.Count; i++)
                {
                    if (ElementGramEditTB.Text + " г." == SetEditLB.Items[i].ToString())
                    {
                        MessageBox.Show("В комплектации товара уже есть элемент [" + ElementGramEditTB.Text + " г.]");
                        return;
                    }
                }

                if (SetEditLB.Items.Count > 20)
                {
                    MessageBox.Show("Превышен лимит элементов в комплектации товара");
                    return;
                }

                SetEditLB.Items.Add(ElementGramEditTB.Text + " г.");

                int[] arraySet = new int[SetEditLB.Items.Count];

                for (int i = 0; i < arraySet.Count(); i++)
                {
                    string s = SetEditLB.Items[i].ToString();
                    string[] arraySplit = s.Split(' ');

                    arraySet[i] = Convert.ToInt32(arraySplit[0]);
                }


                SetEditLB.Items.Clear();
                arraySet = DataClass.work.SortBubble(arraySet);

                for (int i = arraySet.Count() - 1; i >= 0; i--)
                {
                    SetEditLB.Items.Add(arraySet[i] + " г.");
                }
            }
            else
            {
                MessageBox.Show("Для добавления элемента в комплектацию товара, заполните поле [Элемент из кол-ва грамм]");
                return;
            }
        }

        private void DeleteSetButton_Click(object sender, EventArgs e)
        {
            if(SetLB.Items.Count <= 0)
            {
                MessageBox.Show("Список пуст");
                return;
            }

            if(SetLB.SelectedIndex < 0)
            {
                MessageBox.Show("Чтобы удалить элемент из комплектации товара, выберите его в списке");
                return;
            }

            SetLB.Items.RemoveAt(SetLB.SelectedIndex);
        }

        private void DeleteSetEditButton_Click(object sender, EventArgs e)
        {
            if (SetEditLB.Items.Count <= 0)
            {
                MessageBox.Show("Список пуст");
                return;
            }

            if (SetEditLB.SelectedIndex < 0)
            {
                MessageBox.Show("Чтобы удалить элемент из комплектации товара, выберите его в списке");
                return;
            }

            SetEditLB.Items.RemoveAt(SetEditLB.SelectedIndex);
        }

        private void DiscountCB_CheckedChanged(object sender, EventArgs e)
        {
            if(DiscountCB.Checked)
            {
                DiscountGramTB.Enabled = true;
                DiscountTB.Enabled = true;
            }
            else
            {
                DiscountGramTB.Enabled = false;
                DiscountTB.Enabled = false;
            }
        }

        private void DiscountEditCB_CheckedChanged(object sender, EventArgs e)
        {
            if (DiscountEditCB.Checked)
            {
                DiscountGramEditTB.Enabled = true;
                DiscountEditTB.Enabled = true;
            }
            else
            {
                DiscountGramEditTB.Enabled = false;
                DiscountEditTB.Enabled = false;
            }
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            string nameProduct = DataClass.work.FixString(NameProductTB.Text);

            if(nameProduct.Length < 4)
            {
                MessageBox.Show("Поле [Название товара] должно быть обязательно заполнено и содержать минимум 4 символа!");
                return;
            }

            if (TypeCB.SelectedIndex < 0 || FormCB.SelectedIndex < 0)
            {
                MessageBox.Show("Списки [Тип чая] и [Форма чая] должны быть заполнены!");
                return;
            }

            if(PancakeCB.Checked && CountGramPancakeTB.Text == "")
            {
                MessageBox.Show("Поле [Целый блин из кол-ва грамм] должно быть заполнено, если оно активно!");
                return;
            }

            if(TunCB.Checked)
            {
                if (CountPancakeTuneTB.Text == "" || Convert.ToInt32(CountPancakeTuneTB.Text) <= 1)
                {
                    MessageBox.Show("Поле [Кол-во блинов в туне] должно быть заполнено и значение поля должно быть больше 1, если оно активно!");
                    return;
                }
            }

            if(PancakeCB.Checked == false && SetLB.Items.Count < 1)
            {
                MessageBox.Show("Комплектация товара пуста, заполните ее!");
                return;
            }

            double price = 0.0;

            try
            {
                price = double.Parse(BasicPriceTB.Text);
            }
            catch
            {
                MessageBox.Show("Поле [Базовая цена за 1 грамм] неверно заполнено!");
                return;
            }


            if(price < 0.01)
            {
                MessageBox.Show("Поле [Базовая цена за 1 грамм] должно быть заполнено и значение поля должно быть больше или равно 0,01");
                return;
            }

            if(DiscountCB.Checked)
            {
                if(DiscountGramTB.Text == "" || Convert.ToInt32(DiscountGramTB.Text) <= 0 || DiscountTB.Text == "" || Convert.ToInt32(DiscountTB.Text) <= 0)
                {
                    MessageBox.Show("Поля [Скидка за каждое кол-во грамм] и [Величина скидки в % от базовой цены] должны быть заполнены и значения полей должны быть больше 0");
                    return;
                }

                if (Convert.ToInt32(DiscountTB.Text) >= 100)
                {
                    MessageBox.Show("Значение поля [Величина скидки в % от базовой цены] должно быть меньше 100");
                    return;
                }
            }

            if (DataClass.work.GetProduct(nameProduct) >= 0)
            {
                MessageBox.Show("Товар с именем [" + nameProduct + "] уже существует!");
                return;
            }

            string productSet = DataClass.work.GetProductSet(PancakeCB, CountGramPancakeTB, TunCB, CountPancakeTuneTB, SetLB, DiscountCB, DiscountGramTB, DiscountTB);

            int id = -1;

            try
            {
                id = DataClass.work.AddProduct(TypeCB.Text, FormCB.Text, nameProduct, arrayImage, productSet, price, DescriptionTB.Text);
            }
            catch
            {
                MessageBox.Show("Произошла какая-то ошибка, попробуйте снова!");
                return;
            }

            if(id >= 0)
            {
                MessageBox.Show("Товар успешно добавлен!");

                NameProductTB.Text = "";

                PBMain.BackgroundImage = null;

                for(int i=0; i< arrayButton.Length; i++)
                {
                    arrayButton[i].BackgroundImage = null;
                }

                ProductsTC.SelectedIndex = 0;

                TypeCB.SelectedIndex = -1;
                FormCB.SelectedIndex = -1;

                selectedImage = -1;
                arrayImage.Clear();

                PancakeCB.Checked = false;
                TunCB.Checked = false;

                CountGramPancakeTB.Text = "";
                CountGramPancakeTB.Enabled = false;
                CountPancakeTuneTB.Text = "";
                CountPancakeTuneTB.Enabled = false;
                ElementGramTB.Text = "";
                SetLB.Items.Clear();

                DescriptionTB.Text = "";
                BasicPriceTB.Text = "";
                DiscountCB.Checked = false;
                DiscountGramTB.Text = "";
                DiscountTB.Text = "";
                DiscountGramTB.Enabled = false;
                DiscountTB.Enabled = false;

                return;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так, товар не был добавлен!");
                return;
            }
        }

        private void SaveProductButton_Click(object sender, EventArgs e)
        {
            string nameProductEdit = DataClass.work.FixString(NameProductEditTB.Text);

            if (nameProductEdit.Length < 4)
            {
                MessageBox.Show("Поле [Название товара] должно быть обязательно заполнено и содержать минимум 4 символа!");
                return;
            }

            if (TypeEditCB.SelectedIndex < 0 || FormEditCB.SelectedIndex < 0)
            {
                MessageBox.Show("Списки [Тип чая] и [Форма чая] должны быть заполнены!");
                return;
            }

            if (PancakeEditCB.Checked && CountGramPancakeEditTB.Text == "")
            {
                MessageBox.Show("Поле [Целый блин из кол-ва грамм] должно быть заполнено, если оно активно!");
                return;
            }

            if (TunEditCB.Checked)
            {
                if (CountPancakeTuneEditTB.Text == "" || Convert.ToInt32(CountPancakeTuneEditTB.Text) <= 1)
                {
                    MessageBox.Show("Поле [Кол-во блинов в туне] должно быть заполнено и значение поля должно быть больше 1, если оно активно!");
                    return;
                }
            }

            if (PancakeEditCB.Checked == false && SetEditLB.Items.Count < 1)
            {
                MessageBox.Show("Комплектация товара пуста, заполните ее!");
                return;
            }

            double price = 0.0;

            try
            {
                price = double.Parse(BasicPriceEditTB.Text);
            }
            catch
            {
                MessageBox.Show("Поле [Базовая цена за 1 грамм] неверно заполнено!");
                return;
            }


            if (price < 0.01)
            {
                MessageBox.Show("Поле [Базовая цена за 1 грамм] должно быть заполнено и значение поля должно быть больше или равно 0,01");
                return;
            }

            if (DiscountEditCB.Checked)
            {
                if (DiscountGramEditTB.Text == "" || Convert.ToInt32(DiscountGramEditTB.Text) <= 0 || DiscountEditTB.Text == "" || Convert.ToInt32(DiscountEditTB.Text) <= 0)
                {
                    MessageBox.Show("Поля [Скидка за каждое кол-во грамм] и [Величина скидки в % от базовой цены] должны быть заполнены и значения полей должны быть больше 0");
                    return;
                }

                if (Convert.ToInt32(DiscountEditTB.Text) >= 100)
                {
                    MessageBox.Show("Значение поля [Величина скидки в % от базовой цены] должно быть меньше 100");
                    return;
                }
            }

            if (DataClass.work.GetNameProductByID(editID) != nameProductEdit)
            {
                if (DataClass.work.GetProduct(nameProductEdit) >= 0)
                {
                    MessageBox.Show("Товар с именем [" + nameProductEdit + "] уже существует!");
                    return;
                }
            }

            string nameType = DataClass.work.GetTypeName(editID);

            if(nameType == null)
            {
                MessageBox.Show("Что-то пошло не так!");
                return;
            }

            string productSet = DataClass.work.GetProductSet(PancakeEditCB, CountGramPancakeEditTB, TunEditCB, CountPancakeTuneEditTB, SetEditLB, DiscountEditCB, DiscountGramEditTB, DiscountEditTB);

            int result = -1;

            if (nameType == TypeEditCB.SelectedItem.ToString())
            {
                result = DataClass.work.EditProduct(1, editID, TypeEditCB.SelectedItem.ToString(), FormEditCB.SelectedItem.ToString(), nameProductEdit, arrayImageEdit, productSet, price, DescriptionEditTB.Text);
            }
            else
            {
                result = DataClass.work.EditProduct(0, editID, TypeEditCB.SelectedItem.ToString(), FormEditCB.SelectedItem.ToString(), nameProductEdit, arrayImageEdit, productSet, price, DescriptionEditTB.Text);
            }

            if(result == 1)
            {
                MessageBox.Show("Товар успешно изменен!");

                NameProductEditTB.Text = "";

                PBMainEdit.BackgroundImage = null;

                for (int i = 0; i < arrayButtonEdit.Length; i++)
                {
                    arrayButtonEdit[i].BackgroundImage = null;
                }

                ProductsTC.SelectedIndex = 0;
                TableViewCB_SelectedIndexChanged(null, null);
                editID = -1;

                TypeEditCB.SelectedIndex = -1;
                FormEditCB.SelectedIndex = -1;

                selectedImageEdit = -1;
                arrayImageEdit.Clear();

                PancakeEditCB.Checked = false;
                TunEditCB.Checked = false;

                CountGramPancakeEditTB.Text = "";
                CountGramPancakeEditTB.Enabled = false;
                CountPancakeTuneEditTB.Text = "";
                CountPancakeTuneEditTB.Enabled = false;
                ElementGramEditTB.Text = "";
                SetEditLB.Items.Clear();

                DescriptionEditTB.Text = "";
                BasicPriceEditTB.Text = "";
                DiscountEditCB.Checked = false;
                DiscountGramEditTB.Text = "";
                DiscountEditTB.Text = "";
                DiscountGramEditTB.Enabled = false;
                DiscountEditTB.Enabled = false;

                EditPanel.Visible = false;
                MessageEditLabel.Visible = true;

                return;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так, товар не был изменен!");
                return;
            }
        }
    }
}
