using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
