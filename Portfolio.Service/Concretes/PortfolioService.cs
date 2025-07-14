using Portfolio.DB.Entities;
using Portfolio.DB.Repositories;

namespace Portfolio.Service.Concretes;

public class PortfolioService(
    IPortfolioRepository repo) : IPortfolioService
{
    private static int _portfolioUniqueId = 1;
    

    public IEnumerable<EntityPortfolio> GetAll() => repo.GetAll();

    public EntityPortfolio? GetById(int id) => repo.GetById(id);

    public EntityPortfolio Create(string name)
    {
        var p = new EntityPortfolio { Id = _portfolioUniqueId++, Name = name };
        repo.Add(p);
        return p;
    }
}
