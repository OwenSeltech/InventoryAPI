using InventoryAPI.DTOs;
using InventoryAPI.Entities;
using InventoryAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
	public class ProductController : BaseApiController
	{
		private readonly IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpPost("addProduct")]
		public async Task<ActionResult<ResponseDto>> AddProduct(ProductRequestDto requestDto)
		{
			var response = await _productService.AddProduct(requestDto);
			if (!response.IsSuccess) return BadRequest(response.Message);
			else return NoContent();
		}

		[HttpPost("updateProduct")]
		public async Task<ActionResult<ResponseDto>> UpdateProduct(ProductRequestDto requestDto)
		{
			var response = await _productService.EditProduct(requestDto);
			if (!response.IsSuccess) return BadRequest(response.Message);
			else return NoContent();
		}
		[HttpPost("deleteProduct/{productId}")]
		public async Task<ActionResult<ResponseDto>> DeleteProduct(int productId)
		{
			var response = await _productService.DeleteProduct(productId);
			if (!response.IsSuccess) return BadRequest(response.Message);
			else return NoContent();
		}

		[HttpGet]
		public async Task<ActionResult<Product>> GetAllProducts()
		{
			var response = await _productService.GetAllProducts();
			return Ok(response);
		}

		[HttpGet("{productId}")]
		public async Task<ActionResult<Product>> GetProduct(int productId)
		{
			var response = await _productService.GetProductById(productId);
			return Ok(response);
		}

	}
}
