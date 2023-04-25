using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Db.Models;
using Sat.Recruitment.Db.Models.Enums;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.ModeloNegocios;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserTesting
    {
        private readonly UsersController _usersController;
        private readonly UserServices _userServices;

        public UserTesting()
        {
            _userServices = new UserServices();
            _usersController = new UsersController(_userServices);
        }

        [Fact]
        public void TestInsertAndDelete()
        {
            var testCase = new User
            {
                Email = "mike@gmail.com",
                Name = "Mike",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = eUserType.Normal,
                Money = 124
            };

            var u = _usersController.GetByEmail(testCase.Email);
            if (u != null && u.GetType() == typeof(OkObjectResult))
            {
                var r = _usersController.Delete(testCase);
                Assert.IsType<OkObjectResult>(r);
            }

            var r2 = _usersController.Create(testCase);
            Assert.IsType<OkObjectResult>(r2);
        }

        [Fact]
        public void TestGetByEmail()
        {
            var testCase = new User
            {
                Email = "mike@gmail.com"
            };

            var u = _usersController.GetByEmail(testCase.Email);
            Assert.IsType<OkObjectResult>(u);
        }
    }
}
