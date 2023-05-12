using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using System.Data.SQLite;

namespace ИС_для_чайного_магазина
{
    static class DataClass
    {
        public static Work work = new Work();

        public static PrivateFontCollection fontColl = new PrivateFontCollection();

        public static string fileName = "tea.sqlite";// Имя файла базы данных
        public static string pathDB = "../../Resources/Database/";// Путь к базе данных (без имени файла)
        public static string pathFont = "../../Resources/Fonts/Raleway-Regular.ttf";// Полный путь к файлу шрифта (с именем и расширением .ttf)

        public static SQLiteConnection connection;
        public static SQLiteCommand cmd;
        static public SQLiteDataReader reader;
        static public SQLiteDataAdapter adapter;

        public static int fontSizeForm = 8;// Размер шрифта для форм
        public static Font fontForm = work.SetFont(pathFont, fontSizeForm, fontColl);

        public static Font fontMainLabel = work.SetFont(pathFont, 25, fontColl);
        public static Font fontBasic1Label = work.SetFont(pathFont, 12, fontColl);
        public static Font fontBasic1TB = work.SetFont(pathFont, 14, fontColl);
        public static Font fontBasic2Label = work.SetFont(pathFont, 10, fontColl);
        public static Font fontButton = work.SetFont(pathFont, 16, fontColl);

        public static Color colorButton = Color.FromArgb(255, 74, 159, 244);
        public static Color colorButtonEnterMouse = Color.FromArgb(255, 53, 233, 13);
        public static Color colorButtonEnterMouse1 = Color.FromArgb(255, 253, 200, 55);
        public static Color colorBackground = Color.FromArgb(255, 90, 90, 90);

        public static int userID = -1;
        public static int userRoleID = -1;
        public static string userLogin = "";

        public static List<string> nameProductOrder = new List<string>();
        public static List<string> setProductOrder = new List<string>();
        public static List<double> priceProductOrder = new List<double>();
        public static List<double> priceDiscountProductOrder = new List<double>();

        public static string selectedTable = "";

        public static char charPass = '•';
    }
}
