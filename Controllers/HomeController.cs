using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public JsonResult GetUsers() {

            UserPointsEntities entities = new UserPointsEntities();
            var list = entities.UserPointTable.ToList();

            return Json(list,JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddNew(string username, int? userpoint) 
        {
            UserPointsEntities entities = new UserPointsEntities();
            UserPointTable userPointTable = new UserPointTable();

            if (userpoint == null || string.IsNullOrEmpty(username))
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

            userPointTable.UserName = username;
            userPointTable.UserPoint = userpoint;
            entities.UserPointTable.Add(userPointTable);
            entities.SaveChanges();

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}