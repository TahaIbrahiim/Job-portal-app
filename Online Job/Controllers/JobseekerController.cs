using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Online_Job.Models;

namespace Online_Job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobseekerController : ControllerBase
    {
        public readonly Context context;
        public JobseekerController(Context _context)
        {
            context = _context;
        }

        [HttpPost]
        public IActionResult Register(Jobseeker jobseeker)
        {
            if(ModelState.IsValid)
            {
                context.Add(jobseeker);
                context.SaveChanges();
                return Ok();
            }

            return BadRequest();
           
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id) {
            Jobseeker jobseeker = context.Jobseekers.SingleOrDefault(x => x.Id == id);
            return Ok(jobseeker);
        }
    }
}
