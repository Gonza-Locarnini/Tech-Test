using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Db.Models;
using Sat.Recruitment.Db.Models.Enums;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.ViewModel;
using Xunit;

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
            Result r;
            var testCase = new UserViewModel
            {
                email = "mike@gmail.com",
                name = "Mike",
                address = "Av. Juan G",
                phone = "+349 1122354215",
                userType = eUserType.Normal,
                money = 124
            };

            var u = _usersController.GetByEmail(testCase.email);
            if (u != null && u.GetType() == typeof(User))
            {
                r = _usersController.Delete(testCase);
                Assert.True(r.IsSuccess);
            }

            r = _usersController.CreateUser(testCase);

            Assert.True(r.IsSuccess);
        }

        [Fact]
        public void TestGetByEmail()
        {
            Result r;
            var testCase = new UserViewModel
            {
                email = "mike@gmail.com"
            };

            var u = _usersController.GetByEmail(testCase.email);
            Assert.IsType<User>(u);
        }
    }
}
