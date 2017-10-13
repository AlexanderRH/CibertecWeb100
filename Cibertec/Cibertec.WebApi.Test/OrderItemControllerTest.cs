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
    public class OrderItemControllerTest
    {
        private readonly OrderItemController _orderItemController;

        public OrderItemControllerTest()
        {
            _orderItemController = new OrderItemController
                (
                    new NorthwindUnitOfWork(ConfigSettings.NorthwindConnectionString)
                );
        }

        [Fact]
        public void Test_GetAll()
        {
            var result = _orderItemController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<OrderItem>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Test_GetById()
        {
            var result = _orderItemController.GetById(23) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Post()
        {
            var orderItem = GetNewOrderItem();

            var result = _orderItemController.Post(orderItem) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Put()
        {
            var orderItem = GetNewOrderItem();
            orderItem.Id = 23;
            orderItem.UnitPrice = 20;

            var result = _orderItemController.Put(orderItem) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Delete()
        {
            var orderItem = GetNewOrderItem();
            var resultCreate = _orderItemController.Post(orderItem) as OkObjectResult;
            resultCreate.Should().NotBeNull();
            resultCreate.Value.Should().NotBeNull();

            var result = _orderItemController.Delete(orderItem) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        private OrderItem GetNewOrderItem()
        {
            return new OrderItem
            {
                OrderId = 2,
                ProductId = 77,
                UnitPrice = 12,
                Quantity = 2
            };
        }
    }
}
