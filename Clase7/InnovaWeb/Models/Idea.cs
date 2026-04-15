using System;

namespace InnovaWeb.Models
{
    public class Idea
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string NombreEquipo { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public DateTime FechaPostulacion { get; set; } = DateTime.Now;
        public bool IsCreative { get; set; }
        public bool IsWellFormulated { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDisapproved { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}
