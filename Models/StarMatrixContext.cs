using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StarMatrix.Models
{
    public class StarMatrixContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StarMatrixContext() : base("name=StarMatrixContext")
        {
        }

        public System.Data.Entity.DbSet<StarMatrix.Models.Admin> Admins { get; set; }

        public System.Data.Entity.DbSet<StarMatrix.Models.ShipLocation> ShipLocations { get; set; }

        public System.Data.Entity.DbSet<StarMatrix.Models.Tug> Tugs { get; set; }

        public System.Data.Entity.DbSet<StarMatrix.Models.Towage> Towages { get; set; }

        public System.Data.Entity.DbSet<StarMatrix.Models.Recycling> Recyclings { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<StarMatrixContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
