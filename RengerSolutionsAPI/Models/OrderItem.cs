namespace RengerSolutionsAPI.Models;

public class OrderItem
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public string ProductId { get; set; } = string.Empty;

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
}