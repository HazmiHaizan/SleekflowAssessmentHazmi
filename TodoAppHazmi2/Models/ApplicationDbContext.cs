using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppHazmi2.Authentication;

namespace TodoAppHazmi2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TodoItemModel> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoItemModel>(entity =>
            {
                entity.Property(e => e.ItemName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.ItemDescription)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.ItemStatus)
                .IsRequired()
                .HasMaxLength(100);

            });
            base.OnModelCreating(builder);
        }
    }
}
