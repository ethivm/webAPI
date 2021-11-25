using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DNSAPI.Requests;
using DNSAPI.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using DNSAPI.Model;
using System.Threading.Tasks;

namespace DNSAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : Controller
    {
        protected readonly IUserService _userService;
        private readonly ILogger<LoginController> _logger;
        public LoginController(IUserService userService
            , ILogger<LoginController> logger
            )
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> ValidateUser([FromBody]UserLogin request)
        {
            User user = new User();
            try
            {
                _logger.LogInformation("User Request " + request.UserName + " " + request.Password + "Time " + DateTime.Now);

                if (string.IsNullOrEmpty(request.UserName) && string.IsNullOrEmpty(request.Password)) return StatusCode(400);

                user = await _userService.GetToken(request.UserName, request.Password);

                if (user == null) return NotFound("The requesting user could not be found");

                return Json(user);
            }
            catch (Exception ex)
            {
                _logger.LogError("ValidateUser " + DateTime.Now + " Error : " + ex.Message +"  #####  "+ ex.StackTrace + "  #####  " + ex.InnerException);
                return StatusCode(500, "Internal server error");
            }
        }

        //[AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public JsonResult InsertUser(string username, string password, string confirmpassword)
        {
            if (password == confirmpassword)
            {
                _userService.InsertUser(username, password);
            }
            return Json("User Created Successfully! :)");
        }
    }
}