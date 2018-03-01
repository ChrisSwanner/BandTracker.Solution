using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandTracker.Models;
using BandTracker.Controllers;

namespace BandTracker.TestTools
{
  [TestClass]
  public class BandsControllerTest
  {
    [TestMethod]
    public void Index_ReturnCorrect_View()
    {
      BandsController controller = new BandsController();

      IActionResult indexView = controller.Index();
      ViewResult result = indexView as ViewResult;

      Assert.IsInstanceOfType(result, typeof(ViewResult));

    }

    [TestMethod]
    public void Detail_ReturnCorrect_View()
    {
      BandsController controller = new BandsController();

      IActionResult detailView = controller.Detail(1);
      ViewResult result = detailView as ViewResult;

      Assert.IsInstanceOfType(result, typeof(ViewResult));

    }

    [TestMethod]
    public void Delete_ReturnCorrect_View()
    {
      BandsController controller = new BandsController();

      IActionResult deleteView = controller.Index();
      ViewResult result = deleteView as ViewResult;

      Assert.IsInstanceOfType(result, typeof(ViewResult));

    }
  }

}
