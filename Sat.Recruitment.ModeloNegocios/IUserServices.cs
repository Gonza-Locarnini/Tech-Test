using Sat.Recruitment.Db.Models;
using System.Collections.Generic;

namespace Sat.Recruitment.ModeloNegocios
{
    public interface IUserServices
    {
        Result Create(User vmUser);

        Result Delete(User vmUser);

        List<User> Get();
        User Get(string email);
    }
}
