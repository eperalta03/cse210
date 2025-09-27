using System;

class Program
{
    static void Main(string[] args)
    {

        Customer customer1 = new Customer(new Address("123 Main Street", "New York", "NY", "USA"), "John Doe");
        Order order1 = new Order();
        order1.SetCustomer(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 1200, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25, 2));

        Customer customer2 = new Customer(new Address("456 Elm St", "Toronto", "ON", "Canada"), "Jane Smith");
        Order order2 = new Order();
        order2.SetCustomer(customer2);
        order2.AddProduct(new Product("Keyboard", "P004", 50, 1));

        List<Order> orders = new List<Order>();
        orders.Add(order1);
        orders.Add(order2);

        foreach (Order order in orders)
        {
            Console.WriteLine(order.DisplayShippingLabel());
            Console.WriteLine(order.DisplayPackingLabel());
            Console.WriteLine($"Total: ${order.CalculateTotalPrice()}\n");
        }

    }
}