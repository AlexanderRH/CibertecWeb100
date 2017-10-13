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
    public class ProductControllerTest
    {
        private readonly ProductController _productController;

        public ProductControllerTest()
        {
            _productController = new ProductController
                (
                    new NorthwindUnitOfWork(ConfigSettings.NorthwindConnectionString)
                );
        }

        [Fact]
        public void Test_GetAll()
        {
            var result = _productController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Product>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Test_GetById()
        {
            var result = _productController.GetById(23) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Post()
        {
            var product = GetNewProduct();

            var result = _productController.Post(product) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Put()
        {
            var product = GetNewProduct();
            product.Id = 23;
            product.UnitPrice = 65;

            var result = _productController.Put(product) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Delete()
        {
            var product = GetNewProduct();
            var resultCreate = _productController.Post(product) as OkObjectResult;
            resultCreate.Should().NotBeNull();
            resultCreate.Value.Should().NotBeNull();

            var result = _productController.Delete(product) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        private Product GetNewProduct()
        {
            return new Product
            {
                ProductName = "Nuevo Producto",
                SupplierId = 12,
                UnitPrice = 5,
                Package = "10 boxes",
                IsDiscontinued = false
            };
        }
    }
}
