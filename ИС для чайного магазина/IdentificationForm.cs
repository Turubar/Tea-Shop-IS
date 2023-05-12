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
    public partial class IdentificationForm : Form
    {
        public IdentificationForm()
        {
            InitializeComponent();
        }

        Timer timer;

        private void IdentificationForm_Load(object sender, EventArgs e)
        {
            this.Font = DataClass.fontForm;// Настройка шрифта для IdentificationForm
            EnterLabel.Font = DataClass.fontMainLabel;// Настройка шрифта для EnterLabel
            LoginLabel.Font = DataClass.fontBasic1Label;// Настройка шрифта для LoginLabel
            PasswordLabel.Font = DataClass.fontBasic1Label;// Настройка шрифта для PasswordLabel
            ErrorLabel.Font = DataClass.fontBasic2Label;// Настройка шрифта для ErrorLabel
            LoginTB.Font = DataClass.fontBasic1TB;// Настройка шрифта для LoginTB
            PasswordTB.Font = DataClass.fontBasic1TB;// Настройка шрифта для PasswordTB
            AccountLabel.Font = DataClass.fontBasic2Label;// Настройка шрифта для AccountLabel
            AccountLabel.ForeColor = DataClass.colorButton;
            EnterButton.Font = DataClass.fontButton;// Настройка шрифта для EnterButton
            RegistrButton.Font = DataClass.fontButton;// Настройка шрифта для RegistrButton
            ExitButton.Font = DataClass.fontButton;// Настройка шрифта для ExitButton
            this.CenterToParent();// Переместить IdentificationForm в центр родителя

            // Цвет кнопок
            EnterButton.BackColor = DataClass.colorButton;
            RegistrButton.BackColor = DataClass.colorButton;
            ExitButton.BackColor = DataClass.colorButton;

            // Символ для пароля
            PasswordTB.PasswordChar = DataClass.charPass;

            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += timer_Tick;
        }

        private void EnterButton_MouseEnter(object sender, EventArgs e)// При наведении курсора на кнопку, сменить цвет фона
        {
            EnterButton.BackColor = DataClass.colorButtonEnterMouse;
        }

        private void EnterButton_MouseLeave(object sender, EventArgs e)// При покидании курсора видимой области кнопки, сменить цвет фона
        {
            EnterButton.BackColor = DataClass.colorButton;
        }

        private void RegistrButton_MouseEnter(object sender, EventArgs e)// При наведении курсора на кнопку, сменить цвет фона
        {
            RegistrButton.BackColor = DataClass.colorButtonEnterMouse;
        }

        private void RegistrButton_MouseLeave(object sender, EventArgs e)// При покидании курсора видимой области кнопки, сменить цвет фона
        {
            RegistrButton.BackColor = DataClass.colorButton;
        }

        private void EnterButton_Click(object sender, EventArgs e)// Обработчик события нажатия на кнопку EnterButton
        {
            if (LoginTB.Text == "" || PasswordTB.Text == "")
            {
                ErrorLabel.Visible = true;
                PasswordTB.Text = "";
                ErrorLabel.Text = "Поле логина или пароля не заполнено.";

                timer.Enabled = true;
                return;
            }

            DataClass.userID = DataClass.work.GetID(LoginTB.Text, PasswordTB.Text);

            if (DataClass.userID <= -1)
            {
                ErrorLabel.Visible = true;
                PasswordTB.Text = "";
                ErrorLabel.Text = "Неверный логин или пароль.\nПроверьте правильность введенных данных.";

                timer.Enabled = true;
                return;
            }

            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            timer.Enabled = false;
        }


        private void RegistrButton_Click(object sender, EventArgs e)// Обработчик события нажатия на кнопку RegistrButton
        {
            this.Hide();
            Form RF = new RegistrationForm();
            RF.ShowDialog();
            this.Close();
        }

        private void LoginTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                if (e.KeyChar == 13)
                {
                    e.Handled = true;
                    EnterButton_Click(null, null);
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
                    EnterButton_Click(null, null);
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
