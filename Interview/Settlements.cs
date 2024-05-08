using System.Diagnostics.CodeAnalysis;

namespace Interview;

using CsvData = (Guid Id, decimal Commission, decimal Deduction);

[SuppressMessage("ReSharper", "UnusedParameter.Global")]
public static class Settlements
{
    public static IReadOnlyList<DataModels.SettlementSummary> ReadSettlementSummaries(IEnumerable<CsvData> data)
    {
        throw new NotImplementedException();
    }

    public static int Count<T>(IEnumerable<T> items)
    {
        throw new NotImplementedException();
    }

    public static IReadOnlyList<DataModels.SettlementAmounts> AmountsForSettlementId(this IReadOnlyList<DataModels.SettlementSummary> summaries, Guid settlementId)
    {
        throw new NotImplementedException();
    }
    
    public static int CountWhereAmountsAreGreaterThan(this IReadOnlyList<DataModels.SettlementSummary> summaries, decimal amount)
    {
        throw new NotImplementedException();
    }
    
    public static IReadOnlyList<DataModels.SettlementTotals> CalculateTotals(this IReadOnlyList<DataModels.SettlementSummary> summaries)
    {
        throw new NotImplementedException();
    }
}