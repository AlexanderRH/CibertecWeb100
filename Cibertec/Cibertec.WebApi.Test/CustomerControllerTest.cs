using Cibertec.WebApi.Controllers;
using Cibertec.Repositories.Dapper.Northwind;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Cibertec.Models;
using System.Collections.Generic;
using FluentAssertions;
using Cibertec.UnitOfWork;
using Cibertec.Mocked;

namespace Cibertec.WebApi.Test
{
    public class CustomerControllerTest
    {
        private readonly CustomerController _customerController;
        private readonly IUnitOfWork _unitMocked;

        public CustomerControllerTest()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstance();
            _customerController = new CustomerController(_unitMocked);
        }

        [Fact]
        public void Test_GetAll()
        {
            var result = _customerController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Customer>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Test_GetById()
        {
            var result = _customerController.GetById(10) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Post()
        {
            var customer = GetNewCustomer();

            var result = _customerController.Post(customer) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Put()
        {
            var customer = GetNewCustomer();
            customer.Id = 10;
            customer.City = "Trujillo";

            var result = _customerController.Put(customer) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Delete()
        {
            var customer = GetNewCustomer();
            var resultCreate = _customerController.Post(customer) as OkObjectResult;
            resultCreate.Should().NotBeNull();
            resultCreate.Value.Should().NotBeNull();

            var result = _customerController.Delete(customer.Id) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        private Customer GetNewCustomer()
        {
            return new Customer
            {
                City = "Lima",
                Country = "Peru",
                FirstName = "Alexander",
                LastName = "Rodriguez",
                Phone = "555-555-555"
            };
        }
    }
}
