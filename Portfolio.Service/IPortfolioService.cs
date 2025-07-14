using Portfolio.DB.Entities;

namespace Portfolio.Service;

public interface IPortfolioService
{
    /// <summary>
    /// Retrieves all portfolios from the repository.
    /// </summary>
    /// <returns></returns>
    IEnumerable<EntityPortfolio> GetAll();
    /// <summary>
    /// Retrieves a portfolio by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    EntityPortfolio? GetById(int id);
    /// <summary>
    /// Creates a new investment portfolio with a given name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    EntityPortfolio Create(string name);    
    
}
