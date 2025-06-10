using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Online Ordering System");

        Address address = new Address("123 Main St", "Anytown", "Texas", "USA");
        Customer customer = new Customer("Jane Doe", address);
        Order order1 = new Order(customer);

        Address internationalAddress = new Address("456 Elm St", "Metropolis", "Ontario", "Canada");
        Customer internationalCustomer = new Customer("John Smith", internationalAddress);
        Order internationalOrder = new Order(internationalCustomer);

        Product product1 = new Product("Laptop", "P001", 599.99, 1);
        Product product2 = new Product("Smartphone", "P002", 299.99, 2);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("Order Summary:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotal():F2}\n");

        Order order2 = new Order(internationalCustomer);
        Product product3 = new Product("Tablet", "P003", 199.99, 1);
        order2.AddProduct(product3);
        order2.AddProduct(product2);

        Console.WriteLine("Order 2 Summary:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotal():F2}\n");
    }
}