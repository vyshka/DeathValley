using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathValley.DAL.EF;
using DeathValley.DAL.Entities;
using DeathValley.DAL.Interfaces;

namespace DeathValley.DAL.Repositories
{
    public class CacheDataRepository: IRepository<CacheData>
    {
        private AppContext db;

        public CacheDataRepository(AppContext context)
        {
            this.db = context;
        }

        public IEnumerable<CacheData> GetAll()
        {
            return db.Data;
        }

        public CacheData Get(int id)
        {
            return db.Data.Find(id);
        }

        public void Create(CacheData data)
        {
            db.Data.Add(data);
        }

        public IEnumerable<CacheData> Find(Func<CacheData, Boolean> predicate)
        {
            return db.Data.Where(predicate).ToList();
        }
    }
}
