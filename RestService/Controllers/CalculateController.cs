using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebServiceWrapper;

namespace RestService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
      

        private readonly ILogger<CalculateController> _logger;

        public CalculateController(ILogger<CalculateController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        [Route("~/calculate/add")]
        public async Task<AddResponse> AddAsync([FromBody]Request request)
        {
            WebServiceWrapper.WsSoapWrapper SoapWs = new WsSoapWrapper();
            var result = await SoapWs.AddAsync(request);
            return result;
        }
        [HttpPost]
        [Route("~/calculate/subtract")]
        public async Task<SubtractResponse> SubtractAsync([FromBody]Request request)
        {
            
            WebServiceWrapper.WsSoapWrapper SoapWs = new WsSoapWrapper();
            var result = await SoapWs.SubtractAsync(request);
            return result;
        }
        [HttpPost]
        [Route("~/calculate/multiply")]
        public async Task<MultiplyResponse> MultiplyAsync([FromBody]Request request)
        {
            WebServiceWrapper.WsSoapWrapper SoapWs = new WsSoapWrapper();
            var result = await SoapWs.MultiplyAsync(request);
            return result;
        }
        [HttpPost]
        [Route("~/calculate/divide")]
        public async Task<DivideResponse> DivideAsync([FromBody]Request request)
        {
            WebServiceWrapper.WsSoapWrapper SoapWs = new WsSoapWrapper();
            var result = await SoapWs.DivideAsync(request);
            return result;
        }
        
    }
}
