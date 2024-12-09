using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PearlySoft.DbContexts;
using PearlySoft.Models;

namespace PearlySoft.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
              _context = context;
             _webHostEnvironment = webHostEnvironment;
        }

            //[HttpGet]
            //public IActionResult GetIndexView()
            //{
            //    return View("Index", _context.Employees.ToList());
            //}
            //public IActionResult Index()
            //{
            //    return View();
            //}

        [HttpGet]
        public IActionResult GetDetailsView(int id)
        {
            Employee employee = _context.Employees.Include(emp => emp.Department).FirstOrDefault(emp => emp.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", employee);
            }
        }

        [HttpGet]
        public IActionResult GetCreateView()
        {
            ViewBag.AllDepartments = _context.Departments.ToList();
            return View("Create");
        }

        //HTTP Verbs -> HttpGET - HttpPost
        [HttpPost]
        public IActionResult AddNew(Employee employee)
        {
            if (ModelState.IsValid == true)
            {
                if(employee.ImageFile != null)
                {
                    string imgePath = "//upload//" + Guid.NewGuid() + employee.ImageFile.FileName;
                    string imgFullPath = _webHostEnvironment.WebRootPath + imgePath;
                    FileStream fileStream = new FileStream(imgFullPath, FileMode.Create);
                    employee.ImageFile.CopyTo(fileStream);
                    fileStream.Dispose();

                    employee.ImagePath = imgePath;


                }
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllDepartments = _context.Departments.ToList();
                return View("Create");
            }
        }


        [HttpGet]
        public IActionResult GetEditView(int id)
        {

            Employee employee = _context.Employees.Include(emp => emp.Department).FirstOrDefault(emp => emp.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.AllDepartments = _context.Departments.ToList();
                return View("Edit", employee);
            }
        }

        [HttpPost]
        public IActionResult EditCurrent(Employee employee)
        {
            if (ModelState.IsValid == true)
            {

                if (employee.ImageFile != null)
                {

                    if (System.IO.File.Exists(_webHostEnvironment.WebRootPath + employee.ImagePath))
                    {
                        System.IO.File.Delete(_webHostEnvironment.WebRootPath + employee.ImagePath);
                    }

                    string imgePath = "//upload//" + Guid.NewGuid() + employee.ImageFile.FileName;
                    string imgFullPath = _webHostEnvironment.WebRootPath + imgePath;
                    FileStream fileStream = new FileStream(imgFullPath, FileMode.Create);
                    employee.ImageFile.CopyTo(fileStream);
                    fileStream.Dispose();

                    employee.ImagePath = imgePath;


                }
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllDepartments = _context.Departments.ToList();
                return View("Edit");
            }
        }


        [HttpGet]
        public IActionResult GetDeleteView(int id)
        {
            Employee employee = _context.Employees.Include(emp => emp.Department).FirstOrDefault(emp => emp.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", employee);
            }
        }

        [HttpPost]
        public IActionResult DeleteCurrent(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(emp => emp.Id == id);


            if(System.IO.File.Exists(_webHostEnvironment.WebRootPath + employee.ImagePath))
            {
                System.IO.File.Delete(_webHostEnvironment.WebRootPath + employee.ImagePath);
            }


            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("GetIndexView");
        }





        [HttpGet]
        public IActionResult GetIndexView(string? search = "" )  
        {
            List<Employee> employees;
            if (string.IsNullOrEmpty(search) == false)
            {

                employees = _context.Employees.Where(emp => emp.FullName.Contains(search.Trim())
                || emp.Position.Contains(search.Trim())).ToList();
            }

            else
            {
                employees = _context.Employees.ToList();
            }
            ViewBag.CurrentSearch = search;
            return View("Index", employees);


        }


       




        public string GreetVisitor()
        {
            return "Welcome to Pearly Soft!";
        }

        public string GetAge(string name, int birthYear)
        {
            byte age = Convert.ToByte(DateTime.Now.Year - birthYear);
            return "Hi, " + name + ". You are " + age + " years old.";
        }

        public float SumTwoNumbers(float firstNo, float secondNo)
        {
            return firstNo + secondNo;
        }

        public bool IsAllowedHiringAge(int birthYear, int birthMonth, int birthDay)
        {
            DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);
            return ((DateTime.Now - birthDate).Days / 365) >= 18;
        }

    }
}
