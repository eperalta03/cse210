public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

     public void SetCustomer(Customer cust)
    {
        customer = cust;
    }
    public float CalculateTotalPrice()
    {
        float totalPrice = 0;
        foreach (Product product in products)
        {
            totalPrice += product.ComputeTotalCost();
        }

        if (customer.LiveInUSA())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }

        return totalPrice;
    }

    public string DisplayPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in products)
        {
            packingLabel += $"Product: {product.GetProductName()} ID: {product.GetId()}\n";
        }
        return packingLabel;
    }

    public string DisplayShippingLabel()
    {
        string shippingLabel = $"Customer: {customer.GetName()} Address: {customer.GetAddress().GetDisplayAddress()}";
        return shippingLabel;
    }
}