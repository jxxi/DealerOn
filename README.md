# DealerOn

## Running the code

- Open input.txt and put in sample data
- From the command line run:
```csc.exe DealerOnSalesTax.cs Item.cs TaxCalculator.cs Cart.cs```
then
```DealerOnSalesTax```
to run the executable.

## Sample Input
```
1 Imported bottle of perfume at 27.99
1 Bottle of perfume at 18.99
1 Packet of headache pills at 9.75
1 Imported box of chocolates at 11.25
1 Imported box of chocolates at 11.25
```

## Sample Output
```
Imported bottle of perfume: 32.19
Bottle of perfume: 20.89
Packet of headache pills: 9.75
Imported box of chocolates: 23.70 (2 @ 11.25)
Sales Taxes: 7.3
Total: 86.53
```

Notes: Could be cleaned up a little, and unit testing was not added. Receipt functionality should be seperated from Cart
