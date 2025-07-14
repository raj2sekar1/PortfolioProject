using Portfolio.DB.Entities;
using Portfolio.DB.Repositories;

namespace Portfolio.Service.Concretes;

public class TransactionService(
    IPortfolioRepository repo) : ITransactionService
{
    public void AddTransaction(int portfolioId, int assetId, EntityTransaction tx)
    {
        var p = repo.GetById(portfolioId);
        var a = p?.Assets.FirstOrDefault(a => a.Id == assetId);
        if (a != null)
        {
            a.Transactions.Add(tx);
            repo.Update(p!);
        }
    }
}
