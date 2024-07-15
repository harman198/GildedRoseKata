using ApprovalTests.Combinations;
using ApprovalTests.Reporters;

namespace GildedRoseKata.AcceptanceTests
{
    [UseReporter(typeof(DiffReporter))]
    public class QualityUpdaterTests
    {
        private readonly QualityUpdater _sut = new();

        [Test]
        public void UpdateQuality_ApprovalTests()
        {
            IEnumerable<string> names = ["Foo"];
            IEnumerable<int> qualities = [0, -1, 1, 49, 50, 51, int.MinValue, int.MaxValue];
            IEnumerable<int> sellIns = [0, -1, 1, 5, 6, 7, 10, 11, 12, int.MinValue, int.MaxValue];
            CombinationApprovals.VerifyAllCombinations((name, quality, sellIn) =>
            {
                var item = new Item() { Name = name, Quality = quality, SellIn = sellIn };
                _sut.UpdateQuality([item]);
                return item;
            }, names, qualities, sellIns);
        }
    }
}