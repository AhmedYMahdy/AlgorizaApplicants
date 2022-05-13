using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AlgorizaApplicants.DAL.DTOs
{
    public class ApplicantDTO
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool? Hired { get; set; } = false;
    }

    public class ApplicantValidator : AbstractValidator<ApplicantDTO>
    {
        public ApplicantValidator()
        {
            RuleFor(a => a.Name).NotNull().NotEmpty().MinimumLength(5);
            RuleFor(a => a.FamilyName).NotNull().NotEmpty().MinimumLength(5);
            RuleFor(a => a.Address).NotNull().NotEmpty().MinimumLength(10);
            RuleFor(a => a.CountryOfOrigin).NotNull().NotEmpty();
            RuleFor(a => a.EmailAddress).NotNull().NotEmpty().EmailAddress();
            RuleFor(a => a.Age).NotNull().NotEmpty().ExclusiveBetween(19, 61);
        }
    }

}
