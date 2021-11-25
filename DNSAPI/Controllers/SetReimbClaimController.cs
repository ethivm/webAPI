using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DNSAPI.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using DNSAPI.Model;

namespace DNSAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/setreimbclaim")]
    public class SetReimbClaimController : Controller
    {
        protected readonly ISetReimbClaimService _setReimbClaimService;
        private readonly ILogger<SetReimbClaimController> _logger;
        public SetReimbClaimController(ISetReimbClaimService setReimbClaimService
            , ILogger<SetReimbClaimController> logger)
        {
            _setReimbClaimService = setReimbClaimService;
            _logger = logger;
        }

        [Authorize("Bearer")]
        [HttpPost]
        [Route("")]
        public ActionResult SetReimbClaim([FromBody] ReimbClaim request)
        {
            try
            {
                _setReimbClaimService.SetReimbClaim(request);
                return StatusCode(200, "Created Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("SetReimbClaim " + DateTime.Now + " Error : " + ex.Message + "  #####  " + ex.StackTrace + "  #####  " + ex.InnerException);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}