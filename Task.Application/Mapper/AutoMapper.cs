using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Task.Core.DTO;
using Task.Core.Model;

namespace Task.Application.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
         
            CreateMap<Product, ProductDTO>().ReverseMap();
           
        }
    }
}
