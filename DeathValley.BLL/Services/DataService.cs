using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathValley.BLL.BusinessModels;
using DeathValley.BLL.DTO;
using DeathValley.BLL.Interfaces;
using DeathValley.DAL.Entities;
using DeathValley.DAL.Interfaces;

namespace DeathValley.BLL.Services
{
    public class DataService : IDataService
    {
        private IUnitOfWork Database { get; set; }

        public DataService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public List<CacheDataDTO> CalculateData(ParamDTO paramsDto)
        {
            Function func = new Function(paramsDto);
            var data = func.Calculate();
            var Param = Database.Params.Get(paramsDto.ParamId);
            foreach (var item in data)
            {
                var DataItem = new CacheData()
                {
                    Param = Param,
                    PointY = item.PointY,
                    PointX = item.PointX
                };
                Database.Data.Create(DataItem);
            }
            Database.Save();
            return data;
        }

        public List<CacheDataDTO> GetDataByParamId(int id)
        {
            var Param = Database.Params.Get(id);
            var items = Database.Data.Find(d => d.Param == Param);
            List<CacheDataDTO> returnList = new List<CacheDataDTO>();
            foreach (var item in items)
            {
                CacheDataDTO data = new CacheDataDTO(item.PointX, item.PointY, item.CacheDataId);
                returnList.Add(data);
            }
            return returnList;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
