using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceRequestApi
        [HttpGet]
        public async Task<IActionResult> GetRequests()
        {
            var requests = await _context.ServiceRequests.ToListAsync();
            return Ok(requests);
        }

        // GET: api/ServiceRequestApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequest(int id)
        {
            var request = await _context.ServiceRequests.FindAsync(id);

            if (request == null)
                return NotFound();

            return Ok(request);
        }

        // POST: api/ServiceRequestApi
        [HttpPost]
        public async Task<IActionResult> CreateRequest(ServiceRequest request)
        {
            request.Status = "Pending";
            request.RequestDate = DateTime.Now;

            _context.ServiceRequests.Add(request);
            await _context.SaveChangesAsync();

            return Ok(request);
        }

        // PUT: api/ServiceRequestApi/complete/5
        [HttpPut("complete/{id}")]
        public async Task<IActionResult> CompleteRequest(int id)
        {
            var request = await _context.ServiceRequests.FindAsync(id);

            if (request == null)
                return NotFound();

            request.Status = "Completed";

            await _context.SaveChangesAsync();

            return Ok(request);
        }

        // DELETE: api/ServiceRequestApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.ServiceRequests.FindAsync(id);

            if (request == null)
                return NotFound();

            _context.ServiceRequests.Remove(request);
            await _context.SaveChangesAsync();

            return Ok("Request deleted successfully");
        }
    }
}