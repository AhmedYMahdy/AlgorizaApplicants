using AlgorizaApplicants.DAL.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AlgorizaApplicants.API.Helpers
{
    public class BaseController : ControllerBase
    {
        protected OkObjectResult Success(object data=null)
        {
            var result = new GlobalResponse<object>().SuccessResult(data);
            return new OkObjectResult(result);
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
