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

    [HttpPost("/venues/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Venue thisVenue = Venue.Find(id);
      return View(thisItem);
    }



  }

}
