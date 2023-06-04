using InventoryAPI.Entities;
using InventoryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InventoryAPI.Data.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _context;
        public InvoiceRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddInvoiceAsync(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Added;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateInvoiceAsync(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }
        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Where(x => x.InvoiceID == id)
                .Where(x => x.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Invoice>> GetInvoicesByCustomerIdAsync(int id)
        {
            return await _context.Invoices
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Where(x => x.CustomerID == id)
                .Where(x => x.IsDeleted == false)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
