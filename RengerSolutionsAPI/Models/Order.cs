namespace RengerSolutionsAPI.Models;

public class Order
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public Customer Customer { get; set; } = null!;

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<OrderItem> Items { get; set; } = new();
}