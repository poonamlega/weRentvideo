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

namespace weRentvideo.Controllers
{
    public class MembershipController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Membership
        public async Task<ActionResult> Index()
        {
            return View(await db.MembershipModels.ToListAsync());
        }

        // GET: Membership/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipModels membershipModels = await db.MembershipModels.FindAsync(id);
            if (membershipModels == null)
            {
                return HttpNotFound();
            }
            return View(membershipModels);
        }

        // GET: Membership/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Membership/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SignUpFees,DurationInMonths,DiscountRate")] MembershipModels membershipModels)
        {
            if (ModelState.IsValid)
            {
                db.MembershipModels.Add(membershipModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(membershipModels);
        }

        // GET: Membership/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipModels membershipModels = await db.MembershipModels.FindAsync(id);
            if (membershipModels == null)
            {
                return HttpNotFound();
            }
            return View(membershipModels);
        }

        // POST: Membership/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SignUpFees,DurationInMonths,DiscountRate")] MembershipModels membershipModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membershipModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(membershipModels);
        }

        // GET: Membership/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipModels membershipModels = await db.MembershipModels.FindAsync(id);
            if (membershipModels == null)
            {
                return HttpNotFound();
            }
            return View(membershipModels);
        }

        // POST: Membership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MembershipModels membershipModels = await db.MembershipModels.FindAsync(id);
            db.MembershipModels.Remove(membershipModels);
            await db.SaveChangesAsync();
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
