using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcChampionsAWSART.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcChampionsAWSART.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Repositories.ChampionsRepository repo;
        public HomeController(ILogger<HomeController> logger, Repositories.ChampionsRepository repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Equipo> equipos = this.repo.GetEquipos();
            return View(equipos);
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
