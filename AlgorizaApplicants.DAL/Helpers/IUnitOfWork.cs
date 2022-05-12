namespace AlgorizaApplicants.DAL.Helpers;

public interface IUnitOfWork
{
    Task<int> SaveChangeAsync();
}