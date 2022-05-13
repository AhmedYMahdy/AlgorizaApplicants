using AlgorizaApplicants.DAL.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AlgorizaApplicants.API.Helpers
{
    public class BaseController : Controller
    {
        protected ObjectResult Success(object data=null)
        {
            var result = new GlobalResponse<object>().SuccessResult(data);
            return new ObjectResult(result)
                {StatusCode = StatusCodes.Status200OK};
        }

        protected ObjectResult Error(string errorMessage, int statusCode)
        {
            var result = new GlobalResponse<object>().ErrorResult(errorMessage, statusCode);
            return new ObjectResult(result)
            {
                StatusCode = statusCode
            };
        }

    }
}
