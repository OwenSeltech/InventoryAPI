using InventoryAPI.DTOs;
using InventoryAPI.Entities;
using InventoryAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    public class CreditNoteController : BaseApiController
    {
        private readonly ICreditNoteService _creditNoteService;
        public CreditNoteController(ICreditNoteService creditNoteService)
        {
            _creditNoteService = creditNoteService;
        }
        [HttpPost("addCreditNote")]
        public async Task<ActionResult<ResponseDto>> AddCreditNote(CreditNoteRequestDto requestDto)
        {
            var response = await _creditNoteService.AddCreditNote(requestDto);
            if (!response.IsSuccess) return BadRequest(response.Message);
            else return NoContent();
        }

        [HttpPost("updateCreditNote")]
        public async Task<ActionResult<ResponseDto>> UpdateCreditNote(CreditNoteRequestDto requestDto)
        {
            var response = await _creditNoteService.EditCreditNote(requestDto);
            if (!response.IsSuccess) return BadRequest(response.Message);
            else return NoContent();
        }
        [HttpPost("deleteCreditNote/{creditNoteId}")]
        public async Task<ActionResult<ResponseDto>> DeleteCreditNote(int creditNoteId)
        {
            var response = await _creditNoteService.DeleteCreditNote(creditNoteId);
            if (!response.IsSuccess) return BadRequest(response.Message);
            else return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<CreditNote>> GetAllCreditNotes()
        {
            var response = await _creditNoteService.GetAllCreditNotes();
            return Ok(response);
        }

        [HttpGet("{creditNoteId}")]
        public async Task<ActionResult<CreditNote>> GetCreditNote(int creditNoteId)
        {
            var response = await _creditNoteService.GetCreditNoteById(creditNoteId);
            return Ok(response);
        }
    }
}
