using Microsoft.EntityFrameworkCore;
using FoodFacts.Domain.Entities;

namespace FoodFacts.Infrastructure.Data
{
    public class FoodFactsDbContext : DbContext
    {
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public FoodFactsDbContext(DbContextOptions<FoodFactsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(30);
                entity.Property(e => e.Dni).HasMaxLength(30);
                entity.HasOne(e => e.Rol)
                      .WithMany()
                      .HasForeignKey(e => e.RolId);
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(30);
                entity.Property(e => e.Description).HasMaxLength(30);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Plan)
                      .WithMany()
                      .HasForeignKey(e => e.PlanId);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Order)
                      .WithMany()
                      .HasForeignKey(e => e.OrderId);
            });
        }
    }
}