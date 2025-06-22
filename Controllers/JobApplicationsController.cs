using Microsoft.AspNetCore.Mvc;
using JobApplicationMVC.Data;
using JobApplicationMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationMVC.Controllers
{
    public class JobApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.JobApplications.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var app = await _context.JobApplications.FindAsync(id);
            if (app == null) return NotFound();

            return View(app);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(JobApplication app)
        {
            if (ModelState.IsValid)
            {
                _context.Add(app);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(app);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var app = await _context.JobApplications.FindAsync(id);
            if (app == null) return NotFound();

            return View(app);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, JobApplication app)
        {
            if (id != app.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(app);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(app);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var app = await _context.JobApplications.FindAsync(id);
            if (app == null) return NotFound();

            return View(app);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var app = await _context.JobApplications.FindAsync(id);
            if (app == null)
            {
                return NotFound();
            }

            _context.JobApplications.Remove(app);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
