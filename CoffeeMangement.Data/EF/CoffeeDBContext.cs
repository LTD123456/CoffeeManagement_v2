using CoffeeMangement.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMangement.Data.EF
{
    public class CoffeeDBContext : IdentityDbContext<User, AppRole, Guid>
    {
        public CoffeeDBContext(DbContextOptions options) : base(options)
        {

        }

        public CoffeeDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>().HasKey(k => k.ID);
            modelBuilder.Entity<BillInfo>().HasKey(k => k.ID);
            modelBuilder.Entity<Food>().HasKey(k => k.ID);
            modelBuilder.Entity<FoodCategory>().HasKey(k => k.ID);
            modelBuilder.Entity<TableFood>().HasKey(k => k.ID);
            modelBuilder.Entity<User>().HasKey(k =>k.Id);
            modelBuilder.Entity<AppRole>().HasKey(k => k.Id);

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaim");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRole").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogin").HasKey(x=>x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(x => x.UserId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer("Server=LTHIENDUC\\SQLEXPRESS;Database=CoffeeManagement_v1;Trusted_Connection=True;");
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillInfo> BillInfos { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategorys { get; set; }
        public DbSet<TableFood> TableFoods { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
    }
}
