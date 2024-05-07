using BlazorApp2Test.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BlazorApp2Test.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdController : ControllerBase
    {
        private readonly CdStoreContext _context; // Replace YourDbContext with the name of your DbContext

        public CdController(CdStoreContext context) // Replace YourDbContext with the name of your DbContext
        {
            _context = context;
        }

        // GET: api/Cd
        //get all cds
        [HttpGet]
        public async Task<ActionResult<List<Cd>>> GetCd()
        {
            return await _context.Cds.ToListAsync();
        }


        // GET: api/Cd/5
        //get cd by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Cd>> GetCd(int id)
        {
            var cd = await _context.Cds.FindAsync(id);

            if (cd == null)
            {
                return NotFound();
            }

            return cd;
        }

        // PUT: api/Cd/5
        //update cd by id
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCd(int id, Cd cd)
        {
          var cdToUpdate = await _context.Cds.FindAsync(id);
            if (cdToUpdate == null)
            {
                return NotFound();
            }

            cdToUpdate.NameCd = cd.NameCd;
            cdToUpdate.Artist = cd.Artist;
            cdToUpdate.Price = cd.Price;
            cdToUpdate.Genre = cd.Genre;
            cdToUpdate.DateReleased = cd.DateReleased;
            cdToUpdate.Image = cd.Image;


            await _context.SaveChangesAsync();

            return Ok(cdToUpdate);

        }

        // POST: api/Cd
        //add new cd
        [HttpPost]
        public async Task<ActionResult<Cd>> AddCd(Cd cd)
        {
            _context.Cds.Add(cd);
            await _context.SaveChangesAsync();

            return Ok(cd);
        }
    }
}
