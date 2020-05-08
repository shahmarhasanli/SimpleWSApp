using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Web.Models;
using WebServiceWrapper;
using App.Service;
using App.Service.Models;


namespace App.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
          return View();
        }
        
        public IActionResult Add()
        {
         
            Request request = new Request() { intA=16,intB=4};
            OperationResult response=RestApiCall.ExecuteApiMethod("http://localhost:53457/calculate/add",request);
            
            return View(response);
        }
     
        public IActionResult Subtract()
        {
            Request request = new Request() { intA = 18, intB = 9 };
            var response = RestApiCall.ExecuteApiMethod("http://localhost:53457/calculate/subtract", request);
            return View(response);
        }

       
        public IActionResult Multiply()
        {
            Request request = new Request() { intA = 4, intB = 4 };
            var response = RestApiCall.ExecuteApiMethod("http://localhost:53457/calculate/multiply", request);
            return View(response);
        }
 
        public IActionResult Divide()
        {
            Request request = new Request() { intA = 4, intB = 4 };
            var response = RestApiCall.ExecuteApiMethod("http://localhost:53457/calculate/divide", request);
            return View(response);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
