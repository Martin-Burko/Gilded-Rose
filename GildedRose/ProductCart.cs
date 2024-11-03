using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class ProductCart
{
    public List<Product> Products { get; } = new List<Product>();
    public List<BulkDiscountOption> BulkDiscountOptions { get; set; }
    public double TotalPrice { get { return CalculateTotalPrice(); } }

    public void AddProductToCart(string productName, double price, int amount = 1, DiscountOption discountOption = DiscountOption.None)
    {
        for (int i = 0; i < amount; i++)
        {
            var product = new Product(productName, 0, price);
            product.Price = price;
            product.DiscountOption = discountOption;
            Products.Add(product);
        }
    }

    private double CalculateTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in Products)
        {
            totalPrice += product.Price;
        }
        return totalPrice;
    }

    public double CalculateTotalPriceForAProduct(string productName)
    {
        double totalPriceForAProduct = 0;
        var products = Products.Where(p => p.Name == productName);
        foreach (var product in products)
        {
            totalPriceForAProduct += product.Price;
        }
        return totalPriceForAProduct;

    }
}
