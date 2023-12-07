using _06122023forwardbackward.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _06122023forwardbackward.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static List<Employee> employees = new List<Employee>
            {
                new Employee{ Id = 1,Name="Tagore",Salary=2000000},
                new Employee{ Id = 2,Name="Dinesh",Salary=100000000},
                new Employee{ Id = 3,Name="Sai",Salary=999999},
                new Employee{ Id = 4,Name="Sufian",Salary=20000},
                new Employee{ Id = 5,Name="Harsha",Salary=7878800},
                new Employee{ Id = 6,Name="Manikanta",Salary=909090},
                new Employee{ Id = 7,Name="Kushal",Salary=123980}
            };
        static List<Employee> employees2 = new List<Employee>
            {
                new Employee{ Id = 10,Name="Anurag",Salary=20000},
                new Employee{ Id = 11,Name="Shiva",Salary=100000},
                new Employee{ Id = 12,Name="Jaggu",Salary=99999},
                new Employee{ Id = 14,Name="Hemanth",Salary=202000},

            };



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            EmployeeLists DoubleList = new EmployeeLists();

            DoubleList.EmployeeList1 = employees;
            DoubleList.EmployeeList2 = employees2;


            return View(DoubleList);
        }

        public IActionResult Table1(IFormCollection fc)
        {
            string[] ids = fc["employeeId"];

            if(employees.Count == 0)
            {
                TempData["error"] = "No items present in the list";
                return RedirectToAction("Index");
            }
            if(ids.Length == 0)
            {
                TempData["error"] = "Please select atleast one item";
                return RedirectToAction("Index");
            }
            foreach(string id in ids)
            {
                var emp = employees.FirstOrDefault(s => s.Id == int.Parse(id));

                employees2.Add(emp);

                employees.Remove(emp);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Table2(IFormCollection fc)
        {
            string[] ids = fc["employeeId"];
            if (employees.Count == 0)
            {
                TempData["error"] = "No items present in the list";
                return RedirectToAction("Index");
            }
            if (ids.Length == 0)
            {
                TempData["error"] = "Please select atleast one item";
                return RedirectToAction("Index");
            }
            foreach (string id in ids)
            {
                var emp = employees2.FirstOrDefault(s => s.Id == int.Parse(id));

                employees.Add(emp);

                employees2.Remove(emp);
            }
            return RedirectToAction("Index");
        }

    }
}