using ArticleApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticleApp.Controllers
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                //db.Articles.Add(article);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        //public JsonResult IsUserAvailable(string username)
        //{
        //    if (!WebSecurity.UserExists(username))
        //    {
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }
        //    string suggestedUID = String.Format(CultureInfo.InvariantCulture,
        //    "{0} is not available.", username);
        //    for (int i = 1; i < 100; i++)
        //    {
        //        string altCandidate = username + i.ToString();
        //        if (!WebSecurity.UserExists(altCandidate))
        //        {
        //            suggestedUID = String.Format(CultureInfo.InvariantCulture,
        //            "{0} is not available. Try {1}.", username, altCandidate);
        //            break;
        //        }
        //    }
        //    return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        //}
    }
}