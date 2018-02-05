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

        private IDataService _DataService;

        public HomeController(IDataService DataService)
        {
            _DataService = DataService;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Calculate(Params inParams)
        {
            if (ModelState.IsValid)
            {
                var dataDto = Mapper.Map<Params, ParamDTO>(inParams);
                var result = _DataService.GetData(dataDto);
                return Json(result, JsonRequestBehavior.AllowGet);

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