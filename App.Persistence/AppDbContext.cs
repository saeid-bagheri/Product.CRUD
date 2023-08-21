using App.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                .HasMaxLength(50);

                entity.Property(e => e.ManufacturePhone)
                .HasMaxLength(11)
                .IsFixedLength();
            });

            builder.Entity<Product>()
                .HasIndex(p => new { p.ManufactureEmail, p.ProductDate })
                .IsUnique();


        }

    }
}
