using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
