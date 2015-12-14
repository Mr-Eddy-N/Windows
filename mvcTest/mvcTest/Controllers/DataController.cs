using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcTest.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Holi() {
            return View();
        }
        [HttpPost]
        public JsonResult setData(string str){
           
        string message="msss";
            JsonResult jsonr= new JsonResult{Data=message, JsonRequestBehavior= JsonRequestBehavior.AllowGet};
            return jsonr;
        }

    }
}
