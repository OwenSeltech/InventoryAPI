using AutoMapper;
using InventoryAPI.DTOs;
using InventoryAPI.Entities;
using InventoryAPI.Interfaces;

namespace InventoryAPI.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<ResponseDto> AddInvoice(InvoiceRequestDto invoiceRequestDto)
        {
            var responseDto = new ResponseDto();
            var invoice = new Invoice();

            var cust = await _customerRepository.GetCustomerByIdAsync(invoiceRequestDto.CustomerID);
            if(cust == null) 
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Customer Not Found";
                return responseDto;
            }
            var product = await _productRepository.GetProductByIdAsync(invoiceRequestDto.ProductID);
            if (product == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Product Not Found";
                return responseDto;
            }
            if (invoiceRequestDto.ItemsNo < 0)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Number of Items Must Be Greater than 0";
                return responseDto;
            }

            invoiceRequestDto.Product = product;
            invoiceRequestDto.Customer = cust;
            invoiceRequestDto.InvoiceAmount = product.Price * invoiceRequestDto.ItemsNo;
            _mapper.Map(invoiceRequestDto, invoice);
            if (await _invoiceRepository.AddInvoiceAsync(invoice))
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = true;
                responseDto.Message = "Invoice added successfully";
                return responseDto;
            }

            responseDto = new ResponseDto();
            responseDto.IsSuccess = false;
            responseDto.Message = "Failed to add Invoice";
            return responseDto;

        }

        public async Task<ResponseDto> EditInvoice(InvoiceRequestDto invoiceRequestDto)
        {
            var responseDto = new ResponseDto();
            var invoice = new Invoice();

            var invoiceResponse = await _invoiceRepository.GetInvoiceByIdAsync(invoiceRequestDto.InvoiceID);
            if (invoiceResponse == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Invoice Does Not Exist";
                return responseDto;
            }

            var cust = await _customerRepository.GetCustomerByIdAsync(invoiceRequestDto.CustomerID);
            if (cust == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Customer Not Found";
                return responseDto;
            }
            var product = await _productRepository.GetProductByIdAsync(invoiceRequestDto.ProductID);
            if (product == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Product Not Found";
                return responseDto;
            }
            if (invoiceRequestDto.ItemsNo < 0)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Number of Items Must Be Greater than 0";
                return responseDto;
            }

            invoiceRequestDto.Product = product;
            invoiceRequestDto.Customer = cust;
            invoiceRequestDto.InvoiceAmount = product.Price * invoiceRequestDto.ItemsNo;
            _mapper.Map(invoiceRequestDto, invoice);
            if (await _invoiceRepository.UpdateInvoiceAsync(invoice))
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = true;
                responseDto.Message = "Invoice edited successfully";
                return responseDto;
            }

            responseDto = new ResponseDto();
            responseDto.IsSuccess = false;
            responseDto.Message = "Failed to edit Invoice";
            return responseDto;

        }

        public async Task<ResponseDto> DeleteInvoice(int invoiceId)
        {
            var responseDto = new ResponseDto();

            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(invoiceId);
            if (invoice == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Invoice Does Not Exist";
                return responseDto;
            }

            invoice.IsDeleted = true;
            invoice.DateDeleted = DateTime.Now;

            if (await _invoiceRepository.UpdateInvoiceAsync(invoice))
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = true;
                responseDto.Message = "Invoice deleted successfully";
                return responseDto;
            }

            responseDto = new ResponseDto();
            responseDto.IsSuccess = false;
            responseDto.Message = "Failed to delete Invoice";
            return responseDto;

        }

        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            var invoices = await _invoiceRepository.GetAllInvoicesAsync();
            return invoices;
        }
        public async Task<Invoice> GetInvoiceById(int Id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(Id);
            return invoice;
        }

    }
}
