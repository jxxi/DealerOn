
public interface IItem {

    bool Imported { get; }
    decimal TotalPrice { get; }
    decimal TotalPriceTaxed { get; }
    decimal TotalTax { get; }
}

public class Item: IItem {

    public string Name { get; set; }
    public decimal Quantity { get; set; }
    public decimal PricePerUnit { get; set; }

    public Item(decimal quantity, string name, decimal price) {
        Name = name;
        Quantity = quantity;
        PricePerUnit = price;
    }

    public bool Imported {
        get {
            return this.Name.Contains("Imported") ? true : false;
        }
    }

    public decimal TotalPrice { 
        get {
            return this.PricePerUnit*this.Quantity;
        }
    }

    public decimal TotalPriceTaxed {
        get {
            return this.TotalPrice + this.TotalTax;
        }
    }

    public decimal TotalTax {
        get {
            return this.ImportTax + this.SalesTax;
        } 
    }

    private decimal ImportTax { 
        get {
            return TaxCalculator.CalculateImportTax(this.Imported, this.TotalPrice);
        }
    }
    private decimal SalesTax { 
        get {
            return TaxCalculator.CalculateSalesTax(this.Name, this.TotalPrice);
        }
    }
}