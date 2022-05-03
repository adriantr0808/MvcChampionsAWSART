using Microsoft.AspNetCore.Mvc;
using MvcChampionsAWSART.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcChampionsAWSART.Controllers
{
    public class ApuestasController : Controller
    {
        private Repositories.ChampionsRepository repo;

        public ApuestasController(Repositories.ChampionsRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Apuesta> apuestas = this.repo.GetApuestas();
            return View(apuestas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Apuesta a)
        {
            this.repo.InsertApuestas(a.Usuario, a.IdEquipoLocal, a.IdEquipoVisitante, a.GolesEquipoLocal, a.GolesEquipoVisitante);

            return RedirectToAction("Index");
        }

    }
}
