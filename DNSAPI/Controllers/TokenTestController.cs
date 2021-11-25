//using EasyMemoryCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNSAPI.Controllers
{
    [Route("api/tokentest")]
    public class TokenTestController : Controller
    {
       // private readonly ICaching _caching;

        public TokenTestController(
            //ICaching caching
            )
        {
          //  _caching = caching;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok");
        }

      
    }
}