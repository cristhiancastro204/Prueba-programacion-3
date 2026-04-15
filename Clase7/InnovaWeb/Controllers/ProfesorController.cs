using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InnovaWeb.Models;
using InnovaWeb.Services;
using System.Collections.Generic;
using System.Linq;

namespace InnovaWeb.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly DataStoreService _dataStore;

        public ProfesorController(DataStoreService dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string? loggedIn = HttpContext.Session.GetString("ProfesorLogged");
            if (loggedIn == "true")
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string profUser, string profPass)
        {
            if (profUser == "profesor" && profPass == "admin123")
            {
                HttpContext.Session.SetString("ProfesorLogged", "true");
                return RedirectToAction("Dashboard");
            }
            
            ViewBag.Error = "Credenciales de profesor inválidas.";
            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            string? loggedIn = HttpContext.Session.GetString("ProfesorLogged");
            if (loggedIn != "true")
            {
                return RedirectToAction("Index");
            }

            List<Idea> ideas = _dataStore.ObtenerIdeas().OrderByDescending(i => i.FechaPostulacion).ToList();
            ViewBag.Equipos = _dataStore.ObtenerEquipos();
            return View(ideas);
        }

        [HttpPost]
        public IActionResult UpdateIdeaStatus(string id, string field, bool isChecked)
        {
            string? loggedIn = HttpContext.Session.GetString("ProfesorLogged");
            if (loggedIn != "true")
            {
                return Unauthorized();
            }

            List<Idea> ideas = _dataStore.ObtenerIdeas();
            Idea? idea = ideas.FirstOrDefault(i => i.Id == id);
            
            if (idea != null)
            {
                if (field == "isApproved" && isChecked)
                {
                    int aprobadasCount = ideas.Count(i => i.NombreEquipo == idea.NombreEquipo && i.IsApproved && i.Id != idea.Id);
                    if (aprobadasCount >= 2)
                    {
                        return BadRequest("Este equipo ya ha alcanzado el límite máximo de 2 ideas aprobadas.");
                    }
                }

                if (field == "isCreative") idea.IsCreative = isChecked;
                if (field == "isWellFormulated") idea.IsWellFormulated = isChecked;
                if (field == "isApproved") idea.IsApproved = isChecked;
                if (field == "isDisapproved") idea.IsDisapproved = isChecked;
                
                _dataStore.ActualizarIdea(idea);
            }
            
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateIdeaObservation(string id, string text)
        {
            string? loggedIn = HttpContext.Session.GetString("ProfesorLogged");
            if (loggedIn != "true")
            {
                return Unauthorized();
            }

            List<Idea> ideas = _dataStore.ObtenerIdeas();
            Idea? idea = ideas.FirstOrDefault(i => i.Id == id);
            
            if (idea != null)
            {
                idea.Observaciones = text ?? string.Empty;
                _dataStore.ActualizarIdea(idea);
            }
            
            return Ok();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("ProfesorLogged");
            return RedirectToAction("Index");
        }
    }
}
