using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Reporter_MVC.Models
{
    public class ReporterDbContext : DbContext
    {
        public ReporterDbContext() : base("name=ReporterDbContext") { }

        // جداول دیتابیس اینجا اضافه می‌شوند
        public DbSet<Darkhast> Darkhasts { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<GlobalDetail> GlobalDetails { get; set; }
    }
}