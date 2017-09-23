using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
        }

        public Customer SearchByNames(string firstName, string lastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@firstName", firstName);
                parameters.Add("@lastName", lastName);

                return connection.QueryFirst<Customer>(
                    "dbo.CustomerSearchByName", // es mejor indicar el esquema
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
