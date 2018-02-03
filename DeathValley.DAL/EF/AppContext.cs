using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathValley.DAL.Entities;

namespace DeathValley.DAL.EF
{
    public class AppContext : DbContext
    {
        public DbSet<Param> Params { get; set; }
        public DbSet<CacheData> Data { get; set; }

        public AppContext(string connectionString) : base(connectionString)
        {
        }
    }
}
