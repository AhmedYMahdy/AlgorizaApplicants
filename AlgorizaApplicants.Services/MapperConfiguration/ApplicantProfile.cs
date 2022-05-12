using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorizaApplicants.DAL.DTOs;
using AlgorizaApplicants.DAL.Entity;

namespace AlgorizaApplicants.Services.MapperConfiguration
{
    public partial class MapperConfig
    {
        public void ApplicantProfile ()
        {
            CreateMap<ApplicantDTO, Applicant>().ReverseMap();
            CreateMap<Applicant, ApplicantDetailsDTO>().ReverseMap();



        }
    }
}
