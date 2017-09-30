using Cibertec.Models;
using Cibertec.Repositories.Dapper.Northwind;
using System;
using System.Linq;
using Xunit;

namespace Cibertec.Repositories.DapperTest
{
    public class CustomerRepositoryTest
    {
        private readonly NorthwindUnitOfWork repo;

        public CustomerRepositoryTest()
        {
            repo = new NorthwindUnitOfWork("Server=.;Database=Northwind_Lite; Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        [Fact(DisplayName = "[CustomerRepository] GelAll")]
        public void Customer_Repository_GetAll()
        {
            var result = repo.Customer.GetList();
            Assert.True(result.Count() > 0);
        }

        [Fact(DisplayName = "[CustomerRepository] Insert")]
        public void Customer_Repository_Insert()
        {
            var customer = GetNewCustomer();
            var result = repo.Customer.Insert(customer);
            Assert.True(result > 0);
        }

        [Fact(DisplayName = "[CustomerRepository] Delete")]
        public void Customer_Repository_Delete()
        {
            Customer customer = GetNewCustomer();
            var result = repo.Customer.Insert(customer);
            Assert.True(repo.Customer.Delete(customer));
        }

        private Customer GetNewCustomer()
        {
            return new Customer
            {
                City = "Lima",
                Country = "Peru",
                FirstName = "Julio",
                LastName = "Velarde",
                Phone = "555-555-555"
            };
        }

        [Fact(DisplayName = "[CustomerRepository] Update")]
        public void Customer_Repository_Update()
        {
            var customer = repo.Customer.GetById(10);
            Assert.True(customer != null);

            customer.FirstName = $"Today {DateTime.Now.ToShortDateString()}";
            Assert.True(repo.Customer.Update(customer));
        }

        [Fact(DisplayName = "[CustomerRepository] GetById")]
        public void Customer_Repository_GetById()
        {
            var customer = repo.Customer.GetById(10);
            Assert.True(customer != null);
        }

        [Fact(DisplayName = "[CustomerRepository] SearchByNames")]
        public void Customer_Repository_SearchByNames()
        {
            var customer = repo.Customer.SearchByNames("Julio", "Velarde");
            Assert.True(customer != null);
        }
    }
}
