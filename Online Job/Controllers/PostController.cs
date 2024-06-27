using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Job.Models;

namespace Online_Job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public readonly Context context;
        public PostController(Context _context)
        {
            context = _context;
        }

        [HttpPost]
        public IActionResult Register(Post post)
        {
            if (ModelState.IsValid)
            {
                context.Add(post);
                context.SaveChanges();
                return Ok();
            }

            return BadRequest();

        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Post> posts = context.Posts.ToList();
            return Ok(posts);
        }

        [HttpPut("Edit/{id}")]
        public IActionResult EditPost([FromRoute] int id, [FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
                Post oldpost = context.Posts.SingleOrDefault(p => p.Id == id);

                if (oldpost != null)
                {
                    // Check each property before assigning to avoid null reference exception
                    oldpost.PostDescription = post.PostDescription ?? oldpost.PostDescription;
                    oldpost.PostTime = post.PostTime ?? oldpost.PostTime;
                    oldpost.Employer_ID = post.Employer_ID ?? oldpost.Employer_ID;

                    return Ok(post);
                }
                else
                {
                    // Log the issue or return a more detailed error response
                    Console.WriteLine($"Post with ID {id} not found");
                    return NotFound($"Post with ID {id} not found");
                }
            }

            return BadRequest(ModelState);
        }



    }
}
