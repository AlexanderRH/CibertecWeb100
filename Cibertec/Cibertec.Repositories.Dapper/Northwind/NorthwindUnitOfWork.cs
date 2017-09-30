using Cibertec.Repositories.Northwind;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
            OrderItem = new OrderItemRepository(connectionString);
            Order = new OrderRepository(connectionString);
            Product = new ProductRepository(connectionString);
            Supplier = new SupplierRepository(connectionString);
            User = new UserRepository(connectionString);
        }

        public ICustomerRepository Customer { get; private set; }

        public IOrderItemRepository OrderItem { get; private set; }

        public IOrderRepository Order { get; private set; }

        public IProductRepository Product { get; private set; }

        public ISupplierRepository Supplier { get; private set; }

        public IUserRepository User { get; private set; }
    }
}
