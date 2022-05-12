namespace AlgorizaApplicants.Services.Service.Abstraction;

public interface ICountriesService
{
    Task<bool> ValidateCountry(string country);
}