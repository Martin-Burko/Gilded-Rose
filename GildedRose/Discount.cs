using System.Linq;

namespace GildedRoseKata;

public static class Discount
{
    public static ProductCart CalculateDiscounts(ProductCart productCart)
    {
        foreach (var product in productCart.Products)
        {
            switch (product.DiscountOption)
            {
                case DiscountOption.None:
                    continue;
                case DiscountOption.HalfPrice:
                    product.Price = product.Price * ((double)1 / 2);
                    continue;
            }
        }
        var productNamesWithThreeForTwo = productCart.Products.Where(p => p.DiscountOption == DiscountOption.ThreeForTwo).Select(p => p.Name).Distinct();
        foreach (var productName in productNamesWithThreeForTwo)
        {
            var productsWithThisProductName = productCart.Products.Where(p => p.Name == productName);
            var i = 0;
            foreach (var p in productsWithThisProductName)
            {
                i++;
                if (i % 3 == 0)
                {
                    p.Price = 0;
                }
            }
        }

        if (productCart.BulkDiscountOptions == null) { return productCart; }
        foreach (var discount in productCart.BulkDiscountOptions)
        {
            switch (discount)
            {
                case BulkDiscountOption.None:
                    continue;
                case BulkDiscountOption.MinusTenPercent:
                    foreach (var p in productCart.Products)
                    {
                        p.Price = p.Price - (p.Price * 0.1);
                    }
                    continue;
                case BulkDiscountOption.CheapestFree:
                    productCart.Products.MinBy(p => p.Price).Price = 0;
                    continue;
            }
        }
        return productCart;
    }
}

public enum DiscountOption { None, ThreeForTwo, HalfPrice }
public enum BulkDiscountOption { None, CheapestFree, MinusTenPercent }
