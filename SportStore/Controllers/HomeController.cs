using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStoreRepository IStoreRepo;
    public HomeController(ILogger<HomeController> logger, IStoreRepository storeRepo)
    {
        _logger = logger;
        IStoreRepo = storeRepo;
    }

    public IActionResult Index()
    {
        
        return View(IStoreRepo.GetProducts);
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