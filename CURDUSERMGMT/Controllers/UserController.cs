using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CURDUSERMGMT.Models;
using System.Net.Http;

namespace CURDUSERMGMT.Controllers
{
    public class UserController : Controller
    {

      
        [HandleError(View= "Error.cshtml")]
        // GET: User
        public ActionResult Index()
        {
           
            //TESTEntities user = new TESTEntities();
            //List<t_user_profile> lstUsers = user.t_user_profile.ToList();
            //if (lstUsers.Count == 0)
            //{
            //    lstUsers.Add(new t_user_profile());
            //}
            //return View(lstUsers);
         
            if (Session["UserName"] != null)
            {
                IEnumerable<t_user_profile> users = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:2593/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("t_user_profile");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<t_user_profile>>();
                        readTask.Wait();

                        users = readTask.Result;


                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        users = Enumerable.Empty<t_user_profile>();

                        ModelState.AddModelError(string.Empty, "Server error Data has not been founded");
                    }
                }
                return View(users);

            }
            else
            {
                return RedirectToAction("Login" , "Login");
            }
        }


            //public ActionResult Login()
            //{
            //    return View();
            //}


       

    }
}
