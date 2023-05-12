using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Data.SQLite;
using System.Data;

namespace ИС_для_чайного_магазина
{
    public class Work
    {
        public void LoadFile(string pathStart, string pathFinal)// Метод, который копирует файл по выбранному пути
        {
            File.Create(pathFinal).Close();
            File.Copy(pathStart, pathFinal, true);
        }

        public void LoadBasicLibr()// Метод, который подгружает нужные для работы библиотеки
        {
            LoadFile("../../lib/System.Data.SQLite.EF6.dll", "System.Data.SQLite.EF6.dll");
            LoadFile("../../lib/System.Data.SQLite.Linq.dll", "System.Data.SQLite.Linq.dll");

            if (Environment.Is64BitOperatingSystem)
            {
                LoadFile("../../lib/x64/SQLite.Interop.dll", "SQLite.Interop.dll");
            }
            else
            {
                LoadFile("../../lib/x86/SQLite.Interop.dll", "SQLite.Interop.dll");
            }
        }

        public int GetID(string login, string password)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();
            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT *From Accounts";
                DataClass.reader = DataClass.cmd.ExecuteReader();

                while (DataClass.reader.Read())
                {
                    if (DataClass.reader[2].ToString() == login && DataClass.reader[3].ToString() == password)
                    {
                        int id = Convert.ToInt32(DataClass.reader[0]);
                        DataClass.reader.Close();
                        DataClass.connection.Close();
                        DataClass.connection.Dispose();
                        return id;
                    }
                }

                DataClass.reader.Close();
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return -1;
            }
            else
            {
                DataClass.connection.Dispose();
                return -2;
            }
        }

        public string GetUserLoginByID(int id)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT *From Accounts WHERE ID = " + id;
                DataClass.reader = DataClass.cmd.ExecuteReader();

                while (DataClass.reader.Read())
                {
                    string login = DataClass.reader[2].ToString();
                    DataClass.reader.Close();
                    DataClass.connection.Close();
                    DataClass.connection.Dispose();
                    return login;
                }

                DataClass.reader.Close();
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return "-1";
            }
            else
            {
                DataClass.connection.Dispose();
                return "-2";
            }
        }

        public int GetUserIDByLogin(string login)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT *From Accounts WHERE Login = '" + login + "'";
                DataClass.reader = DataClass.cmd.ExecuteReader();

                while (DataClass.reader.Read())
                {
                    int id = Convert.ToInt32(DataClass.reader[0]);
                    DataClass.reader.Close();
                    DataClass.connection.Close();
                    DataClass.connection.Dispose();
                    return id;
                }

                DataClass.reader.Close();
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return -1;
            }
            else
            {
                DataClass.connection.Dispose();
                return -2;
            }
        }

        public int GetUserRoleIDByUserID(int idUser)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT *From Accounts WHERE ID = " + idUser;
                DataClass.reader = DataClass.cmd.ExecuteReader();

                while (DataClass.reader.Read())
                {
                    int idRole = Convert.ToInt32(DataClass.reader[1]);
                    DataClass.reader.Close();
                    DataClass.connection.Close();
                    DataClass.connection.Dispose();
                    return idRole;
                }

                DataClass.reader.Close();
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return -1;
            }
            else
            {
                DataClass.connection.Dispose();
                return -2;
            }
        }

        public int Registr(string login, string password)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "INSERT INTO Accounts ([ID role], [Login], [Password]) VALUES (3, '" + login + "', '" + password + "')";
                try
                {
                    DataClass.cmd.ExecuteNonQuery();
                    return 0;
                }
                catch
                {
                    DataClass.connection.Close();
                    DataClass.connection.Dispose();
                    return -1;
                }
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return -2;
            }
        }

        public List<string> GetListTable(int userRoleID)
        {
            List<string> ListTable = new List<string>();

            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table'";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    ListTable.Add(DataClass.reader[0].ToString());
                }
                DataClass.reader.Close();

                if (userRoleID == 1)
                {
                    for (int i = 0; i < ListTable.Count; i++)
                    {
                        if (ListTable[i].IndexOf("Table") >= 0 || ListTable[i].IndexOf("Accounts") >= 0)
                        {

                        }
                        else
                        {
                            ListTable.Remove(ListTable[i]);
                            i--;
                        }
                    }

                    DataClass.connection.Close();
                    DataClass.connection.Dispose();
                    return ListTable;
                }
                else if (userRoleID == 2)
                {
                    for (int i = 0; i < ListTable.Count; i++)
                    {
                        if (ListTable[i].IndexOf("Table") >= 0)
                        {

                        }
                        else
                        {
                            ListTable.Remove(ListTable[i]);
                            i--;
                        }
                    }

                    DataClass.connection.Close();
                    DataClass.connection.Dispose();
                    return ListTable;
                }
                else
                {
                    DataClass.connection.Close();
                    DataClass.connection.Dispose();
                    return null;
                }
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return null;
            }
        }

        public List<string> GetListName(string nameTable)
        {
            List<string> ListTable = new List<string>();

            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT Name FROM "+ nameTable;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    ListTable.Add(DataClass.reader[0].ToString());
                }
                DataClass.reader.Close();

                return ListTable;
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return null;
            }
        }

        public DataTable GetTable(string nameTable)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.adapter = new SQLiteDataAdapter("SELECT *FROM " + nameTable, DataClass.connection);
                DataSet ds = new DataSet();
                DataClass.adapter.Fill(ds, nameTable);
                return ds.Tables[0];
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return null;
            }
        }

        public DataTable GetTable(string nameTable, string query)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.adapter = new SQLiteDataAdapter(query, DataClass.connection);
                DataSet ds = new DataSet();
                DataClass.adapter.Fill(ds, nameTable);
                DataClass.connection.Close();
                return ds.Tables[0];
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return null;
            }
        }

        public int GetProduct(string nameProduct)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, Name FROM Products";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if(DataClass.reader[1].ToString() == nameProduct)
                    {
                        int id = Convert.ToInt32(DataClass.reader[0]);
                        DataClass.reader.Close();
                        DataClass.connection.Close();
                        DataClass.connection.Dispose();
                        return id;
                    }
                }
                DataClass.reader.Close();

                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return -2;
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return -1;
            }
        }

        public string GetProductSet(CheckBox pancakeCB, TextBox pancakeTB, CheckBox tunCB, TextBox tunTB, ListBox setLB, CheckBox discountCB, TextBox discountGramTB, TextBox discountValueTB)
        {
            string setProduct = "";

            try
            {
                if(pancakeCB.Checked == true)
                {
                    setProduct += "1/" + pancakeTB.Text + "|";
                }
                else
                {
                    setProduct += "0/0|";
                }

                if (tunCB.Checked == true)
                {
                    setProduct += "1/" + tunTB.Text + "|";
                }
                else
                {
                    setProduct += "0/0|";
                }

                if (setLB.Items.Count <= 0)
                {
                    setProduct += "0|";
                }
                else
                {
                    for (int i = 0; i < setLB.Items.Count; i++)
                    {
                        if (i == setLB.Items.Count - 1)
                        {
                            setProduct += setLB.Items[i] + "|";
                        }
                        else
                        {
                            setProduct += setLB.Items[i] + "/";
                        }
                    }
                }

                if (discountCB.Checked == true)
                {
                    setProduct += "1/" + discountGramTB.Text + "/" + discountValueTB.Text;
                }
                else
                {
                    setProduct += "0/0/0";
                }

                return setProduct;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetUsersTable()
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);

                string query = "SELECT Accounts.Login AS Логин, Accounts.Password AS Пароль, Roles.Name AS [Уровень доступа] FROM Accounts LEFT JOIN Roles ON Accounts.[ID role] = Roles.ID";

                DataClass.adapter = new SQLiteDataAdapter(query, DataClass.connection);
                DataSet ds = new DataSet();
                DataClass.adapter.Fill(ds, "Accounts");
                DataClass.adapter.Dispose();
                return ds.Tables[0];
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return null;
            }
        }

        public void EditRoleUser(int idUser, int idRole)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "UPDATE Accounts SET [ID role] = " + idRole + " WHERE ID = " + idUser;
                DataClass.cmd.ExecuteNonQuery();
                DataClass.connection.Close();
                DataClass.connection.Dispose();
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
            }
        }

        public void DeleteUser(int idUser)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "DELETE FROM Accounts WHERE ID = " + idUser;
                DataClass.cmd.ExecuteNonQuery();
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
            }
        }

        public string GetProductSetString(int id)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, [ID type] FROM Products WHERE ID = " + id;

                int typeID = -1;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    typeID = Convert.ToInt32(DataClass.reader[1]);
                }
                DataClass.reader.Close();

                if(typeID <= -1)
                {
                    DataClass.connection.Close();
                    return null;
                }

                DataClass.cmd.CommandText = "SELECT ID, [Related table] FROM Types WHERE ID = " + typeID;

                string typeTable = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    typeTable = DataClass.reader[1].ToString();
                }
                DataClass.reader.Close();

                if (typeTable == "")
                {
                    DataClass.connection.Close();
                    return null;
                }

                DataClass.cmd.CommandText = "SELECT [ID product], [Product set] FROM " + typeTable + " WHERE [ID product] = " + id;

                string result = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    result = DataClass.reader[1].ToString();
                    DataClass.reader.Close();
                    DataClass.connection.Close();
                    return result;
                }

                DataClass.reader.Close();
                DataClass.connection.Close();
                return null;
            }
            else
            {
                DataClass.connection.Close();
                return null;
            }
        }

        public void FillProduct(int idProduct, TextBox nameProductTB, PictureBox pb, Button[] arrayButton, ComboBox typeCB, ComboBox formCB, CheckBox pancakeCB, TextBox countGramPancakeTB, CheckBox tuneCB, TextBox countPancakeTB, ListBox setLB, TextBox descriptionTB, TextBox basicPriceTB, CheckBox discountCB, TextBox discountGramTB, TextBox discountTB)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, Name FROM Products WHERE ID = " + idProduct;

                //
                string nameProduct = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idProduct)
                    {
                        nameProduct = DataClass.reader[1].ToString();
                    }
                }
                DataClass.reader.Close();

                if(nameProduct == "")
                {
                    return;
                }

                nameProductTB.Text = nameProduct;

                //
                DataClass.cmd.CommandText = "SELECT ID, [ID type], [Image 1], [Image 2], [Image 3], [Image 4], [Image 5] FROM Products WHERE ID = " + idProduct;

                List<Image> arrayImage = new List<Image>();
                int idType = -1;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idProduct)
                    {
                        for (int i = 2; i < DataClass.reader.FieldCount; i++)
                        {
                            if (DataClass.reader[i] != DBNull.Value)
                            {
                                byte[] byteImg = (byte[])DataClass.reader[i];
                                Image img = ConvertByteToImage(byteImg);
                                arrayImage.Add(img);
                            }
                        }

                        idType = Convert.ToInt32(DataClass.reader[1]);
                    }
                }
                DataClass.reader.Close();

                if(arrayImage.Count >= 1)
                {
                    pb.BackgroundImage = arrayImage[0];
                }

                for(int i = 0; i < arrayImage.Count; i++)
                {
                    arrayButton[i].BackgroundImage = arrayImage[i];
                }

                typeCB.SelectedIndex = idType - 1;

                //
                DataClass.cmd.CommandText = "SELECT ID, [Related table] FROM Types WHERE ID = " + idType;

                string nameTable = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idType)
                    {
                        nameTable = DataClass.reader[1].ToString();
                    }
                }
                DataClass.reader.Close();

                DataClass.cmd.CommandText = "SELECT [ID product], [ID form], Price, Description FROM " +nameTable+ " WHERE [ID product] = " + idProduct;

                int idForm = -1;
                double price = -1;
                string description = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idProduct)
                    {
                        idForm = Convert.ToInt32(DataClass.reader[1]);
                        price = Convert.ToDouble(DataClass.reader[2]);
                        description = DataClass.reader[3].ToString();
                    }
                }
                DataClass.reader.Close();

                formCB.SelectedIndex = idForm - 1;
                basicPriceTB.Text = price.ToString();
                descriptionTB.Text = description;
                //
                string[] setProduct = GetProductSetString(idProduct).Split('|');

                string[] partPancake = setProduct[0].Split('/');
                if (partPancake[0] == "0")
                {
                    pancakeCB.Checked = false;
                }
                else
                {
                    pancakeCB.Checked = true;
                    countGramPancakeTB.Text = partPancake[1];
                }

                string[] partTune = setProduct[1].Split('/');
                if (partTune[0] == "0")
                {
                    tuneCB.Checked = false;
                }
                else
                {
                    tuneCB.Checked = true;
                    countPancakeTB.Text = partTune[1];
                }

                setLB.Items.Clear();

                string[] partElement = setProduct[2].Split('/');

                if (setProduct[2] != "0")
                {
                    if (partElement.Length >= 1)
                    {
                        for (int i = 0; i < partElement.Length; i++)
                        {
                            setLB.Items.Add(partElement[i]);
                        }
                    }
                }

                string[] partDiscount = setProduct[3].Split('/');
                if (partDiscount[0] == "0")
                {
                    discountCB.Checked = false;
                }
                else
                {
                    discountCB.Checked = true;
                    discountGramTB.Text = partDiscount[1];
                    discountTB.Text = partDiscount[2];
                }
                //

                DataClass.connection.Close();
                return;
            }
            else
            {
                DataClass.connection.Close();
                return;
            }
        }

        public int AddProduct(string nameType, string nameForm, string nameProduct, List<Image> arrayImage, string productSet, double price, string description)
        {
            string nameTypeTable = null;
            int idType = -1;
            int idForm = -1;
            int idProduct = -1;
            List<byte[]> arrayByte = new List<byte[]>();

            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if(DataClass.reader.IsClosed == false)
            {
                DataClass.reader.Close();
            }

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, Name, [Related table] FROM Types";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if(DataClass.reader[1].ToString() == nameType)
                    {
                        nameTypeTable = DataClass.reader[2].ToString();
                        idType = Convert.ToInt32(DataClass.reader[0]);
                    }
                }
                DataClass.reader.Close();

                if(nameTypeTable == null || idType == -1)
                {
                    DataClass.cmd.Dispose();
                    DataClass.connection.Close();
                    return -2;
                }

                DataClass.cmd.CommandText = "SELECT ID, Name FROM Forms";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (DataClass.reader[1].ToString() == nameForm)
                    {
                        idForm = Convert.ToInt32(DataClass.reader[0]);
                    }
                }
                DataClass.reader.Close();

                if (idForm == -1)
                {
                    DataClass.cmd.Dispose();
                    DataClass.connection.Close();
                    return -2;
                }

                string query = "INSERT INTO Products ([ID type], Name";

                for (int i = 0; i < arrayImage.Count; i++)
                {
                    arrayByte.Add(ConvertImageToByte(arrayImage[i]));
                    query += ", [Image " + (i + 1) + "]";
                }

                query += ") VALUES (" + idType + ", '" + nameProduct + "'";

                for(int i = 0; i < arrayByte.Count; i++)
                {
                    query += ", " + "@img" + (i+1);
                }

                query += ")";

                DataClass.cmd.CommandText = query;

                for(int i=0; i<arrayByte.Count; i++)
                {
                    DataClass.cmd.Parameters.Add("@img" + (i+1), DbType.Binary, 8000).Value = arrayByte[i];
                }

                DataClass.cmd.ExecuteNonQuery();

                DataClass.cmd.CommandText = "SELECT ID, Name FROM Products";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (DataClass.reader[1].ToString() == nameProduct)
                    {
                        idProduct = Convert.ToInt32(DataClass.reader[0]);
                    }
                }
                DataClass.reader.Close();

                if(idProduct == -1)
                {
                    DataClass.cmd.Dispose();
                    DataClass.connection.Close();
                    return -2;
                }

                DataClass.cmd.CommandText = "INSERT INTO " + nameTypeTable + "([ID product], [ID form], [Product set], Price, Description) VALUES (" + idProduct + ", " + idForm + ", '" + productSet + "', '" + price + "', '" + description + "')";
                DataClass.cmd.ExecuteNonQuery();

                DataClass.cmd.Dispose();
                DataClass.connection.Close();
                return idProduct;
            }
            else
            {
                DataClass.cmd.Dispose();
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return -3;
            }
        }

        public int EditProduct(int state, int idProduct, string nameType, string nameForm, string nameProduct, List<Image> arrayImage, string productSet, double price, string description)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                List<byte[]> arrayByte = new List<byte[]>();

                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, [ID type] FROM Products WHERE ID = " + idProduct;

                int idType = -1;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idProduct)
                    {
                        idType = Convert.ToInt32(DataClass.reader[1]);
                    }
                }
                DataClass.reader.Close();


                if(idType <= -1)
                {
                    DataClass.connection.Close();
                    return -1;
                }

                DataClass.cmd.CommandText = "SELECT ID, [Related table] FROM Types WHERE ID = " + idType;

                string nameTable = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idType)
                    {
                        nameTable = DataClass.reader[1].ToString();
                    }
                }
                DataClass.reader.Close();

                if(nameTable == "")
                {
                    DataClass.connection.Close();
                    return -1;
                }

                if(state == 0)
                {
                    DataClass.cmd.CommandText = "DELETE FROM " + nameTable + " WHERE [ID product] = " + idProduct;
                    DataClass.cmd.ExecuteNonQuery();

                    DataClass.cmd.CommandText = "SELECT ID, Name FROM Types WHERE Name = '" + nameType + "'";

                    int newType = -1;

                    DataClass.reader = DataClass.cmd.ExecuteReader();
                    while (DataClass.reader.Read())
                    {
                        if (DataClass.reader[1].ToString() == nameType)
                        {
                            newType = Convert.ToInt32(DataClass.reader[0]);
                        }
                    }
                    DataClass.reader.Close();

                    if(newType <= -1)
                    {
                        DataClass.connection.Close();
                        return -1;
                    }

                    idType = newType;

                    DataClass.cmd.CommandText = "SELECT ID, [Related table] FROM Types WHERE ID = " + idType;

                    DataClass.reader = DataClass.cmd.ExecuteReader();
                    while (DataClass.reader.Read())
                    {
                        if (Convert.ToInt32(DataClass.reader[0]) == idType)
                        {
                            nameTable = DataClass.reader[1].ToString();
                        }
                    }
                    DataClass.reader.Close();
                }

                string query = "UPDATE Products SET [ID type] = " + idType + ", Name = '" + nameProduct + "'";

                for(int i = 0; i < 5; i++)
                {
                    if(i == 4)
                    {
                        query += ", [Image " + (i + 1) + "] = @img" + (i + 1) + " WHERE ID = " + idProduct;
                    }
                    else
                    {
                        query += ", [Image " + (i + 1) + "] = @img" + (i + 1);
                    }
                }

                for(int i = 0; i < arrayImage.Count; i++)
                {
                    arrayByte.Add(ConvertImageToByte(arrayImage[i]));
                }

                DataClass.cmd.CommandText = query;

                for (int i = 0; i < 5; i++)
                {
                    if (i < arrayByte.Count)
                    {
                        DataClass.cmd.Parameters.Add("@img" + (i + 1), DbType.Binary, 8000).Value = arrayByte[i];
                    }
                    else
                    {
                        DataClass.cmd.Parameters.Add("@img" + (i + 1), DbType.Binary, 8000).Value = DBNull.Value;
                    }
                }

                DataClass.cmd.ExecuteNonQuery();

                DataClass.cmd.CommandText = "SELECT ID, Name FROM Forms WHERE Name = '" + nameForm + "'";

                int idForm = -1;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (DataClass.reader[1].ToString() == nameForm)
                    {
                        idForm = Convert.ToInt32(DataClass.reader[0]);
                    }
                }
                DataClass.reader.Close();

                if (idForm == -1)
                {
                    DataClass.connection.Close();
                    return -1;
                }

                if (state == 0)
                {
                    DataClass.cmd.CommandText = "INSERT INTO " + nameTable + "([ID product], [ID form], [Product set], Price, Description) VALUES (" + idProduct + ", " + idForm + ", '" + productSet + "', '" + price + "', '" + description + "')";
                    DataClass.cmd.ExecuteNonQuery();
                    DataClass.connection.Close();
                    return 1;
                }
                else
                {
                    DataClass.cmd.CommandText = "UPDATE " + nameTable + " SET [ID product] = " + idProduct + ", [ID form] = " + idForm + ", [Product set] = '" + productSet + "', Price = '" + price + "', Description = '" + description + "' WHERE [ID product] = " + idProduct;
                    DataClass.cmd.ExecuteNonQuery();
                    DataClass.connection.Close();
                    return 1;
                }
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return -1;
            }
        }

        public int DeleteProduct(int idProduct)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);

                DataClass.cmd.CommandText = "SELECT ID, [ID type] FROM Products WHERE ID = " + idProduct;

                int idType = -1;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while(DataClass.reader.Read())
                {
                    if(Convert.ToInt32(DataClass.reader[0]) == idProduct)
                    {
                        idType = Convert.ToInt32(DataClass.reader[1]);
                    }
                }
                DataClass.reader.Close();

                DataClass.cmd.CommandText = "Select ID, [Related table] From Types WHERE ID = " + idType;

                string nameTable = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while(DataClass.reader.Read())
                {
                    if(Convert.ToInt32(DataClass.reader[0]) == idType)
                    {
                        nameTable = DataClass.reader[1].ToString();
                    }
                }
                DataClass.reader.Close();

                DataClass.cmd.CommandText = "DELETE FROM Products WHERE ID = " + idProduct;

                try
                {
                    DataClass.cmd.ExecuteNonQuery();
                }
                catch
                {
                    DataClass.connection.Close();
                    return 0;
                }

                DataClass.cmd.CommandText = "DELETE FROM " + nameTable + " WHERE [ID product] = " + idProduct;

                try
                {
                    DataClass.cmd.ExecuteNonQuery();
                }
                catch
                {
                    DataClass.connection.Close();
                    return 0;
                }

                DataClass.connection.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int GetTableIDType(string nameType)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, Name, [Related table] FROM Types Where Name = '"+ nameType +"'";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if(DataClass.reader[1].ToString() == nameType)
                    {
                        int id = Convert.ToInt32(DataClass.reader[0]);
                        DataClass.reader.Close();
                        DataClass.connection.Close();
                        DataClass.connection.Dispose();
                        return id;
                    }
                }
                DataClass.reader.Close();

                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return -1;
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return -1;
            }
        }

        public DataTable GetProductByIDType(int tableID, List<string> arrayColumn)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);

                string query = "SELECT ";

                for(int i = 0; i < arrayColumn.Count; i++)
                {
                    if(i != arrayColumn.Count - 1)
                    {
                        query += arrayColumn[i] + ", "; 
                    }
                    else
                    {
                        query += arrayColumn[i] + "FROM Products WHERE [ID type] = " + tableID;
                    }
                }

                DataClass.adapter = new SQLiteDataAdapter(query, DataClass.connection);
                DataSet ds = new DataSet();
                DataClass.adapter.Fill(ds, "Products");
                DataClass.adapter.Dispose();
                return ds.Tables[0];
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return null;
            }
        }

        public string GetNameProductByID(int id)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, Name FROM Products Where ID = " + id;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == id)
                    {
                        string nameProduct = DataClass.reader[1].ToString();
                        DataClass.reader.Close();
                        DataClass.connection.Close();
                        DataClass.connection.Dispose();
                        return nameProduct;
                    }
                }
                DataClass.reader.Close();

                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return null;
            }
            else
            {
                DataClass.connection.Close();
                DataClass.connection.Dispose();
                return null;
            }
        }

        public Panel DrawProducts(Panel parent, List<int> arrayIDProduct, List<string> arrayNameProduct, List<Image> arrayImageProduct, List<List<double>> arrayPriceProduct, List<List<string>> arraySetProduct, int userRoleID)
        {
            int offsetWidth = 20;
            int offsetHeight = 20;
            int widthPanel = 400;
            int heightPanel = 270;

            int countProducts = arrayIDProduct.Count;
            int countPanelString = Convert.ToInt32(parent.Width / (widthPanel + offsetWidth));

            int x = Convert.ToInt32((parent.Width / 2) - ( countPanelString * (widthPanel + (offsetWidth)) / 2));
            int y = offsetWidth;

            productPanel = new Panel[countProducts];

            int numPanel = 0;

            for(int i = 0; i < productPanel.Length; i++)
            {
                if (numPanel != countPanelString)
                {
                    productPanel[i] = DrawPanel(parent, "ProductPanel" + i, new Size(widthPanel, heightPanel), Color.Transparent, new Point(x + (numPanel * (widthPanel + offsetWidth)), y));
                }
                else
                {
                    numPanel = 0;
                    y += heightPanel + offsetHeight;
                    productPanel[i] = DrawPanel(parent, "ProductPanel" + i, new Size(widthPanel, heightPanel), Color.Transparent, new Point(x + (numPanel * (widthPanel + offsetWidth)), y));
                }
                
                productPanel[i].BackgroundImage = Image.FromFile("../../Resources/Images/ProductPanelBackgroundImage1.png");
                productPanel[i].BackgroundImageLayout = ImageLayout.Stretch;

                numPanel++;

                DrawPictureBox(productPanel[i], "PBProduct" + i, arrayImageProduct[i], new Size(200, 150), new Point(20, 95));
                DrawLabel(productPanel[i], "LabelNameProduct" + i, arrayNameProduct[i], DataClass.fontBasic1TB, new Size(360, 70), Color.White, new Point(20, 20));
                (productPanel[i].Controls["LabelNameProduct" + i] as Label).TextAlign = ContentAlignment.MiddleCenter;

                if ((productPanel[i].Controls["LabelNameProduct" + i] as Label).Text.Length > 50)
                {
                    (productPanel[i].Controls["LabelNameProduct" + i] as Label).Font = DataClass.fontBasic2Label;
                }

                CreateCB(productPanel[i], "CBSetProduct" + i, arraySetProduct[i], new Size(155, 60), new Point(225, 95));
                (productPanel[i].Controls["CBSetProduct" + i] as ComboBox).Tag = i;
                (productPanel[i].Controls["CBSetProduct" + i] as ComboBox).SelectedIndex = (productPanel[i].Controls["CBSetProduct" + i] as ComboBox).Items.Count - 1;

                DrawLabel(productPanel[i], "LabelPriceProduct" + i, arrayPriceProduct[i][arrayPriceProduct[i].Count - 1].ToString("F") + " ₽", DataClass.fontButton, new Size(155, 60), Color.White, new Point(225, 125));
                (productPanel[i].Controls["LabelPriceProduct" + i] as Label).TextAlign = ContentAlignment.MiddleCenter;

                if (userRoleID == 1 || userRoleID == 2)
                {
                    CreateButton(productPanel[i], "ButtonAddProduct" + i, "", Image.FromFile("../../Resources/Images/ProductAddBackgorundImage1.png"), new Size(50, 50), new Point(330, 195));
                    (productPanel[i].Controls["ButtonAddProduct" + i] as Button).Tag = i;
                    (productPanel[i].Controls["ButtonAddProduct" + i] as Button).Font = DataClass.fontBasic2Label;
                    (productPanel[i].Controls["ButtonAddProduct" + i] as Button).BackColor = Color.Transparent;
                    (productPanel[i].Controls["ButtonAddProduct" + i] as Button).FlatAppearance.BorderSize = 0;

                    (productPanel[i].Controls["ButtonAddProduct" + i] as Button).MouseClick += AddProductButton_MouseClick;
                    (productPanel[i].Controls["ButtonAddProduct" + i] as Button).MouseEnter += AddProductButton_MouseEnter;
                    (productPanel[i].Controls["ButtonAddProduct" + i] as Button).MouseLeave += AddProductButton_MouseLeave;
                }

                (productPanel[i].Controls["LabelNameProduct" + i] as Label).MouseClick += LabelNameProduct_MouseClick;
                (productPanel[i].Controls["LabelNameProduct" + i] as Label).MouseEnter += LabelNameProduct_MouseEnter;
                (productPanel[i].Controls["LabelNameProduct" + i] as Label).MouseLeave += LabelNameProduct_MouseLeave;
                (productPanel[i].Controls["CBSetProduct" + i] as ComboBox).SelectedIndexChanged += CBSetProduct;
            }

            listPrices = arrayPriceProduct;

            return null;
        }

        private void AddProductButton_MouseClick(object sender, EventArgs e)
        {
            Button but = sender as Button;
            int index = Convert.ToInt32(but.Tag);

            string priceS = (productPanel[index].Controls["LabelPriceProduct" + index] as Label).Text;
            double price = Convert.ToDouble(priceS.Replace(" ₽", " "));

            DataClass.nameProductOrder.Add((productPanel[index].Controls["LabelNameProduct" + index] as Label).Text);
            DataClass.setProductOrder.Add((productPanel[index].Controls["CBSetProduct" + index] as ComboBox).SelectedItem.ToString());
            DataClass.priceProductOrder.Add(price);
            DataClass.priceDiscountProductOrder.Add(GetPriceDiscountProduct((productPanel[index].Controls["LabelNameProduct" + index] as Label).Text, (productPanel[index].Controls["CBSetProduct" + index] as ComboBox).SelectedItem.ToString()));
        }

        private void LabelNameProduct_MouseClick(object sender, EventArgs e)
        {
            Label label = sender as Label;

            Form PF = new ProductForm(label.Text);
            PF.ShowDialog();
        }

        private void LabelNameProduct_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;

            label.ForeColor = DataClass.colorButton;
        }

        private void LabelNameProduct_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;

            label.ForeColor = Color.White;
        }

        private void AddProductButton_MouseEnter(object sender, EventArgs e)
        {
            Button but = sender as Button;

            int index = Convert.ToInt32(but.Tag);
            (productPanel[index].Controls["ButtonAddProduct" + index] as Button).BackgroundImage = Image.FromFile("../../Resources/Images/ProductAddBackgorundImage2.png");
        }

        private void AddProductButton_MouseLeave(object sender, EventArgs e)
        {
            Button but = sender as Button;

            int index = Convert.ToInt32(but.Tag);
            (productPanel[index].Controls["ButtonAddProduct" + index] as Button).BackgroundImage = Image.FromFile("../../Resources/Images/ProductAddBackgorundImage1.png");
        }

        public void DrawProduct(Form form, string nameProduct)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, [ID type], Name, [Image 1], [Image 2], [Image 3], [Image 4], [Image 5] FROM Products WHERE Name = '" + nameProduct + "'";

                int idType = 1;
                int idProduct = -1;
                List<Image> arrayImage = new List<Image>();

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (DataClass.reader[2].ToString() == nameProduct)
                    {
                        idType = Convert.ToInt32(DataClass.reader[1]);
                        idProduct = Convert.ToInt32(DataClass.reader[0]);

                        for (int i = 0; i < 5; i++)
                        {
                            byte[] arrayByte = null;
                            if (DataClass.reader[i + 3] != DBNull.Value)
                            {
                                arrayByte = (byte[])DataClass.reader[i + 3];
                            }
      
                            Image img = null;

                            if (arrayByte != null)
                            {
                                img = ConvertByteToImage(arrayByte);
                            }

                            arrayImage.Add(img);
                        }
                    }
                }
                DataClass.reader.Close();

                DataClass.cmd.CommandText = "SELECT ID, [Related table] FROM Types WHERE ID = " + idType;

                string nameTable = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idType)
                    {
                        nameTable = DataClass.reader[1].ToString();
                    }
                }
                DataClass.reader.Close();

                DataClass.cmd.CommandText = "SELECT [ID product], [Product set], [Price], [Description] FROM " + nameTable + " WHERE [ID product] = " + idProduct;

                string productSet = "";
                double price = 0;
                string description = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idProduct)
                    {
                        productSet = DataClass.reader[1].ToString();
                        price = Convert.ToDouble(DataClass.reader[2]);
                        description = DataClass.reader[3].ToString();
                    }
                }
                DataClass.reader.Close();

                DataClass.connection.Close();

                priceProduct = new List<double>();
                (form.Controls["NameProductLabel"] as Label).Text = nameProduct;

                List<string> set = new List<string>();
                string[] part = productSet.Split('|').ToArray();

                string[] pancake = part[0].Split('/');
                if(pancake[0] != "0")
                {
                    set.Add("Целый блин (" + pancake[1] + " г.)");
                    priceProduct.Add(Convert.ToInt32(pancake[1]) * price);
                }

                string[] tun = part[1].Split('/');
                if(tun[0] != "0")
                {
                    set.Insert(0, "Тун (" + tun[1] + " блин.)");
                    priceProduct.Insert(0, Convert.ToInt32(tun[1]) * Convert.ToInt32(pancake[1]) * price);
                }

                string[] elements = part[2].Split('/');
                if(elements[0] != "0")
                {
                    for(int i = 0; i < elements.Length; i++)
                    {
                        set.Add(elements[i]);
                        string[] gram = elements[i].Split(' ');
                        priceProduct.Add(Convert.ToDouble(gram[0]) * price);
                    }
                }

                (form.Controls["CBSetProduct"] as ComboBox).Items.AddRange(set.ToArray());
                (form.Controls["CBSetProduct"] as ComboBox).SelectedIndexChanged += CBSetProduct_SelectedIndexChanged;
                

                (form.Controls["PriceProductLabel"] as Label).Text = price.ToString("F") + " ₽";
                (form.Controls["DescriptionProductTB"] as TextBox).Text = description;

                (form.Controls["CBSetProduct"] as ComboBox).SelectedIndex = (form.Controls["CBSetProduct"] as ComboBox).Items.Count - 1;

                for (int i = 0; i < arrayImage.Count; i++)
                {
                    (form.Controls["PBImageProduct" + (i + 1)] as PictureBox).BackgroundImage = arrayImage[i];
                }

                for (int i = 0; i < 5; i++)
                {
                    if((form.Controls["PBImageProduct" + (i + 1)] as PictureBox).BackgroundImage == null)
                    {
                        (form.Controls["PBImageProduct" + (i + 1)] as PictureBox).BackgroundImage = Image.FromFile("../../Resources/Images/NoPhoto.png");
                    }
                }

                if (arrayImage.Count > 0)
                {
                    (form.Controls["PBImage"] as PictureBox).BackgroundImage = arrayImage[0];
                }
                else
                {
                    (form.Controls["PBImage"] as PictureBox).BackgroundImage = Image.FromFile("../../Resources/Images/NoPhoto.png");
                }

                form.Text = "Подробная информация о товаре: " + nameProduct;
            }
            else
            {
                DataClass.connection.Close();
            }
        }

        private void CBSetProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form PF = Application.OpenForms["ProductForm"];
            (PF.Controls["PriceProductLabel"] as Label).Text = priceProduct[(PF.Controls["CBSetProduct"] as ComboBox).SelectedIndex].ToString("F") + " ₽";
        }

        List<double> priceProduct;

        private void CBSetProduct(object sender, EventArgs e)
        {
            ComboBox CB = sender as ComboBox;

            int index = Convert.ToInt32(CB.Tag);
            (productPanel[index].Controls["LabelPriceProduct" + index] as Label).Text = Math.Round(listPrices[index][CB.SelectedIndex], 2).ToString("F") + " ₽";
        }

        Panel[] productPanel;
        List<List<double>> listPrices = new List<List<double>>();

        public string FixString(string s)
        {
            s = s.Trim();

            while (s.IndexOf("  ") >= 0)
            {
                s = s.Replace("  ", " ");
            }

            return s;
        }

        public string GetTypeName(int idProduct)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, [ID type] FROM Products WHERE ID = " + idProduct;

                int idType = -1;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idProduct)
                    {
                        idType = Convert.ToInt32(DataClass.reader[1]);
                    }
                }
                DataClass.reader.Close();

                if(idType <= -1)
                {
                    return null;
                }

                DataClass.cmd.CommandText = "SELECT ID, Name FROM Types WHERE ID = " + idType;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idType)
                    {
                        string nameType = DataClass.reader[1].ToString();
                        DataClass.reader.Close();
                        DataClass.connection.Close();
                        return nameType;
                    }
                }
                DataClass.reader.Close();
                DataClass.connection.Close();
                return null;
            }
            else
            {
                DataClass.connection.Close();
                return null;
            }
        }

        public Image GetImage()// Метод, который получает картинку с помощью OpenFileDialog
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Выберите изображение|*.JPG;*.PNG|JPG|*.JPG|PNG|*.PNG";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                string fileName = OFD.FileName;
                try
                {
                    Image image = Image.FromFile(fileName);
                    OFD.Dispose();
                    return image;
                }
                catch
                {
                    OFD.Dispose();
                    return null;
                }
            }
            OFD.Dispose();

            return null;
        }

        public byte[] ConvertImageToByte(Image image)// Метод, который конвертирует картинку в массив байтов
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            byte[] b = ms.ToArray();
            return b;
        }

        public Image ConvertByteToImage(byte[] b)// Метод, который конвертирует массив байтов в картинку
        {
            MemoryStream ms = new MemoryStream(b, 0, b.Length);
            ms.Write(b, 0, b.Length);
            Image image;
            try
            {
                image = new Bitmap(ms);
                return image;
            }
            catch
            {
                return null;
            }
        }

        public Panel DrawPanel(Form Parent, string namePanel, Color backColor, Point locationPanel)
        {
            Panel panel = new Panel();
            panel.Parent = Parent;
            panel.Location = locationPanel;
            panel.BackColor = backColor;
            panel.AutoScroll = true;
            return panel;
        }

        public Panel DrawPanel(Panel Parent, string namePanel, Size sizePanel, Color backColor, Point locationPanel)
        {
            Panel panel = new Panel();
            panel.Parent = Parent;
            panel.Size = sizePanel;
            panel.Location = locationPanel;
            panel.BackColor = backColor;
            //panel.BorderStyle = BorderStyle.FixedSingle;
            return panel;
        }

        public Label DrawLabel(Panel parentPanel, string nameLabel, string textLabel, Font fontLabel, Color colorText, Point locationLabel)
        {
            Label label = new Label();
            label.Name = nameLabel;
            label.Parent = parentPanel;
            label.Font = fontLabel;
            label.ForeColor = colorText;
            label.Text = textLabel;
            label.AutoSize = true;
            label.Location = locationLabel;
            return label;
        }

        public Label DrawLabel(Panel parentPanel, string nameLabel, string textLabel, Font fontLabel, Size sizeLabel, Color colorText, Point locationLabel)
        {
            Label label = new Label();
            label.Name = nameLabel;
            label.Parent = parentPanel;
            label.Font = fontLabel;
            label.ForeColor = colorText;
            label.Text = textLabel;
            label.Size = sizeLabel;
            label.Location = locationLabel;
            return label;
        }

        public PictureBox DrawPictureBox(Panel parentPB, string namePB, Image imgPB, Size sizePB, Point locationPB)
        {
            PictureBox PB = new PictureBox();
            PB.Name = namePB;
            PB.BackgroundImageLayout = ImageLayout.Stretch;
            PB.Size = sizePB;
            PB.BorderStyle = BorderStyle.Fixed3D;

            if(imgPB != null)
            {
                PB.BackgroundImage = imgPB;
            }

            PB.Parent = parentPB;
            PB.Location = locationPB;
            return PB;
        }

        public PictureBox DrawPictureBoxProduct(Panel parentPB, string namePB, Image imgPB, Size sizePB, Point locationPB)
        {
            PictureBox PB = new PictureBox();
            PB.Name = namePB;
            PB.BackgroundImageLayout = ImageLayout.Stretch;
            PB.Size = sizePB;
            PB.BorderStyle = BorderStyle.FixedSingle;

            if (imgPB != null)
            {
                PB.BackgroundImage = imgPB;
            }

            PB.Parent = parentPB;
            PB.Location = locationPB;
            return PB;
        }

        public TextBox CreateTB(Panel parentTB, string nameTB, Font fontTB, Size sizeTB, Point locationTB)
        {
            TextBox TB = new TextBox();
            TB.Parent = parentTB;
            TB.Name = nameTB;
            TB.Font = fontTB;
            TB.Size = sizeTB;
            TB.Location = locationTB;
            return TB;
        }

        public ComboBox CreateCB(Panel parent, string nameCB, List<string> arrayElement, Size sizeCB, Point locationCB)
        {
            ComboBox CB = new ComboBox();
            CB.Parent = parent;
            CB.Name = nameCB;
            CB.Items.AddRange(arrayElement.ToArray());
            CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CB.Location = locationCB;
            CB.Size = sizeCB;
            return CB;
        }

        public Button CreateButton(Panel parent, string nameButton, string textButton, Size sizeButton, Point locationButton)
        {
            Button but = new Button();
            but.Name = nameButton;
            but.Parent = parent;
            but.Text = textButton;
            but.FlatStyle = FlatStyle.Flat;
            but.Size = sizeButton;
            but.Location = locationButton;
            return but;
        }

        public Button CreateButton(Panel parent, string nameButton, string textButton, Image img, Size sizeButton, Point locationButton)
        {
            Button but = new Button();
            but.Name = nameButton;
            but.Parent = parent;
            but.Text = textButton;
            but.BackgroundImage = img;
            but.BackgroundImageLayout = ImageLayout.Stretch;
            but.FlatStyle = FlatStyle.Flat;
            but.Size = sizeButton;
            but.Location = locationButton;
            return but;
        }

        public Font SetFont(string pathToFile, int sizeFont, PrivateFontCollection fontColl)
        {
            fontColl.AddFontFile(pathToFile);
            FontFamily ff = fontColl.Families[fontColl.Families.Length-1];
            Font font = new Font(ff, sizeFont);
            return font;
        }

        public void SearchProduct(DataGridView DGVProducts, TextBox SearchProductTB)
        {
            string query = "SELECT Products.Name as [Название товара], Types.Name as [Тип чая] FROM Products INNER JOIN Types ON Products.[ID type] = Types.ID";

            DataTable DT = DataClass.work.GetTable("Products", query);
            DGVProducts.DataSource = DT;
            DGVProducts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            List<string> rows = new List<string>();

            for (int i = 0; i < DGVProducts.RowCount; i++)
            {
                if (DGVProducts.Rows[i].Cells[0].Value.ToString().IndexOf(SearchProductTB.Text, StringComparison.OrdinalIgnoreCase) >= 0 || DGVProducts.Rows[i].Cells[1].Value.ToString().IndexOf(SearchProductTB.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    rows.Add("Products.Name = '" + DGVProducts.Rows[i].Cells[0].Value.ToString() + "'");
                }
            }

            for (int i = 0; i < rows.Count; i++)
            {
                if (i == 0)
                {
                    query += " Where " + rows[i];
                }
                else
                {
                    query += " Or " + rows[i];
                }
            }

            if (rows.Count <= 0)
            {
                query += " Where Products.ID < 0";
            }

            DT = DataClass.work.GetTable("Products", query);
            DGVProducts.DataSource = DT;
            DGVProducts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach(DataGridViewColumn col in DGVProducts.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void SearchOrder(DataGridView DGVOrders, TextBox SearchOrdersTB)
        {
            string query = "SELECT [Order number] AS [ Заказ], [Name client] AS [Покупатель], [Phone number client] AS [Телефон], Price [Стоимость], Date AS [Дата] FROM Orders";

            DataTable DT = DataClass.work.GetTable("Orders", query);
            DGVOrders.DataSource = DT;

            foreach(DataGridViewColumn col in DGVOrders.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            List<string> rows = new List<string>();

            for (int i = 0; i < DGVOrders.RowCount; i++)
            {
                if (DGVOrders.Rows[i].Cells[0].Value.ToString().IndexOf(SearchOrdersTB.Text, StringComparison.OrdinalIgnoreCase) >= 0 || DGVOrders.Rows[i].Cells[1].Value.ToString().IndexOf(SearchOrdersTB.Text, StringComparison.OrdinalIgnoreCase) >= 0 || DGVOrders.Rows[i].Cells[2].Value.ToString().IndexOf(SearchOrdersTB.Text, StringComparison.OrdinalIgnoreCase) >= 0 || DGVOrders.Rows[i].Cells[4].Value.ToString().IndexOf(SearchOrdersTB.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    rows.Add("[Order number] = " + DGVOrders.Rows[i].Cells[0].Value.ToString());
                }
            }

            for (int i = 0; i < rows.Count; i++)
            {
                if (i == 0)
                {
                    query += " Where " + rows[i];
                }
                else
                {
                    query += " Or " + rows[i];
                }
            }

            if (rows.Count <= 0)
            {
                query += " Where ID < 0";
            }

            DT = DataClass.work.GetTable("Orders", query);
            DGVOrders.DataSource = DT;
            DGVOrders.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for(int i = 0; i < DGVOrders.RowCount; i++)
            {
                DGVOrders.Rows[i].Cells[3].Value = DGVOrders.Rows[i].Cells[3].Value + " ₽";
            }

            foreach (DataGridViewColumn col in DGVOrders.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            DGVOrders.Columns[DGVOrders.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.Automatic;
            DGVOrders.Columns[DGVOrders.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public double GetPriceProductByID(int idProduct)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, [ID type] From Products Where ID = " + idProduct;

                int idType = -1;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idProduct)
                    {
                        idType = Convert.ToInt32(DataClass.reader[1]);
                    }
                }
                DataClass.reader.Close();

                DataClass.cmd.CommandText = "SELECT ID, [Related table] From Types Where ID = " + idType;

                string nameTable = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idType)
                    {
                        nameTable = DataClass.reader[1].ToString();
                    }
                }
                DataClass.reader.Close();

                DataClass.cmd.CommandText = "SELECT [ID product], [Price] From " + nameTable + " Where [ID product] = " + idProduct;

                double priceProduct = -1;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idProduct)
                    {
                        priceProduct = Convert.ToDouble(DataClass.reader[1]);
                    }
                }
                DataClass.reader.Close();

                DataClass.connection.Close();
                return priceProduct;
            }
            else
            {
                DataClass.connection.Close();
                return -1;
            }
        }

        public double GetPriceDiscountProduct(string nameProduct, string elemenentSet)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "SELECT ID, [ID type], Name From Products Where Name = '" + nameProduct + "'";

                int idProduct = -1;
                int idType = -1;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (DataClass.reader[2].ToString() == nameProduct)
                    {
                        idProduct = Convert.ToInt32(DataClass.reader[0]);
                        idType = Convert.ToInt32(DataClass.reader[1]);
                    }
                }
                DataClass.reader.Close();

                DataClass.cmd.CommandText = "SELECT ID, [Related table] From Types Where ID = " + idType;

                string nameTable = "";

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idType)
                    {
                        nameTable = DataClass.reader[1].ToString();
                    }
                }
                DataClass.reader.Close();

                DataClass.cmd.CommandText = "SELECT [ID product], [Product set], [Price] From " + nameTable + " Where [ID product] = " + idProduct;

                string productSet = "";
                double priceProduct = -1;

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (Convert.ToInt32(DataClass.reader[0]) == idProduct)
                    {
                        productSet = DataClass.reader[1].ToString();
                        priceProduct = Convert.ToDouble(DataClass.reader[2]);
                    }
                }
                DataClass.reader.Close();

                DataClass.connection.Close();

                string[] part = productSet.Split('|');
                string[] discount = part[part.Length - 1].Split('/');;

                int countGramDiscount = Convert.ToInt32(discount[1]);
                int percent = Convert.ToInt32(discount[2]);

                int countGramProduct = 0;
                int countPancake = 1;
                int countGramPancake = 1;
                int countGramElement = 1;

                bool next = true;

                if(elemenentSet.IndexOf("Тун") >= 0)
                {
                    string s = elemenentSet.Replace("Тун (", "");
                    countPancake = Convert.ToInt32(s.Replace(" блин.)", ""));
                    string[] pancake = part[0].Split('/');
                    countGramPancake = Convert.ToInt32(pancake[1]);
                }

                if (elemenentSet.IndexOf("Целый") >= 0)
                {
                    string s = elemenentSet.Replace("Целый блин (", "");
                    countGramPancake = Convert.ToInt32(s.Replace(" г.)", ""));
                    next = false;
                }

                if (elemenentSet.IndexOf("г.") >= 0 && next != false)
                {
                    string s = elemenentSet.Replace(" г.", "");
                    countGramElement = Convert.ToInt32(s);
                }

                countGramProduct = countPancake * countGramPancake * countGramElement;
                int countPercent = percent * Convert.ToInt32(countGramProduct / countGramDiscount);

                double newPriceProduct = (priceProduct - (((double) countPercent / 100) * priceProduct)) * countGramProduct;

                if(discount[0] != "0")
                {
                    return Math.Round(newPriceProduct, 2);
                }
                else
                {
                    return Math.Round(priceProduct * countGramProduct, 2);
                }
            }
            else
            {
                DataClass.connection.Close();
                return -1;
            }
        }

        public int ConfirmOrder(List<string> nameProducts, List<string> setProducts, int discount, List<double> priceProducts, List<double> priceOrderProducts, double resultPrice, string nameClient, string phoneNumberClient, string Date)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);

                Random run = new Random();

                int numberOrder = 0;
                bool order = true;

                while (order)
                {
                    DataClass.cmd.CommandText = "SELECT [Order number] From Orders";

                    numberOrder = run.Next(1000000, 10000000);
                    order = false;

                    DataClass.reader = DataClass.cmd.ExecuteReader();
                    while (DataClass.reader.Read())
                    {
                        if (numberOrder == Convert.ToInt32(DataClass.reader[0]))
                        {
                            order = true;
                        }
                    }

                    DataClass.reader.Close();
                }

                string productsColumn = "";

                for(int i = 0; i < nameProducts.Count; i++)
                {
                    if(i != nameProducts.Count - 1)
                    {
                        productsColumn += nameProducts[i] + "|" + setProducts[i] + "|" + discount + "/" + priceProducts[i] + "/" + priceOrderProducts[i] + "#";
                    }
                    else
                    {
                        productsColumn += nameProducts[i] + "|" + setProducts[i] + "|" + discount + "/" + priceProducts[i] + "/" + priceOrderProducts[i];
                    }
                }

                DataClass.cmd.CommandText = "INSERT INTO Orders ([Order number], Date,  Products, Price, [Name client], [Phone number client]) VALUES (" + numberOrder + ", '" + Date + "', '" + productsColumn + "', '" + resultPrice.ToString() + "', '" + nameClient + "', '" + phoneNumberClient + "')";
                
                try
                {
                    DataClass.cmd.ExecuteReader();
                    DataClass.connection.Close();
                    return numberOrder;
                }
                catch
                {
                    DataClass.connection.Close();
                    return -1;
                }
            }
            else
            {
                DataClass.connection.Close();
                return -1;
            }
        }

        public void DeleteOrder(int numberOrder)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "DELETE FROM Orders WHERE [Order number] = " + numberOrder;

                try
                {
                    DataClass.cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Товар не был удален!");
                }
            }
            else
            {
                DataClass.connection.Close();
            }
        }

        public void ReConfirmOrder(int orderNumber, DataGridView DGVProductsOrder, Label nameClientLabel, TextBox nameClientTB, Label numberClientLabel, TextBox numberClientTB, CheckBox DiscountCB)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);
                DataClass.cmd.CommandText = "Select [Order number], Products, Price, [Name client], [Phone number client] From Orders Where [Order number] = " + orderNumber;

                string products = "";
                string price = "";
                string nameClient = "";
                string phoneNumber = ""; 

                DataClass.reader = DataClass.cmd.ExecuteReader();
                while (DataClass.reader.Read())
                {
                    if (orderNumber == Convert.ToInt32(DataClass.reader[0]))
                    {
                        products = DataClass.reader[1].ToString();
                        price = DataClass.reader[2].ToString();
                        nameClient = DataClass.reader[3].ToString();
                        phoneNumber = DataClass.reader[4].ToString();
                    }
                }
                DataClass.reader.Close();

                int discount = 0;

                string[] setProducts = products.Split('#');

                for(int i = 0; i < setProducts.Length; i++)
                {
                    string[] elementSet = setProducts[i].Split('|');

                    DataClass.nameProductOrder.Add(elementSet[0]);
                    DataClass.setProductOrder.Add(elementSet[1]);

                    string[] partElement = elementSet[2].Split('/');

                    discount = Convert.ToInt32(partElement[0]);
                    DataClass.priceProductOrder.Add(Convert.ToDouble(partElement[1]));
                    DataClass.priceDiscountProductOrder.Add(Convert.ToDouble(partElement[2]));
                }

                for (int i = 0; i < DataClass.nameProductOrder.Count; i++)
                {
                    DGVProductsOrder.Rows.Add();
                    DGVProductsOrder.Rows[i].Cells[0].Value = i + 1;
                    DGVProductsOrder.Rows[i].Cells[1].Value = DataClass.nameProductOrder[i];
                    DGVProductsOrder.Rows[i].Cells[2].Value = DataClass.setProductOrder[i];

                    if (discount == 1)
                    {
                        DGVProductsOrder.Rows[i].Cells[3].Value = DataClass.priceDiscountProductOrder[i].ToString("F") + " ₽";
                    }
                    else
                    {
                        DGVProductsOrder.Rows[i].Cells[3].Value = DataClass.priceProductOrder[i].ToString("F") + " ₽";
                    }
                }

                if(nameClient != "")
                {
                    nameClientLabel.ForeColor = DataClass.colorButtonEnterMouse;
                    nameClientTB.Text = nameClient;
                }
                else
                {
                    nameClientLabel.ForeColor = Color.White;
                    nameClientTB.Text = "";
                }

                if (phoneNumber != "")
                {
                    numberClientLabel.ForeColor = DataClass.colorButtonEnterMouse;
                    numberClientTB.Text = phoneNumber;
                }
                else
                {
                    numberClientLabel.ForeColor = Color.White;
                    numberClientTB.Text = "";
                }

                if(discount == 1)
                {
                    //DiscountCB.ForeColor = DataClass.colorButtonEnterMouse;
                    DiscountCB.Checked = true;
                }
                else
                {
                    //DiscountCB.ForeColor = Color.White;
                    DiscountCB.Checked = false;
                }
            }
            else
            {
                DataClass.connection.Close();
            }
        }

        public int ReconfirmOrderDatabase(int numberOrder, List<string> nameProducts, List<string> setProducts, int discount, List<double> priceProducts, List<double> priceOrderProducts, double resultPrice, string nameClient, string phoneNumberClient, string Date)
        {
            DataClass.connection = new SQLiteConnection("Data Source=../../Resources/Database/" + DataClass.fileName + ";Version=3;");
            DataClass.connection.Open();

            if (DataClass.connection.State == ConnectionState.Open)
            {
                DataClass.cmd = new SQLiteCommand(DataClass.connection);

                string productsColumn = "";

                for (int i = 0; i < nameProducts.Count; i++)
                {
                    if (i != nameProducts.Count - 1)
                    {
                        productsColumn += nameProducts[i] + "|" + setProducts[i] + "|" + discount + "/" + priceProducts[i] + "/" + priceOrderProducts[i] + "#";
                    }
                    else
                    {
                        productsColumn += nameProducts[i] + "|" + setProducts[i] + "|" + discount + "/" + priceProducts[i] + "/" + priceOrderProducts[i];
                    }
                }

                DataClass.cmd.CommandText = "UPDATE Orders SET Date = '" + Date + "',  Products = '" + productsColumn + "', Price = '" + resultPrice + "', [Name client] = '" + nameClient + "', [Phone number client] =  '" + phoneNumberClient + "' WHERE [Order number] = " + numberOrder;

                try
                {
                    DataClass.cmd.ExecuteReader();
                    DataClass.connection.Close();
                    return numberOrder;
                }
                catch
                {
                    DataClass.connection.Close();
                    return -1;
                }
            }
            else
            {
                DataClass.connection.Close();
                return -1;
            }
        }

        public int[] SortBubble(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                { 
                    if (array[j] > array[j + 1])
                    {
                        int buffer = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = buffer;
                    }
                }
            }

            return array;
        }
    }
}
