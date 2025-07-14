using Portfolio.DB.Entities;
using Portfolio.DB.Repositories;

namespace Portfolio.Service.Concretes;

public class AssetService(
    IPortfolioRepository repo) : IAssetService
{
    private static int _assetUniqueueId = 1;

    public void AddAsset(int portfolioId, EntityAsset asset)
    {
        var p = repo.GetById(portfolioId);
        if (p != null)
        {
            asset = asset with { Id = _assetUniqueueId++ };
            p.Assets.Add(asset);
            repo.Update(p);
        }
    }
}
