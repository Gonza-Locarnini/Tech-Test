using Sat.Recruitment.Db.Models;
using Sat.Recruitment.Api.ViewModel;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Services
{
    public interface IUserServices
    {
        Result Create(UserViewModel vmUser);

        Result Delete(UserViewModel vmUser);

        List<User> Get();
        User Get(string email);
    }
}
