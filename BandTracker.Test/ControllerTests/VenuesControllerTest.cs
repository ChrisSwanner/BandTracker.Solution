using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandTracker.Models;
using BandTracker.Controllers;

namespace BandTracker.TestTools
{
  [TestClass]
  public class VenuesControllerTest
  {
    [TestMethod]
    public void CreateVenueForm_ReturnCorrect_View()
    {
      VenuesController controller = new VenuesController();

      IActionResult createVenueFormView = controller.CreateVenueForm();
      ViewResult result = createVenueFormView as ViewResult;

      Assert.IsInstanceOfType(result, typeof(ViewResult));

    }

    // [TestMethod]
    // public void Delete_ReturnCorrect_View()
    // {
    //   VenuesController controller = new VenuesController();
    //
    //   IActionResult deleteView = controller.Index();
    //   ViewResult result = deleteView as ViewResult;
    //
    //   Assert.IsInstanceOfType(result, typeof(ViewResult));
    //
    // }
  }

}
