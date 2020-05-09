using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebServiceWrapper;

namespace RestService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
      

        private readonly ILogger<CalculateController> _logger;
        private readonly IConfiguration _configuration;
        public CalculateController(ILogger<CalculateController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("~/calculate/add")]
        public ActionResult<AddResponse> AddAsync([FromBody]Request request)
        {
            WebServiceWrapper.WsSoapWrapper SoapWs = new WsSoapWrapper(_configuration);
            var result = SoapWs.AddAsync(request);
            return Ok(result);
        }
        [HttpPost]
        [Route("~/calculate/subtract")]
        public ActionResult<SubtractResponse> SubtractAsync([FromBody]Request request)
        {
            
            WebServiceWrapper.WsSoapWrapper SoapWs = new WsSoapWrapper(_configuration);
            var result = SoapWs.SubtractAsync(request);
            return Ok(result);
        }
        [HttpPost]
        [Route("~/calculate/multiply")]
        public ActionResult<MultiplyResponse> MultiplyAsync([FromBody]Request request)
        {
            WebServiceWrapper.WsSoapWrapper SoapWs = new WsSoapWrapper(_configuration);
            var result =  SoapWs.MultiplyAsync(request);
            return Ok(result);
        }
        [HttpPost]
        [Route("~/calculate/divide")]
        public ActionResult<DivideResponse> DivideAsync([FromBody]Request request)
        {
            WebServiceWrapper.WsSoapWrapper SoapWs = new WsSoapWrapper(_configuration);
            var result = SoapWs.DivideAsync(request);
            return Ok(result);
        }
        
    }
}
