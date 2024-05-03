using WebApp3BySijan.Repositories;
using WebApp3BySijan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;

namespace WebApp3BySijan.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeRepo Repo = new EmployeeRepo();
        public ActionResult Index()
        {
            // Retrive the data from DB before viewing the page
            List<Employee>? emps = Repo.GetAllRecord();
            return View(emps);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Employee emp = new Employee();
                emp.ID = Convert.ToInt32(collection["ID"]);
                emp.Name = Convert.ToString(collection["Name"]);
                emp.Address = Convert.ToString(collection["Address"]);
                emp.Phone = Convert.ToInt32(collection["Phone"]);
                Repo.SetEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            EmployeeRepo e = new EmployeeRepo();
            try
            {
                Employee e1 = e.GetSingleEmployeeRecord(id);
                return View(e1);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
        }

       
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // Form data to update the current data
                string newName = Convert.ToString(collection["Name"]);
                string newAddr = Convert.ToString(collection["Address"]);
                int newPhone = Convert.ToInt32(collection["Phone"]);
                Repo.EditEmployee(id, newName, newAddr,newPhone);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                id = Convert.ToInt32(collection["ID"]);
                Repo.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

