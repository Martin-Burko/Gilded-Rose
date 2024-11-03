using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class ProductCartTest
{
    [Test]
    public void CalculateTotalPrice_ForAProductCartWithThreeDifferentProducts_ItReturnsTheTotalPrice()
    {
        var productCart = new ProductCart();
        productCart.AddProductToCart("+5 Dexterity Vest", 4.90);
        productCart.AddProductToCart("Aged Brie", 9.90, 2);
        productCart.AddProductToCart("Elixir of the Mongoose", 14.90, 3);

        Assert.That(productCart.TotalPrice, Is.EqualTo(69.40));
    }

    [Test]
    public void CalculateTotalPriceForAProduct_ForAProductCartWithThreeDifferentProducts_ItReturnsTheTotalPriceOfOnlyOneProduct()
    {
        var productCart = new ProductCart();
        productCart.AddProductToCart("+5 Dexterity Vest", 4.90);
        productCart.AddProductToCart("Aged Brie", 9.90, 2);
        productCart.AddProductToCart("Elixir of the Mongoose", 14.90, 3);

        Assert.That(productCart.CalculateTotalPriceForAProduct("Aged Brie"), Is.EqualTo(19.80));
    }
}
