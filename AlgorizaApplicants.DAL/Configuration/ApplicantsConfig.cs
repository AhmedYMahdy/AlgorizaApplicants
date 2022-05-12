using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorizaApplicants.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgorizaApplicants.DAL.Configuration
{
    public class ApplicantsConfig : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.FamilyName).HasMaxLength(50);
            builder.Property(e => e.Address).HasMaxLength(500);
            builder.Property(e => e.CountryOfOrigin).HasMaxLength(50);
            builder.Property(e => e.Hired).HasDefaultValue(false);
            builder.Property(e => e.CreationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.ModificationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
