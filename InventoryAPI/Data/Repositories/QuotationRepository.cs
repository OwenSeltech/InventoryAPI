using InventoryAPI.Entities;
using InventoryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly DataContext _context;
        public QuotationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddQuotationAsync(Quotation quotation)
        {
            _context.Entry(quotation).State = EntityState.Added;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateQuotationAsync(Quotation quotation)
        {
            _context.Entry(quotation).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Quotation>> GetAllQuotationsAsync()
        {
            return await _context.Quotations
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }
        public async Task<Quotation> GetQuotationByIdAsync(int id)
        {
            return await _context.Quotations
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Where(x => x.QuotationID == id)
                .Where(x => x.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
