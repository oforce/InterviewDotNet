namespace Interview;

public static class DataModels
{
    public record SettlementSummary(Guid Id, List<SettlementAmounts> Amounts);
    public record SettlementAmounts(decimal Commission, decimal Deduction);
    public record SettlementTotals(Guid Id, decimal GrossCommissions, decimal GrossDeductions, decimal NetTotal);
}