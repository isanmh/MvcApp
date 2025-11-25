using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
namespace MvcApp.Controllers
{
    public class EmployeeController : Controller
    {

        // koneksi database 
        private readonly AppDbContext _db;

        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // tenary if (condition ? true : false)
            return _db.Employees != null ? View(_db.Employees.ToList()) :
                    Problem("Data tidak ditemukan.");
        }
    }
}