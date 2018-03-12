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
                Logic.Logic logic = new GetItemsFromDb(Database, id);
                return logic.GetItems();

            }
            else
            {
                Logic.Logic logic = new CalculateItems(Database, paramsDto);
                return logic.GetItems();
            }
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
