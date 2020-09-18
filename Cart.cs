using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


public class Cart {
    public static string regexPattern = @"(\d+)\s?(\b[\w\s]+\b)*\s?(at)\s?.*?(\d+\.\d+)";
    List<Item> items = new List<Item>();

    string[] itemInfo;
    string name;
    decimal quantity, price;

    public void AddToCart(string input) {
        itemInfo = SplitItemInfo(input);
        quantity = decimal.Parse(itemInfo[1]);
        price = decimal.Parse(itemInfo[4]);
        name = itemInfo[2].Trim();

        if (ItemAlreadyExistsInCart(name))
        {
            IncreaseItemQuantity(name, quantity);
        }
        else
        {
            Item item = new Item(quantity, name, price);
            items.Add(item);
        }
    }

    public void PrintReceipt() {
        string receipt = "";
        string lineItem = "";
        foreach (var item in items)
        {
            lineItem = string.Format("{0}: {1}", item.Name, item.TotalPriceTaxed);

            if (item.Quantity > 1){
                lineItem += string.Format(" ({0} @ {1})", item.Quantity, item.PricePerUnit);
            }
            lineItem += "\n";

            receipt += lineItem;
        }
        decimal salesTax = GetSalesTaxTotal();
        decimal cartTotal = GetCartTotal();

        receipt += string.Format("Sales Taxes: {0}\n", salesTax);
        receipt += string.Format("Total: {0}", cartTotal);

        Console.Write(receipt);
    }

    private decimal GetCartTotal() {
        decimal total = 0;
        foreach (var item in items) {
            total += item.TotalPriceTaxed;
        }

        return total;
    }

    private decimal GetSalesTaxTotal() {
        decimal tax = 0;
        foreach (var item in items) {
            tax += item.TotalTax;
        }

        return tax;
    }

    private bool ItemAlreadyExistsInCart(string name) {
        var match = items.FirstOrDefault(item => item.Name == name);
        if (match != null){
            return true;
        }
        return false;
    }

    private void IncreaseItemQuantity(string name, decimal quantity) {
        var match = items.FirstOrDefault(item => item.Name == name);
        if (match != null){
            match.Quantity += quantity;
        }
    }

    private string[] SplitItemInfo(string input) {
        return Regex.Split(input, regexPattern, RegexOptions.IgnoreCase);
    }
}