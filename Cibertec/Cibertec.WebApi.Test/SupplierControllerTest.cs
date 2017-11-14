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
    public class SupplierControllerTest
    {
        private readonly SupplierController _supplierController;

        public SupplierControllerTest()
        {
            _supplierController = new SupplierController
                (
                    new NorthwindUnitOfWork(ConfigSettings.NorthwindConnectionString)
                );
        }

        [Fact]
        public void Test_GetAll()
        {
            var result = _supplierController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Supplier>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Test_GetById()
        {
            var result = _supplierController.GetById(11) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Post()
        {
            var supplier = GetNewSupplier();

            var result = _supplierController.Post(supplier) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Put()
        {
            var supplier = GetNewSupplier();
            supplier.Id = 18;
            supplier.ContactTitle = "Otro Titulo";

            var result = _supplierController.Put(supplier) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Delete()
        {
            var supplier = GetNewSupplier();
            var resultCreate = _supplierController.Post(supplier) as OkObjectResult;
            resultCreate.Should().NotBeNull();
            resultCreate.Value.Should().NotBeNull();

            var result = _supplierController.Delete(supplier.Id) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        private Supplier GetNewSupplier()
        {
            return new Supplier
            {
                CompanyName = "Nueva Compañia",
                ContactName = "Nuevo Contacto",
                ContactTitle = "Nuevo Titulo",
                City = "Boston",
                Country = "USA",
                Phone = "545787",
                Fax = "546654"
            };
        }
    }
}
