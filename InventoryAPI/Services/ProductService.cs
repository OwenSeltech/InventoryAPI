using AutoMapper;
using InventoryAPI.DTOs;
using InventoryAPI.Entities;
using InventoryAPI.Interfaces;

namespace InventoryAPI.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_mapper = mapper;
			_productRepository = productRepository;
		}

		public async Task<ResponseDto> AddProduct(ProductRequestDto productRequestDto)
		{
			var responseDto = new ResponseDto();
			if (_productRepository.ProductExists(productRequestDto.ProductName))
			{
				responseDto = new ResponseDto();
				responseDto.IsSuccess = false;
				responseDto.Message = "Product Name Exists";
				return responseDto;
			}

			var product = new Product();
			_mapper.Map(productRequestDto, product);
			if (await _productRepository.AddProductAsync(product))
			{
				responseDto = new ResponseDto();
				responseDto.IsSuccess = true;
				responseDto.Message = "Product added successfully";
				return responseDto;
			}

			responseDto = new ResponseDto();
			responseDto.IsSuccess = false;
			responseDto.Message = "Failed to add Product";
			return responseDto;

		}

		public async Task<ResponseDto> EditProduct(ProductRequestDto productRequestDto)
		{
			var responseDto = new ResponseDto();

			var productResponse = await _productRepository.GetProductByIdAsync(productRequestDto.ProductID);
			if (productResponse == null)
			{
				responseDto = new ResponseDto();
				responseDto.IsSuccess = false;
				responseDto.Message = "Product Does Not Exist";
				return responseDto;
			}

			if(productResponse.ProductName.Trim() != productRequestDto.ProductName.Trim())
			{
				if (_productRepository.ProductExists(productRequestDto.ProductName.Trim()))
				{
					responseDto = new ResponseDto();
					responseDto.IsSuccess = false;
					responseDto.Message = "Product Name Exist";
					return responseDto;
				}
			}

			var product = new Product();

			_mapper.Map(productRequestDto, product);
			if (await _productRepository.UpdateProductAsync(product))
			{
				responseDto = new ResponseDto();
				responseDto.IsSuccess = true;
				responseDto.Message = "Product edited successfully";
				return responseDto;
			}

			responseDto = new ResponseDto();
			responseDto.IsSuccess = false;
			responseDto.Message = "Failed to edit Product";
			return responseDto;

		}

		public async Task<ResponseDto> DeleteProduct(int productId)
		{
			var responseDto = new ResponseDto();

			var product = await _productRepository.GetProductByIdAsync(productId);
			if (product == null)
			{
				responseDto = new ResponseDto();
				responseDto.IsSuccess = false;
				responseDto.Message = "Product Does Not Exist";
				return responseDto;
			}

			product.IsDeleted = true;
			product.DateDeleted = DateTime.Now;

			if (await _productRepository.UpdateProductAsync(product))
			{
				responseDto = new ResponseDto();
				responseDto.IsSuccess = true;
				responseDto.Message = "Product deleted successfully";
				return responseDto;
			}

			responseDto = new ResponseDto();
			responseDto.IsSuccess = false;
			responseDto.Message = "Failed to delete Product";
			return responseDto;

		}

		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			var products = await _productRepository.GetAllProductsAsync();
			return products;
		}
		public async Task<Product> GetProductById(int Id)
		{
			var product = await _productRepository.GetProductByIdAsync(Id);
			return product;
		}

	}
}
