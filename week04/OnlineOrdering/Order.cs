using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    private double GetShippingCost()
    {
        if (_customer.IsShippingAddressInUSA())
        {
            return 5.00; // Flat rate for USA
        }
        else
        {
            return 35.00; // Flat rate for international shipping
        }
    }
    public double CalculateTotal()
    {
        double totalProductsPrice = 0;
        foreach (Product product in _products)
        {
            totalProductsPrice += product.GetTotalPrice();
        }
        double shippingCost = GetShippingCost();
        return totalProductsPrice + shippingCost;
    }
    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();
        packingLabel.AppendLine("--- Packing Label ---");
        packingLabel.AppendLine($"Order for: {_customer.Name}");
        packingLabel.AppendLine("Products:");
        foreach (Product product in _products)
        {
            packingLabel.AppendLine($"- {product.Name} (ID: {product.ProductId}, Quantity: {product.Quantity})");
        }
        packingLabel.AppendLine("--- End of Packing Label ---");
        return packingLabel.ToString();
    }
    public string GetShippingLabel()
    {
        StringBuilder shippingLabel = new StringBuilder();
        shippingLabel.AppendLine("--- Shipping Label ---");
        shippingLabel.AppendLine($"To: {_customer.Name}");
        shippingLabel.AppendLine($"Address: {_customer.ShippingAddress}");
        shippingLabel.AppendLine($"Shipping Cost: ${GetShippingCost():0.00}");
        shippingLabel.AppendLine("--- End of Shipping Label ---");
        return shippingLabel.ToString();
    }
}