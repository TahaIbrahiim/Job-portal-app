using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Job.Models;

namespace Online_Job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        public readonly Context context;
        public EmployerController(Context _context)
        {
            context = _context;
        }

        [HttpPost]
        public IActionResult Register(Employer employer)
        {
            if (ModelState.IsValid)
            {
                context.Add(employer);
                context.SaveChanges();
                return Ok();
            }

            return BadRequest();

        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return Ok(employers);
        }
    }
}
