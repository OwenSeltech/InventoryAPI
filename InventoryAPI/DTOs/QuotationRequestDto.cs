using InventoryAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryAPI.DTOs
{
    public class QuotationRequestDto
    {
        public int QuotationID { get; set; }
        [Required(ErrorMessage = "The Customer Id field is required.")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "The Customer Id field is required.")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "The Customer Id field is required.")]
        public int ItemsNo { get; set; }
        [JsonIgnore]
        public decimal QuotationAmount { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
