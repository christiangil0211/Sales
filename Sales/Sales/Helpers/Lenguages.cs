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
    }
}
