using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UtilityPay.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public ActionResult Index()
        {
            ViewBag.ValueProposition = new[] { "Manage invoices.",
                "Keep track of utility bills.",
                "Split payments with roomates." };

            ViewBag.NextButtonValue = new[] { "Continue", "Tell me more", "I'm interested" };

            return View(ViewBag);
        }


        public ActionResult GetStarted()
        {
            ViewBag.ValueProposition = "Submit payments";

            return View(ViewBag);
        }
    }
}