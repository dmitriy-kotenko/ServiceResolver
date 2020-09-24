using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceResolver.Dialogs;
using ServiceResolver.Models;
using ServiceResolver.Utilities;

namespace ServiceResolver.Controllers
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
            var dialogWithOneParameter = StaticContext.GenericServiceProvider.Get<PrintDialogBase>(
                new KeyValuePair<string, object>("name", "someDialog"));

            var dialogWithTwoParameter = StaticContext.GenericServiceProvider.Get<PrintDialogBase>(
                new KeyValuePair<string, object>("name", "someOtherDialog"),
                new KeyValuePair<string, object>("visible", true));

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
