using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTOs
{
    public class CustomerRequestDto
    {
        [Required(ErrorMessage = "The Customer FirstName field is required.")]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "The Customer LastName field is required.")]
        public string CustomerLastName { get; set; }
        [Required(ErrorMessage = "The Customer Address field is required.")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage = "The Customer Email Address field is required.")]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w+$", ErrorMessage = "Invalid email address")]
        public string CustomerEmailAddress { get; set; }
        public int CustomerID { get; set; }
    }
}
