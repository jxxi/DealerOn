using System;
using System.Collections.Generic;
using System.Linq;


public static class TaxCalculator {

    public static decimal CalculateImportTax(bool imported, decimal price) {
        decimal importTaxAmount = .05M;
        decimal importTax = 0;

        if (imported) {
            importTax = importTaxAmount*price;
        }

        return RoundUp(importTax);
    }

    public static decimal CalculateSalesTax(string name, decimal price) {
        decimal salesTax = 0;
        decimal baseTaxAmount = .10M;

        if (!SalesTaxExempt(name)) {
            salesTax = baseTaxAmount*price;
        }
 
        return RoundUp(salesTax);
    }

    private static decimal RoundUp(decimal input) {
        return Math.Round((Math.Round(input * 20, MidpointRounding.AwayFromZero) / 20),1);
    }

    private static bool SalesTaxExempt(string name) {
        string[] TaxExemptItems = { "Book", "Chocolate bar", "Imported box of chocolates", "Packet of headache pills" };

        if (TaxExemptItems.Contains(name, StringComparer.OrdinalIgnoreCase)) {
            return true;
        }

        return false;
    }
}