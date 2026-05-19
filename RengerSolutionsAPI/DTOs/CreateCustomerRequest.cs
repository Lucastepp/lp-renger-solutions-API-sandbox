using System.ComponentModel.DataAnnotations;

namespace RengerSolutionsAPI.DTOs
{
    public class CreateCustomerRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
