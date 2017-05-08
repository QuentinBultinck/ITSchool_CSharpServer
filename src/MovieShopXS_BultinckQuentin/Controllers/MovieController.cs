using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieShopXS_BultinckQuentin.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopXS_BultinckQuentin.Controllers
{
    [Route("")]
    public class MovieController : Controller
    {

        private MovieBaseRepository repository;

        public MovieController(MovieBaseRepository rep)
        {
            repository = rep;
        }

        [Route("")]
        [Route("Movies")]
        // GET: /<controller>/
        public IActionResult Movies()
        {
            return View();
        }
    }
}
