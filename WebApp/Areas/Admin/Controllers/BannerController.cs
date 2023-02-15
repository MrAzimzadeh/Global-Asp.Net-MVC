using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly ILogger<BannerController> _logger;

        private readonly AppDbContext _context;

        public BannerController(ILogger<BannerController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var banner = _context.Banners.OrderByDescending(x => x.Id).ToList();
            return View(banner);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string title, string subTitle)
        {
            Banner banner = new Banner();
            banner.Title = title;
            banner.SubTitle = subTitle;
            _context.Banners.Add(banner);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int Id)
        {
            var detail = _context.Banners.FirstOrDefault(x => x.Id == Id);
            return View(detail);
        }

        public IActionResult Delete(int Id)
        {
            var delete = _context.Banners.FirstOrDefault(x => x.Id == Id);
            return View(delete);
        }
        [HttpPost]
        public IActionResult Delete(Banner banner)
        {
            var delete = _context.Banners.FirstOrDefault(x => x.Id == banner.Id);
            _context.Banners.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            var edit = _context.Banners.Find(Id);
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(Banner banner)
        {
            var edit = _context.Banners.FirstOrDefault(x => x.Id == banner.Id);
            edit.SubTitle = banner.SubTitle;
            edit.Title = banner.Title;
            _context.Banners.Update(edit);
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