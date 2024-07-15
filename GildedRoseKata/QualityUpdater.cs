namespace GildedRoseKata;

public class QualityUpdater
{
    public void UpdateQuality(IList<Item> items)
    {
        for (var i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            DoStuff(item);
        }
    }

    private static void DoStuff(Item item)
    {
        if (item.Name == "Aged Brie")
        {
            DoStuffAgedBrie(item);
            return;
        }
        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            DoStuffBackstage(item);
            return;
        }
        if (item.Quality > 0)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.Quality = item.Quality - 1;
            }
        }

        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn = item.SellIn - 1;
        }

        if (item.SellIn < 0)
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }
        return;
    }

    private static void DoStuffBackstage(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality = item.Quality + 1;

            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }

        item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0)
        {
            item.Quality = item.Quality - item.Quality;
        }
    }

    private static void DoStuffAgedBrie(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality = item.Quality + 1;
        }

        item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}