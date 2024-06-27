using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Job.Models;

namespace Online_Job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly Context context;
        public AdminController(Context _context)
        {
            context = _context;
        }

        [HttpPut("JobSeeker/{id:int}")]
        public IActionResult EditJobSeeker([FromRoute]int id, [FromBody] Jobseeker jobseeker)
        {
            if (ModelState.IsValid)
            {
                Jobseeker oldjobseeker = context.Jobseekers.FirstOrDefault(e => e.Id == id);

                oldjobseeker.Name = jobseeker.Name;
                oldjobseeker.Email = jobseeker.Email;
                oldjobseeker.Phone = jobseeker.Phone;
                oldjobseeker.Password = jobseeker.Password;
                oldjobseeker.BirthOfDate = jobseeker.BirthOfDate;
                oldjobseeker.ConfirmPassword = jobseeker.ConfirmPassword;
                oldjobseeker.image = jobseeker.image;

                context.SaveChanges();

                return Ok(jobseeker);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("EditPost/{id:int}")]

        public IActionResult EditPost([FromRoute]int id, [FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
                Post oldpost = context.Posts.Include(e=>e.Employer).SingleOrDefault(p => p.Id == id);
                
                oldpost.PostDescription = post.PostDescription;
                oldpost.PostTime = post.PostTime;
                oldpost.Employer_ID = post.Employer.Id;

                context.SaveChanges();

                return Ok(post);
            }

            return BadRequest(ModelState);
        }   


        [HttpPut("Employer/Edit/{id:int}")]

        public IActionResult EditEmployer([FromRoute] int id, [FromBody] Employer employer)
        {
            if (ModelState.IsValid)
            {
                Employer oldemployer = context.Employers.Include(p=>p.posts).SingleOrDefault(p => p.Id == id);

                oldemployer.Name=employer.Name;
                oldemployer.Email=employer.Email;
                oldemployer.image=employer.image;
                oldemployer.posts=employer.posts;
                oldemployer.Password = employer.Password;
                oldemployer.ConfirmPassword = employer.ConfirmPassword;

                context.SaveChanges();

                return Ok(employer);
            }

            return BadRequest(ModelState);
        }

    }
}
