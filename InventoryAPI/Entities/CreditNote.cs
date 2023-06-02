using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Entities
{
	public class CreditNote
	{
		public int CreditNoteID { get; set; }
		public int CustomerID { get; set; }
		public int InvoiceID { get; set; }
		public decimal CreditAmount { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime DateAdded { get; set; } 
		public bool IsDeleted { get; set; } = false;
		public DateTime? DateDeleted { get; set; }
		public Customer Customer { get; set; }
		public Invoice Invoice { get; set; }
	}
}
