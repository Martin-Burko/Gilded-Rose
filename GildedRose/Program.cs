using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        IList<Product> items = new List<Product>
        {
            new Product("+5 Dexterity Vest", 10, 20),
            new Product("Aged Brie", 2, 0),
            new Product("Elixir of the Mongoose", 5, 7),
            new Product("Sulfuras, Hand of Ragnaros", 0, 80),
            new Product("Sulfuras, Hand of Ragnaros", -1, 80),
            new Product
            (
                "Backstage passes to a TAFKAL80ETC concert",
                15,
                20
            ),
            new Product
            (
                "Backstage passes to a TAFKAL80ETC concert",
                10,
                49
            ),
            new Product
            (
                "Backstage passes to a TAFKAL80ETC concert",
                5,
                49
            ),
            // this conjured item does not work properly yet
            new Product("Conjured Mana Cake", 3, 6)
        };

        var app = new GildedRose(items);

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}
