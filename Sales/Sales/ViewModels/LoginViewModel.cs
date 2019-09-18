namespace Sales.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using Sales.Common.Models;
    using Sales.Helpers;
    using Sales.Services;
    using Sales.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel: BaseViewModel
    {

        #region Attributes
        private ApiService apiService;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.Email = "christiangildesarrollo@outlook.com";
            this.Password = "America1927?";
            this.IsRemembered = true;
            apiService = new ApiService();
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }

        private async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
             await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
        #endregion

        #region Methods
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                        Lenguages.Error,
                        Lenguages.EmailValidation,
                        Lenguages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                        Lenguages.Error,
                        Lenguages.PasswordValidation,
                        Lenguages.Accept);
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert
                    (
                        Lenguages.Error,
                        connection.Message,
                        Lenguages.Accept
                    );
                return;
            }
            var token = await this.apiService.GetToken("https://salesapis.azurewebsites.net",this.Email,this.Password);

            if (token == null || string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert
                    (
                        Lenguages.Error,
                        Lenguages.SomethingWrong,
                        Lenguages.Accept
                    );
                return;
            }

            Settings.TokenType = token.TokenType;
            Settings.AccessToken = token.AccessToken;
            Settings.IsRemembered = this.IsRemembered;

            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlUsersController"].ToString();
            var response = await this.apiService.GetUser("https://salesapis.azurewebsites.net", prefix, $"{controller}/GetUser", this.Email, token.TokenType, token.AccessToken);
            if (response.IsSuccess)
            {
                var userASP = (MyUserASP)response.Result;
                MainViewModel.GetInstance().UserASP = userASP;
                Settings.UserASP = JsonConvert.SerializeObject(userASP);
            }

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            Application.Current.MainPage = new MasterPage();
            this.IsRunning = false;
            this.IsEnabled = true;
        }
        #endregion
    }
}
