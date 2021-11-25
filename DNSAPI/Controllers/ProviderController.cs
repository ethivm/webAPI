using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DNSAPI.Requests;
using DNSAPI.Service.Interface;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace DNSAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/membernetwork")]
    public class ProviderController : Controller
    {
        protected readonly IProviderService _providerService;
        private readonly ILogger<ProviderController> _logger;
        public ProviderController(IProviderService providerService
              , ILogger<ProviderController> logger)
        {
            _providerService = providerService;
            _logger = logger;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> membernetworkdetails(string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id)) return StatusCode(400);

                var result = await _providerService.GetMemberNetwork(Id);

                if (result == null) return NotFound("The requesting data could not be found");

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("membernetworkdetails " + DateTime.Now + " Error : " + ex.Message + "  #####  " + ex.StackTrace + "  #####  " + ex.InnerException);
                return StatusCode(500, "Internal server error");
            }
           
        }

       
    }
}