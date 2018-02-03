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
    public class EFUnitOfWork:IUnitOfWork
    {
        private AppContext db;
        private ParamRepository paramRepository;
        private CacheDataRepository cacheDataRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new AppContext(connectionString);;
        }

        public IRepository<Param> Params
        {
            get
            {
                if(paramRepository == null)
                    paramRepository = new ParamRepository(db);
                return paramRepository;
            }
        }

        public IRepository<CacheData> Data
        {
            get
            {
                if(cacheDataRepository == null)
                    cacheDataRepository = new CacheDataRepository(db);
                return cacheDataRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
