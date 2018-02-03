using System;
using DeathValley.DAL.Entities;

namespace DeathValley.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Param> Params { get; }

        IRepository<CacheData> Data { get; }
        void Save();
    }
}