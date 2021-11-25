//using EasyMemoryCache;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DNSAPI.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
       // private readonly ICaching _caching;

        public TestController(
            //ICaching caching
            )
        {
          //  _caching = caching;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok");
        }

      
    }
}