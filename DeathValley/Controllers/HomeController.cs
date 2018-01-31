using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeathValley.Models;

namespace DeathValley.Controllers
{
    public class HomeController : Controller
    {
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
                Function func = new Function(data);
                var result = func.Calculate();
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