using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Entities
{
	public class Product
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public int InventoryQuantity { get; set; }
		public decimal Price { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime DateAdded { get; set; }
		public bool IsDeleted { get; set; } = false;
		public DateTime? DateDeleted { get; set; }
	}
}
