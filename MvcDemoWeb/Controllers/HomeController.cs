using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcDemoBusiness.Models;
using MvcDemoBusiness.Realization;
using MvcDemoWeb.Models;
using MvcDemoWeb.Models.Request;

namespace MvcDemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITestService _testService;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ITestService testService,IMapper mapper, ILogger<HomeController> logger)
        {
            _testService = testService;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        { 
            _logger.LogError("打印日志");
            GetStringRequest request = new GetStringRequest()
            {
                Id = 1,
                Name = "测试",
                CreateTime =1212121,
                Age = 12
            };
            var testRequest = _mapper.Map<TestRequest>(request);

            string str = _testService.GetTestString(testRequest);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
