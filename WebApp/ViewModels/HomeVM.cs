using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class HomeVM
    {
        public List<Banner> Banners { get; set; }
        public BannerHome BannerHomes { get; set; }
    }
}