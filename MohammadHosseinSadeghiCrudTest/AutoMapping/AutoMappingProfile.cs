using AutoMapper;
using Domain.Entities.Customers;
using MohammadHosseinSadeghiCrudTest.Models;
using ParsianTadrisExamSadeghi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadHosseinSadeghiCrudTest.AutoMapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
         


            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();


            CreateMap<Customer, CustomerCreateDTO>();
            CreateMap<CustomerCreateDTO, Customer>();

            CreateMap<Customer, CustomerEditDTO>();
            CreateMap<CustomerEditDTO, Customer>();

        }

     
    }
}
