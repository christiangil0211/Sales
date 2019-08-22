[assembly: Xamarin.Forms.Dependency(typeof(Sales.iOS.Implementations.Localize))]

namespace Sales.iOS.Implementations
{
    using System.Globalization;
    using System.Threading;
    using Foundation;
    using Helpers;
    using Interfaces;
    public class Localize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];

                netLanguage = iOSToDonetLanguage(pref);
            }

            System.Globalization.CultureInfo ci = null;

            try
            {
                ci = new System.Globalization.CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {

                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    ci = new System.Globalization.CultureInfo("en");

                }
                catch (CultureNotFoundException e2)
                {

                    ci = new System.Globalization.CultureInfo("en");
                }
            }

            return ci;
        }

        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
        string iOSToDonetLanguage(string iOSLanguage)
        {
            var netLanguage = iOSLanguage;

            switch (iOSLanguage)
            {
                case "ms-MY":
                case "ms-SG":
                    netLanguage = "ms";
                    break;
                case "gsw-CH":
                    netLanguage = "de-CH";
                    break;
            }
            return netLanguage;
        }

        string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            var netLanguage = platCulture.LanguageCode;

            switch (platCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT";
                    break;
                case "gws":
                    netLanguage = "de-CH";
                    break;
            }
            return netLanguage;
        }
    }
}