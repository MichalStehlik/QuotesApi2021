using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotesApi2021.Data;
using QuotesApi2021.Models;
using QuotesApi2021.ViewModels;

namespace QuotesApi2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly QuotesDbContext _context;

        public TagsController(QuotesDbContext context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags(TagType? type, string text, string order)
        {
            IQueryable<Tag> tags = _context.Tags;
            if (type != null)
                tags = tags.Where(t => t.Type == type);
            if (!String.IsNullOrEmpty(text))
                tags = tags.Where(t => t.Text.Contains(text));

            tags = order switch
            {
                "text_desc" => tags.OrderByDescending(t => t.Text),
                _ => tags.OrderBy(t => t.Text)
            };

            return await tags.ToListAsync();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound("tag not found");
            }

            return Ok(tag);
            // return StatusCode(200, tag);
        }

        // PUT: api/Tags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag(int id, Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            _context.Entry(tag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(id))
                {
                    return NotFound("tag not found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            // return Ok(tag);
        }

        // POST: api/Tags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(TagIM tag)
        {
            Tag newTag = new Tag { Text = tag.Text, Type = tag.Type };
            _context.Tags.Add(newTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTag", new { id = newTag.Id }, newTag);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Tags/5/quotes
        [HttpGet("{id}/quotes")]
        public async Task<ActionResult<IEnumerable<Quote>>> GetTagQuotes(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return await _context.Quotes.Where(q => q.Tags.Contains(tag)).ToListAsync();
        }

        private bool TagExists(int id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }
    }
}
