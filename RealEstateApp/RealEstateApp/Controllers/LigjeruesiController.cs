using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RealEstateApp.Data;
using RealEstateApp.Entities;

namespace RealEstateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigjeruesiController : ControllerBase
    {
        private readonly DataContext _context;

        public LigjeruesiController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ligjeruesi>>> GetLigjerata()
        {
            try
            {
                return await _context.Ligjeruesi.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Ligjeruesi>> PostLigjeruesi([FromForm] Ligjeruesi ligjeruesi)
        {
            try
            {
                var lecturer = new Ligjeruesi
                {
                    LecturerName = ligjeruesi.LecturerName,///atributet
                    Departament = ligjeruesi.Departament,
                    Email = ligjeruesi.Email,
                    

                };

                _context.Ligjeruesi.Add(lecturer);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetApartmentById", new { id = lecturer.LecturerID }, lecturer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new record: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLigjeruesi(int id, Ligjeruesi ligjeruesi)
        {
            if (id != ligjeruesi.LecturerID)
            {
                return BadRequest();
            }

            _context.Entry(ligjeruesi).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteLigjeruesi(int id)
        {
            try
            {
                var lecturer = await _context.Ligjeruesi.FindAsync(id);
                if (lecturer == null)
                {
                    return NotFound();
                }

                _context.Ligjeruesi.Remove(lecturer);

                await _context.SaveChangesAsync();

                return Ok(await _context.Ligjeruesi.ToListAsync());
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
