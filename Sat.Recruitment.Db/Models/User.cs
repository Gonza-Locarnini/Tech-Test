using Sat.Recruitment.Db.Models.Enums;

namespace Sat.Recruitment.Db.Models
{
    public class User : DbModels
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public eUserType UserType { get; set; }
        public decimal Money { get; set; }
    }
}
