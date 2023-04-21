using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Extensions;
using Sat.Recruitment.Db.Models;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.ViewModel;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public List<User> Get() =>
            _userServices.Get();

        [HttpGet]
        [Route("{email}")]
        public User GetByEmail(string email) =>
            _userServices.Get(email);

        [HttpPost]
        [Route("create-user")]
        public Result CreateUser(UserViewModel user) =>
            _userServices.Create(user);

        [HttpPost]
        [Route("delete-user")]
        public Result Delete(UserViewModel user) =>
            _userServices.Delete(user);


    }
}
