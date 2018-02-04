using System.Collections.Generic;
using DeathValley.BLL.DTO;
using DeathValley.DAL.Entities;

namespace DeathValley.BLL.Interfaces
{
    public interface IDataService
    {
        List<CacheDataDTO> CalculateData(ParamDTO paramsDto);
        List<CacheDataDTO> GetDataByParamId(int id);
        void Dispose();
    }
}