using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathValley.DAL.EF;
using DeathValley.DAL.Entities;
using DeathValley.DAL.Interfaces;

namespace DeathValley.DAL.Repositories
{
    public class ParamRepository:IRepository<Param>
    {
        private AppContext db;

        public ParamRepository(AppContext context)
        {
            this.db = context;
        }

        public IEnumerable<Param> GetAll()
        {
            return db.Params;
        }

        public Param Get(int id)
        {
            return db.Params.Find(id);
        }

        public void Create(Param param)
        {
            db.Params.Add(param);
        }

        public IEnumerable<Param> Find(Func<Param, Boolean> predicate)
        {
            return db.Params.Where(predicate).ToList();
        }
    }
}
