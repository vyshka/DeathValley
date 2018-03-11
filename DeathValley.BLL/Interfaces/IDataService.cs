using System.Collections.Generic;
using DeathValley.BLL.DTO;
using DeathValley.DAL.Entities;

namespace DeathValley.BLL.Interfaces
{
    public interface IDataService
    {

        List<CacheDataDTO> GetData(ParamDTO paramsDto);
        void Dispose();
    }
}