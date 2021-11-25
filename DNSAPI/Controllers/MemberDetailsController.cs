using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DNSAPI.Requests;
using DNSAPI.Service.Interface;
using DNSAPI.Model;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace DNSAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/getmemdetails")]
    public class MemberDetailsController : Controller
    {
        protected readonly IMemDetailsService _memDetailsService;
        private readonly ILogger<MemberDetailsController> _logger;
        public MemberDetailsController(IMemDetailsService memDetailsService
            , ILogger<MemberDetailsController> logger)
        {
            _memDetailsService = memDetailsService;
            _logger = logger;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> Memberdetails(string Id)
        {
            MemberDetails result = new MemberDetails();
            try
            {
                if (string.IsNullOrEmpty(Id)) return StatusCode(400);

                 result = await
                    _memDetailsService.GetmemDetails(Id);

                if (result == null) return NotFound("The requesting data could not be found");

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Memberdetails " + DateTime.Now + " Error : " + ex.Message + "  #####  " + ex.StackTrace + "  #####  " + ex.InnerException);
                return StatusCode(500, "Internal server error");
            }
            
        }

       
    }
}