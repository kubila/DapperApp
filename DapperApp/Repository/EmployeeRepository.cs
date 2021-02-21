using DapperApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IDbConnection _db;
        public EmployeeRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GeAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
