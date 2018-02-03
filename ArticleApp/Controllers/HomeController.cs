using ArticleApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ArticleApp.Controllers
{
    public class HomeController : Controller
    {
        private object dbContext;

        public ActionResult Index()
        {
            // Make sure the principals are in sync
            System.Threading.Thread.CurrentPrincipal = System.Web.HttpContext.Current.User;

            GetArticle(0);
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

        [HandleError(ExceptionType = typeof(System.IOException), View = "FileError")]
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

        protected override void OnException(ExceptionContext exceptionContext)
        {
            if (exceptionContext.IsChildAction)
            {
                //we don't want to display the error screen if it is a child action,
                base.OnException(exceptionContext);
                return;
            }
            // log the exception in your configured logger
            //Logger.Log(exceptionContext.Exception);
            //handle when the app is not configured to use the custom error path
            if (!exceptionContext.HttpContext.IsCustomErrorEnabled)
            {
                exceptionContext.ExceptionHandled = true;
                this.View("ErrorManager").ExecuteResult(this.ControllerContext);
            }
        }

        internal Article GetArticle(int id)
        {
            //if (id <= 0)
            //{
            //    throw new ArgumentException("id");
            //}
            Contract.Requires(id > 0);

            Contract.Ensures(Contract.Result<Article>() != null);

            return new Article();
        }

        [ContractInvariantMethod]
        protected void ManageInvariant()
        {
            //System.Diagnostics.Contracts.Invariant(this.Id < 0);
        }

        //[ControllerAction]
        public void Authenticate(string uname, string pass)
        {
            //User user = dbContext.Users.First(x => x.UserName.Equals(uname()));
            //if (user != null && user.Password.Equals(EncryptHash(pass)))
            //{
            //    FormsAuthentication.SetAuthCookie(uname, false);
            //    RedirectToAction("Main", "DashBoard");
            //}
            // unable to login
            RenderView("Index", new LoginViewData
            {
                ErrorMessage = "Invalid credentials."
            });
        }

        public void CreateAuthTicket()
        {
            string userName = "userName";
            bool createPersistentCookie = true;
            string[] rolesArr = { "role1", "role2" };

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                userName,
                DateTime.Now,
                DateTime.Now.AddDays(90),
                createPersistentCookie, // a Boolean indicating whether a cookie
                                        // should be created on the user's machine
                String.Join(";", rolesArr) //user's roles
                );
            // add cookie to response stream
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.
            FormsCookieName, encTicket);
            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        private object EncryptHash(string pass)
        {
            throw new NotImplementedException();
        }

        private void RenderView(string v, LoginViewData loginViewData)
        {
            throw new NotImplementedException();
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