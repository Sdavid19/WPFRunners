using Jedlik.EntityFramework.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futoverseny.adatok
{
    public class FutoversenyContext : JedlikDbContext
    {
        public DbSet<VersenyzoModel> Versenyzok { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connString = "Server=localhost;database=verseny;uid=root;pwd=;";
            optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TavolsagModel>().HasData(
                new TavolsagModel() { Id = 1, Megnevezes = "maraton" },
                new TavolsagModel() { Id = 2, Megnevezes = "félmaraton" },
                new TavolsagModel() { Id = 3, Megnevezes = "10km" },
                new TavolsagModel() { Id = 4, Megnevezes = "5km" },
                new TavolsagModel() { Id = 5, Megnevezes = "2km" }
                );

            modelBuilder.Entity<VersenyzoModel>().HasData(
               new VersenyzoModel() { Id = 1, Nev = "Sanyi", Neme = "fiu", Korosztaly = "senior", Rajtszam = 1, TavolsagId = 3}
            );
        }
    }
}
