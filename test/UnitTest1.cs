using console;

namespace test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var product1 = new Product(
            description: "Book ",
            price: 12.49m,
            isTaxable: false
        );
        var product2 = new Product(
            description: "Music CD",
            price: 14.99m
        );
        var product3 = new Product(
            description: "Chocolate bar",
            price: 0.85m,
            isTaxable: false
        );

        var cart = new Cart(product1, product2, product3);
        cart.WriteOutput("Output 1");

        Assert.Equal(12.49m, product1.calculatePrice());
        Assert.Equal(16.49m, product2.calculatePrice());
        Assert.Equal(0.85m, product3.calculatePrice());

        Assert.Equal(1.50m, cart.calculateTax());
        Assert.Equal(29.83m, cart.calculateCartValue());
    }

    [Fact]
    public void Test2()
    {
        var product1 = new Product(
            description: "Imported box of chocolates",
            price: 10.0m,
            isTaxable: false,
            isImported: true            
        );
        var product2 = new Product(
            description: "Imported bottle of perfume",
            price: 47.50m,
            isImported: true   
        );
       
        var cart = new Cart(product1, product2);
        cart.WriteOutput("Output 2");

        Assert.Equal(10.50m, product1.calculatePrice());
        Assert.Equal(54.65m, product2.calculatePrice());

        Assert.Equal(7.65m, cart.calculateTax());
        Assert.Equal(65.15m, cart.calculateCartValue());
    }

     [Fact]
    public void Test3()
    {
        var product1 = new Product(
            description: "Imported bottle of perfume",
            price: 27.99m,
            isImported: true   
        );
        var product2 = new Product(
            description: "Bottle of perfume",
            price: 18.99m
        );
        var product3 = new Product(
            description: "Packet of paracetamol",
            price: 9.75m,
            isTaxable: false
        );
        var product4 = new Product(
            description: "Box of imported chocolates",
            price: 11.25m,
            isTaxable: false,
            isImported: true   
        );

        var cart = new Cart(product1, product2, product3, product4);
        cart.WriteOutput("Output 3");

        Assert.Equal(32.19m, product1.calculatePrice());
        Assert.Equal(20.89m, product2.calculatePrice());
        Assert.Equal(9.75m, product3.calculatePrice());
        Assert.Equal(11.85m, product4.calculatePrice());

        Assert.Equal(6.70m, cart.calculateTax());
        Assert.Equal(74.68m, cart.calculateCartValue());
    }
}