using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "version 0.0.1";
        }
    }
}