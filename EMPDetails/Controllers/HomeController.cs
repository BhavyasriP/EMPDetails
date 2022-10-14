using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMPDetails.Models;

namespace EMPDetails.Controllers
{
    public class HomeController : Controller
    {
        private ASP_TrainingEntities db = new ASP_TrainingEntities();

        // GET: Home
        public async Task<ActionResult> Index()
        {
            return View(await db.USerInfoes.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USerInfo uSerInfo = await db.USerInfoes.FindAsync(id);
            if (uSerInfo == null)
            {
                return HttpNotFound();
            }
            return View(uSerInfo);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "empname,empAddress,empDept,empid,empMobile")] USerInfo uSerInfo)
        {
            if (ModelState.IsValid)
            {
                db.USerInfoes.Add(uSerInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(uSerInfo);
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USerInfo uSerInfo = await db.USerInfoes.FindAsync(id);
            if (uSerInfo == null)
            {
                return HttpNotFound();
            }
            return View(uSerInfo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "empname,empAddress,empDept,empid,empMobile")] USerInfo uSerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSerInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(uSerInfo);
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USerInfo uSerInfo = await db.USerInfoes.FindAsync(id);
            if (uSerInfo == null)
            {
                return HttpNotFound();
            }
            return View(uSerInfo);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            USerInfo uSerInfo = await db.USerInfoes.FindAsync(id);
            db.USerInfoes.Remove(uSerInfo);
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
