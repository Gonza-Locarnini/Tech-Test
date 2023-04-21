using System;
using System.Collections.Generic;

namespace Sat.Recruitment.Db.Repositories
{
    public interface IGenericRepositories<T> : IDisposable
    {
        List<T> Get();
        bool Exists(T obj);
        bool Insert(T obj);
        bool Delete(T obj);
    }
}
