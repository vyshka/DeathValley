using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathValley.BLL.DTO;
using DeathValley.DAL.Interfaces;
using DeathValley.DAL.Entities;
using DeathValley.BLL.BusinessModels;

namespace DeathValley.BLL.Logic
{
    public abstract class Logic
    {
        public IUnitOfWork Database { get; set; }
        public int id { get; set; }
        public  ParamDTO paramsDto { get; set; }

        public Logic(IUnitOfWork uow, int id)
        {
            Database = uow;
            this.id = id;
        }

        public Logic(IUnitOfWork uow, ParamDTO paramsDto)
        {
            Database = uow;
            this.paramsDto = paramsDto;
        }
        abstract public List<CacheDataDTO> GetItems();
    }

    public class GetItemsFromDb : Logic
    {
        public GetItemsFromDb(IUnitOfWork uow, int id) : base (uow, id)
        {
        }
        public override List<CacheDataDTO> GetItems()
        {
            var items = GetDataByParamId(id);
            return items;
        }

        List<CacheDataDTO> GetDataByParamId(int id)
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

    }

    public class CalculateItems : Logic
    {

        public CalculateItems(IUnitOfWork uow, ParamDTO paramsDto) : base(uow, paramsDto)
        {
        }

        public override List<CacheDataDTO> GetItems()
        {
            int dataID = AddParams(paramsDto);
            paramsDto.ParamId = dataID;
            var items = CalculateData(paramsDto);
            return items;
        }

        int AddParams(ParamDTO paramDto)
        {
            Param _param = new Param
            {
                CoefficientA = paramDto.CoefficientA,
                CoefficientB = paramDto.CoefficientB,
                CoefficientC = paramDto.CoefficientC,
                RangeFrom = paramDto.RangeFrom,
                RangeTo = paramDto.RangeTo,
                Step = paramDto.Step
            };
            Database.Params.Create(_param);
            Database.Save();
            return _param.ParamId;
        }

        List<CacheDataDTO> CalculateData(ParamDTO paramsDto)
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

    }
}
