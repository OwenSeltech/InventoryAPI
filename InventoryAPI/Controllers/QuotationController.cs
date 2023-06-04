using InventoryAPI.DTOs;
using InventoryAPI.Entities;
using InventoryAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    public class QuotationController : BaseApiController
    {
        private readonly IQuotationService _quotationService;
        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }
        [HttpPost("addQuotation")]
        public async Task<ActionResult<ResponseDto>> AddQuotation(QuotationRequestDto requestDto)
        {
            var response = await _quotationService.AddQuotation(requestDto);
            if (!response.IsSuccess) return BadRequest(response.Message);
            else return NoContent();
        }

        [HttpPost("updateQuotation")]
        public async Task<ActionResult<ResponseDto>> UpdateQuotation(QuotationRequestDto requestDto)
        {
            var response = await _quotationService.EditQuotation(requestDto);
            if (!response.IsSuccess) return BadRequest(response.Message);
            else return NoContent();
        }
        [HttpPost("deleteQuotation/{quotationId}")]
        public async Task<ActionResult<ResponseDto>> DeleteQuotation(int quotationId)
        {
            var response = await _quotationService.DeleteQuotation(quotationId);
            if (!response.IsSuccess) return BadRequest(response.Message);
            else return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<Quotation>> GetAllQuotations()
        {
            var response = await _quotationService.GetAllQuotations();
            return Ok(response);
        }

        [HttpGet("{quotationId}")]
        public async Task<ActionResult<Quotation>> GetQuotation(int quotationId)
        {
            var response = await _quotationService.GetQuotationById(quotationId);
            return Ok(response);
        }
    }
}
