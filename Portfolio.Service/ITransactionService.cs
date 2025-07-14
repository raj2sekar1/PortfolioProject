using Portfolio.DB.Entities;

namespace Portfolio.Service;

public interface ITransactionService
{
    /// <summary>
    /// Records a transaction (buy/sell) for an asset within a portfolio.
    /// </summary>
    /// <param name="portfolioId"></param>
    /// <param name="assetId"></param>
    /// <param name="tx"></param>
    void AddTransaction(int portfolioId, int assetId, EntityTransaction tx);
}
