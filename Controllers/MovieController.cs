using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using weRentvideo.Models;
using weRentvideo.ViewModels;

namespace weRentvideo.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movie
        public async Task<ActionResult> Index()
        {
            return View(await db.MovieModels.ToListAsync());
        }

        // GET: Movie/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieModels movieModels = await db.MovieModels.FindAsync(id);
     
            if (movieModels == null)
            {
                return HttpNotFound();
            }
            return View(movieModels);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            GenreDropDownViewModel GenreVM = new GenreDropDownViewModel();
            GenreVM.GenreIds = db.GenreModels.Select(a => a.Id).ToList();
            ViewBag.GenreDD = db.GenreModels.Select(x => new { x.Id, x.GenreType }).ToList();
            return View(GenreVM);
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GenreDropDownViewModel movieModels)
        {
            MovieModels GM = movieModels.Movie;
           
            if (ModelState.IsValid)
            {
                db.MovieModels.Add(GM);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(GM);
        }

        // GET: Movie/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieModels movieModels = await db.MovieModels.FindAsync(id);
            if (movieModels == null)
            {
                return HttpNotFound();
            }
            return View(movieModels);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,RDate,Genre,NumberInStock")] MovieModels movieModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movieModels);
        }

        // GET: Movie/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieModels movieModels = await db.MovieModels.FindAsync(id);
            if (movieModels == null)
            {
                return HttpNotFound();
            }
            return View(movieModels);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MovieModels movieModels = await db.MovieModels.FindAsync(id);
            db.MovieModels.Remove(movieModels);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        /// get:movie

        public ActionResult Movie()
        {

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
