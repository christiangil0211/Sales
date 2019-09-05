namespace Sales.Helpers
{
    using System;
    using System.Net.Mail;
    public static class RegexHelper
    {
        public static bool IsValidEmailAdress(string emailaddress)
        {
            try
            {
                var email = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
                //32217523
            }
        }

    }
}
