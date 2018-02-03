﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathValley.BLL.DTO;
using DeathValley.BLL.Infrastructure;
using DeathValley.BLL.Interfaces;
using DeathValley.DAL.Interfaces;

namespace DeathValley.BLL.Services
{
    public class ParamService: IParamService
    {
        private IUnitOfWork Database { get; set; }

        public ParamService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public int GetIdIfExist(ParamDTO paramDto)
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

        //public void Add(ParamDTO paramDto)
        //{

        //}
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}