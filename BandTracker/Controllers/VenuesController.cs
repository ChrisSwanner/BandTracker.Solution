using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BandTracker.Models;

namespace BandTracker.Controllers
{
  public class VenuesController : Controller
  {

    [HttpGet("bands/{bandID}/venues/new")]
    public ActionResult CreateVenueForm(int bandId)
    {
      Band foundBand = Band.Find(bandId);
      return View(foundBand);
    }

    [Route("/venues")]
    public ActionResult ItemIndex()
    {
      return View("Index", Venue.GetAll());
    }

    [HttpGet("/venues/new")]
    public ActionResult CreateVenueForm()
    {
      return View();
    }

  }

}
