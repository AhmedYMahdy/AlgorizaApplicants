using AlgorizaApplicants.DAL.Entity;

namespace AlgorizaApplicants.DAL.RepositoryAbstraction;

public interface IApplicantsRepository
{
    Task<Applicant> AddAsync(Applicant entity);
    void Remove(long id);
    Task<Applicant> UpdateAsync(Applicant entity);
    Task<IEnumerable<Applicant>> GetAllAsync();
    Task<Applicant> GetByIdAsync(long id);
    Task<int> SaveChangesAsync();
}