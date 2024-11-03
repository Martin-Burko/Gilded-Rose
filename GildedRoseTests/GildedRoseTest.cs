using GildedRoseKata;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseTests;

public class GildedRoseTest
{
    int days = 3;

    [Test]
    public void UpdateQuality_ForRegularItemsWithoutSpecialCases_ItLowersSellInAndQualityByOneEachDay()
    {
        var items = new List<Product> {
            new Product("+5 Dexterity Vest", 10, 20)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items[0].SellIn, Is.EqualTo(7));
        Assert.That(items[0].Quality, Is.EqualTo(17));
    }

    [Test]
    public void UpdateQuality_ForRegularItemsWithoutSpecialCases_QualityMustNotBeNegative()
    {
        var items = new List<Product> {
            new Product("+5 Dexterity Vest", 10, 1),
            new Product("+5 Dexterity Vest", 10, 0),
            new Product("+5 Dexterity Vest", 0, 1),
            new Product("+5 Dexterity Vest", 0, 0),
            new Product("+5 Dexterity Vest", -10, 1),
            new Product("+5 Dexterity Vest", -10, 0)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items.All(i => i.Quality == 0), Is.True);
    }

    [Test]
    public void UpdateQuality_ForItemsWhereSellDateHasPassed_ItLowersQualityByTwoEachDay()
    {
        var items = new List<Product> {
            new Product("+5 Dexterity Vest", 2, 20),
            new Product("+5 Dexterity Vest", 1, 20),
            new Product("+5 Dexterity Vest", 0, 20),
            new Product("+5 Dexterity Vest", -1, 20)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items[0].Quality, Is.EqualTo(16));
        Assert.That(items[1].Quality, Is.EqualTo(15));
        Assert.That(items[2].Quality, Is.EqualTo(14));
        Assert.That(items[3].Quality, Is.EqualTo(14));
    }

    [Test]
    public void UpdateQuality_ForAgedBrie_ItIncreasesQualityByOneEachDay()
    {
        var items = new List<Product> {
            new Product("Aged Brie", 5, 30)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items.All(i => i.Quality == 33), Is.True);
    }

    [Test]
    public void UpdateQuality_ForAgedBrie_QualityMustNotBeGreaterThanFifty()
    {
        var items = new List<Product> {
            new Product("Aged Brie", 5, 48),
            new Product("Aged Brie", 5, 49),
            new Product("Aged Brie", 5, 50)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items.All(i => i.Quality == 50), Is.True);
    }

    [Test]
    public void UpdateQuality_ForBackstagePasses_QualityIncreasesByOneEachDay()
    {
        var items = new List<Product> {
            new Product("Backstage passes to a TAFKAL80ETC concert", 20, 5)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items[0].Quality, Is.EqualTo(8));
    }

    [Test]
    public void UpdateQuality_ForBackstagePassesWithSellInLessOrEqualTen_QualityIncreasesByTwoEachDay()
    {
        var items = new List<Product> {
            new Product("Backstage passes to a TAFKAL80ETC concert", 11, 5),
            new Product("Backstage passes to a TAFKAL80ETC concert", 10, 5),
            new Product("Backstage passes to a TAFKAL80ETC concert", 9, 5)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items[0].Quality, Is.EqualTo(10));
        Assert.That(items[1].Quality, Is.EqualTo(11));
        Assert.That(items[2].Quality, Is.EqualTo(11));
    }

    [Test]
    public void UpdateQuality_ForBackstagePassesWithSellInLessOrEqualFive_QualityIncreasesByThreeEachDay()
    {
        var items = new List<Product> {
            new Product("Backstage passes to a TAFKAL80ETC concert", 6, 5),
            new Product("Backstage passes to a TAFKAL80ETC concert", 5, 5),
            new Product("Backstage passes to a TAFKAL80ETC concert", 4, 5)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items[0].Quality, Is.EqualTo(13));
        Assert.That(items[1].Quality, Is.EqualTo(14));
        Assert.That(items[2].Quality, Is.EqualTo(14));
    }

    [Test]
    public void UpdateQuality_ForBackstagePassesAfterTheConcert_QualityIsZero()
    {
        var items = new List<Product> {
            new Product("Backstage passes to a TAFKAL80ETC concert", 2, 20),
            new Product("Backstage passes to a TAFKAL80ETC concert", 1, 20),
            new Product("Backstage passes to a TAFKAL80ETC concert", 0, 20)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items.All(i => i.Quality == 0), Is.True);
    }

    # region Failing Tests before Refactoring
    [Test]
    public void UpdateQuality_ForRegularItemsWithQualityAlreadyNegative_QualityMustNotBeNegative()
    {
        var items = new List<Product> {
            new Product("+5 Dexterity Vest", 10, -1)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items.All(i => i.Quality == 0), Is.EqualTo(true));
    }

    [Test]
    public void UpdateQuality_ForAgedBrieWhereSellDateHasPassed_ItIncreasesQualityByOneEachDay()
    {
        var items = new List<Product> {
            new Product("Aged Brie", 0, 30),
            new Product("Aged Brie", -5, 30)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items.All(i => i.Quality == 33), Is.True);
    }

    [Test]
    public void UpdateQuality_ForItemsWithQualityAlreadyFiftyOrGreater_QualityMustNotBeGreaterThanFifty()
    {
        var items = new List<Product> {
            new Product("Aged Brie", 5, 50),
            new Product("Aged Brie", 5, 51),
            new Product("Aged Brie", 5, 52),
            new Product("+5 Dexterity Vest", 5, 50),
            new Product("+5 Dexterity Vest", 5, 51),
            new Product("+5 Dexterity Vest", 5, 52)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items.All(i => i.Quality <= 50), Is.True);
    }

    [Test]
    public void UpdateQuality_ForSulfuras_SellInNeverChangesAndQualityIsAlwaysEighty()
    {
        var items = new List<Product> {
            new Product("Sulfuras, Hand of Ragnaros", 5, 0),
            new Product("Sulfuras, Hand of Ragnaros", 0, 80),
            new Product("Sulfuras, Hand of Ragnaros", -5, 40)
        };

        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items[0].SellIn, Is.EqualTo(5));
        Assert.That(items[1].SellIn, Is.EqualTo(0));
        Assert.That(items[2].SellIn, Is.EqualTo(-5));
        Assert.That(items.All(i => i.Quality == 80), Is.True);
    }

    [Test]
    public void UpdateQuality_ForAListWithConjuredItem_QualityDecreasesTwiceAsFast()
    {
        var days = 2;
        var items = new List<Product> { new Product("Conjured Mana Cake", 5, 10) };
        var app = new GildedRose(items);
        app = UpdateQuality(app, days);

        Assert.That(items[0].Quality, Is.EqualTo(6));
    }
    # endregion Failing Tests before Refactoring

    private GildedRose UpdateQuality(GildedRose app, int days)
    {
        for (int i = 0; i < days; i++)
        {
            app.UpdateQuality();
        }
        return app;
    }
}