using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Product> Items;

    public GildedRose(IList<Product> Items)
    {
        this.Items = Items;
    }

    /*public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].Quality > 0)
                {
                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                }
            }
        }
    }*/

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            switch (Items[i].Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    Items[i].Quality = 80;
                    continue;
                case "Backstage passes to a TAFKAL80ETC concert":
                    if (Items[i].SellIn < 1)
                        Items[i].Quality = 0;
                    else if (Items[i].SellIn < 6)
                        Items[i].Quality += 3;
                    else if (Items[i].SellIn < 11)
                        Items[i].Quality += 2;
                    else
                        Items[i].Quality += 1;

                    Items[i].SellIn -= 1;
                    Items[i] = CheckQualityMinAndMaxValue(Items[i]);
                    continue;
                case "Aged Brie":
                    Items[i].SellIn -= 1;
                    Items[i].Quality += 1;
                    Items[i] = CheckQualityMinAndMaxValue(Items[i]);
                    continue;
            }

            if (Items[i].Name.StartsWith("Conjured"))
                Items[i].Quality -= 1;

            Items[i].SellIn -= 1;
            Items[i].Quality -= 1;
            if (Items[i].SellIn < 0)
                Items[i].Quality -= 1;

            Items[i] = CheckQualityMinAndMaxValue(Items[i]);
        }
    }

    private Product CheckQualityMinAndMaxValue(Product item)
    {
        if (item.Quality < 0)
            item.Quality = 0;
        if (item.Quality > 50)
            item.Quality = 50;
        return item;
    }
}