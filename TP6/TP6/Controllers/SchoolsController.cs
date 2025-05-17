using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP6.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TP6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public SchoolsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/schools/get-all-schools
        [HttpGet("get-all-schools")]
        public async Task<ActionResult<IEnumerable<School>>> GetSchools()
        {
            return await _context.Schools.ToListAsync();
        }

        // GET: api/schools/get-school-by-id/5
        [HttpGet("get-school-by-id/{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return school;
        }

        // POST: api/schools/create-school
        [HttpPost("create-school")]
        public async Task<ActionResult<School>> PostSchool(School school)
        {
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSchool), new { id = school.Id }, school);
        }

        // PUT: api/schools/edit-school/5
        [HttpPut("edit-school/{id}")]
        public async Task<IActionResult> PutSchool(int id, School school)
        {
            if (id != school.Id)
            {
                return BadRequest();
            }

            _context.Entry(school).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // DELETE: api/schools/delete-school/5
        [HttpDelete("delete-school/{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/schools/search-by-name?name=Green Valley
        [HttpGet("search-by-name")]
        public async Task<ActionResult<IEnumerable<School>>> SearchByName([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("The 'name' query parameter is required.");
            }

            var schools = await _context.Schools
                .Where(s => s.Name.Contains(name))
                .ToListAsync();

            if (!schools.Any())
            {
                return NotFound($"No schools found with the name containing '{name}'.");
            }

            return Ok(schools);
        }

        private bool SchoolExists(int id)
        {
            return _context.Schools.Any(e => e.Id == id);
        }
    }
}
