using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using InnovaWeb.Models;

namespace InnovaWeb.Services
{
    public class DataStoreService
    {
        private readonly string _equiposPath = "equipos.json";
        private readonly string _ideasPath = "ideas.json";

        public List<Equipo> ObtenerEquipos()
        {
            if (!File.Exists(_equiposPath))
            {
                return new List<Equipo>();
            }
            string json = File.ReadAllText(_equiposPath);
            List<Equipo>? equipos = JsonSerializer.Deserialize<List<Equipo>>(json);
            return equipos ?? new List<Equipo>();
        }

        public void GuardarEquipo(Equipo equipo)
        {
            List<Equipo> equipos = ObtenerEquipos();
            equipos.Add(equipo);
            string json = JsonSerializer.Serialize(equipos);
            File.WriteAllText(_equiposPath, json);
        }

        public List<Idea> ObtenerIdeas()
        {
            if (!File.Exists(_ideasPath))
            {
                return new List<Idea>();
            }
            string json = File.ReadAllText(_ideasPath);
            List<Idea>? ideas = JsonSerializer.Deserialize<List<Idea>>(json);
            return ideas ?? new List<Idea>();
        }

        public void GuardarIdea(Idea idea)
        {
            List<Idea> ideas = ObtenerIdeas();
            ideas.Add(idea);
            string json = JsonSerializer.Serialize(ideas);
            File.WriteAllText(_ideasPath, json);
        }

        public void ActualizarIdea(Idea ideaActualizada)
        {
            List<Idea> ideas = ObtenerIdeas();
            int index = ideas.FindIndex(i => i.Id == ideaActualizada.Id);
            if (index != -1)
            {
                ideas[index] = ideaActualizada;
                string json = JsonSerializer.Serialize(ideas);
                File.WriteAllText(_ideasPath, json);
            }
        }
    }
}
