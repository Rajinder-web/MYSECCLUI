using BlazorApp.Model;

namespace BlazorApp.Services
{
    public interface IPortfolioClientService
    {
        Task<AggregatedPortfolioViewModel?> GetAggregatedPortfolioSummaryAsync();
    }
}
