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

            var userName = App.Current.Properties.ContainsKey("Name") ? App.Current.Properties.ContainsKey("Name").ToString() : "";
            var userWeight = App.Current.Properties.ContainsKey("Weight") ? App.Current.Properties.ContainsKey("Weight").ToString() : "";
            var userHeight = App.Current.Properties.ContainsKey("Height") ? App.Current.Properties.ContainsKey("Height").ToString() : "";
            var userAge = App.Current.Properties.ContainsKey("Age") ? App.Current.Properties.ContainsKey("Age").ToString() : "";
            var userGender = App.Current.Properties.ContainsKey("Gender") ? App.Current.Properties.ContainsKey("Gender").ToString() : "";
            var userAim = App.Current.Properties.ContainsKey("Aim") ? App.Current.Properties.ContainsKey("Aim").ToString() : "";

            MainPage = new NavigationPage(new LoginPage(userName, userWeight, userHeight, userAge, userGender, userAim));
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
