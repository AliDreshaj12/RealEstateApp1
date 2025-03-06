using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Data;
using RealEstateApp.DTO;
using RealEstateApp.Entities;
using RealEstateApp.Features;

namespace RealEstateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigjerataController : ControllerBase
    {
        private readonly DataContext _context;

        public LigjerataController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ligjerata>>> GetLigjerata()
        {
            try
            {
                return await _context.Ligjerata.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }


        [HttpPost, Authorize(Policy = "AgentPolicy")]
        public async Task<ActionResult<Ligjerata>> PostLigjerata([FromForm] Ligjerata ligjerata)
        {
            try
            {
                var lecture = new Ligjerata
                {
                    LectureName = ligjerata.LectureName,///atributet
                    Ligjeruesi = ligjerata.Ligjeruesi,
                };

                _context.Ligjerata.Add(lecture);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetApartmentById", new { id = lecture.LectureId }, lecture);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new record: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLigjerata(int id, Ligjerata ligjerata)
        {
            if (id != ligjerata.LectureId)
            {
                return BadRequest();
            }

            _context.Entry(ligjerata).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LigjerataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the record. Concurrency issue.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the data.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLigjerata(int id)
        {
            try
            {
                var lecture = await _context.Ligjerata.FindAsync(id);
                if (lecture == null)
                {
                    return NotFound();
                }

                _context.Ligjerata.Remove(lecture);

                await _context.SaveChangesAsync();

                return Ok(await _context.Ligjerata.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data.");
            }
        }
        private bool LigjerataExists(int id)
        {
            try
            {
                return _context.Ligjerata.Any(e => e.LecturerID == id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

