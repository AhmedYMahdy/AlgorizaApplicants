using System.Net;
using AlgorizaApplicants.API.Helpers;
using AlgorizaApplicants.DAL.DTOs.Shared;
using AlgorizaApplicants.Services.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace AlgorizaApplicants.API.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : BaseController
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet("Validate/{country}")]
        [ProducesResponseType(typeof(GlobalResponse<bool>), 200)]
        public async Task<IActionResult> Create(string country)
        {
            var result = await _countriesService.ValidateCountry(country);
            if (!result)
                return Error("Sorry!! This Country Doesn't Exist", (int)HttpStatusCode.NotFound);
            return Success();
        }
    }
}
