using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewsApi.DataLayer.Models;

namespace NewsApi.DataLayer.Context
{
    public class ApiContex : DbContext
    {

        public ApiContex(DbContextOptions<ApiContex> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = -1,
                    UserName = "alibiyabani63@gmail.com",
                    Email = "alibiyabani63@gmail.com",
                    Password = "87-0F-28-CB-E9-E0-86-2E-AD-7D-7A-7E-59-26-AE-62",
                    UserRole = "admin"
                }
                );
        }

    }
}
