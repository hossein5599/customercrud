using AutoMapper;
using Domain.Entities.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MohammadHosseinSadeghiCrudTest.AutoMapping;
using MohammadHosseinSadeghiCrudTest.Controllers;
using MohammadHosseinSadeghiCrudTest.Infrustracture;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject
{
    public class CustomerUnitTest
    {
       
        /// <summary>
        /// به علت تنگی وقت فقط یه نمونه تست را گذاشتم که یعنی بلدم
        /// </summary>



            #region Property  
        public Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        #endregion
        private static IMapper _mapper;
        //  private static Microsoft.Extensions.Logging.ILogger _logger;
        //private Microsoft.Extensions.Logging.ILogger _logger;
        private static ILogger<CustomersController> _logger;
        public CustomerUnitTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            if (_logger == null)
            {
                var mock = new Mock<ILogger<CustomersController>>();
                _logger = mock.Object;
            }



        

        }

        [Fact]
        public async void Index()
        {



            List<Customer> customers = new List<Customer>()
            {
                new Customer { Id = 1, FirstName = "hossein", LastName ="sadeghi",PhoneNumber = "09010192167", Email = "m.hossein.sadeghi@gmail.com" ,BankAccountNumber = "1212121212121212" , DateOfBirth = new DateTime(1989,2,24)  },
                new Customer { Id = 2, FirstName = "ali", LastName ="akbari",PhoneNumber = "09010192167", Email = "ssein.sadeghi@gmail.com" ,BankAccountNumber = "1212121212121212" , DateOfBirth = new DateTime(1989,2,24)  },

            };

           

            mock.Setup(p => p.Customer.GetAllAsync()).ReturnsAsync(customers);
            //Arrange
            CustomersController cust = new CustomersController(mock.Object, _mapper, _logger);
            //Act
            var result = await cust.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
            
            //Assert.Equal("Index", result.ViewName);


        }
       
    }
}

