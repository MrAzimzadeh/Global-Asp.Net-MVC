using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<About> Abuts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BannerHome> BannerHomes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<HireUs> HireUs { get; set; }
        public DbSet<Works> Works { get; set; }
        
    }
}