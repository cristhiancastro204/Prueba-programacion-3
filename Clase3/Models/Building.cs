namespace Clase3.Models
{
    public class Building
    {
        public string Name { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Management { get; set; } = string.Empty;
        public string Ownership { get; set; } = string.Empty;
        public int Units { get; set; }
        public string? BuildingUrl { get; set; }
    }
}
