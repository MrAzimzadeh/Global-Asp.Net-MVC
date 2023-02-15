using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var banner = _context.Banners.OrderByDescending(x => x.Id).ToList();
        var home = _context.BannerHomes.OrderByDescending(x => x.Id).First();

        HomeVM homeVM = new HomeVM()
        {
            Banners = banner,
            BannerHomes = home
        };
        return View(homeVM);
    }

    [HttpPost]
    public IActionResult Hire(string name, string email, List<string> check)
    {
        //biz burada gelen melumati parcalayib arasina vergul qoyuruq 
        string checkStr = string.Join(",", check);
        HireUs hire = new HireUs();
        hire.Name = name;
        hire.Email = email;
        hire.Check = checkStr;
        _context.HireUs.Add(hire);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
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
