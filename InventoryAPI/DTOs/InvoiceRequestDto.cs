using InventoryAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryAPI.DTOs
{
    public class InvoiceRequestDto
    {
        public int InvoiceID { get; set; }
        [Required(ErrorMessage = "The Customer Id field is required.")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "The Product Id field is required.")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "The Items field is required.")]
        public int ItemsNo { get; set; }
        [JsonIgnore]
        public decimal InvoiceAmount { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
