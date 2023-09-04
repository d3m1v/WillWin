using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WillWin.Models;

namespace WillWin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (!App.Current.Properties.TryGetValue("userName", out object name))
                firstLogin();


        }

        async void firstLogin()
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}
