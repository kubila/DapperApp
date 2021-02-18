﻿using Dapper;
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
            throw new NotImplementedException();
        }

        public List<Company> GetAll()
        {
            var query = "SELECT * FROM Companies";

            return _db.Query<Company>(query).ToList();
        }

        public void Remove(int id)
        {
            
        }

        public Company Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
