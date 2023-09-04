using System;
using System.Reflection;
using System.Runtime.InteropServices;
using WillWin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace WillWin
{
    public partial class App : Application
    {
        private static DataBase DB;
        public static DataBase Db
        {
            get
            {
                if (DB == null)
                    DB = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DB.sqlite3"));
                return DB;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
