using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorizaApplicants.DAL.DbContext;

namespace AlgorizaApplicants.DAL.Helpers
{
    public class UnitOfWork :  IUnitOfWork
    {
        private  AlgorizaContext _context { get; }

        public UnitOfWork(AlgorizaContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<int> SaveChangeAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}
