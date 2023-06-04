using InventoryAPI.DTOs;
using InventoryAPI.Entities;

namespace InventoryAPI.Interfaces
{
    public interface ICreditNoteService
    {
        Task<ResponseDto> AddCreditNote(CreditNoteRequestDto creditNoteRequestDto);
        Task<ResponseDto> EditCreditNote(CreditNoteRequestDto creditNoteRequestDto);
        Task<IEnumerable<CreditNote>> GetAllCreditNotes();
        Task<CreditNote> GetCreditNoteById(int Id);
        Task<ResponseDto> DeleteCreditNote(int CreditNoteId);
    }
}
