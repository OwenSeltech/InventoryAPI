using InventoryAPI.Entities;
using InventoryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly DataContext _context;
		public ProductRepository(DataContext context)
		{
			_context = context;
		}
		public async Task<bool> AddProductAsync(Product product)
		{
			_context.Entry(product).State = EntityState.Added;
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> UpdateProductAsync(Product product)
		{
			_context.Entry(product).State = EntityState.Modified;
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<IEnumerable<Product>> GetAllProductsAsync()
		{
			return await _context.Products.Where(x => x.IsDeleted == false).ToListAsync();
		}
		public async Task<Product> GetProductByIdAsync(int id)
		{
			return await _context.Products
				.Where(x => x.ProductID == id)
				.Where(x => x.IsDeleted == false)
				.AsNoTracking()
				.FirstOrDefaultAsync();
		}
		public async Task<Product> GetProductByNameAsync(string name)
		{
			return await _context.Products
				.Where(o => o.ProductName.ToLower().Trim() == name.ToLower().Trim())
				.Where(x => x.IsDeleted == false)
				.AsNoTracking()
				.FirstOrDefaultAsync();
		}
		public bool ProductExists(string product)
		{
			return _context.Products.Any(o => o.ProductName.ToLower().Trim() == product.ToLower().Trim());
		}

	}
}
