using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class ShopsDB : DbContext
    {
        public ShopsDB() : base("ShopsDB") { }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<ShopsDB>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<Item> Items { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
