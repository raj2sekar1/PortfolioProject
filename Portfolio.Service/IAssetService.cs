using Portfolio.DB.Entities;

namespace Portfolio.Service;

public interface IAssetService
{
    /// <summary>
    /// Adds a new asset to a portfolio.
    /// </summary>
    /// <param name="portfolioId"></param>
    /// <param name="asset"></param>
    void AddAsset(int portfolioId, EntityAsset asset);
}
