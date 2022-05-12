using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AlgorizaApplicants.API.Controllers;
using AlgorizaApplicants.DAL.DTOs;
using AlgorizaApplicants.DAL.DTOs.Shared;
using AlgorizaApplicants.Services.Service.Abstraction;
using AutoMapper.QueryableExtensions.Impl;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace AlgorizaApplicants.UnitTest
{
    public class ApplicantsTests
    {

        private IApplicantsService _applicantService;
        private ApplicantController _controller;

        public ApplicantsTests()
        {
            _applicantService = Substitute.For<IApplicantsService>();
            _controller = new ApplicantController(_applicantService);
        }

        [Fact]
        public async Task AddApplicant_ReturnsOk()
        {
            //Arrange
            _applicantService.Add(Arg.Any<ApplicantDTO>()).Returns(true);

            //Act
            var result = await _controller.Add(new ApplicantDTO
            {
                Name = "Ahmed",
                FamilyName = "Mahdy",
                Age = 26,
                Address = "Cairo, Egypt.",
                Hired = false,
                EmailAddress = "Ahmed.ucef@gmail.com",
                CountryOfOrigin = "Egy"
            });

            //Assert
            var response = result.Should().BeOfType<ObjectResult>().Subject;
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            var details = (GlobalResponse<object>)response.Value;
            details?.IsSuccess.Should().Be(true);
        }

        [Fact]
        public async Task AddApplicant_ReturnsBadRequest()
        {
            //Arrange
            _applicantService.Add(Arg.Any<ApplicantDTO>()).Returns(false);

            //Act
            var result = await _controller.Add(new ApplicantDTO
            {
                Name = "Ah",
                FamilyName = "Ma",
                Age = 18,
                Address = "Cai,Eg.",
                Hired = false,
                EmailAddress = "Ahmed.ucef",
                CountryOfOrigin = "Egy"
            });

            //Assert
            var response = result.Should().BeOfType<ObjectResult>().Subject;
            response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            var details = (GlobalResponse<object>)response.Value;
            details?.IsSuccess.Should().Be(false);
            details?.ErrorMessage.Should().Contain("Error in Adding Applicant");
        }

        [Fact]
        public async Task UpdateApplicant_ReturnsOk()
        {
            //Arrange
            _applicantService.Update(Arg.Any<ApplicantDetailsDTO>()).Returns(true);

            //Act
            var result = await _controller.Update(new ApplicantDetailsDTO()
            {
                Id = 3,
                Name = "Ahmed2",
                FamilyName = "Mahdy2",
                Age = 25,
                Address = "New York, US.",
                Hired = false,
                EmailAddress = "Ahmed.ucef@hotmail.com",
                CountryOfOrigin = "Egypt"
            });

            //Assert
            var response = result.Should().BeOfType<ObjectResult>().Subject;
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            var details = (GlobalResponse<object>)response.Value;
            details?.IsSuccess.Should().Be(true);
        }


        [Fact]
        public async Task UpdateApplicant_ReturnsBadRequest()
        {
            //Arrange
            _applicantService.Update(Arg.Any<ApplicantDetailsDTO>()).Returns(false);

            //Act
            var result = await _controller.Update(new ApplicantDetailsDTO()
            {
                Id = 50,
                Name = "Ah",
                FamilyName = "Ma",
                Age = 18,
                Address = "Cai,Eg.",
                Hired = false,
                EmailAddress = "Ahmed.ucef",
                CountryOfOrigin = "Egy"
            });

            //Assert
            var response = result.Should().BeOfType<ObjectResult>().Subject;
            response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            var details = (GlobalResponse<object>)response.Value;
            details?.IsSuccess.Should().Be(false);
            details?.ErrorMessage.Should().Contain("Error in Updating Applicant");
        }


        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            //Arrange
            var applicants = new PaginationObject<ApplicantDetailsDTO>(new List<ApplicantDetailsDTO>(), 1, 0, 0);
            _applicantService.GetAll().Returns(applicants);

            //Act
            var result = await _controller.GetAll();

            //Assert
            var response = result.Should().BeOfType<ObjectResult>().Subject;
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            var details = (GlobalResponse<object>)response.Value;
            ((PaginationObject<ApplicantDetailsDTO>)details?.Data).TotalCount.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task GetAll_ReturnsBadRequest()
        {
            //Arrange
            _applicantService.GetAll().ReturnsNull();

            //Act
            var result = await _controller.GetAll();

            //Assert
            var response = result.Should().BeOfType<ObjectResult>().Subject;
            response.StatusCode.Should().Be(StatusCodes.Status404NotFound);
            var details = (GlobalResponse<object>)response.Value;
            ((PaginationObject<ApplicantDetailsDTO>)details?.Data).Should().BeNull();
            details?.ErrorMessage.Should().Contain("Error in getting Applicants");
        }

        [Fact]
        public async Task GetById_ReturnsOk()
        {
            //Arrange
            var applicant = new ApplicantDetailsDTO();
            _applicantService.GetById(Arg.Any<long>()).Returns(applicant);
            //Act
            var result = await _controller.GetById(3);

            //Assert
            var response = result.Should().BeOfType<ObjectResult>().Subject;
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            var details = (GlobalResponse<object>)response.Value;
            details?.IsSuccess.Should().Be(true);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound()
        {
            //Arrange
            _applicantService.GetById(Arg.Any<long>()).ReturnsNull();

            //Act
            var result = await _controller.GetById(100);

            //Assert
            var badRequest = result.Should().BeOfType<ObjectResult>().Subject;
            badRequest.StatusCode.Should().Be(StatusCodes.Status404NotFound);
            var problemDetails = (GlobalResponse<object>)badRequest.Value;
            problemDetails?.IsSuccess.Should().Be(false);
            problemDetails?.ErrorMessage.Should().Contain("Can't Find This Applicant");
        }

    }
}
