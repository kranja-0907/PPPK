using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieActor.Controllers
{
    public class ActorController : Controller
    {
        ~ActorController()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
        private readonly ModelContainer db = new ModelContainer();

        // GET: Actor
        public ActionResult ActorIndex()
        {
            return View(db.Actors);
        }

        // GET: Actor/Details/5
        public ActionResult DetailsActor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.SingleOrDefault(a => a.IDActor == id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actor/Create
        public ActionResult CreateActor()
        {
            return View();
        }

        // POST: Actor/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName, LastName, MovieIDMovie")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }
            return RedirectToAction("ActorIndex");
        }

        // GET: Actor/Edit/5
        public ActionResult EditActor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors
                .SingleOrDefault(a => a.IDActor == id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actor/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed()
        {
            Actor movieToUpdate = db.Actors.FirstOrDefault();
            if (TryUpdateModel(movieToUpdate, "",
                new string[] { "FirstName", "LastName", "MovieIDMovie" }))
            {
                db.Entry(movieToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ActorIndex");
            }
            return View(movieToUpdate);
        }

        // GET: Actor/Delete/5
        public ActionResult DeleteActor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.SingleOrDefault(a => a.IDActor == id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actor/Delete/5
        [HttpPost]
        [ActionName("DeleteActor")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            db.Actors.Remove(db.Actors.Find(id));
            db.SaveChanges();
            return RedirectToAction("ActorIndex");
        }
    }
}
