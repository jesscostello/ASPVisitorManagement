using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPVisitorManagement.Models;
using ASPVisitorManagement.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.CommandLine;

namespace ASPVisitorManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITextFileOperations _textFileOperations;

        public HomeController(ITextFileOperations textFileOperations)
        {
            _textFileOperations = textFileOperations;
        }

        public IActionResult Index()
        {
            ViewData["Conditions"] = _textFileOperations.LoadCondiditonsForAcceptanceText();
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
