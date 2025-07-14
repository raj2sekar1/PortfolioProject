using Portfolio.DB.Entities;

namespace Portfolio.DB.Repositories;

public class InMemoryPortfolioRepository : IPortfolioRepository
{
    private readonly List<EntityPortfolio> _portfolios = [];

    public List<EntityPortfolio> GetAll() => _portfolios;
    public EntityPortfolio? GetById(int id) => _portfolios.FirstOrDefault(p => p.Id == id);
    public void Add(EntityPortfolio portfolio) => _portfolios.Add(portfolio);
    public void Update(EntityPortfolio portfolio)
    {
        var idx = _portfolios.FindIndex(p => p.Id == portfolio.Id);
        if (idx >= 0) _portfolios[idx] = portfolio;
    }
    public void Delete(int id) => _portfolios.RemoveAll(p => p.Id == id);
}
