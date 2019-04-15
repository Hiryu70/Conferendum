using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Conferendum.Models
{
    public class ConferenceContext : DbContext
    {
        public DbSet<SectionEntry> SectionEntry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=conferendum;user=confadmin;password=Ghjcnj_Gfhjkm1");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SectionEntry>(entity =>
            {
                entity.HasKey(e => e.Section);
                entity.Property(e => e.City).IsRequired();
                entity.Property(e => e.Location).IsRequired();
                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
