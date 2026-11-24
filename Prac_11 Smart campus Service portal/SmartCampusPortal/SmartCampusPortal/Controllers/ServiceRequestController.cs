using Microsoft.AspNetCore.Mvc;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartCampusPortal.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display All Requests
        public async Task<IActionResult> Index()
        {
            var requests = await _context.ServiceRequests.ToListAsync();
            return View(requests);
        }

        // Create Request - GET
        public IActionResult Create()
        {
            return View();
        }

        // Create Request - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceRequest request)
        {
            if (ModelState.IsValid)
            {
                request.Status = "Pending";
                request.RequestDate = DateTime.Now;

                _context.ServiceRequests.Add(request);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(request);
        }

        // Update Status
        public async Task<IActionResult> UpdateStatus(int id)
        {
            var request = await _context.ServiceRequests.FindAsync(id);

            if (request == null)
                return NotFound();

            request.Status = "Completed";

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Delete Request
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _context.ServiceRequests.FindAsync(id);

            if (request != null)
            {
                _context.ServiceRequests.Remove(request);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}