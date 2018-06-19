using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityDefinitionsController : ControllerBase
    {
        private readonly EAVContext _context;

        public EntityDefinitionsController(EAVContext context)
        {
            _context = context;
        }

        // GET: api/EntityDefinitions
        [HttpGet]
        public IEnumerable<EntityDefinition> GetEntityDefinitions()
        {
            return _context.EntityDefinitions;
        }

        // GET: api/EntityDefinitions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityDefinition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityDefinition = await _context.EntityDefinitions.FindAsync(id);

            if (entityDefinition == null)
            {
                return NotFound();
            }

            return Ok(entityDefinition);
        }

        // PUT: api/EntityDefinitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityDefinition([FromRoute] int id, [FromBody] EntityDefinition entityDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entityDefinition.EntityDefinitionId)
            {
                return BadRequest();
            }

            _context.Entry(entityDefinition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityDefinitionExists(id))
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

        // POST: api/EntityDefinitions
        [HttpPost]
        public async Task<IActionResult> PostEntityDefinition([FromBody] EntityDefinition entityDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntityDefinitions.Add(entityDefinition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityDefinition", new { id = entityDefinition.EntityDefinitionId }, entityDefinition);
        }

        // DELETE: api/EntityDefinitions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityDefinition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityDefinition = await _context.EntityDefinitions.FindAsync(id);
            if (entityDefinition == null)
            {
                return NotFound();
            }

            _context.EntityDefinitions.Remove(entityDefinition);
            await _context.SaveChangesAsync();

            return Ok(entityDefinition);
        }

        private bool EntityDefinitionExists(int id)
        {
            return _context.EntityDefinitions.Any(e => e.EntityDefinitionId == id);
        }
    }
}