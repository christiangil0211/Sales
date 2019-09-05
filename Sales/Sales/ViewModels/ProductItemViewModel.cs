namespace Sales.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Sales.Common.Models;
    using Sales.Helpers;
    using Sales.Services;
    using Sales.Views;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ProductItemViewModel : Product
    {
        #region Attributes
        private ApiService apiService;
        #endregion

        #region Command
        public ICommand DeleteProductCommand
        {
            get
            {
                return new RelayCommand(DeleteProduct);
            }
        }
        public ICommand EditProductCommand 
        {
            get
            {
                return new RelayCommand(EditProduct);
            }
        }
        private async void EditProduct()
        {
            MainViewModel.GetInstance().EditProduct = new EditProductViewModel(this);
            await App.Navigator.PushAsync(new EditProductPage());
        }
        #endregion

        #region Constructor
        public ProductItemViewModel()
        {
            this.apiService = new ApiService();
        }
        #endregion

        #region Methods

        private async void DeleteProduct()
        {
            var answer = await Application.Current.MainPage.DisplayAlert(
                Lenguages.Confirm,
                Lenguages.DeleteConfirmation,
                Lenguages.Yes,
                Lenguages.No
                );
            if (!answer)
            {
                return;
            }
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert
                    (
                        Lenguages.Error,
                        connection.Message,
                        Lenguages.Accept
                    );
                return;
            }
            var response = await this.apiService.Delete
               (
                   "https://salesapis.azurewebsites.net",
                   "/api",
                   "/Products",
                    ProductId,
                    Settings.TokenType,
                    Settings.AccessToken
               );
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert
                    (
                        Lenguages.Error,
                        response.Message,
                        Lenguages.Accept
                    );
                return;
            }

            var productsViewModel = ProductsViewModel.GetInstance();
            var deletedProduct = productsViewModel.MyProducts.Where(p => p.ProductId == this.ProductId).FirstOrDefault();

            if (deletedProduct != null)
            {
                productsViewModel.MyProducts.Remove(deletedProduct);
            }
            productsViewModel.RefreshList();

            #endregion
        }
    }
}
