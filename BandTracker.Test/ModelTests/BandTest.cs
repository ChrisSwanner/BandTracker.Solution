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
  }
}
