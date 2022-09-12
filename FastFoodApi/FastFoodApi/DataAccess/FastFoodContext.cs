using FastFoodApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodApi.DataAccess
{
    public class FastFoodContext
    {
        public class FastFoodDbContext : DbContext
        {
            public FastFoodDbContext(DbContextOptions<FastFoodDbContext> options) : base(options)
            {

            }
            public DbSet<FastFoodShopModel> FastfoodshopModels { get; set; }
            public DbSet<FastFoodShopIdModel> fastfoodshopModels { get; set; }
            public DbSet<ItemsModel> itemsModels { get; set; }
            public DbSet<UserModel> userModels { get; set; }
        }
    }
}
