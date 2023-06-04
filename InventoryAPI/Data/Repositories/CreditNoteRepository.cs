using InventoryAPI.Entities;
using InventoryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data.Repositories
{
    public class CreditNoteRepository : ICreditNoteRepository
    {

        private readonly DataContext _context;
        public CreditNoteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCreditNoteAsync(CreditNote creditNote)
        {
            _context.Entry(creditNote).State = EntityState.Added;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCreditNoteAsync(CreditNote creditNote)
        {
            _context.Entry(creditNote).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CreditNote>> GetAllCreditNotesAsync()
        {
            return await _context.CreditNotes
                .Include(x => x.Customer)
                .Include(x => x.Invoice)
                .Include(x => x.Invoice.Product)
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }
        public async Task<CreditNote> GetCreditNoteByIdAsync(int id)
        {
            return await _context.CreditNotes
                .Include(x => x.Customer)
                .Include(x => x.Invoice)
                .Include(x => x.Invoice.Product)
                .Where(x => x.CreditNoteID == id)
                .Where(x => x.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
