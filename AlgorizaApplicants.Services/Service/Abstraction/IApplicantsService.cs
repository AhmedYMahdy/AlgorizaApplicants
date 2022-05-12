using AlgorizaApplicants.DAL.DTOs;
using AlgorizaApplicants.DAL.DTOs.Shared;
using AlgorizaApplicants.DAL.Entity;

namespace AlgorizaApplicants.Services.Service.Abstraction;

public abstract class IApplicantsService
{
    public abstract Task<bool> Add(ApplicantDTO applicantDto);
    public abstract Task<bool> Update(ApplicantDetailsDTO applicantDto);
    public abstract Task<ApplicantDetailsDTO> GetById(long id);
    public abstract Task<PaginationObject<ApplicantDetailsDTO>> GetAll();
    public abstract Task<bool> Remove(long id);
}