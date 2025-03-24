using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;

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

    public IActionResult Index(int productPage= 1)
    {
        // return View(IStoreRepo.GetProducts.
        //     OrderBy(p => p.productId)
        //     .Skip(productPage * pageSize -pageSize).Take(pageSize));
        var pageSize = 5;
        return View(new ProductListViewModel
        {

            Products = IStoreRepo.GetProducts.OrderBy(p => p.productId).Skip((productPage - 1) * pageSize)
                .Take(pageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemPerPage = pageSize,
                TotalItems = IStoreRepo.GetProducts.Count()
            }
        });
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