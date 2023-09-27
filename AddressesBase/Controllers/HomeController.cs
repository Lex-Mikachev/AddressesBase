using System.Diagnostics;
using AddressesBase.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AddressesBase.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressesBase.Controllers;

public class HomeController : Controller
{
    private ApplicationContext _db;
    
//    public readonly ILogger<HomeController> _logger;
/*
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
*/
    public HomeController(ApplicationContext context)
    {
        _db = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}