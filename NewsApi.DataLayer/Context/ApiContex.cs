using Microsoft.EntityFrameworkCore;
using NewsApi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.DataLayer.Context
{
    public class ApiContex : DbContext
    {

        public ApiContex(DbContextOptions<ApiContex> options) :base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
