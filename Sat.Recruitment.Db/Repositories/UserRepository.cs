using LiteDB;
using Sat.Recruitment.Db.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Db.Repositories
{
    public class UserRepository : IGenericRepositories<User>
    {
        private ILiteCollection<User> Db
        {
            get
            {
                return DbProvider.Db.GetCollection<User>("User");
            }
        }

        public List<User> Get()
        {
            var lst = Db.FindAll();
            if (lst != null && lst.Count() > 0)
                return lst.ToList();
            return null;
        }

        public User Get(string email)
        {
            return Db.FindOne(x => x.Email == email);
        }
        public bool Exists(User obj)
        {
            return Get(obj.Email) != null;
        }
        public bool Insert(User obj)
        {
            return Db.Insert(obj) > 0;
        }
        public bool Delete(User obj)
        {
            return Db.DeleteMany(x => x.Email == obj.Email) > 0;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
