using InventoryAPI.Entities;

namespace InventoryAPI.Interfaces
{
    public interface ICreditNoteRepository
    {
        Task<bool> AddCreditNoteAsync(CreditNote creditNote);
        Task<bool> UpdateCreditNoteAsync(CreditNote creditNote);
        Task<IEnumerable<CreditNote>> GetAllCreditNotesAsync();
        Task<CreditNote> GetCreditNoteByIdAsync(int id);
    }
}
