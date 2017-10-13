using Cibertec.WebApi.Controllers;
using Cibertec.Repositories.Dapper.Northwind;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Cibertec.Models;
using System.Collections.Generic;
using FluentAssertions;
using System;

namespace Cibertec.WebApi.Test
{
    public class OrderControllerTest
    {
        private readonly OrderController _orderController;

        public OrderControllerTest()
        {
            _orderController = new OrderController
                (
                    new NorthwindUnitOfWork(ConfigSettings.NorthwindConnectionString)
                );
        }

        [Fact]
        public void Test_GetAll()
        {
            var result = _orderController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Order>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Test_GetById()
        {
            var result = _orderController.GetById(23) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Post()
        {
            var order = GetNewOrder();

            var result = _orderController.Post(order) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Put()
        {
            var order = GetNewOrder();
            order.Id = 23;
            order.OrderNumber = "546545";

            var result = _orderController.Put(order) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Delete()
        {
            var order = GetNewOrder();
            var resultCreate = _orderController.Post(order) as OkObjectResult;
            resultCreate.Should().NotBeNull();
            resultCreate.Value.Should().NotBeNull();

            var result = _orderController.Delete(order) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        private Order GetNewOrder()
        {
            return new Order
            {
                OrderDate = DateTime.Now,
                OrderNumber = "154547",
                CustomerId = 10,
                TotalAmount = 100
    };
        }
    }
}
