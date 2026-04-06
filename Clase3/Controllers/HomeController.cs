using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Clase3.Models;

namespace Clase3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _env;

    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public IActionResult Index()
    {
        var filePath = Path.Combine(_env.WebRootPath, "data", "buildings.json");
        var jsonData = System.IO.File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var model = JsonSerializer.Deserialize<HomeViewModel>(jsonData, options);

        if (model == null)
        {
            model = new HomeViewModel();
        }

        // Filtro exacto de los edificios solicitados en las imágenes
        var exactOrder = new List<string> 
        {
            "Imprint", "Alta at K Station", "Marquee at Block 37", "Coast at Lakeshore East",
            "The Shelby", "1000 South Clark", "Coeval", "811 Uptown",
            "L Logan Square", "The Kent Chicago", "Southport Lofts", "Wave Chicago",
            "2 West Delaware", "944 West Montrose", "The Hazelton", "Wilson Club",
            "3200 North Clark", "619 South Lasalle", "The Buckler", "Avenir"
        };

        var filteredBuildings = new List<Building>();
        foreach (var name in exactOrder)
        {
            var b = model.Buildings.FirstOrDefault(x => x.Name.Trim().Equals(name, StringComparison.OrdinalIgnoreCase));
            if (b != null) filteredBuildings.Add(b);
        }
        
        model.Buildings = filteredBuildings;

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
