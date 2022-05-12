using AlgorizaApplicants.DAL.Entity;

namespace AlgorizaApplicants.DAL.RepositoryAbstraction;

public interface IApplicantsRepository
{
    Task<Applicant> AddAsync(Applicant entity);
    void Delete(long id);
    Task<Applicant> UpdateAsync(Applicant entity);
    Task<IQueryable<Applicant>> GetAllAsync();
    Task<Applicant> GetById(long id);
}