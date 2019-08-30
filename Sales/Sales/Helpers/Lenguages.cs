namespace Sales.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;
    public class Lenguages
    {
        static Lenguages()
        {
            var ci = DependencyService.Get<ILocallize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocallize>().SetLocale(ci);
        }
        public static string Accept
        {
            get { return Resource.Accept; }
        }
        public static string Error
        {
            get { return Resource.Error; }
        }
        public static string NoInternet
        {
            get { return Resource.NoInternet; }
        }
        public static string Products
        {
            get { return Resource.Products; }
        }
        public static string TumOnInternet
        {
            get { return Resource.TumOnInternet; }
        }
        public static string AddProduct
        {
            get { return Resource.AddProduct; }
        }
        public static string Description
        {
            get { return Resource.Description; }
        }
        public static string DescriptionPlaceholder
        {
            get { return Resource.DescriptionPlaceholder; }
        }
        public static string Price
        {
            get { return Resource.Price; }
        }
        public static string PreciPlaceholder
        {
            get { return Resource.PreciPlaceholder; }
        }
        public static string Remarks
        {
            get { return Resource.Remarks; }
        }
        public static string Save
        {
            get { return Resource.Save; }
        }
        public static string ChangeImage
        {
            get { return Resource.ChangeImage; }
        }
        public static string DescriptionError
        {
            get { return Resource.DescriptionError; }
        }
        public static string PriceError
        {
            get { return Resource.PriceError; }
        }
        public static string ImageSource
        {
            get { return Resource.ImageSource; }
        }
        public static string FromGallery
        {
            get { return Resource.FromGallery; }
        }
        public static string NewPicture
        {
            get { return Resource.NewPicture; }
        }
        public static string Cancel
        {
            get { return Resource.Cancel; }
        }
        public static string Edit
        {
            get { return Resource.Edit; }
        }
        public static string Delete
        {
            get { return Resource.Delete; }
        }
        public static string DeleteConfirmation
        {
            get { return Resource.DeleteConfirmation; }
        }
        public static string Yes
        {
            get { return Resource.Yes; }
        }
        public static string No
        {
            get { return Resource.No; }
        }
        public static string Confirm
        {
            get { return Resource.Confirm; }
        }
        public static string EditProduct
        {
            get { return Resource.EditProduct; }
        }
        public static string IsAvailable
        {
            get { return Resource.IsAvailable; }
        }
        public static string Search
        {
            get { return Resource.Search; }
        }
        public static string Login
        {
            get { return Resource.Login; }
        }
        public static string Email
        {
            get { return Resource.Email; }
        }
        public static string EmailPlaceHolder
        {
            get { return Resource.EmailPlaceHolder; }
        }
        public static string PasswordPlaceHolder
        {
            get { return Resource.PasswordPlaceHolder; }
        }
        public static string Rememberme
        {
            get { return Resource.Rememberme; }
        }
        public static string Forgot
        {
            get { return Resource.Forgot; }
        }
        public static string Register
        {
            get { return Resource.Register; }
        }
        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }
        public static string PasswordValidation
        {
            get { return Resource.PasswordValidation; }
        }
        public static string Menu
        {
            get { return Resource.Menu; }
        }
        public static string Password
        {
            get { return Resource.Password; }
        }
        public static string About
        {
            get { return Resource.About; }
        }
        public static string Setup
        {
            get { return Resource.Setup; }
        }
        public static string Exit
        {
            get { return Resource.Exit; }
        }
        public static string SomethingWrong
        {
            get { return Resource.SomethingWrong; }
        }

    }
}
