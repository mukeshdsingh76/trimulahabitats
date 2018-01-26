using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TirumalaHabitats.Models;
using TirumalaHabitats.Common;

namespace TirumalaHabitats.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(ContactUsModel model)
    {
      if (ModelState.IsValid)
      {
        try
        {
          EmailManager.SendEmail(model);
          ModelState.Clear();
          //return View("Index", new ContactUsModel { ResponseStatus = "Thanks for submitting the request." });
          return View("Confirmation");
        }
        catch (Exception ex)
        {
          return View("Index", new ContactUsModel { ResponseStatus = "Error : " + ex.Message });
        }
      }
      else
      {
        return View("Index", new ContactUsModel { ResponseStatus = "Sorry, your information is not valid" });
      }
    }
  }
}