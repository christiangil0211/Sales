namespace Sales.Interfaces
{
    using System.Globalization;

    public interface ILocallize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}
