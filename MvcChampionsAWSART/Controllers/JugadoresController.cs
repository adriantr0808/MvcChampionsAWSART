using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcChampionsAWSART.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcChampionsAWSART.Controllers
{
    public class JugadoresController : Controller
    {
        private Repositories.ChampionsRepository repo;
        private Services.ServiceAWSS3 service;

        public JugadoresController(Repositories.ChampionsRepository repo, Services.ServiceAWSS3 service)
        {
            this.repo = repo;
            this.service = service;
        }
        public IActionResult Index()
        {
            List<Jugador> jugadores = this.repo.GetJugadores();
            return View(jugadores);
        }

        public IActionResult Create()
        {
            List<Equipo> equipos = this.repo.GetEquipos();
            ViewData["EQUIPOS"] = equipos;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Jugador j,IFormFile file,  int idequipo)
        {
            using (Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync(stream, file.FileName);
            }
            this.repo.InsertJugador( j.Nombre, j.Posicion, file.FileName, idequipo);
            
            return RedirectToAction("Index");
        }


        
    }
}
