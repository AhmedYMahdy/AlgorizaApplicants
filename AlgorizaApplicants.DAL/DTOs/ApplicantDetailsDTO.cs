using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorizaApplicants.DAL.DTOs
{
    public class ApplicantDetailsDTO: ApplicantDTO
    {
        public long Id { get; set; }
    }
}
