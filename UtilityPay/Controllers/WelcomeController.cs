using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UtilityPay.Controllers
{
    public class WelcomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ValueProposition = "Manage invoices.";
            ViewBag.NextButtonValue = "Continue";
            ViewBag.WelcomeStep = 2;

            return View(ViewBag);
        }

        public ActionResult Step(int step)
        {
            var message = "";
            var buttonText = "";
            int NextWelcomeStep = 0;

            if (step == 2)
            {
                message = "Keep track of utility bills.";
                buttonText = "Tell me more";
                NextWelcomeStep = 3;
            }
            else if (step == 3)
            {
                message = "Split payments with roomates.";
                buttonText = "I'm interested";
                NextWelcomeStep = 4;
            }
            else if (step == 4)
            {
                return RedirectToAction("GetStarted", "Welcome");
            }

            ViewBag.ValueProposition = message;
            ViewBag.NextButtonValue = buttonText;
            ViewBag.WelcomeStep = NextWelcomeStep;

            return View("~/Views/Welcome/Index.cshtml", ViewBag);
        }

        public ActionResult GetStarted()
        {
            ViewBag.ValueProposition = "Submit payments";

            return View(ViewBag);
        }
    }
}