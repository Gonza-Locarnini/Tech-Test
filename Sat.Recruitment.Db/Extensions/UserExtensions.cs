using Sat.Recruitment.Db.Models;
using Sat.Recruitment.Db.Models.Enums;
using System;

namespace Sat.Recruitment.Db.Extensions
{
    public static class UserExtensions
    {
        public static void HasNullOrEmpties(this User obj)
        {
            var errors = "";
            if (string.IsNullOrEmpty(obj.Name))
                errors = Literals.Users.NAME_IMPUT_EMPTY;
            if (string.IsNullOrEmpty(obj.Email))
                errors += Literals.Users.EMAIL_IMPUT_EMPTY;
            if (string.IsNullOrEmpty(obj.Address))
                errors += Literals.Users.ADDRESS_IMPUT_EMPTY;
            if (string.IsNullOrEmpty(obj.Phone))
                errors += Literals.Users.PHONE_IMPUT_EMPTY;

            if(errors != "")
                throw new Exception(errors);
        }
    }
}
