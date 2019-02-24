using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Bookly.DTOs;
using Bookly.Models;

namespace Bookly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}