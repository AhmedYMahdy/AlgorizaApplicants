using AlgorizaApplicants.DAL.DTOs;
using AlgorizaApplicants.DAL.DTOs.Shared;
using AlgorizaApplicants.DAL.Entity;

namespace AlgorizaApplicants.Services.Service.Abstraction;

public interface IApplicantsService
{
    Task<bool> AddApplicant(ApplicantDTO applicantDto);
    Task<bool> UpdateRole(ApplicantDetailsDTO applicantDTO);
    Task<ApplicantDetailsDTO> GetById(long id);
    Task<PaginationObject<ApplicantDetailsDTO>> GetAll();
    Task<(bool, string)> Remove(long id);
}