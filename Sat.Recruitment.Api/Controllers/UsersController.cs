using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Db.Models;
using Sat.Recruitment.ModeloNegocios;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userServices.Get();
            return Ok(users);
        }

        [HttpGet("{email}")]
        public IActionResult GetByEmail(string email)
        {
            var user = _userServices.Get(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            var result = _userServices.Create(user);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] User user)
        {
            var result = _userServices.Delete(user);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


    }
}
