namespace InnovaWeb.Models
{
    public class Equipo
    {
        public string NombreEquipo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int NumIntegrantes { get; set; }
        public string NombresIntegrantes { get; set; } = string.Empty;
    }
}
