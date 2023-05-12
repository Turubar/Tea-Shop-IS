using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ИС_для_чайного_магазина
{
    public partial class RegistrationForm : Form
    {
        private SQLiteConnection connection;
        private SQLiteCommand cmd;
        private SQLiteDataReader reader;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        Timer timer;

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            this.Font = DataClass.fontForm;// Настройка шрифта для RegistrationForm
            RegistrLabel.Font = DataClass.fontMainLabel;// Настройка шрифта для RegistrLabel
            LoginLabel.Font = DataClass.fontBasic1Label;// Настройка шрифта для LoginLabel
            PasswordLabel.Font = DataClass.fontBasic1Label;// Настройка шрифта для PasswordLabel
            LoginTB.Font = DataClass.fontBasic1TB;// Настройка шрифта для LoginTB
            PasswordTB.Font = DataClass.fontBasic1TB;// Настройка шрифта для PasswordTB
            ConfirmButton.Font = DataClass.fontButton;// Настройка шрифта для ConfirmButton
            RegistrButton.Font = DataClass.fontButton;// Настройка шрифта для RegistrButton
            ExitButton.Font = DataClass.fontButton;// Настройка шрифта для ExitButton
            SeePassword1CB.Font = DataClass.fontBasic2Label;// Настройка шрифта для SeePassword1CB
            SeePassword2CB.Font = DataClass.fontBasic2Label;// Настройка шрифта для SeePassword2CB
            ConfirmLabel.Font = DataClass.fontBasic1Label;// Настройка шрифта для ConfirmLabel
            ConfirmPasswordTB.Font = DataClass.fontBasic1TB;// Настройка шрифта для ConfirmPasswordTB
            
            MessageLabel.Font = DataClass.fontBasic2Label;// Настройка шрифта для MessageLabel

            // Цвет кнопок
            ConfirmButton.BackColor = DataClass.colorButton;
            RegistrButton.BackColor = DataClass.colorButton;
            ExitButton.BackColor = DataClass.colorButton;

            // Символ для пароля
            PasswordTB.PasswordChar = DataClass.charPass;
            ConfirmPasswordTB.PasswordChar = DataClass.charPass;

            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += timer_Tick;
        }

        private void ConfirmButton_MouseEnter(object sender, EventArgs e)// При наведении курсора на кнопку, сменить цвет фона
        {
            ConfirmButton.BackColor = DataClass.colorButtonEnterMouse;
        }

        private void ConfirmButton_MouseLeave(object sender, EventArgs e)// При покидании курсора видимой области кнопки, сменить цвет фона
        {
            ConfirmButton.BackColor = DataClass.colorButton;
        }

        private void RegistrButton_MouseEnter(object sender, EventArgs e)// При наведении курсора на кнопку, сменить цвет фона
        {
            RegistrButton.BackColor = DataClass.colorButtonEnterMouse;
        }

        private void RegistrButton_MouseLeave(object sender, EventArgs e)// При покидании курсора видимой области кнопки, сменить цвет фона
        {
            RegistrButton.BackColor = DataClass.colorButton;
        }

        private void SeePassword1CB_CheckedChanged(object sender, EventArgs e)
        {
            if(SeePassword1CB.Checked)
            {
                PasswordTB.UseSystemPasswordChar = true;
            }
            else
            {
                PasswordTB.UseSystemPasswordChar = false;
            }
        }

        private void SeePassword2CB_CheckedChanged(object sender, EventArgs e)
        {
            if (SeePassword2CB.Checked)
            {
                ConfirmPasswordTB.UseSystemPasswordChar = true;
            }
            else
            {
                ConfirmPasswordTB.UseSystemPasswordChar = false;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (LoginTB.Text.Length < 4)
            {
                MessageLabel.Text = "Минимальная длина логина - 4 символа.\nМаксимальная - 16 символов.";
                MessageLabel.Visible = true;
                ConfirmButton.Enabled = false;
                timer.Enabled = true;
                return;
            }

            if (PasswordTB.Text.Length < 8)
            {
                MessageLabel.Text = "Минимальная длина пароля - 8 символа.\nМаксимальная - 16 символов.";
                MessageLabel.Visible = true;
                ConfirmButton.Enabled = false;
                timer.Enabled = true;
                return;
            }

            if (DataClass.work.GetUserIDByLogin(LoginTB.Text) >= 0)
            {
                MessageLabel.Text = "Данный логин уже занят.\nПопробуйте другой.";
                MessageLabel.Visible = true;
                ConfirmButton.Enabled = false;
                timer.Enabled = true;
                return;
            }

            timer.Enabled = false;
            MessageLabel.Text = "Логин [ "+LoginTB.Text+" ]\nможно использовать.";
            MessageLabel.Visible = true;
            ConfirmButton.Enabled = false;
            LoginTB.Enabled = false;
            PasswordTB.Enabled = false;

            this.Height = 655;
            this.Location = new Point(this.Location.X, this.Location.Y - 90);
            ConfirmPanel.Visible = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MessageLabel.Visible = false;
            ConfirmButton.Enabled = true;
            timer.Enabled = false;
        }

        private void RegistrButton_Click(object sender, EventArgs e)
        {
            if (PasswordTB.Text != ConfirmPasswordTB.Text)
            {
                ConfirmPasswordTB.Text = "";
                PasswordTB.Text = "";
                ConfirmButton.Enabled = true;
                LoginTB.Enabled = true;
                PasswordTB.Enabled = true;
                SeePassword2CB.Checked = false;
                ConfirmPanel.Visible = false;


                MessageLabel.Text = "Пароли не совпадают!\nПопробуйте снова.";
                timer.Enabled = true;

                this.Height = 475;
                this.Location = new Point(this.Location.X, this.Location.Y + 90);

                return;
            }

            

            if (DataClass.work.Registr(LoginTB.Text, PasswordTB.Text) == 0)
            {
                MessageBox.Show("Учетная запись успешно зарегистрированна!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Неполадки с соединением!");
                this.Close();
            }
        }

        private void LoginTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                if (e.KeyChar == 13)
                {
                    e.Handled = true;
                    ConfirmButton_Click(null, null);
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void PasswordTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                if (e.KeyChar == 13)
                {
                    e.Handled = true;
                    ConfirmButton_Click(null, null);
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ConfirmPasswordTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                if (e.KeyChar == 13)
                {
                    e.Handled = true;
                    RegistrButton_Click(null, null);
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.BackColor = DataClass.colorButtonEnterMouse;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.BackColor = DataClass.colorButton;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
