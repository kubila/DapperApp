using Dapper;
using DapperApp.Data;
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
    public class CompanyRepository : ICompanyRepository
    {
        public IDbConnection _db;   
        public CompanyRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public Company Add(Company company)
        {
            throw new NotImplementedException();
        }

        public Company Find(int id)
        {
            // DON'T APPEND STRINGS,PARAMS,INTS TO YOUR QUERIES LIKE BELOW, DON'T DON'T DON'T
            // "SELECT * FROM Companies WHERE CompanyId =" + id    ///// SQL INJECTION HEREEEEEEEEEEEEEEEEE

            var query = "SELECT * FROM Companies WHERE CompanyId = @Id";
            return _db.Query<Company>(query, new { @Id = id }).Single();
        }

        public List<Company> GetAll()
        {
            var query = "SELECT * FROM Companies";

            return _db.Query<Company>(query).ToList();
        }

        public void Remove(int id)
        {
            var query = "DELETE FROM Companies WHERE CompanyId = @Id";
            _db.Query<Company>(query, new { @Id = id });
        }

        public Company Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
