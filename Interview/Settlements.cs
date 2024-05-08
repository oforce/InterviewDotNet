using System.Diagnostics.CodeAnalysis;

namespace Interview;

using CsvData = (Guid Id, decimal Commission, decimal Deduction);
using SummaryList = IReadOnlyList<DataModels.SettlementSummary>;

[SuppressMessage("ReSharper", "UnusedParameter.Global")]
public static class Settlements
{
    public static IEnumerable<CsvData> ParseCsvData(IEnumerable<string[]> rows)
    {
        throw new NotImplementedException();
    }

    public static SummaryList ReadSettlementSummaries(IEnumerable<CsvData> data)
    {
        throw new NotImplementedException();
    }

    public static int CountSettlements(this SummaryList items)
    {
        throw new NotImplementedException();
    }

    public static IReadOnlyList<DataModels.SettlementAmounts> AmountsForSettlementId(this SummaryList summaries, Guid id)
    {
        throw new NotImplementedException();
    }

    public static int CountWhereAmountsAreGreaterThan(this SummaryList summaries, decimal amount)
    {
        throw new NotImplementedException();
    }

    public static IReadOnlyList<DataModels.SettlementTotals> CalculateTotals(this SummaryList summaries)
    {
        throw new NotImplementedException();
    }
}