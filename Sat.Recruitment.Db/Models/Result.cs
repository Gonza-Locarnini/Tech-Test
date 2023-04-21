using Sat.Recruitment.Db.Models.Enums;

namespace Sat.Recruitment.Db.Models
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
        public eErrorTypes ErrorType { get; set; }

        public Result(bool isSuccess, string error = "", eErrorTypes errorType = eErrorTypes.Nothing)
        {
            IsSuccess = isSuccess;
            Errors = error;
            ErrorType = errorType;
        }
        public Result(string error, eErrorTypes errorType)
        {
            IsSuccess = false;
            Errors = error;
            ErrorType = errorType;
        }
    }
}
