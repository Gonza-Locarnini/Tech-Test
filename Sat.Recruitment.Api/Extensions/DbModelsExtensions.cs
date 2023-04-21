using Sat.Recruitment.Db.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sat.Recruitment.Api.Extensions
{
    public static class DbModelsExtensions
    {
        public static void Parse<T>(this T obj, string sObject) where T : DbModels
        {
            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            int idx = 0;
            var splObj = sObject.Split(',');
            foreach (PropertyInfo prop in props)
            {
                var t = prop.GetType();
                prop.SetValue(obj, Convert.ChangeType(splObj[idx], t));
                idx++;
            }
        }
    }
}
