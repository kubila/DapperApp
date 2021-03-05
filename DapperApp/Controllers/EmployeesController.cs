using DapperApp.Models;
using DapperApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ICompanyRepository _companyRepo;

        [BindProperty]
        Employee Employee { get; set; }

        public EmployeesController(IEmployeeRepository employeeRepo, ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
            _employeeRepo = employeeRepo;
        }

        // GET: EmployeeController
        public IActionResult Index()
        {
            return View(_employeeRepo.GeAll());
        }

        // GET: EmployeeController/Details/5
        public IActionResult Details(int? id)
        {
            if ( id == null )
            {
                return NotFound();
            }

            var employee = _employeeRepo.Find(id.GetValueOrDefault());

            if ( employee == null )
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult CreatePost()
        {
            if( !ModelState.IsValid)
            {
                return View(Employee);
            }

            try
            {
                _employeeRepo.Add(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
