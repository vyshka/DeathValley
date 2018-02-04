using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DeathValley.BLL.DTO;
using DeathValley.Models;

namespace DeathValley.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Data, ParamDTO>();
            });
        }
    }
}