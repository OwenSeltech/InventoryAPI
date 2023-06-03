using InventoryAPI.DTOs;
using InventoryAPI.Entities;

namespace InventoryAPI.Interfaces
{
    public interface IInvoiceService
    {
        Task<ResponseDto> AddInvoice(InvoiceRequestDto invoiceRequestDto);
        Task<ResponseDto> EditInvoice(InvoiceRequestDto invoiceRequestDto);
        Task<IEnumerable<Invoice>> GetAllInvoices();
        Task<Invoice> GetInvoiceById(int Id);
        Task<ResponseDto> DeleteInvoice(int InvoiceId);
    }
}
