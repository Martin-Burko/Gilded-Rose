using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class DiscountTest
{
    [Test]
    public void CalculateDiscounts_ForAProductCartWithThreeDifferentProducts_ItReturnsTheTotalPrice()
    {
        var productCart = new ProductCart();
        productCart.AddProductToCart("+5 Dexterity Vest", 4.90, 1, DiscountOption.HalfPrice);
        productCart.AddProductToCart("Aged Brie", 9.90, 2, DiscountOption.HalfPrice);
        productCart.AddProductToCart("Elixir of the Mongoose", 14.90, 3, DiscountOption.ThreeForTwo);

        productCart = Discount.CalculateDiscounts(productCart);

        Assert.That(productCart.TotalPrice, Is.EqualTo(42.15));
    }
}
