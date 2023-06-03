using InventoryAPI.DTOs;
using InventoryAPI.Entities;

namespace InventoryAPI.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<bool> AddInvoiceAsync(Invoice Invoice);
        Task<bool> UpdateInvoiceAsync(Invoice Invoice);
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int id);
        
    }
}
