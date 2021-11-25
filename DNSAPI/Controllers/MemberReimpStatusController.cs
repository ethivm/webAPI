using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DNSAPI.Service.Interface;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;

namespace DNSAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/getmemreimpstatus")]
    public class MemberReimpStatusController : Controller
    {
        protected readonly IMemReimpStatusService _memReimpStatusService;
        private readonly ILogger<MemberReimpStatusController> _logger;
        public MemberReimpStatusController(IMemReimpStatusService memReimpStatusService
            , ILogger<MemberReimpStatusController> logger)
        {
            _memReimpStatusService = memReimpStatusService;
            _logger = logger;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> MemReimpStatus(string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id)) return StatusCode(400);

                var result = await _memReimpStatusService.GetmemReimpStatus(Id);

                if (result == null) return NotFound("The requesting data could not be found");

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("MemReimpStatus " + DateTime.Now + " Error : " + ex.Message + "  #####  " + ex.StackTrace + "  #####  " + ex.InnerException);
                return StatusCode(500, "Internal server error");
            }
            
        }

       
    }
}