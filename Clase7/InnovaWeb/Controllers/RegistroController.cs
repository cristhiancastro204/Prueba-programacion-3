using Microsoft.AspNetCore.Mvc;
using InnovaWeb.Models;
using InnovaWeb.Services;
using System.Collections.Generic;
using System.Linq;

namespace InnovaWeb.Controllers
{
    public class RegistroController : Controller
    {
        private readonly DataStoreService _dataStore;

        public RegistroController(DataStoreService dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string teamName, string password, string passwordConfirm, int numMembers, string membersNames)
        {
            if (password != passwordConfirm)
            {
                ViewBag.Error = "Las contraseñas no coinciden.";
                return View();
            }

            if (numMembers < 1 || numMembers > 2)
            {
                ViewBag.Error = "El número de integrantes no está permitido (Max: 2).";
                return View();
            }

            string[] nombres = membersNames.Split(',');
            if (nombres.Length != numMembers)
            {
                ViewBag.Error = $"Usted indicó {numMembers} integrantes, pero ingresó {nombres.Length} nombres separados por coma.";
                return View();
            }
            
            List<Equipo> equipos = _dataStore.ObtenerEquipos();
            
            for (int i = 0; i < nombres.Length; i++)
            {
                nombres[i] = nombres[i].Trim();
            }

            foreach (Equipo eq in equipos)
            {
                string[] eqNombres = eq.NombresIntegrantes.Split(',');
                foreach (string n in eqNombres)
                {
                    string nm = n.Trim().ToLower();
                    if (nombres.Any(incoming => incoming.ToLower() == nm))
                    {
                        ViewBag.Error = $"El integrante '{n.Trim()}' ya se encuentra registrado en el equipo '{eq.NombreEquipo}'. Los integrantes no pueden repetirse.";
                        return View();
                    }
                }
            }

            Equipo? existente = equipos.FirstOrDefault(e => e.NombreEquipo.ToLower() == teamName.ToLower());
            if (existente != null)
            {
                ViewBag.Error = "Ya hay un equipo con ese nombre, ingrese otro nombre.";
                return View();
            }

            Equipo nuevoEquipo = new Equipo
            {
                NombreEquipo = teamName,
                Password = password,
                NumIntegrantes = numMembers,
                NombresIntegrantes = membersNames
            };

            _dataStore.GuardarEquipo(nuevoEquipo);
            ViewBag.Success = "Ingresado con exito";
            return View();
        }
    }
}
