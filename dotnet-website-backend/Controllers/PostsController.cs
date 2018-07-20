using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetwebsitebackend.Entity;
using dotnetwebsitebackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetwebsitebackend.Controllers
{
    [Route("api/posts")]
    public class PostsController : Controller
    {
        private readonly DataContext _context;

        public PostsController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the last 5 blog posts
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        public IEnumerable<Post> GetCategory(string category, string search = null, int take = 5)
        {
            return _context.Posts
                           .Where(x => x.category == category)
                           .Where(x => search == null || x.content.Contains(search) || x.title.Contains(search))
                           .OrderByDescending(x => x.createdAt)
                           .Take(take);
        }

        /// <summary>
        /// Gets the post by its identifier
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        [HttpGet("{id}", Name = "GetPost")]
        public async Task<IActionResult> Get(string id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        /// <summary>
        /// Creates a new post
        /// </summary>
        /// <returns>The post.</returns>
        /// <param name="post">Post.</param>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]Post post)
        {
            if (await _context.Posts.AnyAsync(x => x.id == post.id))
            {
                return StatusCode(409); // Conflict
            }

            _context.Posts.Add(post);

            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetPost", new { post.id }, post);
        }

        /// <summary>
        /// Updates an existing post
        /// </summary>
        /// <returns>The put.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="post">Post.</param>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromForm]Post post)
        {
            if (await _context.Posts.AnyAsync(x => x.id == id) == false)
            {
                return NotFound();
            }
            _context.Posts.Update(post);

            await _context.SaveChangesAsync();

            return Ok(post);
        }

        /// <summary>
        /// Deletes a post
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            foreach(var claim in this.User.Claims){
                Console.WriteLine(claim);
            }

            var dbPost = await _context.Posts.FirstOrDefaultAsync(x => x.id == id);
            if (dbPost == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(dbPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
