using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestSerwerTen.Models
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) :base(options)
        {

        }
        public DbSet<uzytkownik> uzytkowniko { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            base.OnModelCreating(modelBuilder);
        }
    /*    public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            updateUpdatedProperty<Uzytkownik>();
            return base.SaveChanges();
        }
        */
    }
}
