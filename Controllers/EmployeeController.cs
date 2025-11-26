using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
        {
            // tenary if (condition ? true : false)
            return _db.Employees != null ?
                    View(await _db.Employees.ToListAsync()) :
                    Problem("Data tidak ditemukan.");
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name,Division,Role")] Employee employee
            )
        {
            // cek validasi jika tidak valid
            if (ModelState.IsValid)
            {
                _db.Add(employee);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            // logika pengecekan id & Model Database
            if (id == null || _db.Employees == null)
            {
                return NotFound();
            }

            // Jika ada
            var employee = await _db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

    }
}