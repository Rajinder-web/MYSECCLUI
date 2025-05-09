using MYSECCLUI.Model;
using MYSECCLUI.Services;
using System.Net.Http.Json;

namespace MYSECCLUI.Services
{
    public class PortfolioClientService: IPortfolioClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PortfolioClientService> _logger;

        public PortfolioClientService(HttpClient httpClient, ILogger<PortfolioClientService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<AggregatedPortfolioViewModel?> GetAggregatedPortfolioSummaryAsync()
        {
            try
            {
                // The endpoint defined in P1Investment.Api's PortfolioController
                var response = await _httpClient.GetAsync("api/portfolio/aggregated-summary");

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength == 0)
                    {
                        _logger.LogWarning("API returned success but with empty content.");
                        return null;
                    }
                    return await response.Content.ReadFromJsonAsync<AggregatedPortfolioViewModel>();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Failed to fetch portfolio summary. Status: {StatusCode}, Content: {ErrorContent}",
                                     response.StatusCode, errorContent);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while fetching portfolio summary.");
                return null;
            }
        }
    }
}
