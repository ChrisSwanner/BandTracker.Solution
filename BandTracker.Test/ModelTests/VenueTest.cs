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
    public void Save_SaveVenue_ItemList()
    {
      Venue testVenue = new Venue("Venue", "");

      testVenue.Save();
      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{testVenue};

      CollectionAssert.AreEqual(testList, result);
    }
  }
}
