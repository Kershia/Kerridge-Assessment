namespace console;

public class Product
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public bool IsTaxable { get; set; }
    public bool IsImported { get; set; }

    public Product(string description, decimal price, int quantity = 1, bool isTaxable = true, bool isImported = false)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be null or empty.");
        if (price <= 0)
            throw new ArgumentException("Price cannot be less than or 0.");
        if (quantity <= 0)
            throw new ArgumentException("Quantity cannot be less than or 0.");

        Description = description;
        Price = price;
        Quantity = quantity;
        IsTaxable = isTaxable;
        IsImported = isImported;
    }

    private decimal roundToNearestFiveCents(decimal value)
    {
        if (value == 0)
        {
            return value;
        }

        decimal fraction = value - Math.Truncate(value);
        var cents = fraction * 100;

        var lastDigit = cents % 10;
        if (lastDigit > 0 && lastDigit < 5)
        {
            var x = Math.Floor(cents / 10);
            var y = x * 10;
            cents = y + 5;
        }

        return Math.Truncate(value) + (cents / 100);
    }

    public decimal calculateTax()
    {
        var taxRate = 0m;

        if (IsTaxable)
        {
            taxRate += 0.1m;
        }

        if (IsImported)
        {
            taxRate += 0.05m;
        }

        var taxedPrice = (Price * Quantity) * taxRate;
        var roundedTaxPrice = Math.Round(taxedPrice, 2);

        return roundedTaxPrice;
    }

    public decimal calculateUntaxedPrice()
    {
        return Price * Quantity;
    }

    public decimal calculatePrice()
    {
        return roundToNearestFiveCents(calculateUntaxedPrice() + calculateTax());
    }
}