using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathValley.BLL.BusinessModels;
using DeathValley.BLL.DTO;
using DeathValley.BLL.Interfaces;
using DeathValley.BLL.Logic;
using DeathValley.DAL.Entities;
using DeathValley.DAL.Interfaces;

namespace DeathValley.BLL.Services
{
    public class DataService : IDataService
    {
        private IUnitOfWork Database { get; set; }

        int GetIdIfExist(ParamDTO paramDto)
        {

            var items = Database.Params.GetAll()
                .Where(p => p.CoefficientA == paramDto.CoefficientA)
                .Where(p => p.CoefficientB == paramDto.CoefficientB)
                .Where(p => p.CoefficientC == paramDto.CoefficientC)
                .Where(p => p.RangeFrom == paramDto.RangeFrom)
                .Where(p => p.RangeTo == paramDto.RangeTo)
                .Where(p => p.Step == paramDto.Step);
            if (items.Count() == 1)
            {
                var item = items.First();
                return item.ParamId;
            }

            return 0;
        }

        public DataService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public List<CacheDataDTO> GetData(ParamDTO paramsDto)
        {
            var id = GetIdIfExist(paramsDto);
            if (id != 0)
            {
                //var items = GetDataByParamId(id);
                //return items;
                Logic.Logic logic = new GetItemsFromDb(Database, id);
                return logic.GetItems();

            }
            else
            {
                //int dataID = AddParams(paramsDto);
                //paramsDto.ParamId = dataID;
                //var items = CalculateData(paramsDto);
                Logic.Logic logic = new CalculateItems(Database, paramsDto);
                return logic.GetItems();
            }
        }

        //int AddParams(ParamDTO paramDto)
        //{
        //    Param _param = new Param
        //    {
        //        CoefficientA = paramDto.CoefficientA,
        //        CoefficientB = paramDto.CoefficientB,
        //        CoefficientC = paramDto.CoefficientC,
        //        RangeFrom = paramDto.RangeFrom,
        //        RangeTo = paramDto.RangeTo,
        //        Step = paramDto.Step
        //    };
        //    Database.Params.Create(_param);
        //    Database.Save();
        //    return _param.ParamId;
        //}


        //List<CacheDataDTO> CalculateData(ParamDTO paramsDto)
        //{
        //    Function func = new Function(paramsDto);
        //    var data = func.Calculate();
        //    var Param = Database.Params.Get(paramsDto.ParamId);
        //    foreach (var item in data)
        //    {
        //        var DataItem = new CacheData()
        //        {
        //            Param = Param,
        //            PointY = item.PointY,
        //            PointX = item.PointX
        //        };
        //        Database.Data.Create(DataItem);
        //    }
        //    Database.Save();
        //    return data;
        //}

        //List<CacheDataDTO> GetDataByParamId(int id)
        //{
        //    var Param = Database.Params.Get(id);
        //    var items = Database.Data.Find(d => d.Param == Param);
        //    List<CacheDataDTO> returnList = new List<CacheDataDTO>();
        //    foreach (var item in items)
        //    {
        //        CacheDataDTO data = new CacheDataDTO(item.PointX, item.PointY, item.CacheDataId);
        //        returnList.Add(data);
        //    }
        //    return returnList;
        //}

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
