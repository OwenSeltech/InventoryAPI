using InventoryAPI.Entities;

namespace InventoryAPI.Interfaces
{
    public interface IQuotationRepository
    {
        Task<bool> AddQuotationAsync(Quotation quotation);
        Task<bool> UpdateQuotationAsync(Quotation quotation);
        Task<IEnumerable<Quotation>> GetAllQuotationsAsync();
        Task<Quotation> GetQuotationByIdAsync(int id);
    }
}
