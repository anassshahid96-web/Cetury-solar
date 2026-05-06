using SolarBackend.Models;

namespace SolarBackend.Services;

public sealed class QuoteEstimator
{
    public QuoteEstimate Estimate(decimal monthlyBillPkr)
    {
        const decimal averageUnitRatePkr = 55m;
        const decimal monthlyUnitsPerKw = 120m;
        const decimal installedCostPerKwPkr = 180000m;
        const decimal savingsRatio = 0.85m;

        var monthlyUnits = monthlyBillPkr / averageUnitRatePkr;
        var estimatedSystemSizeKw = monthlyUnits / monthlyUnitsPerKw;
        var estimatedMonthlySavings = monthlyBillPkr * savingsRatio;
        var annualSavings = estimatedMonthlySavings * 12m;
        var installedCost = estimatedSystemSizeKw * installedCostPerKwPkr;

        var estimatedRoiYears = annualSavings == 0m ? 0m : installedCost / annualSavings;

        return new QuoteEstimate
        {
            EstimatedSystemSizeKw = Math.Round(estimatedSystemSizeKw, 2, MidpointRounding.AwayFromZero),
            EstimatedMonthlySavingsPkr = Math.Round(estimatedMonthlySavings, 0, MidpointRounding.AwayFromZero),
            EstimatedRoiYears = Math.Round(estimatedRoiYears, 2, MidpointRounding.AwayFromZero)
        };
    }
}
