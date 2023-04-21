using Sat.Recruitment.Db.Models.Enums;

namespace Sat.Recruitment.Api.ViewModel
{
    public class UserViewModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public eUserType userType { get; set; }
        public decimal money { get; set; }
    }
}
