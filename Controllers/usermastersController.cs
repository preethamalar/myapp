using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myapp.Models;

namespace myapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usermastersController : ControllerBase
    {
        private readonly userContext _context;

        public usermastersController(userContext context)
        {
            _context = context;
        }

        // GET: api/usermasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<usermaster>>> Getusermasters()
        {
            return await _context.usermasters.ToListAsync();
        }

        // GET: api/usermasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<usermaster>> Getusermaster(long id)
        {
            var usermaster = await _context.usermasters.FindAsync(id);

            if (usermaster == null)
            {
                return NotFound();
            }

            return usermaster;
        }

        // PUT: api/usermasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putusermaster(long id, usermaster usermaster)
        {
            if (id != usermaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(usermaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usermasterExists(id))
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

        // POST: api/usermasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
         public async Task<ActionResult<usermaster>> Postusermaster(usermaster usermaster)
         {
         _context.usermasters.Add(usermaster);
         await _context.SaveChangesAsync();

            return CreatedAtAction("Getusermaster", new { id = usermaster.Id }, usermaster);
         }

        //meee



        // DELETE: api/usermasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<usermaster>> Deleteusermaster(long id)
        {
            var usermaster = await _context.usermasters.FindAsync(id);
            if (usermaster == null)
            {
                return NotFound();
            }

            _context.usermasters.Remove(usermaster);
            await _context.SaveChangesAsync();

            return usermaster;
        }

        private bool usermasterExists(long id)
        {
            return _context.usermasters.Any(e => e.Id == id);
        }
    }
}
