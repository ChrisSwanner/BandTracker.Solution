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

    [HttpPost("/bands")]
    public ActionResult CreateBand()
    {
      Band newBand = new Band(Request.Form["band-name"], Request.Form["band-description"]);
      newBand.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/bands/{id}")]
    public ActionResult Detail(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Band selectedBand = Band.Find(id);
      List<Venue> allVenues = selectedBand.GetVenues();
      model.Add("band", selectedBand);
      model.Add("venues", allVenues);
      return View(model);
    }

    [HttpPost("/bands/{id}/venues")]
    public ActionResult CreateVenue(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Band foundBand = Band.Find(id);
      List<Venue> bandVenues = foundBand.GetVenues();
      Venue newVenue = new Venue(Request.Form["venue-name"], Request.Form["venue-address"]);
      newVenue.SetBandId(foundBand.GetId());
      newVenue.Save();
      model.Add("venues", bandVenues);
      model.Add("band", foundBand);
      return RedirectToAction("Detail", model);
    }
  }
}
