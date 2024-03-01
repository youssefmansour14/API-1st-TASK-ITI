using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinyaG01Demo.Models;

namespace MinyaG01Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindingController : ControllerBase
    {
        //Bind Primitive DT => Route Segment /id || ==> Query string ?id
        //Complix dt => Request Body
        [HttpPost("{name}")]
        //[Route("")]
        public IActionResult Index(int id
            ,string name,Student d)
        {
            return Content("Ay7aga");
        }
    }
}
