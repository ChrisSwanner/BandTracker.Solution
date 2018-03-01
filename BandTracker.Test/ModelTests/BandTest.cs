using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BandTracker.Models;
using System;

namespace Bandtracker.Tests
{
  [TestClass]
  public class BandTests : IDisposable
  {
    public void Dispose()
    {
    }

    [TestMethod]
    public void GetAll_BandListIsEmptyAtStart_0()
    {
      int result = Band.GetAll().Count;

      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SaveABandToTheDatabase_BandList()
    {
      Band testBand = new Band("The cool band", "");
      testBand.Save();


      List<Band> result = Band.GetAll();
      System.Console.WriteLine(result);
      List<Band> testList = new List<Band>{testBand};

      CollectionAssert.AreEqual(testList, result);
    }
  }
}
