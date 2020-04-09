using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();
            //get message from Web.config file
            model.Message = ConfigurationManager.AppSettings["message"];
            model.Name = name ?? "No Name";
            return View(model);
        }
    }
}