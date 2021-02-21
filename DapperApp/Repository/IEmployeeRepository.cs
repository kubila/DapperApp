using DapperApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Repository
{
    public interface IEmployeeRepository
    {
        Employee Find(int id);

        List<Employee> GeAll();
        Employee Add(Employee employee);

        Employee Update(Employee employee);

        void Remove(int id);

    }
}
