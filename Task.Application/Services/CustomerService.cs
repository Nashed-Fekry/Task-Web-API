using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Interfaces;
using Task.Core.Model;
using Task.Core.DTO;

namespace Task.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> AddCustomerAsync(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var addedCustomer = await _customerRepository.AddAsync(customer);
            return _mapper.Map<CustomerDTO>(addedCustomer);
        }
    }

}
