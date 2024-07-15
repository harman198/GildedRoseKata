using ApprovalTests;
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
            IList<Item> items = [new Item() { Name = "Foo", Quality = 0, SellIn = 0 }];
            _sut.UpdateQuality(items);
            Approvals.VerifyAll(items, "Items");
        }
    }
}