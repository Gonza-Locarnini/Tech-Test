using Sat.Recruitment.Db.Models;
using System;

namespace Sat.Recruitment.Api.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizeEmail(this string obj)
        {
            obj = obj.Trim();
            if (obj.EndsWith(".") || !IsValidEmail(obj))
                throw new Exception(Literals.Users.EMAIL_IMPUT_ERROR);
            else
            {
                var spl = obj.Split('@', StringSplitOptions.RemoveEmptyEntries);
                spl[0] = spl[0].Replace(".", "");
                obj = String.Join("@", spl[0], spl[1]);
            }
            return obj;
        }

        public static bool IsValidEmail(this string obj) {
            try
            {
                var addr = new System.Net.Mail.MailAddress(obj);
                return addr.Address == obj;
            }
            catch
            {
                return false;
            }
        }
    }
}
