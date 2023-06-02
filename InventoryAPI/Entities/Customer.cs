using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Entities
{
	public class Customer
	{
		public int CustomerID { get; set; }
		public string CustomerFirstName { get; set; }
		public string CustomerLastName { get; set; }
		public string CustomerAddress { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime DateAdded { get; set; }
		public bool IsDeleted { get; set; } = false;
		public DateTime? DateDeleted { get; set; }
	}
}
