namespace Sales.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Sales.Common.Models;
    using Sales.Helpers;
    using Sales.Services;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        private bool isRefreshing;
        private ApiService apiService;
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }
        public ProductsViewModel()
        {
            apiService = new ApiService();
            this.LoadProducts();
        }
        private async void LoadProducts()
        {
            var connection = await this.apiService.CheckConnection();

            //var rul = Application.Current.Resources["UrlAPI"].ToString();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert
                    (
                        Lenguages.Error,
                        connection.Message,
                        Lenguages.Accept
                    );
                return;
            }
            this.IsRefreshing = true;
            var response = await this.apiService.GetList<Product>
                (
                    "https://salesapis.azurewebsites.net",
                    "/api",
                    "/Products"
                );
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert
                    (
                        Lenguages.Error,
                        response.Message,
                        Lenguages.Accept
                    );
                return;
            }
            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
            this.IsRefreshing = false;
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadProducts);
            }
        }
    }
}
