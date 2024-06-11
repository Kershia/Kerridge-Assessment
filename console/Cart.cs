using System.Text;

namespace console;

public class Cart
{
     public List<Product> Products { get; set; } = [];

     public Cart(params Product[] products)
     {
        Products.AddRange(products);
     }

     public decimal calculateTax()
     {
        var cartTaxedPrice = Products.Sum(m => m.calculatePrice());
        var cartUntaxedPrice = Products.Sum(m => m.calculateUntaxedPrice());

        return cartTaxedPrice - cartUntaxedPrice;
     }

     public decimal calculateCartValue()
     {
        return Products.Sum(m => m.calculatePrice());
     }

     public void WriteOutput(string title)
     {
        var filename = $"../../../../{title}.txt";
        if (File.Exists(filename))
        {
            File.Delete(filename);
        }

        var sb = new StringBuilder();

        sb.AppendLine($"{title}:");

        foreach (var product in Products)
        {
            sb.AppendLine($"{product.Quantity} {product.Description}: {product.calculatePrice()}");
        }

        var cartTaxedPrice = Products.Sum(m => m.calculatePrice());
        var cartUntaxedPrice = Products.Sum(m => m.calculateUntaxedPrice());
        sb.AppendLine($"Sales Tax: {cartTaxedPrice - cartUntaxedPrice}");
        sb.AppendLine($"Total: {cartTaxedPrice}");

        File.WriteAllText(filename, sb.ToString());
     }
}
