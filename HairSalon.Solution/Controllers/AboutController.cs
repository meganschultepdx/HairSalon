using Microsoft.AspNetCore.Mvc;
using System;

namespace HairSalon.Controllers
{
  public class AboutController : Controller
  {

    [HttpGet("/about")]
    public ActionResult About()
    {
      return View();
    }

    // <img src="../img/pinkhair.jpg" width="400px">

  }
}
