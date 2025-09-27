public class Customer
{
    private string _name;
    private Address _address;
    public Customer(Address address, string name)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public bool LiveInUSA()
    {
        return _address.ItIsInUSA();
    }
}