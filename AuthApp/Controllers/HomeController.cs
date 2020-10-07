using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApp.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController(AuthenticationContext context){}


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() 
        {
            return new string[] { "Viktor", "Gordon" };
        }
    }
}
