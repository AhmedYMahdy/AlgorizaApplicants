using AutoMapper;


namespace AlgorizaApplicants.Services.MapperConfiguration
{
    public  partial class MapperConfig :Profile
    {
        public MapperConfig()
        {
            ApplicantProfile();
        }
    }
}
