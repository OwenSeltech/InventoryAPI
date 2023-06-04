using AutoMapper;
using InventoryAPI.DTOs;
using InventoryAPI.Entities;
using InventoryAPI.Interfaces;

namespace InventoryAPI.Services
{
    public class CreditNoteService : ICreditNoteService
    {
        private readonly ICreditNoteRepository _creditNoteRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        public CreditNoteService(ICreditNoteRepository creditNoteRepository, IMapper mapper, ICustomerRepository customerRepository, IInvoiceRepository invoiceRepository)
        {
            _mapper = mapper;
            _creditNoteRepository = creditNoteRepository;
            _customerRepository = customerRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<ResponseDto> AddCreditNote(CreditNoteRequestDto creditNoteRequestDto)
        {
            var responseDto = new ResponseDto();
            var creditNote = new CreditNote();

            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(creditNoteRequestDto.InvoiceID);
            if (invoice == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Invoice Not Found";
                return responseDto;
            }

            if (creditNoteRequestDto.CreditAmount < 0)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Credit Amount Should be greater than Zero";
                return responseDto;
            }
            if (creditNoteRequestDto.CreditAmount > invoice.InvoiceAmount)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Sorry Credit Amount should not be greater than the invoice amonunt";
                return responseDto;
            }

            creditNoteRequestDto.Invoice = invoice;
            creditNoteRequestDto.Customer = invoice.Customer;
            creditNoteRequestDto.CustomerID = invoice.CustomerID;
            _mapper.Map(creditNoteRequestDto, creditNote);
            if (await _creditNoteRepository.AddCreditNoteAsync(creditNote))
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = true;
                responseDto.Message = "CreditNote added successfully";
                return responseDto;
            }

            responseDto = new ResponseDto();
            responseDto.IsSuccess = false;
            responseDto.Message = "Failed to add CreditNote";
            return responseDto;

        }

        public async Task<ResponseDto> EditCreditNote(CreditNoteRequestDto creditNoteRequestDto)
        {
            var responseDto = new ResponseDto();
            var creditNote = new CreditNote();

            var creditNoteResponse = await _creditNoteRepository.GetCreditNoteByIdAsync(creditNoteRequestDto.CreditNoteID);
            if (creditNoteResponse == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "CreditNote Does Not Exist";
                return responseDto;
            }

            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(creditNoteRequestDto.InvoiceID);
            if (invoice == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Invoice Not Found";
                return responseDto;
            }

            if (creditNoteRequestDto.CreditAmount < 0)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Credit Amount Should be greater than Zero";
                return responseDto;
            }
            if (creditNoteRequestDto.CreditAmount > invoice.InvoiceAmount )
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Sorry Credit Amount should not be greater than the invoice amonunt";
                return responseDto;
            }
            creditNoteRequestDto.Invoice = invoice;
            creditNoteRequestDto.Customer = invoice.Customer;
            creditNoteRequestDto.CustomerID = invoice.CustomerID;
            _mapper.Map(creditNoteRequestDto, creditNote);
            if (await _creditNoteRepository.UpdateCreditNoteAsync(creditNote))
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = true;
                responseDto.Message = "CreditNote edited successfully";
                return responseDto;
            }

            responseDto = new ResponseDto();
            responseDto.IsSuccess = false;
            responseDto.Message = "Failed to edit CreditNote";
            return responseDto;

        }

        public async Task<ResponseDto> DeleteCreditNote(int creditNoteId)
        {
            var responseDto = new ResponseDto();

            var creditNote = await _creditNoteRepository.GetCreditNoteByIdAsync(creditNoteId);
            if (creditNote == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "CreditNote Does Not Exist";
                return responseDto;
            }

            creditNote.IsDeleted = true;
            creditNote.DateDeleted = DateTime.Now;

            if (await _creditNoteRepository.UpdateCreditNoteAsync(creditNote))
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = true;
                responseDto.Message = "CreditNote deleted successfully";
                return responseDto;
            }

            responseDto = new ResponseDto();
            responseDto.IsSuccess = false;
            responseDto.Message = "Failed to delete CreditNote";
            return responseDto;

        }

        public async Task<IEnumerable<CreditNote>> GetAllCreditNotes()
        {
            var creditNotes = await _creditNoteRepository.GetAllCreditNotesAsync();
            return creditNotes;
        }
        public async Task<CreditNote> GetCreditNoteById(int Id)
        {
            var creditNote = await _creditNoteRepository.GetCreditNoteByIdAsync(Id);
            return creditNote;
        }
    }
}
