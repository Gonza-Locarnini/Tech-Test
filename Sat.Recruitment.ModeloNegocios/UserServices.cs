using Sat.Recruitment.Db.Extensions;
using Sat.Recruitment.Db.Models;
using Sat.Recruitment.Db.Models.Enums;
using Sat.Recruitment.Db.Repositories;
using System.Collections.Generic;
using System;

namespace Sat.Recruitment.ModeloNegocios
{
    public class UserServices : IUserServices
    {
        public Result Create(User user)
        {
            var ur = new UserRepository();

            user.Money = AdaptPrice(user.Money, user.UserType);

            if (!ur.Exists(user))
            {
                try
                {
                    user.HasNullOrEmpties();
                    user.Email = user.Email.NormalizeEmail();
                    ur.Insert(user);
                    return new Result(true, Literals.Users.USER_CREATED);
                }
                catch
                {
                    return new Result(Literals.Users.USER_ERROR_INSERT, eErrorTypes.User_Insert);
                }
            }
            else
                return new Result(Literals.Users.USER_DUPLICATED, eErrorTypes.User_Duplicated);
        }

        public Result Delete(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
                return new Result(Literals.Users.EMAIL_IMPUT_EMPTY, eErrorTypes.User_SomeInputEmptyOrIncorrect);

            var ur = new UserRepository();
            var u = ur.Get(user.Email);
            if(u != null)
            {
                ur.Delete(u);
                return new Result(true, Literals.Users.USER_DELETED);
            }
            return new Result(Literals.Users.USER_DOESNT_EXIST, eErrorTypes.User_DoesntExist);
        }

        public List<User> Get() => 
            new UserRepository().Get();

        public User Get(string email) => 
            new UserRepository().Get(email);

        public decimal AdaptPrice(decimal money, eUserType userType)
        {
            IPriceAdapter priceAdapter;
            switch (userType)
            {
                case eUserType.Normal:
                    priceAdapter = new NormalUser();
                    break;
                case eUserType.SuperUser:
                    priceAdapter = new SuperUser();
                    break;
                case eUserType.Premium:
                    priceAdapter = new PremiumUser();
                    break;
                default:
                    throw new ArgumentException($"Invalid user type: {userType}");
            }
            PriceCalculator priceCalculator = new PriceCalculator(priceAdapter);
            return priceCalculator.Calculate(money);
        }
    }
}
