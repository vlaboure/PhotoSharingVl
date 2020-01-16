using NUnit.Framework;
using System.Collections.Generic;
using PhotoSharingVl.Models;
using PhotoSharingVl.Controllers;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhotoSaringTest
{
    [TestClass]
    public class PhotoControllerTest
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            PhotoController controller = new PhotoController();
            var res = controller.Index() as ViewResult;
            Assert.Equals(res.ViewName,"Index");
        }
        [TestMethod]
        public void Test_PhotoGalery_Model_Type()
        {
            PhotoController controller = new PhotoController();
            var res = controller._PhotoGallery();
        }
    }
}