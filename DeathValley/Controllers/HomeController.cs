using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DeathValley.BLL.DTO;
using DeathValley.Models;
using DeathValley.BLL.Infrastructure;
using DeathValley.BLL.Interfaces;

namespace DeathValley.Controllers
{
    public class HomeController : Controller
    {
        private IParamService _ParamService;
        private IDataService _DataService;

        public HomeController(IParamService ParamService, IDataService DataService)
        {
            _ParamService = ParamService;
            _DataService = DataService;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Calculate(Data data)
        {
            if (ModelState.IsValid)
            {
                var dataDto = Mapper.Map<Data, ParamDTO>(data);
                var id = _ParamService.GetIdIfExist(dataDto);
                if (id != 0)
                {
                    var items = _DataService.GetDataByParamId(id);
                    return Json(items, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    int dataID = _ParamService.Add(dataDto);
                    dataDto.ParamId = dataID;
                    var items = _DataService.CalculateData(dataDto);
                    return Json(items, JsonRequestBehavior.AllowGet);
                }
                
            }
            else
            {
                var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
                var message = "";

                foreach (var modelStateError in modelStateErrors)
                {
                    message += modelStateError.ErrorMessage + Environment.NewLine;
                }

                return Json(new {success = false, response = message});
            }
            
        }
    }
}