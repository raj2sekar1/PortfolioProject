using Portfolio.Core.DTOs;

namespace Portfolio.Service;

public interface IPerformanceService
{
    /// <summary>
    /// Calculates portfolio performance over a specified date range.
    /// </summary>
    /// <param name="portfolioId"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    PerformanceResultDto GetPerformance(int portfolioId, DateTime from, DateTime to);
}
