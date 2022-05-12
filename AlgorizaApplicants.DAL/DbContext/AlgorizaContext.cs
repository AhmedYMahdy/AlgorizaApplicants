using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorizaApplicants.DAL.Configuration;
using AlgorizaApplicants.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace AlgorizaApplicants.DAL.DbContext
{
    public class AlgorizaContext :Microsoft.EntityFrameworkCore.DbContext
    {
        public AlgorizaContext(DbContextOptions<AlgorizaContext> options) : base(options)
        {
        }

        public virtual DbSet<Applicant> Applicants { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=Algoriza;Trusted_Connection=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicantsConfig());
        }
    }


}
