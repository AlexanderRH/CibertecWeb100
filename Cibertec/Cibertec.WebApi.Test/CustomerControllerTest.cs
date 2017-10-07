using Cibertec.WebApi.Controllers;
using Cibertec.Repositories.Dapper.Northwind;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Cibertec.Models;
using System.Collections.Generic;
using FluentAssertions;

namespace Cibertec.WebApi.Test
{
    public class CustomerControllerTest
    {
        private readonly CustomerController _customerController;

        public CustomerControllerTest()
        {
            _customerController = new CustomerController
                (
                    new NorthwindUnitOfWork(ConfigSettings.NorthwindConnectionString)
                );
        }

        [Fact]
        public void Test_Get_All()
        {
            var result = _customerController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Customer>;
            model.Count.Should().BeGreaterThan(0);
        }
    }
}
