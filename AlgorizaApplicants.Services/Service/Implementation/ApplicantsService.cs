using System.Data.Entity;
using AlgorizaApplicants.DAL.DTOs;
using AlgorizaApplicants.DAL.DTOs.Shared;
using AlgorizaApplicants.DAL.Entity;
using AlgorizaApplicants.DAL.Helpers;
using AlgorizaApplicants.DAL.RepositoryAbstraction;
using AlgorizaApplicants.Services.Service.Abstraction;
using AutoMapper;

namespace AlgorizaApplicants.Services.Service.Implementation
{
    public class ApplicantsService : IApplicantsService
    {
        private readonly IApplicantsRepository _applicantRepository; 
        private readonly IMapper _mapper; 
        private readonly IUnitOfWork _uow;
        public ApplicantsService(IApplicantsRepository applicantRepository, IMapper mapper, IUnitOfWork uow)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
            _uow = uow;
        }


        public override async Task<bool> Add(ApplicantDTO applicantDto)
        {
            try
            {
                var applicantEntity = _mapper.Map<Applicant>(applicantDto);
                await _applicantRepository.AddAsync(applicantEntity);
                var result = await _uow.SaveChangeAsync();
                //var result = await _applicantRepository.SaveChangesAsync(); 
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override async Task<bool> Update(ApplicantDetailsDTO applicantDTO)
        {
            try
            {
                var entityExist = await _applicantRepository.GetByIdAsync(applicantDTO.Id);
                if (entityExist == null)
                    return false;

                var applicantEntity = _mapper.Map<Applicant>(applicantDTO);
                applicantEntity.ModificationDate = DateTime.UtcNow;
                applicantEntity.CreationDate = entityExist.CreationDate;
                await _applicantRepository.UpdateAsync(applicantEntity);
                var result = await _uow.SaveChangeAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override async Task<ApplicantDetailsDTO> GetById(long id)
        {
            try
            {
                var applicantEntity = await _applicantRepository.GetByIdAsync(id);
                if (applicantEntity == null)
                    return null;
                return _mapper.Map<ApplicantDetailsDTO>(applicantEntity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override async Task<PaginationObject<ApplicantDetailsDTO>> GetAll()
        {
            try
            {
                var applicantList = await _applicantRepository.GetAllAsync();
                if (applicantList == null)
                    return null;
                var applicants = _mapper.Map<List<ApplicantDetailsDTO>>(applicantList.OrderBy(a => a.CreationDate));
                return new PaginationObject<ApplicantDetailsDTO>(applicants, applicants.Count);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override async Task<bool> Remove(long id)
        {
            try
            {
               _applicantRepository.Remove(id);
                var result = await _uow.SaveChangeAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

