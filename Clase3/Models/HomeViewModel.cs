using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Clase3.Models
{
    public class HomeViewModel
    {
        [JsonPropertyName("hero_image_url")]
        public string HeroImageUrl { get; set; } = string.Empty;
        
        [JsonPropertyName("count")]
        public int Count { get; set; }
        
        [JsonPropertyName("buildings")]
        public List<Building> Buildings { get; set; } = new List<Building>();
    }
}
