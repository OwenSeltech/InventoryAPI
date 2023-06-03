using InventoryAPI.Entities;

namespace InventoryAPI.Interfaces
{
    public interface IProductRepository
	{
		Task<bool> AddProductAsync(Product product);
		Task<bool> UpdateProductAsync(Product product);
		Task<IEnumerable<Product>> GetAllProductsAsync();
		Task<Product> GetProductByIdAsync(int id);
		Task<Product> GetProductByNameAsync(string name);
		public bool ProductExists(string product);
	}
}
