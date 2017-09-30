using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using Cibertec.Repositories.Northwind;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.Repositories.EntityFramework.Northwind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(DbContext context)
        {
            Customer = new CustomerRepository(context);
            /*
            OrderItem = new OrderItemRepository(context);
            Order = new OrderRepository(context);
            Product = new ProductRepository(context);
            Supplier = new SupplierRepository(context);
            User = new UserRepository(context);
            */
        }

        public ICustomerRepository Customer { get; private set; }

        public IOrderItemRepository OrderItem { get; private set; }

        public IOrderRepository Order { get; private set; }

        public IProductRepository Product { get; private set; }

        public ISupplierRepository Supplier { get; private set; }

        public IUserRepository User { get; private set; }
    }
}
