using InventoryAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryAPI.DTOs
{
    public class CreditNoteRequestDto
    {
        public int CreditNoteID { get; set; }
        [JsonIgnore]
        public int? CustomerID { get; set; }
        [Required(ErrorMessage = "The Invoice ID field is required.")]
        public int InvoiceID { get; set; }
        [Required(ErrorMessage = "The Credit Amount field is required.")]
        public decimal CreditAmount { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public Customer? Customer { get; set; }
        [JsonIgnore]
        public Invoice? Invoice { get; set; }
    }
}
