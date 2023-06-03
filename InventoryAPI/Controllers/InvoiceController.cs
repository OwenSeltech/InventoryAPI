using InventoryAPI.DTOs;
using InventoryAPI.Entities;
using InventoryAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    public class InvoiceController : BaseApiController
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpPost("addInvoice")]
        public async Task<ActionResult<ResponseDto>> AddInvoice(InvoiceRequestDto requestDto)
        {
            var response = await _invoiceService.AddInvoice(requestDto);
            if (!response.IsSuccess) return BadRequest(response.Message);
            else return NoContent();
        }

        [HttpPost("updateInvoice")]
        public async Task<ActionResult<ResponseDto>> UpdateInvoice(InvoiceRequestDto requestDto)
        {
            var response = await _invoiceService.EditInvoice(requestDto);
            if (!response.IsSuccess) return BadRequest(response.Message);
            else return NoContent();
        }
        [HttpPost("deleteInvoice/{invoiceId}")]
        public async Task<ActionResult<ResponseDto>> DeleteInvoice(int invoiceId)
        {
            var response = await _invoiceService.DeleteInvoice(invoiceId);
            if (!response.IsSuccess) return BadRequest(response.Message);
            else return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<Invoice>> GetAllInvoices()
        {
            var response = await _invoiceService.GetAllInvoices();
            return Ok(response);
        }

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int invoiceId)
        {
            var response = await _invoiceService.GetInvoiceById(invoiceId);
            return Ok(response);
        }
    }
}
