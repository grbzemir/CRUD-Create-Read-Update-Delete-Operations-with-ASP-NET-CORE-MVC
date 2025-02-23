using CrudOperations.Models;
using Microsoft.AspNetCore.Mvc;
using MvcCrud.Models;
using System.Diagnostics;

namespace MvcCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchoolContext _context;

        public HomeController(ILogger<HomeController> logger , SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Students.ToList();
            return View(list);
        }

        public async Task<IActionResult> Update(int id)
        {
            var student = _context.Students.Find(id);
            return View("Student", student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create(Student student)

        {
            if(student.Id == 0)
            {
                await _context.AddAsync(student);
            }
            else
            {

                _context.Update(student);             
            }


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        public IActionResult Student(int? Id)
        {
            Student student;
            if(Id.HasValue) 
            {

                student = _context.Students.Find(Id);
                
            }

            else
            {
                 student = new Student();

            }

            return View(student);
          
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
