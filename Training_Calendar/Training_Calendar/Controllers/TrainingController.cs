using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training_Calendar.Models;

namespace Training_Calendar.Controllers
{
    public class TrainingController : Controller 
    {
        // GET: Training
        Technical_Context_Db DB = new Technical_Context_Db();

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListTechnical()
        {
            return Json(DB.ListAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListBehavioral()
        {
            return Json(DB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Technical_Model_Db obj)
        {
           // var result = DB.Add(obj);
            return Json(DB.Add(obj));

           // return Json(DB.Add(obj), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Technical = DB.ListAll().Find(x => x.Training_Id.Equals(ID));
            return Json(Technical, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult Update(Technical_Model_Db obj)
        //{
        //    return Json(DB.Update(obj), JsonRequestBehavior.AllowGet);
        //}

        public JsonResult Update(Technical_Model_Db ID)
          {
            return Json(DB.Update(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int ID)
        {
            return Json(DB.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }

}