using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
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
        public ActionResult Create([Bind(Include ="AnimalID,Name,ShortDescription,MainDescription,DateRecieved,Quantity,Price,Picture")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(animal);
        }
    }
}