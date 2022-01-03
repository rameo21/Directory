using Microsoft.EntityFrameworkCore;
using ReportAPI.EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.DataLayer
{
    public class ReportDbContext:DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options)
 : base(options)
        {
        }

        public ReportDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=_Jzg6x^c;Host=localhost;Port=5432;Database=Report;Pooling=true;Integrated Security=true;");
        }
        public DbSet<Report> Report { get; set; }
    }
}
