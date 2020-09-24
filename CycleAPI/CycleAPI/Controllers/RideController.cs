using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CycleAPI.Models;

namespace CycleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly masterContext _context;

        public RideController(masterContext context)
        {
            _context = context;
        }

        // GET: api/Ride
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RideMetric>>> GetRideMetrics()
        {
            return await _context.RideMetrics.ToListAsync();
        }

        // GET: api/Ride/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RideMetric>> GetRideMetric(int id)
        {
            var rideMetric = await _context.RideMetrics.FindAsync(id);

            if (rideMetric == null)
            {
                return NotFound();
            }

            return rideMetric;
        }

        // PUT: api/Ride/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRideMetric(int id, RideMetric rideMetric)
        {
            if (id != rideMetric.Id)
            {
                return BadRequest();
            }

            _context.Entry(rideMetric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RideMetricExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ride
        [HttpPost]
        public async Task<ActionResult<RideMetric>> PostRideMetric(RideMetric rideMetric)
        {
            _context.RideMetrics.Add(rideMetric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRideMetric", new { id = rideMetric.Id }, rideMetric);
        }

        // DELETE: api/Ride/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RideMetric>> DeleteRideMetric(int id)
        {
            var rideMetric = await _context.RideMetrics.FindAsync(id);
            if (rideMetric == null)
            {
                return NotFound();
            }

            _context.RideMetrics.Remove(rideMetric);
            await _context.SaveChangesAsync();

            return rideMetric;
        }

        private bool RideMetricExists(int id)
        {
            return _context.RideMetrics.Any(e => e.Id == id);
        }
    }
}
