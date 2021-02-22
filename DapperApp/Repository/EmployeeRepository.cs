using Dapper;
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
            var query = "INSERT INTO Employees (Name, Email, Phone, Title, CompanyId) VALUES(@Name, @Email, @Phone, @Title, @CompanyId);"
            + "SELECT CAST(SCOPE_IDENTITY() as int)";
            _db.Query(query, new { employee.Name, employee.Email, employee.Phone, employee.Title, employee.CompanyId});
            return employee;
        }

        public Employee Find(int id)
        {
            var query = "SELECT * FROM Employees WHERE EmployeeId = @Id";
            return _db.Query(query, new { @Id = id }).Single();

        }

        public List<Employee> GeAll()
        {
            var query = "SELECT * FROM Employees";
            return _db.Query<Employee>(query).ToList();
        }

        public void Remove(int id)
        {
            var query = "DELETE FROM Employees WHERE EmployeeId = @Id";
            _db.Query(query, new { @Id = id });
        }

        public Employee Update(Employee employee)
        {
           
        }
    }
}
