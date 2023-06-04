using InventoryAPI.DTOs;
using InventoryAPI.Entities;

namespace InventoryAPI.Interfaces
{
    public interface IQuotationService
    {
        Task<ResponseDto> AddQuotation(QuotationRequestDto quotationRequestDto);
        Task<ResponseDto> EditQuotation(QuotationRequestDto quotationRequestDto);
        Task<IEnumerable<Quotation>> GetAllQuotations();
        Task<Quotation> GetQuotationById(int Id);
        Task<ResponseDto> DeleteQuotation(int QuotationId);
    }
}
