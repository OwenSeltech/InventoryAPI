using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTOs
{
	public class ProductRequestDto
	{
		[Required(ErrorMessage = "The Product Name field is required.")]
		public string ProductName { get; set; }
		[Required(ErrorMessage = "The Inventory Quantity field is required.")]
		public int InventoryQuantity { get; set; }
		[Required(ErrorMessage = "The Price field is required.")]
		public decimal Price { get; set; }
		public int ProductID { get; set; }
		

	}
}
