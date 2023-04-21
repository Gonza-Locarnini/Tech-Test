using Sat.Recruitment.Api.Extensions;
using Sat.Recruitment.Db.Models;
using Sat.Recruitment.Db.Models.Enums;
using Sat.Recruitment.Db.Repositories;
using Sat.Recruitment.Api.ViewModel;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Services
{
    public class UserServices : IUserServices
    {
        public Result Create(UserViewModel vmUser)
        {
            var ur = new UserRepository();
            User newUser;

            vmUser.money = AdaptPrice(vmUser.money, vmUser.userType);

            var r = vmUser.Convert(out newUser);

            if (r.IsSuccess)
            {
                if (!ur.Exists(newUser))
                {
                    try
                    {
                        ur.Insert(newUser);
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
            else
                return r;
        }

        public Result Delete(UserViewModel vmUser)
        {
            if (string.IsNullOrEmpty(vmUser.email))
                return new Result(Literals.Users.EMAIL_IMPUT_EMPTY, eErrorTypes.User_SomeInputEmptyOrIncorrect);

            var ur = new UserRepository();
            var u = ur.Get(vmUser.email);
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
            var gif = 0M;
            if (userType == eUserType.Normal)
            {
                if (money > 100)
                    gif = money * 0.12M;
                if (money > 10)
                    gif = money * 0.8M;
            }
            if (userType == eUserType.SuperUser)
            {
                if (money > 100)
                    gif = money * 0.20M;
            }
            if (userType == eUserType.Premium)
            {
                if (money > 100)
                    gif = money * 2;
            }
            return money + gif;
        }
    }
}
