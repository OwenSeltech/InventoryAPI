using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Entities
{
	public class Quotation
	{
		public int QuotationID { get; set; }
		public int CustomerID { get; set; }
		public int ProductID { get; set; }
		public decimal QuotationAmount { get; set; }

		public Customer Customer { get; set; }
		public Product Product { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime DateAdded { get; set; }
		public bool IsDeleted { get; set; } = false;
		public DateTime? DateDeleted { get; set; }
	}
}
