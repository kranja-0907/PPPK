using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieActor.Controllers
{
    public class MovieController : Controller
    {
        ~MovieController()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
        private readonly ModelContainer db = new ModelContainer();
        // GET: Movie
        public ActionResult Index()
        {
            return View(db.Movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Include(a => a.UploadedFiles)
                .SingleOrDefault(a => a.IDMovie == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name, YearOfRelease")] Movie movie,
            IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                movie.UploadedFiles = new List<UploadedFile>();
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var picture = new UploadedFile
                        {
                            Name = System.IO.Path.GetFileName(file.FileName),
                            ContentType = file.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(file.InputStream))
                        {
                            picture.Content = reader.ReadBytes(file.ContentLength);
                        }
                        movie.UploadedFiles.Add(picture);
                    }
                }

                db.Movies.Add(movie);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies
                .Include(a => a.UploadedFiles)
                .SingleOrDefault(a => a.IDMovie == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(int id, IEnumerable<HttpPostedFileBase> files)
        {
            Movie movieToUpdate = db.Movies.Find(id);
            if (TryUpdateModel(movieToUpdate, "",
                new string[] { "Name", "YearOfRelease" }))
            {
                if (movieToUpdate.UploadedFiles == null)
                {
                    movieToUpdate.UploadedFiles = new List<UploadedFile>();
                }
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var picture = new UploadedFile
                        {
                            Name = System.IO.Path.GetFileName(file.FileName),
                            ContentType = file.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(file.InputStream))
                        {
                            picture.Content = reader.ReadBytes(file.ContentLength);
                        }
                        movieToUpdate.UploadedFiles.Add(picture);
                    }
                }

                db.Entry(movieToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieToUpdate);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies
                .Include(a => a.UploadedFiles)
                .SingleOrDefault(a => a.IDMovie == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.UploadedFiles.RemoveRange(db.UploadedFiles.Where(f => f.MovieIDMovie == id));
            db.Movies.Remove(db.Movies.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
