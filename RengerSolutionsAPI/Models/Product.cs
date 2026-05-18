namespace RengerSolutionsAPI.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new();
}