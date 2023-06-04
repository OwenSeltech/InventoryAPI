using AutoMapper;
using InventoryAPI.DTOs;
using InventoryAPI.Entities;
using InventoryAPI.Interfaces;

namespace InventoryAPI.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepository _quotationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public QuotationService(IQuotationRepository quotationRepository, IMapper mapper, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _quotationRepository = quotationRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<ResponseDto> AddQuotation(QuotationRequestDto quotationRequestDto)
        {
            var responseDto = new ResponseDto();
            var quotation = new Quotation();

            var cust = await _customerRepository.GetCustomerByIdAsync(quotationRequestDto.CustomerID);
            if (cust == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Customer Not Found";
                return responseDto;
            }
            var product = await _productRepository.GetProductByIdAsync(quotationRequestDto.ProductID);
            if (product == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Product Not Found";
                return responseDto;
            }
            if (quotationRequestDto.ItemsNo < 0)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Number of Items Must Be Greater than 0";
                return responseDto;
            }

            quotationRequestDto.Product = product;
            quotationRequestDto.Customer = cust;
            quotationRequestDto.QuotationAmount = product.Price * quotationRequestDto.ItemsNo;
            _mapper.Map(quotationRequestDto, quotation);
            if (await _quotationRepository.AddQuotationAsync(quotation))
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = true;
                responseDto.Message = "Quotation added successfully";
                return responseDto;
            }

            responseDto = new ResponseDto();
            responseDto.IsSuccess = false;
            responseDto.Message = "Failed to add Quotation";
            return responseDto;

        }

        public async Task<ResponseDto> EditQuotation(QuotationRequestDto quotationRequestDto)
        {
            var responseDto = new ResponseDto();
            var quotation = new Quotation();

            var quotationResponse = await _quotationRepository.GetQuotationByIdAsync(quotationRequestDto.QuotationID);
            if (quotationResponse == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Quotation Does Not Exist";
                return responseDto;
            }

            var cust = await _customerRepository.GetCustomerByIdAsync(quotationRequestDto.CustomerID);
            if (cust == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Customer Not Found";
                return responseDto;
            }
            var product = await _productRepository.GetProductByIdAsync(quotationRequestDto.ProductID);
            if (product == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Product Not Found";
                return responseDto;
            }
            if (quotationRequestDto.ItemsNo < 0)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Number of Items Must Be Greater than 0";
                return responseDto;
            }

            quotationRequestDto.Product = product;
            quotationRequestDto.Customer = cust;
            quotationRequestDto.QuotationAmount = product.Price * quotationRequestDto.ItemsNo;
            _mapper.Map(quotationRequestDto, quotation);
            if (await _quotationRepository.UpdateQuotationAsync(quotation))
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = true;
                responseDto.Message = "Quotation edited successfully";
                return responseDto;
            }

            responseDto = new ResponseDto();
            responseDto.IsSuccess = false;
            responseDto.Message = "Failed to edit Quotation";
            return responseDto;

        }

        public async Task<ResponseDto> DeleteQuotation(int quotationId)
        {
            var responseDto = new ResponseDto();

            var quotation = await _quotationRepository.GetQuotationByIdAsync(quotationId);
            if (quotation == null)
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = false;
                responseDto.Message = "Quotation Does Not Exist";
                return responseDto;
            }

            quotation.IsDeleted = true;
            quotation.DateDeleted = DateTime.Now;

            if (await _quotationRepository.UpdateQuotationAsync(quotation))
            {
                responseDto = new ResponseDto();
                responseDto.IsSuccess = true;
                responseDto.Message = "Quotation deleted successfully";
                return responseDto;
            }

            responseDto = new ResponseDto();
            responseDto.IsSuccess = false;
            responseDto.Message = "Failed to delete Quotation";
            return responseDto;

        }

        public async Task<IEnumerable<Quotation>> GetAllQuotations()
        {
            var quotations = await _quotationRepository.GetAllQuotationsAsync();
            return quotations;
        }
        public async Task<Quotation> GetQuotationById(int Id)
        {
            var quotation = await _quotationRepository.GetQuotationByIdAsync(Id);
            return quotation;
        }
    }
}
