using InventoryAPI.DTOs;
using InventoryAPI.Entities;

namespace InventoryAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<ResponseDto> AddCustomer(CustomerRequestDto customerRequestDto);
        Task<ResponseDto> EditCustomer(CustomerRequestDto customerRequestDto);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int Id);
        Task<ResponseDto> DeleteCustomer(int CustomerId);
    }
}
