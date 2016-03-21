using PetStore.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult Create([Bind(Include ="AnimalID,Name,ShortDescription,MainDescription,DateRecieved,Quantity,Price")] Animal animal)
        {     
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Picture"];

                string path = Server.MapPath("~/Images/" + file.FileName);
                file.SaveAs(path);

                animal.PicturePath = path;
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
    }
}