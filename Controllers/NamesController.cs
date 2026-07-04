using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST.Data;
using REST.Models;

namespace REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NamesController(AppDbContext dbContext) : ControllerBase
    {
        /// <summary>
        /// Retrieve name collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetNames()
        {
            var names = await dbContext.Names
                .OrderBy(item => item.Name)
                .ToListAsync();

            return Ok(names);
        }

        /// <summary>
        /// Retrieve a single name item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetName(Guid id)
        {
            var item = await dbContext.Names.FindAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        /// <summary>
        /// Update name in name collection
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateName(Guid id, NameItem item)
        {
            if (id != item.Id)
            {
                return BadRequest("Route id must match payload id.");
            }

            var existingItem = await dbContext.Names.FindAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            existingItem.Name = item.Name;
            await dbContext.SaveChangesAsync();

            return Ok(existingItem);
        }

        /// <summary>
        /// Add name to name collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddName(NameItem item)
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            dbContext.Names.Add(item);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetName), new { id = item.Id }, item);
        }

        /// <summary>
        /// Delete from name collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveName(Guid id)
        {
            var existingItem = await dbContext.Names.FindAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            dbContext.Names.Remove(existingItem);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
