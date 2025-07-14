using Portfolio.DB.Entities;

namespace Portfolio.DB.Repositories;

public interface IPortfolioRepository
{
    /// <summary>
    /// Retrieves all portfolios.
    /// </summary>
    /// <returns></returns>
    List<EntityPortfolio> GetAll();
    /// <summary>
    /// etrieves a portfolio by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    EntityPortfolio? GetById(int id);
    /// <summary>
    /// Adds a new portfolio to the in-memory store.
    /// </summary>
    /// <param name="portfolio"></param>
    void Add(EntityPortfolio portfolio);
    /// <summary>
    /// Updates an existing portfolio.
    /// </summary>
    /// <param name="portfolio"></param>
    void Update(EntityPortfolio portfolio);
    /// <summary>
    /// Delete an existing portfolio.
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
}
