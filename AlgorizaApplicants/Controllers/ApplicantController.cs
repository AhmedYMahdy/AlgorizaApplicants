﻿using System.Net;
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
    public class ApplicantController :BaseController
    {
        private readonly IApplicantsService _applicantsService;

        public ApplicantController(IApplicantsService applicantsService)
        {
            _applicantsService = applicantsService;
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(GlobalResponse<bool>), 200)]
        public async Task<IActionResult> Create([FromBody] ApplicantDTO applicantDto)
        {
            var result = await _applicantsService.AddApplicant(applicantDto);
            if (!result)
                return Error("Error in Adding Applicant", (int)HttpStatusCode.BadRequest);
            return Success();
        }

        [HttpPost("Update")]
        [ProducesResponseType(typeof(GlobalResponse<bool>), 200)]
        public async Task<IActionResult> Update([FromBody] ApplicantDetailsDTO applicantDto)
        {
            var result = await _applicantsService.UpdateRole(applicantDto);
            if (!result)
                return Error("Error in Updating Applicant", (int)HttpStatusCode.BadRequest);
            return Success();
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(GlobalResponse<ApplicantDetailsDTO>), 200)]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _applicantsService.GetById(id);
            if (result==null)
                return Error("Can't Find This Applicant", (int)HttpStatusCode.NotFound);
            return Success(result);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GlobalResponse<PaginationObject<ApplicantDetailsDTO>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _applicantsService.GetAll();
            if (result == null)
                return Error("Error in getting Applicants", (int)HttpStatusCode.NotFound);
            return Success(result);
        }


        [HttpDelete("Remove/{id}")]
        [ProducesResponseType(typeof(GlobalResponse<bool>), 200)]
        public async Task<IActionResult> Remove(long id)
        {
            var result = await _applicantsService.Remove(id);
            if (!result.Item1)
                return Error("Error in removing Applicants", (int)HttpStatusCode.NotFound);
            return Success();
        }
    }
}