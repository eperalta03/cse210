public class Product
{
    private string _productName;
    private string _id;
    private float _price;
    private int _quantity;

    public Product(string productName, string id, float price, int quantity)
    {
        _productName = productName;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public string GetProductName()
    {
        return _productName;
    }

    public string GetId()
    {
        return _id;
    }

    public float ComputeTotalCost()
    {
        float totalCost = _price * _quantity;
        return totalCost;
    }
}