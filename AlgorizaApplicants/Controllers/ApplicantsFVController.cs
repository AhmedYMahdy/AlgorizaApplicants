using AlgorizaApplicants.DAL.DTOs;
using AlgorizaApplicants.DAL.DTOs.Shared;
using AlgorizaApplicants.Services.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace AlgorizaApplicants.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    public class ApplicantsFVController : Controller
    {
        private readonly IApplicantsService _applicantsService;
        public ApplicantsFVController(IApplicantsService applicantsService)
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
    }
}
