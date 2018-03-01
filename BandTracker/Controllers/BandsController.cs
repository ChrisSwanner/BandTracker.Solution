using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BandTracker.Models;

namespace BandTracker.Controllers
{
  public class BandsController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    {
      List<Band> allBands = Band.GetAll();
      return View("Index", allBands);
    }

    [HttpGet("/bands/new")]
    public ActionResult CreateBandForm()
    {
      return View();
    }
  }
}
