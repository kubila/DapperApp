using DapperApp.Data;
using DapperApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Repository
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public Company Add(Company company)
        {
            _context.Companies.Add(company);
           _context.SaveChanges();
            return company;
        }

        public Company Find(int id)
        {
            return _context.Companies.FirstOrDefault(u => u.CompanyId == id); // that's using linq, so if no match it's returning a null.
           //return _context.Companies.Find(id); // that works exactly like the one above. except if record not found it throws an error.
        }

        public List<Company> GetAll()
        {
            return _context.Companies.ToList();
        }

        public void Remove(int id)
        {
            Company company = _context.Companies.FirstOrDefault(c => c.CompanyId == id);
            _context.Companies.Remove(company);
            _context.SaveChanges();
            return;
            
        }

        public Company Update(Company company)
        {
            
            _context.Companies.Update(company);
            _context.SaveChanges();
            return company;
        }
    }
}
