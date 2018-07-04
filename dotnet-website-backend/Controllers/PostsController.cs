using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetwebsitebackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetwebsitebackend.Controllers
{
    [Route("api/posts")]
    public class PostsController : Controller
    {
        static int _postId = 0;
        static List<Post> _posts = new List<Post>();

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _posts.OrderByDescending(x => x.createdAt);
        }

        [HttpGet("{id}", Name = "GetPost")]
        public IActionResult Get(string id)
        {
            var post = _posts.FirstOrDefault(x => x.id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post([FromForm]Post post)
        {
            post.createdAt = DateTime.Now;
            post.id = (++_postId).ToString();
            _posts.Add(post);
            return CreatedAtRoute("GetPost", new { id = post.id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromForm]Post post)
        {
            var dbPost = _posts.FirstOrDefault(x => x.id == id);
            if (dbPost == null)
            {
                return NotFound();
            }
            _posts.Remove(dbPost);
            _posts.Add(post);

            return Ok(post);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var dbPost = _posts.FirstOrDefault(x => x.id == id);
            if (dbPost == null)
            {
                return NotFound();
            }
            _posts.Remove(dbPost);

            return NoContent();
        }
    }
}
