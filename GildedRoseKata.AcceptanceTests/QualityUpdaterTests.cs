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
            IEnumerable<int> qualities = [0];
            IEnumerable<int> sellIns = [0];
            CombinationApprovals.VerifyAllCombinations((name, quality, sellIn) =>
            {
                var item = new Item() { Name = name, Quality = quality, SellIn = sellIn };
                _sut.UpdateQuality([item]);
                return item;
            }, names, qualities, sellIns);
        }
    }
}