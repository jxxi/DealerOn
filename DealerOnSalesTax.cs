using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


public class DealerOnSalesTax {

    static public void Main(String[] args){
        var lines = File.ReadLines("input.txt");
        Cart cart = new Cart();

        foreach (var line in lines) {
            cart.AddToCart(line);
        }
        cart.PrintReceipt();
    }
}
