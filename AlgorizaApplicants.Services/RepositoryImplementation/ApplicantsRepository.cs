using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorizaApplicants.DAL.DbContext;
using AlgorizaApplicants.DAL.Entity;
using AlgorizaApplicants.DAL.RepositoryAbstraction;
using Microsoft.EntityFrameworkCore;

namespace AlgorizaApplicants.Services.RepositoryImplementation
{
    public class ApplicantsRepository : IApplicantsRepository
    {
        private DbSet<Applicant> _dbSet;
        private AlgorizaContext _context;

        public ApplicantsRepository(AlgorizaContext dbContext)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<Applicant>();
        }
        public async Task<Applicant> AddAsync(Applicant entity)
        {
            try
            {
                var result = await _dbSet.AddAsync(entity);
                return result.Entity;
            }
            catch (Exception e)
            {
                throw  new Exception(e.Message);

            }
        }
        public void Remove(long id)
        {
            var exist = _dbSet.Find(id);

            if (exist == null)
                throw new Exception("Entity not found");

            _dbSet.Remove(exist);
        }
        public async Task<Applicant> UpdateAsync(Applicant entity)
        {
            try
            {
                var updatedEntity = _dbSet.Update(entity); 
                updatedEntity.State = EntityState.Modified;
                return updatedEntity.Entity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<IEnumerable<Applicant>> GetAllAsync()
        {
            return _dbSet.AsEnumerable();
        }
        public async Task<Applicant> GetByIdAsync(long id)
        {
            return await _dbSet.Where(a=>a.Id==id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
