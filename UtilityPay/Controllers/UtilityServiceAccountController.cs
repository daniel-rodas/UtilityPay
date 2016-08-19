using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityPay.Interfaces;
using UtilityPay.Models;

namespace UtilityPay.Controllers
{
    public class UtilityServiceAccountController : Controller
    {
        private readonly IConsumer _consumer;
        private readonly IUtilityServiceAccount _utilityService;

        public UtilityServiceAccountController()
        {
            //_utilityService = new UtilityServiceAccount();
        }

        
        public UtilityServiceAccountController(IConsumer consumer, IUtilityServiceAccount utilityService)
        {
            _consumer = consumer;
            _utilityService = utilityService;
        }

        // GET: UtilityServiceAccount
        public ActionResult Setup()
        {
            ViewBag.SomeString = _utilityService.DoSomething();
            return View(ViewBag);
        }
    }
}