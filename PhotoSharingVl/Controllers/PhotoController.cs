using PhotoSharingVl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingVl.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoSharedContext context = new PhotoSharedContext();
        // GET: Photo
        public ActionResult Index()
        {
            ViewBag.Title = "Photos exemples du site";
            return View("Index");
        }
        //retourne une photo en fonction de l'Id
        public ActionResult Display(int id)
        {
            Photo photo= context.Photos.Find(id);
            if (photo == null)
                return HttpNotFound();
            return View(photo);
        }
        public ActionResult _PhotoGallery(int number=0)
        {
            ViewBag.test = "test";
            List<Photo> photos;
            //si pas de nombre de photos précisé, on prend tout sinon on prend number
            photos = number == 0 ? context.Photos.ToList() : photos =(from p in context.Photos orderby p.DateCreation descending select p).Take(number).ToList();
            return PartialView("_PhotoGallery",photos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Photo newPhoto = new Photo();
            newPhoto.DateCreation = DateTime.Today;
            return View("Create",newPhoto);
        }

        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.DateCreation = DateTime.Today;
            //si le modèle est non valide
            if (!ModelState.IsValid)
                return View("Create",photo);
            else
            {
                //type d'image
                photo.ImageMimeType = image.ContentType;
                //création d'un tableau de bytes de la taille de l'image
                photo.PhotoFile = new byte[image.ContentLength];
                //remplissage du tableau--- chargement image en mémoire
                image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
            }
            context.Photos.Add(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo != null)
                    return View("Delete", photo);
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Photo photo = context.Photos.Find(id);
            if(photo==null)
                return HttpNotFound();
            context.Photos.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Comment(int? id)
        {           
            Photo photo = context.Photos.FirstOrDefault(p => p.Id == id);
            Comment comment = new Comment
            {
                PhotoID = photo.Id
            };
            ViewBag.MimType = photo.ImageMimeType;
            ViewBag.Title = "Commentaires sur cette photo";
            if(photo!=null)
                return View(comment);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Comment(Photo photo,Comment comment)
        {
   
                comment.PhotoID = photo.Id;               
                context.Comments.Add(comment);
                context.SaveChanges();
                return RedirectToAction("Index");
             
        }
        public ActionResult View_Comment(int id)
        {
            ViewBag.Title="Commentaires sur cette photo :";
            Photo photo = context.Photos.FirstOrDefault(p => p.Id == id);
            return View(photo);
        }
        public FileContentResult GetImage(int id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo != null)
                return File(photo.PhotoFile,photo.ImageMimeType);
            return null;
        }
    }
}

///********************************************************************************************
//pour update
//        public int Update(object entity)
//{
//    var entityProperties = entity.GetType().GetProperties();

//    Contacts con = ToType(entity, typeof(Contacts)) as Contacts;

//    if (con != null)
//    {
//        _context.Entry(con).State = EntityState.Modified;
//        _context.Contacts.Attach(con);

//        foreach (var ep in entityProperties)
//        {
//            if (ep.Name != "Id")
//                _context.Entry(con).Property(ep.Name).IsModified = true;
//        }
//    }

//    return _context.SaveChanges();
//}

//******************************************************************************
//***************************************************autre edit avec un post DIFFERENT
//    public ActionResult Edit(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    Course course = db.Courses.Find(id);
//    if (course == null)
//    {
//        return HttpNotFound();
//    }
//    PopulateDepartmentsDropDownList(course.DepartmentID);
//    return View(course);
//}

//[HttpPost, ActionName("Edit")]
//[ValidateAntiForgeryToken]
//public ActionResult EditPost(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    var courseToUpdate = db.Courses.Find(id);
//    if (TryUpdateModel(courseToUpdate, "",
//       new string[] { "Title", "Credits", "DepartmentID" }))
//    {
//        try
//        {
//            db.SaveChanges();

//            return RedirectToAction("Index");
//        }
//        catch (RetryLimitExceededException /* dex */)
//        {
//            //Log the error (uncomment dex variable name and add a line here to write a log.
//            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
//        }
//    }
//    PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
//    return View(courseToUpdate);
//}
