using ContactAPI.EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPI.DataLayer
{
    public class DirectoryDbContext : DbContext
    {
        public DirectoryDbContext(DbContextOptions<DirectoryDbContext> options)
    : base(options)
        {
        }

        public DirectoryDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=_Jzg6x^c;Host=localhost;Port=5432;Database=Directory;Pooling=true;Integrated Security=true;");
        }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactDetail> ContactDetail { get; set; }
    }
}
