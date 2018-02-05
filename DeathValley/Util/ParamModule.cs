using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeathValley.BLL.Interfaces;
using DeathValley.BLL.Services;
using Ninject.Modules;

namespace DeathValley.Util
{
    public class ParamModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataService>().To<DataService>();
        }
    }
}