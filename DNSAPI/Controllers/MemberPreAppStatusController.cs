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
    [Route("api/getmempreappstatus")]
    public class MemberPreAppStatusController : Controller
    {
        protected readonly IMemPreAppStatusService _memPreAppStatusService;
        private readonly ILogger<MemberPreAppStatusController> _logger;

        public MemberPreAppStatusController(IMemPreAppStatusService memPreAppStatusService
             , ILogger<MemberPreAppStatusController> logger)
        {
            _memPreAppStatusService = memPreAppStatusService;
            _logger = logger;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetMemPreAppStatus(string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id)) return StatusCode(400);

                var result = await _memPreAppStatusService.GetMemPreAppStatus(Id);

                if (result == null) return NotFound("The requesting data could not be found");

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetMemPreAppStatus " + DateTime.Now + " Error : " + ex.Message + "  #####  " + ex.StackTrace + "  #####  " + ex.InnerException);
                return StatusCode(500, "Internal server error");
            }
           
        }

       
    }
}