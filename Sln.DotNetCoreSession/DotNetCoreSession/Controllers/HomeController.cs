using DotNetCoreSession.LIB;
using DotNetCoreSession.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DotNetCoreSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var contentRoot = _hostingEnvironment.ContentRootPath;
            HttpContext.Session.SetString("SessionTime", DateTime.Now.AddDays(-10).ToLongDateString());
            List<PersonalInfo> listPersonalInfo = JSONReader<PersonalInfo>.GetAll("dataPersonalInfo", contentRoot);
            HttpContext.Session.SetObjectAsJson("PersonalInfoData", listPersonalInfo);

            return View();
        }

        public IActionResult DisplayingSessionVariable()
        {
            List<PersonalInfo> myComplexObject = HttpContext.Session.GetObjectFromJson<List<PersonalInfo>>("PersonalInfoData");
            ViewBag.ListData = myComplexObject;
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
