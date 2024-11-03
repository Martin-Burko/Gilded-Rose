using System;

namespace GildedRoseKata;

public class Product
{
    private Guid Id;
    public string Name { get; init; }
    public int SellIn { get; set; }
    public int Quality { get; internal set; }
    public double Price { get; internal set; }
    public DiscountOption DiscountOption { get; internal set; }

    public Product(string name, int sellIn, int quality)
    {
        Id = Guid.NewGuid();
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public Product(string name, int quality, double price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Quality = quality;
        DiscountOption = DiscountOption.None;
    }



    public void SetPrice(double price)
    {
        Price = price;
    }

    public void SetQuality(int quality)
    {
        Quality = quality;
    }

    public void SetDiscount(DiscountOption discountOption)
    {
        DiscountOption = discountOption;
    }
}
