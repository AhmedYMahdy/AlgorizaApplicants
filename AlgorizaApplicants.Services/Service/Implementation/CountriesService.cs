using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using AlgorizaApplicants.Services.Service.Abstraction;
using Microsoft.Extensions.Configuration;

namespace AlgorizaApplicants.Services.Service.Implementation
{
    public class CountriesService : ICountriesService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public CountriesService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> ValidateCountry(string country)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var url = $"{_configuration["CountriesApiUrl"]}{country}?fullText=true";
            var httpResponseMessage = await httpClient.GetAsync(url);

            return httpResponseMessage.StatusCode == HttpStatusCode.OK;
        }
    }
}
