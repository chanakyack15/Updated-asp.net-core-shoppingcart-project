using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailsController : ControllerBase
    {
        private readonly ProductdetailContext _context;

        public CartDetailsController(ProductdetailContext context)
        {
            _context = context;
        }

        // GET: api/CartDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDetail>>> GetCartDetail()
        {
            return await _context.CartDetails.ToListAsync();
        }

        // GET: api/CartDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetail>> GetCartDetails(int id)
        {
            var cartDetails = await _context.CartDetails.FindAsync(id);

            if (cartDetails == null)
            {
                return NotFound();
            }

            return cartDetails;
        }

        // PUT: api/CartDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartDetails(int id, CartDetail cartDetails)
        {
            if (id != cartDetails.Cid)
            {
                return BadRequest();
            }

            _context.Entry(cartDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartDetailsExists(id))
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

        // POST: api/CartDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CartDetail>> PostCartDetails(CartDetail cartDetails)
        {
            _context.CartDetails.Add(cartDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartDetails", new { id = cartDetails.Cid }, cartDetails);
        }

        // DELETE: api/CartDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartDetail>> DeleteCartDetails(int id)
        {
            var cartDetails = await _context.CartDetails.FindAsync(id);
            if (cartDetails == null)
            {
                return NotFound();
            }

            _context.CartDetails.Remove(cartDetails);
            await _context.SaveChangesAsync();

            return cartDetails;
        }

        private bool CartDetailsExists(int id)
        {
            return _context.CartDetails.Any(e => e.Cid == id);
        }
    }
}
