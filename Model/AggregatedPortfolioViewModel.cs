namespace MYSECCLUI.Model
{
    public class AggregatedPortfolioViewModel
    {
        public decimal TotalCombinedValue { get; set; }
        public Dictionary<string, decimal> ValueByAccountType { get; set; } = new Dictionary<string, decimal>();
        public List<string> FetchedPortfolioIds { get; set; } = new List<string>();
        public DateTime LastUpdated { get; set; }
    }
}
