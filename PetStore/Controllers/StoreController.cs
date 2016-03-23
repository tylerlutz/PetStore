using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class StoreController : Controller
    {
        private PetStoreContext db = new PetStoreContext();

        // GET: Store
        public ActionResult Inventory()
        {
            var animals = db.Animals;
            return View(animals.ToList());
        }

        public ActionResult Manage()
        {
            var animals = db.Animals;
            return View(animals.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="AnimalID,Name,ShortDescription,MainDescription,DateRecieved,Quantity,Price")] Animal animal, Picture picture)
        {     
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(picture.File.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                picture.File.SaveAs(path);

                animal.PicturePath = fileName.ToString();
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(animal);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Animal animal = db.Animals.Find(id);

            if(animal == null)
            {
                return HttpNotFound();
            }

            return View(animal);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Animal animal = db.Animals.Find(id);

            if(animal == null)
            {
                return HttpNotFound();
            }

            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalID,Name,ShortDescription,MainDescription,DateRecieved,Quantity,Price,PicturePath")] Animal animal, Picture picture)
        {
            if (ModelState.IsValid)
            {
                if(picture.File != null)
                {
                    var fileName = Path.GetFileName(picture.File.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    picture.File.SaveAs(path);

                    if(animal.PicturePath != fileName)
                    {
                        animal.PicturePath = fileName;
                        string fullPath = Request.MapPath("~/Images/" + fileName);
                        System.IO.File.Delete(fileName);
                    }

                    db.Entry(animal).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Manage");
                }else
                {
                    db.Entry(animal).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Manage");
                }
            }
            return View(animal);
        }

        
        public ActionResult Delete(int? id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
            string path = Request.MapPath("~/Images/" + animal.PicturePath);
            System.IO.File.Delete(path);
            db.SaveChanges();
            return RedirectToAction("Manage");
        }
    }
}