using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error")]
        public IActionResult ErrorStatusCode([FromQuery] int code)
        {
            return View(code);
        }
    }
}
