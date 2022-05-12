using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorizaApplicants.DAL.DTOs
{
    public class ApplicantDTO
    {
        [MinLength(5)]
        public string Name { get; set; }
        [MinLength(5)]
        public string FamilyName { get; set; }
        [MinLength(10)]
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Range(20, 60)]
        public int Age { get; set; }
        [DefaultValue(false)]
        public bool Hired { get; set; }
    }
}
