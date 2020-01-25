using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PhotoSharingVl.Models;
using PhotoSharingVl.Controllers;
using System.Linq;
using System.Web.Mvc;
using PhotoSharingTests.Doubles;

namespace PhotoSharingTests
{
    [TestClass]
    public class PhotoControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            // intanciation d'un objet de type FakePhotoSharingContext
            var context = new FakePhotoSharingContext();
            PhotoController controller = new PhotoController(context);
            var res = controller.Index() as ViewResult;
            Assert.AreEqual(res.ViewName, "Index");
        }
        [TestMethod]
        public void Test_PhotoGalery_Model_Type()
        {
            var fakePhotoSharing = new FakePhotoSharingContext();

            fakePhotoSharing.Photos = new[]
            {
                new Photo(),
                new Photo(),
                new Photo(),
                new Photo()
            }.AsQueryable();
            PhotoController controller = new PhotoController(fakePhotoSharing);
            //création d'un controlleur _PhotoGallery  de type PartialView
            var res = controller._PhotoGallery()as PartialViewResult;
            //on vérifie que le model est de type List<Photo>
            Assert.AreEqual(res.Model.GetType(), typeof(List<Photo>));
        }

        [TestMethod]
        public void Test_GetImage_Return_Type()
        {

            FakePhotoSharingContext fakePhotoSharing = new FakePhotoSharingContext();
            fakePhotoSharing.Photos = new[]
            {
                new Photo{ Id=1,PhotoFile=new byte[1],ImageMimeType="image/jpeg" },
                new Photo{ Id=2,PhotoFile=new byte[1],ImageMimeType="image/jpeg" },
                new Photo{ Id=3,PhotoFile=new byte[1],ImageMimeType="image/jpeg" },
                new Photo{ Id=4,PhotoFile=new byte[1],ImageMimeType="image/jpeg" }
            }.AsQueryable();
            var controller = new PhotoController(fakePhotoSharing);
            var result = controller.GetImage(1) as ActionResult;
            Assert.AreEqual(typeof(FileContentResult), result.GetType());

        }
    }
}
//pour continuer 15/01
//https://github.com/MicrosoftLearning/20486-DevelopingASPNETMVCWebApplications/blob/master/Instructions/20486C/20486C_MOD06_LAK.md
//https://github.com/MicrosoftLearning/20486-DevelopingASPNETMVCWebApplications/blob/master/Instructions/20486C/20486C_MOD06_LAB_MANUAL.md