using Sat.Recruitment.Db.Models;
using Sat.Recruitment.Db.Models.Enums;
using Sat.Recruitment.Api.ViewModel;
using System;

namespace Sat.Recruitment.Api.Extensions
{
    public static class UserExtensions
    {
        public static Result Convert(this UserViewModel obj, out User sObject){
            try
            {
                obj.HasNullOrEmpties();

                sObject = new User
                {
                    Name = obj.name,
                    Email = obj.email.NormalizeEmail(),
                    Address = obj.address,
                    Phone = obj.phone,
                    UserType = obj.userType,
                    Money = obj.money
                };
                return new Result(true);
            }
            catch (Exception ex){
                sObject = null;
                return new Result(ex.Message, eErrorTypes.User_Conversion);
            }
        }

        public static void HasNullOrEmpties(this UserViewModel obj)
        {
            var errors = "";
            if (string.IsNullOrEmpty(obj.name))
                errors = Literals.Users.NAME_IMPUT_EMPTY;
            if (string.IsNullOrEmpty(obj.email))
                errors += Literals.Users.EMAIL_IMPUT_EMPTY;
            if (string.IsNullOrEmpty(obj.address))
                errors += Literals.Users.ADDRESS_IMPUT_EMPTY;
            if (string.IsNullOrEmpty(obj.phone))
                errors += Literals.Users.PHONE_IMPUT_EMPTY;

            if(errors != "")
                throw new Exception(errors);
        }
    }
}
