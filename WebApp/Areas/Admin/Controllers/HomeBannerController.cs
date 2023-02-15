using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Helpers;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeBannerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeBannerController> _logger;

        private readonly IWebHostEnvironment _env;
        public HomeBannerController(ILogger<HomeBannerController> logger, AppDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var banner = _context.BannerHomes.ToList();
            return View(banner);
        }
        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Create(string title, string? empty, IFormFile photo)
        {
            BannerHome home = new BannerHome();
            home.Title = title;
            home.PhotoUrl = ImageHelper.UploadSinglePhoto(photo, _env);
            if (empty != null)
            {
                home.Empty = empty;
            }
            else
            {
                home.Empty = "";
            }
            _context.BannerHomes.Add(home);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}