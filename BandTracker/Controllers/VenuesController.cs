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


  }

}
