using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CURDUSERMGMT.Models;
using System.Data.Entity;
using System.Web.Security;

namespace CURDUSERMGMT.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}

        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(t_user_profile objUser)
        {
            if (ModelState.IsValid)
            {
                using (TESTEntities db = new TESTEntities())
               {
                    var obj = db.t_user_profile.Where(a => a.t_user_Id.Equals(objUser.t_user_Id) &&
                   a.t_user_Pass.Equals(objUser.t_user_Pass)).FirstOrDefault();
                    if (obj != null)
                    {

                        var result = db.t_user_profile.SingleOrDefault(b => b.t_user_Id.Equals(objUser.t_user_Id));
                        if (result != null)
                        {
                            result.t_user_LoginTime = DateTime.Now;
                            db.SaveChanges();
                        }
                        Session["UserID"] = obj.t_user_Id.ToString();
                        Session["UserName"] = obj.t_user_FirstName + obj.t_user_LastName.ToString();
                        Session["LastLoginout"] = obj.t_user_LogoutTime.ToString();
                        Session["LastLoginin"] = obj.t_user_LoginTime.ToString();
                        return RedirectToAction("Index", "User");

                    }
                    else
                    TempData["msg"] = "<script>alert('Invalid UserId And Password');</script>";
                    return RedirectToAction("Login", "Login");
                    
                }
            }
            return View(objUser);
        }

        public ActionResult LogOut(t_user_profile objUser)
        {
            using (TESTEntities db = new TESTEntities())
            {
                var userId = Session["UserID"].ToString();
                var result = db.t_user_profile.SingleOrDefault(b => b.t_user_Id.Equals(userId));
                if (result != null)
                {
                    result.t_user_LogoutTime = DateTime.Now;
                    db.SaveChanges();
                }

                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Login");
            }
        }
    }
}