public class Customer
{
    public string Name { get; private set; }
    public Address ShippingAddress { get; private set; }

    public Customer(string name, Address shippingAddress)
    {
        Name = name;
        ShippingAddress = shippingAddress;
    }
    public bool IsShippingAddressInUSA()
    {
        return ShippingAddress.IsInUSA();
    }
}