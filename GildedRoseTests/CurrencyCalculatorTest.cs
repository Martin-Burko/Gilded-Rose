using GildedRoseKata;
using NUnit.Framework;
using System;

namespace GildedRoseTests;

public class CurrencyCalculatorTest
{
    [Test]
    public void CalculateEurTo_ForAPriceInEur_ItReturnsThePriceInUsDollars()
    {
        double priceInEur = 4.90;
        double priceInUsDollar = 5.30;

        double calculatedPrice = CurrencyCalculator.CalculateEurTo("USD", priceInEur);

        Assert.That(calculatedPrice, Is.EqualTo(priceInUsDollar));
    }

    [Test]
    public void CalculateToEur_ForAPriceInUsDollars_ItReturnsThePriceInEur()
    {
        double priceInUsDollar = 9.95;
        double priceInEur = 9.22;

        double calculatedPrice = CurrencyCalculator.CalculateToEur("USD", priceInUsDollar);

        Assert.That(calculatedPrice, Is.EqualTo(priceInEur));
    }

    [Test]
    public void CalculateEurTo_ForANotSupportedCurrency_ItThrowsAnException()
    {
        double priceInEur = 9.90;

        Assert.Throws<ArgumentException>(() => CurrencyCalculator.CalculateEurTo("AAA", priceInEur));
    }
}
