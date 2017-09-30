using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
