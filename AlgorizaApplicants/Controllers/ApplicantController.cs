using System.Net;
using AlgorizaApplicants.API.Helpers;
using AlgorizaApplicants.DAL.DTOs;
using AlgorizaApplicants.DAL.DTOs.Shared;
using AlgorizaApplicants.DAL.Entity;
using AlgorizaApplicants.DAL.Migrations;
using AlgorizaApplicants.DAL.RepositoryAbstraction;
using AlgorizaApplicants.Services.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
namespace AlgorizaApplicants.API.Controllers
{
    [Route("api/[controller]")]
    public class ApplicantController : BaseController
    {
        private readonly IApplicantsService _applicantsService;

        
        public ApplicantController(IApplicantsService applicantsService)
        {
            _applicantsService = applicantsService;
        }

        [HttpGet("applicants")]
        public IActionResult Applicants()
        {
            return View(_applicantsService.GetAll().Result.DataList);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet("Update/{id}")]
        public IActionResult Update(long id)
        {

            return View(_applicantsService.GetById(id).Result);
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ApplicantDTO applicantDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicantsService.Add(applicantDto);
                if (!result)
                    return BadRequest("Error in Adding Applicant");
                return RedirectToAction("Applicants");
            }
            return BadRequest("Error invalid parameters");

        }

        [HttpPost("Update/{id}")]
        [Swashbuckle.AspNetCore.]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ApplicantDetailsDTO applicantDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicantsService.Update(applicantDto);
                if (!result)
                    return BadRequest("Error in Updating Applicant");
                return RedirectToAction("Applicants");
            }
            return BadRequest("Error invalid parameters");
        }

        [HttpGet("Remove/{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(GlobalResponse<bool>), 200)]
        public async Task<IActionResult> Remove(long id)
        {
            var result = await _applicantsService.Remove(id);
            if (result)
                return RedirectToAction("Applicants");
            return NotFound("Error in removing Applicants");
        }

        [HttpPost("Add2")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(GlobalResponse<bool>), 200)]
        public async Task<IActionResult> Add2(ApplicantDTO applicantDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _applicantsService.Add(applicantDto);
                if (!result)
                    return Error("Error in Adding Applicant", (int)HttpStatusCode.BadRequest);
                return Success();
            }
            return Error("Error invalid parameters", (int)HttpStatusCode.UnsupportedMediaType);

        }

        [HttpPost("Update2")]
        [ProducesResponseType(typeof(GlobalResponse<bool>), 200)]
        public async Task<IActionResult> Update2(ApplicantDetailsDTO applicantDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicantsService.Update(applicantDto);
                if (!result)
                    return Error("Error in Updating Applicant", (int)HttpStatusCode.BadRequest);
                return Success();
            }
            return Error("Error invalid parameters", (int)HttpStatusCode.UnsupportedMediaType);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(GlobalResponse<ApplicantDetailsDTO>), 200)]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _applicantsService.GetById(id);
            if (result == null)
                return Error("Can't Find This Applicant", (int)HttpStatusCode.NotFound);
            return Success(result);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GlobalResponse<PaginationObject<ApplicantDetailsDTO>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _applicantsService.GetAll();
            if (result == null || result.TotalCount == 0)
                return Error("Error in getting Applicants", (int)HttpStatusCode.NotFound);
            return Success(result);
        }


        [HttpDelete("Remove2/{id}")]
        [ProducesResponseType(typeof(GlobalResponse<bool>), 200)]
        public async Task<IActionResult> Remove2(long id)
        {
            var result = await _applicantsService.Remove(id);
            if (!result)
                return Error("Error in removing Applicants", (int)HttpStatusCode.NotFound);
            return Success();
        }
    }
}
