namespace RengerSolutionsAPI.DTOs
{
    public class CreateOrderRequest
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string OrderNumber { get; set; } = string.Empty;
        public List<CreateOrderItemRequest> Items { get; set; } = new();
    }
}
