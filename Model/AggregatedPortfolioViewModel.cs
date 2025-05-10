﻿namespace MYSECCLUI.Model
{
    public class AggregatedPortfolioViewModel
    {
        public string AccountType { get; set; } = string.Empty;
        public double PortfolioAllAccountsTotal { get; set; }
        public int TotalAccounts { get; set; }
        public decimal PortfolioTotalValue { get; set; }
        public List<string> FetchedPortfolioIds { get; set; } = new List<string>();
    }
}
