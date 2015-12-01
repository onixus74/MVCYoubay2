using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCYoubay2.Models;

namespace MVCYoubay2.Controllers
{
    public class SubcategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subcategory
        public async Task<ActionResult> Index()
        {
            return View(await db.t_subcategory.ToListAsync());
        }

        // GET: Subcategory/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_subcategory t_subcategory = await db.t_subcategory.FindAsync(id);
            if (t_subcategory == null)
            {
                return HttpNotFound();
            }
            return View(t_subcategory);
        }

        // GET: Subcategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subcategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "subcategoryId,categoryName,category_categoryId,assistantAvatarImage,categoryDisplayPriority,isActive,subcategoryAttributesAndTypes")] t_subcategory t_subcategory)
        {
            if (ModelState.IsValid)
            {
                db.t_subcategory.Add(t_subcategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_subcategory);
        }

        // GET: Subcategory/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_subcategory t_subcategory = await db.t_subcategory.FindAsync(id);
            if (t_subcategory == null)
            {
                return HttpNotFound();
            }
            return View(t_subcategory);
        }

        // POST: Subcategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "subcategoryId,categoryName,category_categoryId,assistantAvatarImage,categoryDisplayPriority,isActive,subcategoryAttributesAndTypes")] t_subcategory t_subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_subcategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_subcategory);
        }

        // GET: Subcategory/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_subcategory t_subcategory = await db.t_subcategory.FindAsync(id);
            if (t_subcategory == null)
            {
                return HttpNotFound();
            }
            return View(t_subcategory);
        }

        // POST: Subcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_subcategory t_subcategory = await db.t_subcategory.FindAsync(id);
            db.t_subcategory.Remove(t_subcategory);
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
