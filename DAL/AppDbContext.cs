using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Machines> Machines { get; set; }
        public DbSet<Shifts> Shifts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=EMIR;Database=DijiTaskDB;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }
}
