using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public static class CurrencyCalculator
{
    private static Dictionary<string, double> ExchangeRates = new Dictionary<string, double>()
    {
        { "USD", 1.08 },
        { "CHF", 0.94 },
        { "GBP", 0.84 },
        { "JPY", 165.71 },
        { "HUF", 407.97 }
    };

    public static double CalculateEurTo(string currency, double priceInEur)
    {
        CurrencySupported(currency);
        var exchangeRate = ExchangeRates[currency];
        var priceInCurrency = Math.Round(priceInEur * exchangeRate, 2, MidpointRounding.ToPositiveInfinity);
        return priceInCurrency;
    }

    public static double CalculateToEur(string currency, double priceInCurrency)
    {
        CurrencySupported(currency);
        var exchangeRate = ExchangeRates[currency];
        var priceInEuro = Math.Round(priceInCurrency / exchangeRate, 2, MidpointRounding.ToPositiveInfinity);
        return priceInEuro;
    }

    private static void CurrencySupported(string currency)
    {
        if (!ExchangeRates.ContainsKey(currency))
        {
            throw new ArgumentException($"The currency {currency} is not supported.");
        }
    }
}
