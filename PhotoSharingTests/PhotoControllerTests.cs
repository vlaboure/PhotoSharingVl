using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.Generic;
using PhotoSharingVl.Models;
using PhotoSharingVl.Controllers;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhotoSharingTests
{
    [TestClass]
    public class PhotoControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            PhotoController controller = new PhotoController();
            var res = controller.Index() as ViewResult;
            Assert.Equals(res.ViewName, "Index");
        }
        [TestMethod]
        public void Test_PhotoGalery_Model_Type()
        {
            PhotoController controller = new PhotoController();
            //création d'un controlleur _PhotoGallery  de type PartialView
            var res = controller._PhotoGallery()as PartialViewResult;
            //on vérifie que le model est de type List<Photo>
            Assert.AreEqual(res.Model.GetType(), typeof(List<Photo>));
        }
    }
}
//pour continuer 15/01
//https://github.com/MicrosoftLearning/20486-DevelopingASPNETMVCWebApplications/blob/master/Instructions/20486C/20486C_MOD06_LAK.md
//https://github.com/MicrosoftLearning/20486-DevelopingASPNETMVCWebApplications/blob/master/Instructions/20486C/20486C_MOD06_LAB_MANUAL.md