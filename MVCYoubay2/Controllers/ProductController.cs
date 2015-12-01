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
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public  ViewResult Index()
        {
            var products = db.t_product.Include(a => a.t_subcategory);
            return View(products.ToList());
        }

        public ActionResult ListForManager()
        {
            var Products = db.t_product.ToList();
            return View(Products);
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_product t_product = await db.t_product.FindAsync(id);
            if (t_product == null)
            {
                return HttpNotFound();
            }
            return View(t_product);
        }

        public async Task<ActionResult> DetailsForUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_product products = await db.t_product.FindAsync(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.subcategory_subcategoryId = new SelectList(db.t_subcategory, "subcategoryId", "categoryName");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "productId,productName,productDescription,sellerPrice,subcategory_subcategoryId,quantityAvailable,productImage,isDisabledByAdmin,isDisabledBySeller,subcategoryAttributesAndValues,seller_youBayUserId")] t_product t_product)
        {
            if (ModelState.IsValid)
            {
                db.t_product.Add(t_product);
                await db.SaveChangesAsync();
                return RedirectToAction("ListForManager");
            }
            ViewBag.subcategory_subcategoryId = new SelectList(db.t_subcategory, "subcategoryId", "categoryName" , t_product.subcategory_subcategoryId);
            return View(t_product);
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_product t_product = await db.t_product.FindAsync(id);
            if (t_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.subcategory_subcategoryId = new SelectList(db.t_subcategory, "subcategoryId", "categoryName", t_product.subcategory_subcategoryId);
            return View(t_product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "productId,productName,productDescription,sellerPrice,subcategory_subcategoryId,quantityAvailable,productImage,isDisabledByAdmin,isDisabledBySeller,subcategoryAttributesAndValues,seller_youBayUserId")] t_product t_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.subcategory_subcategoryId = new SelectList(db.t_subcategory, "subcategoryId", "categoryName", t_product.subcategory_subcategoryId);
            return View(t_product);
        }

        // GET: Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_product t_product = await db.t_product.FindAsync(id);
            if (t_product == null)
            {
                return HttpNotFound();
            }
            return View(t_product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            t_product t_product = await db.t_product.FindAsync(id);
            db.t_product.Remove(t_product);
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
