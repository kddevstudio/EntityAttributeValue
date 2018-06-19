using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api;
using Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributesController : ControllerBase
    {
        private readonly EAVContext _context;

        public AttributesController(EAVContext context)
        {
            _context = context;
        }

        // GET: api/Attributes
        [HttpGet]
        public IEnumerable<Models.Attribute> GetAttributes()
        {
            return _context.Attributes;
        }

        // GET: api/Attributes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttribute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attribute = await _context.Attributes.FindAsync(id);

            if (attribute == null)
            {
                return NotFound();
            }

            return Ok(attribute);
        }

        // PUT: api/Attributes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttribute([FromRoute] int id, [FromBody] Models.Attribute attribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attribute.AttributeId)
            {
                return BadRequest();
            }

            _context.Entry(attribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeExists(id))
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

        // POST: api/Attributes
        [HttpPost]
        public async Task<IActionResult> PostAttribute([FromBody] Models.Attribute attribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Attributes.Add(attribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttribute", new { id = attribute.AttributeId }, attribute);
        }

        // DELETE: api/Attributes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attribute = await _context.Attributes.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }

            _context.Attributes.Remove(attribute);
            await _context.SaveChangesAsync();

            return Ok(attribute);
        }

        private bool AttributeExists(int id)
        {
            return _context.Attributes.Any(e => e.AttributeId == id);
        }
    }
}