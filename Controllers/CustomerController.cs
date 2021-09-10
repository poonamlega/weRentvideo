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
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customer
        public async Task<ActionResult> Index()
        {
            return View(await db.CustomerModels.Include(c=> c.MembershipModelsId).ToListAsync());
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModels customerModels = await db.CustomerModels.FindAsync(id);
            if (customerModels == null)
            {
                return HttpNotFound();
            }
            return View(customerModels);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            EditViewModel editVM = new EditViewModel();

            editVM.MembershipIds =  db.MembershipModels.Select(a => a.Id).ToList();
            ViewBag.MembershipDropdown = db.MembershipModels.Select(x => new { x.Id, x.MembershipName }).ToList();
            return View(editVM);
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EditViewModel customerModels)
        {
            CustomerModels customerModels1 = customerModels.customer;
            if (ModelState.IsValid)
            {
                db.CustomerModels.Add(customerModels1);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customerModels1);
        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {       
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditViewModel editVM = new EditViewModel();
            editVM.customer = await db.CustomerModels.FindAsync(id);
            editVM.MembershipIds = db.MembershipModels.Select(a => a.Id).ToList();
            ViewBag.MembershipDropdown = db.MembershipModels.Select(x => new { x.Id, x.MembershipName }).ToList();
            if (editVM.customer == null)
            {
                return HttpNotFound();
            }
            return View(editVM);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditViewModel customerModels)
        {
            CustomerModels customerModel = customerModels.customer;
            if (ModelState.IsValid)
            {
                db.Entry(customerModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customerModel);
        }
   
        // GET: Customer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModels customerModels = await db.CustomerModels.FindAsync(id);
            if (customerModels == null)
            {
                return HttpNotFound();
            }
            return View(customerModels);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CustomerModels customerModels = await db.CustomerModels.FindAsync(id);
            db.CustomerModels.Remove(customerModels);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public ActionResult Customer()
        {
            ViewBag.Message = "Your customer page.";
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
