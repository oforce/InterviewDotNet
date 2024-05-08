using System.Globalization;
using Xunit.Abstractions;

namespace Interview.Test;

[TestSubject(typeof(Collections))]
public class CollectionsTest(CollectionsTest.Context context, ITestOutputHelper output)
    : IClassFixture<CollectionsTest.Context>
{
    [Fact]
    public void can_read_from_csv_file()
    {
        // Act
        var data = context.SettlementCsvData();

        // Assert
        data.ShouldNotBeNull();
        data.Count.ShouldBe(49);
    }

    [Fact]
    public void count_is_correct()
    {
        // Arrange
        var data = context.SettlementCsvData();
        var summaries = Collections.ReadSettlementSummaries(data);

        // Act
        var count = Collections.Count(summaries);

        // Assert
        count.ShouldBe(8);
    }

    [Theory]
    [InlineData("0702b621-e076-4d96-a219-3a7e4208c4f7", 2)]
    [InlineData("3228fe14-dc3d-4fe5-83d7-f66e35919329", 17)]
    [InlineData("35857b85-8d7a-448c-9782-4bd52faa3e54", 3)]
    [InlineData("4759b98e-a001-4778-a7e6-e98240c75123", 4)]
    [InlineData("687b5bd7-2564-4770-8a4f-0669340cfe8d", 5)]
    [InlineData("96a4e4a2-2ae4-4711-9534-8d6d8330f6f6", 10)]
    [InlineData("e2d11981-e85b-4fd2-b810-44a41945107a", 6)]
    [InlineData("f2ce7dac-176e-4359-9b41-e2d2c602a48f", 2)]
    public void amounts_for_settlement_id(string settlementId, int expectedCount)
    {
        // Arrange
        var data = context.SettlementCsvData();
        var summaries = Collections.ReadSettlementSummaries(data);

        // Act
        var amounts = Collections.AmountsForSettlementId(summaries, Guid.Parse(settlementId));

        // Assert
        amounts.ShouldNotBeNull();
        amounts.Count.ShouldBe(expectedCount);
    }

    [Theory]
    [InlineData(100, 21)]
    [InlineData(500, 10)]
    [InlineData(800, 3)]
    public void count_where_amounts_are_greater_than(int greaterThan, int expectedCount)
    {
        // Arrange
        var data = context.SettlementCsvData();
        var summaries = Collections.ReadSettlementSummaries(data);

        // Act
        var count = Collections.CountWhereAmountsAreGreaterThan(summaries, greaterThan);

        // Assert
        count.ShouldBe(expectedCount);
    }
    
    [Theory]
    [InlineData("0702b621-e076-4d96-a219-3a7e4208c4f7", 0, 158.504664183717500, -158.504664183717500)]
    [InlineData("3228fe14-dc3d-4fe5-83d7-f66e35919329", 3953.6517141460919000, 330.490489606843700, 3623.1612245392482000)]
    [InlineData("35857b85-8d7a-448c-9782-4bd52faa3e54", 666.036528775923000, 64.983427365318900, 601.053101410604100)]
    [InlineData("4759b98e-a001-4778-a7e6-e98240c75123", 841.512190979754000, 101.409457847949100, 740.102733131804900)]
    [InlineData("687b5bd7-2564-4770-8a4f-0669340cfe8d", 225.766603724616000, 136.7765613009438100, 88.9900424236721900)]
    [InlineData("96a4e4a2-2ae4-4711-9534-8d6d8330f6f6", 3158.296850655789000, 197.6893700144328200, 2960.6074806413561800)]
    [InlineData("e2d11981-e85b-4fd2-b810-44a41945107a", 1704.991474757491000, 149.142690511674400, 1555.848784245816600)]
    [InlineData("f2ce7dac-176e-4359-9b41-e2d2c602a48f", 0, 129.230945230829900, -129.230945230829900)]
    public void calculate_totals(string settlementId, decimal expectedGrossCommissions, decimal expectedGrossDeductions, decimal expectedNetTotal)
    {
        // Arrange
        var data = context.SettlementCsvData();
        var summaries = Collections.ReadSettlementSummaries(data);

        // Act
        var totals = Collections.CalculateTotals(summaries);
        var total = totals.First(x => x.Id == Guid.Parse(settlementId));

        // Assert
        total.ShouldNotBeNull();
        total.GrossCommissions.ShouldBe(expectedGrossCommissions, 0.000005m);
        total.GrossDeductions.ShouldBe(expectedGrossDeductions, 0.000005m);
        total.NetTotal.ShouldBe(expectedNetTotal, 0.000005m);
    }

    public class Context : UnitTestContext
    {
        private const string CsvFilePath = "Data/Settlements.csv";

        public IReadOnlyList<SettlementCsvData> SettlementCsvData() =>
            StreamCsvFile(CsvFilePath)
                .Select(values => new SettlementCsvData(
                    Guid.Parse(values[0]),
                    decimal.Parse(values[1]),
                    decimal.Parse(values[2]))
                ).ToList();

        private static IEnumerable<string[]> StreamCsvFile(string path)
        {
            using var reader = new StreamReader(path);
            var _ = reader.ReadLine();

            // Read each data row
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line?.Split(',');
                if (values == null) continue;

                yield return values;
            }
        }
    }
}