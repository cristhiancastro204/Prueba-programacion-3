using Microsoft.AspNetCore.Mvc;
using InnovaWeb.Models;
using InnovaWeb.Services;
using System.Collections.Generic;
using System.Linq;

namespace InnovaWeb.Controllers
{
    public class PostulacionController : Controller
    {
        private readonly DataStoreService _dataStore;

        public PostulacionController(DataStoreService dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string loginTeamName, string loginPassword, string ideaText)
        {
            List<Equipo> equipos = _dataStore.ObtenerEquipos();
            
            Equipo? equipo = equipos.FirstOrDefault(e => e.NombreEquipo.ToLower() == loginTeamName.ToLower() && e.Password == loginPassword);
            
            if (equipo == null)
            {
                ViewBag.Error = "Credenciales incorrectas o el equipo no existe.";
                return View();
            }

            List<Idea> ideas = _dataStore.ObtenerIdeas();
            int aprobadasCount = ideas.Count(i => i.NombreEquipo == equipo.NombreEquipo && i.IsApproved);
            
            if (aprobadasCount >= 2)
            {
                ViewBag.Error = "Su equipo ya cuenta con 2 ideas aprobadas, por lo que no puede postular más ideas.";
                return View();
            }

            Idea nuevaIdea = new Idea
            {
                NombreEquipo = equipo.NombreEquipo,
                Texto = ideaText,
                IsCreative = false,
                IsWellFormulated = false,
                IsApproved = false
            };

            _dataStore.GuardarIdea(nuevaIdea);
            
            ViewBag.Success = "La idea fue postulada con éxito, espere por aprobación.";
            return View();
        }
    }
}
