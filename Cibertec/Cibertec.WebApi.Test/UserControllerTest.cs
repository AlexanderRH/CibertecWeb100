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
    public class UserControllerTest
    {
        private readonly UserController _userController;

        public UserControllerTest()
        {
            _userController = new UserController
                (
                    new NorthwindUnitOfWork(ConfigSettings.NorthwindConnectionString)
                );
        }

        [Fact]
        public void Test_GetAll()
        {
            var result = _userController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<User>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Test_GetById()
        {
            var result = _userController.GetById(1) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Post()
        {
            var user = GetNewUser();

            var result = _userController.Post(user) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Put()
        {
            var user = GetNewUser();
            user.Id = 1;
            user.LastName = "Velarde.";

            var result = _userController.Put(user) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Delete()
        {
            var user = GetNewUser();
            var resultCreate = _userController.Post(user) as OkObjectResult;
            resultCreate.Should().NotBeNull();
            resultCreate.Value.Should().NotBeNull();

            var result = _userController.Delete(user) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        private User GetNewUser()
        {
            return new User
            {
                Email = "alexrod2121@gmail.com",
                FirstName = "Alexander",
                LastName = "Rodriguez",
                Password = "password",
                Roles = "admin"
            };
        }
    }
}
