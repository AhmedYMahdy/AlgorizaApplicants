using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace AlgorizaApplicants.DAL.DTOs.Shared
{
    public class GlobalResponse<T> : ActionResult
    {
        public GlobalResponse()
        {
            IsSuccess = false;
        }

        public bool? IsSuccess { get; set; }
        public T? Data { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        
        public GlobalResponse<T> SuccessResult(T? data)
        {
            var result = new GlobalResponse<T> { IsSuccess = true, Data = data, StatusCode = (int)HttpStatusCode.OK };
            return result;
        }
        public GlobalResponse<T> ErrorResult(string errorMessage, int statusCode)
        {
            var result = new GlobalResponse<T> { IsSuccess = false, StatusCode = statusCode, ErrorMessage = errorMessage };
            return result;
        }
    }

}
