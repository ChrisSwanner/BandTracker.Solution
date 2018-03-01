using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BandTracker.Models;
using System;

namespace Bandtracker.TestTools
{

  [TestClass]
  public class VenueTests : IDisposable
  {
    public void Dispose()
        {
          Band.DeleteAll();
          Venue.DeleteAll();
        }

    [TestMethod]
    public void GetNameOfVenue_FetchName_String()
    {
      string venueName = "Venue";
      Venue newVenue = new Venue("Venue", "Address");

      string result = newVenue.GetName();

      Assert.AreEqual(result, venueName);
    }

    [TestMethod]
    public void Save_SaveVenue_List()
    {
      Venue newVenue = new Venue("Name", "Address");
      newVenue.Save();

      List<Venue> result = Venue.GetAll();
      Console.WriteLine(result.Count);
      List<Venue> testList = new List<Venue>{newVenue};
      Console.WriteLine(testList.Count);

      Assert.AreEqual(testList.Count, result.Count);
    }
  }
}
