using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Context;
using Task.Core.DTO;
using Task.Core.Interfaces;
using Task.Core.Model;

namespace Task.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            var addedOrder = await _orderRepository.AddAsync(order);
            return _mapper.Map<OrderDTO>(addedOrder);
        }
    }


}
