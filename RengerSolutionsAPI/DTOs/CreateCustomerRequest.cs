using System.ComponentModel.DataAnnotations;

namespace RengerSolutionsAPI.DTOs
{
    public class CreateCustomerRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
