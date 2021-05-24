using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TelephoneNumbersWebAPI.Models;
using VaccinationAppointmentVerificationWebAPI.CustomAttribute;

namespace VaccinationAppointmentVerificationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneDirectoriesController : ControllerBase
    {
        //private readonly dbContext _context;

        List<TelephoneDirectory> Telephones = new List<TelephoneDirectory>
        {
            new TelephoneDirectory
            {
                Id=1,PhoneNumber="543210"
            },
              new TelephoneDirectory
            {
                Id=1,PhoneNumber="98765"
            },
                  new TelephoneDirectory
            {
                Id=1,PhoneNumber="543211"
            },
              new TelephoneDirectory
            {
                Id=1,PhoneNumber="98766"
            }
        };
        public TelephoneDirectoriesController()
        {
           // _context = context;
        }

        // GET: api/TelephoneDirectories
        [HttpGet]
        public ActionResult<IEnumerable<TelephoneDirectory>> GetTelephones()
        {
            return Telephones.ToList();
        }

        // GET: api/TelephoneDirectories/5
        [HttpGet("{id}")]
        public ActionResult<TelephoneDirectory> GetTelephoneDirectory(int id)
        {
            var telephoneDirectory = Telephones.Find(f=>f.Id==id);

            if (telephoneDirectory == null)
            {
                return NotFound();
            }

            return telephoneDirectory;
        }
        [HttpGet]
     [Authorize]
        [Route("PhoneByNumber")]
        
        public ActionResult<TelephoneDirectory> PhoneByNumber(string Number,string Token)
        {
            var telephoneDirectory = Telephones.Where(w => w.PhoneNumber == Number).FirstOrDefault();
            if (telephoneDirectory == null)
            {
                return NotFound();
            }

            return telephoneDirectory;
        }
        // PUT: api/TelephoneDirectories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTelephoneDirectory(int id, TelephoneDirectory telephoneDirectory)
        //{
        //    if (id != telephoneDirectory.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(telephoneDirectory).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TelephoneDirectoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/TelephoneDirectories
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<TelephoneDirectory>> PostTelephoneDirectory(TelephoneDirectory telephoneDirectory)
        //{
        //    _context.Telephones.Add(telephoneDirectory);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTelephoneDirectory", new { id = telephoneDirectory.Id }, telephoneDirectory);
        //}

        //// DELETE: api/TelephoneDirectories/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<TelephoneDirectory>> DeleteTelephoneDirectory(int id)
        //{
        //    var telephoneDirectory = await _context.Telephones.FindAsync(id);
        //    if (telephoneDirectory == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Telephones.Remove(telephoneDirectory);
        //    await _context.SaveChangesAsync();

        //    return telephoneDirectory;
        //}

        //private bool TelephoneDirectoryExists(int id)
        //{
        //    return _context.Telephones.Any(e => e.Id == id);
        //}
    }
}
