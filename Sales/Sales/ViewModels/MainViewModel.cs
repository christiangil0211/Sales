namespace Sales.ViewModels
{
    using System.Collections.ObjectModel;
    using GalaSoft.MvvmLight.Command;
    using Sales.Views;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System;
    using Sales.Helpers;

    public class MainViewModel
    {
        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public EditProductViewModel EditProduct { get; set; }
        public ProductsViewModel Products { get; set; }
        public AddProductViewModel AddProduct { get; set; }
        public LoginViewModel Login { get; set; }
        public RegisterViewModel Register { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            this.LoadMenu();
            instance = this;
        }    
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }

        #endregion

        #region Command
        public ICommand AddProductCommand
        {
            get
            {
                return new RelayCommand(GoToAddProduct);
            }

        }        
        private async void GoToAddProduct()
        {
            this.AddProduct = new AddProductViewModel();
            await App.Navigator.PushAsync(new AddProductPage());
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();

            this.Menu.Add(new MenuItemViewModel

            {
                Icon = "ic_info",
                PageName = "AboutPage",
                Title = Lenguages.About,

            });
            this.Menu.Add(new MenuItemViewModel

            {
                Icon = "ic_phonelink_setup",
                PageName = "Setup",
                Title = Lenguages.Setup,

            });
            this.Menu.Add(new MenuItemViewModel

            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Lenguages.Exit,

            });
        }
        #endregion
    }
}
