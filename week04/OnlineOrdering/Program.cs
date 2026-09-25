using System;
using System.Collections.Generic;

public class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Trim().ToUpper() == "USA" || country.Trim().ToUpper() == "UNITED STATES";
    }

    public string GetFullAddress()
    {
        return street + "\n" + city + ", " + stateOrProvince + "\n" + country;
    }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    public Address GetAddress()
    {
        return address;
    }
}

public class Product
{
    private string name;
    private string productId;
    private decimal pricePerUnit;
    private int quantity;

    public Product(string name, string productId, decimal pricePerUnit, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.pricePerUnit = pricePerUnit;
        this.quantity = quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }

    public decimal GetTotalCost()
    {
        return pricePerUnit * quantity;
    }
}

public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product p)
    {
        products.Add(p);
    }

    public decimal CalculateTotalCost()
    {
        decimal productsTotal = 0;
        foreach (Product p in products)
        {
            productsTotal += p.GetTotalCost();
        }

        decimal shippingCost = customer.LivesInUSA() ? 5 : 35;
        return productsTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in products)
        {
            label += "- " + p.GetName() + " (ID: " + p.GetProductId() + ")\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + customer.GetName() + "\n" + customer.GetAddress().GetFullAddress();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Order 1: USA Customer
        Address address1 = new Address("123 Main St", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "M100", 25.50m, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "K200", 79.99m, 1));

        // Order 2: International Customer
        Address address2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Sarah Johnson", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("USB-C Hub", "H300", 19.99m, 3));
        order2.AddProduct(new Product("HDMI Cable", "C400", 12.50m, 2));
        order2.AddProduct(new Product("Mouse Pad", "P500", 9.99m, 1));

        // Display results for Order 1
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.CalculateTotalCost());
        Console.WriteLine();

        // Display results for Order 2
        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.CalculateTotalCost());
    }
}