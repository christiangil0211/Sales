﻿namespace Sales.Helpers
{
    using System;

    public class PlatformCulture
    {
        public PlatformCulture(string platformCultureString)
        {
            if (string.IsNullOrEmpty(platformCultureString))
            {
                throw new ArgumentException("Expected culture identifer", "platformCultureString");
            }

            PlatformString = platformCultureString.Replace("_", "-");
            var dashIndex = PlatformString.IndexOf("-", StringComparison.Ordinal);
            if (dashIndex > 0)
            {
                var parts = PlatformString.Split('-');
                LanguageCode = parts[0];
                LocaleCode = parts[1];
            }
        }
        
        public string PlatformString { get; private set; }

        public string LanguageCode { get; private set; }

        public string LocaleCode { get; private set; }


        public override string ToString()
        {
            return PlatformString;
        }
    }
}
