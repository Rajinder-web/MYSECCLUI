using MYSECCLUI.Model;

namespace MYSECCLUI.Services
{
    public interface IPortfolioClientService
    {
        Task<AggregatedPortfolioViewModel?> GetAggregatedPortfolioSummaryAsync();
    }
}
