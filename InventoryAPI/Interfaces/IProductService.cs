using InventoryAPI.Data.Repositories;
using InventoryAPI.DTOs;
using InventoryAPI.Entities;

namespace InventoryAPI.Interfaces
{
	public interface IProductService
	{
		Task<ResponseDto> AddProduct(ProductRequestDto productRequestDto);
		Task<ResponseDto> EditProduct(ProductRequestDto productRequestDto);
		Task<IEnumerable<Product>> GetAllProducts();
		Task<Product> GetProductById(int Id);
		Task<ResponseDto> DeleteProduct(int productId);
	}
}
