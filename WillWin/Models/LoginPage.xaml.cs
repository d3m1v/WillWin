using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Rg.Plugins.Popup.Exceptions;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;
using Xamarin.Forms.Xaml;

namespace WillWin.Models
{
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        string genderInput = "Male";
        string aimInput = "Muscles";

        LoginViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this.viewModel = new LoginViewModel();
        }

        public LoginPage(string userName, string userWeight, string userHeight, string userAge, string userGender, string userAim)
        {
            InitializeComponent();
            BindingContext = this.viewModel = new LoginViewModel();
            viewModel.Name = userName;
            viewModel.Weight = userWeight;
            viewModel.Height = userHeight;
            viewModel.Age = userAge;
            viewModel.Gender = userGender;
            viewModel.Aim = userAim;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private async void registrationEnd(object sender, EventArgs e)
        {
            // проверка строки на перевод в целое число
            Boolean isInt(String str)
            {
                if (str == null || string.IsNullOrEmpty(str))
                {
                    return false;
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if (!Char.IsDigit(str, i))
                    {
                        return false;
                    }
                }
                return true;
            }

            // проверка строки на перевод в число с плавающей точкой
            Boolean isDouble(String str)
            {
                return Double.TryParse(str, out double d);
            }

            // инициализация имени пользователя
            if (string.IsNullOrEmpty(nameField.Text))
            {
                await DisplayAlert("Ошибка", "Отсутствует имя пользователя", "Ок");
                return;
            }
            else if (nameField.Text == "")
            {
                await DisplayAlert("Ошибка", "Отсутствует имя пользователя", "Ок");
                return;
            }
            string nameInput = nameField.Text.Trim();

            // инициализация возраста пользователя
            if (string.IsNullOrEmpty(ageField.Text))
            {
                await DisplayAlert("Ошибка", "Отсутствует возраст пользователя", "Ок");
                return;
            }
            else if (ageField.Text == "")
            {
                await DisplayAlert("Ошибка", "Отсутствует возраст пользователя", "Ок");
                return;
            }
            else if (!isInt(ageField.Text))
            {
                await DisplayAlert("Ошибка", "Отсутствует возраст пользователя", "Ок");
                return;
            }
            else if (int.Parse(ageField.Text) < 10)
            {
                await DisplayAlert("Ошибка", "Отсутствует возраст пользователя", "Ок");
                return;
            }
            string ageInput = ageField.Text.Trim();

            // инициализация роста пользователя
            if (string.IsNullOrEmpty(heightField.Text))
            {
                await DisplayAlert("Ошибка", "Отсутствует рост пользователя", "Ок");
                return;
            }
            else if (heightField.Text == "")
            {
                await DisplayAlert("Ошибка", "Отсутствует рост пользователя", "Ок");
                return;
            }
            else if (!isInt(heightField.Text))
            {
                await DisplayAlert("Ошибка", "Отсутствует рост пользователя", "Ок");
                return;
            }
            else if (int.Parse(heightField.Text) < 50)
            {
                await DisplayAlert("Ошибка", "Отсутствует рост пользователя", "Ок");
                return;
            }
            string heightInput = heightField.Text.Trim();

            // инициализация веса пользователя
            if (string.IsNullOrEmpty(weightField.Text))
            {
                await DisplayAlert("Ошибка", "Отсутствует рост пользователя", "Ок");
                return;
            }
            else if (weightField.Text == "")
            {
                await DisplayAlert("Ошибка", "Отсутствует рост пользователя", "Ок");
                return;
            }
            else if (!isDouble(weightField.Text))
            {
                await DisplayAlert("Ошибка", "Отсутствует рост пользователя", "Ок");
                return;
            }
            else if (double.Parse(weightField.Text) < 20)
            {
                await DisplayAlert("Ошибка", "Отсутствует рост пользователя", "Ок");
                return;
            }
            string weightInput = weightField.Text.Trim();

            // занесение данных о пользователе в базу данных
            LoginViewModel item = new LoginViewModel
            {
                Name = nameInput,
                Age = ageInput,
                Height = heightInput,
                Weight = weightInput,
                Gender = genderInput,
                Aim = aimInput,
            };
            App.Db.SaveItem(item);
            await Navigation.PushAsync(new MainPage());
        }

        private void rbMale(object sender, CheckedChangedEventArgs e)
        {
            genderInput = "Male";
        }
        private void rbFemale(object sender, CheckedChangedEventArgs e)
        {
            genderInput = "Female";
        }
        private void rbMuscles(object sender, CheckedChangedEventArgs e)
        {
            aimInput = "Muscles";
        }
        private void rbMaintaining(object sender, CheckedChangedEventArgs e)
        {
            aimInput = "Maintaining";
        }
        private void rbLoss(object sender, CheckedChangedEventArgs e)
        {
            aimInput = "Loss";
        }
    }
}