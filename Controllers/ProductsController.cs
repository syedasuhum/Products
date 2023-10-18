using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Products.Models;

namespace Products.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsEntities db = new ProductsEntities();

        // GET: Products
        public ActionResult Index(string searching)
        {
            //try
            //{
            //    var productlist = ProductsEntities.GetAllProducts();
            //    //if (productlist.Count == 0)
            //    //{
            //    //    TempData["InfoMessage"] = "Currently products not avaliable";

            //    //}
            //    if (string.IsNullOrEmpty(searchValue))
            //    {
            //        TempData["InfoMessage"] = "please provide search";
            //        return View(productlist);
            //    }
            //    else
            //    {
            //        if(searchBy.ToLower()== "Product_Name")
            //        {
            //            var searchByProduct_Name = productlist.Where(p => p.Product_Name.ToLower().Contains(searchValue.ToLower())) ;
            //            return View(searchByProduct_Name);
            //        }
            //        if (searchBy.ToLower() == "Price")
            //        {
            //            var searchByProduct_Price = productlist.Where(p => p.Price==decimal.Parse(searchValue));
            //            return View(searchByProduct_Price);
            //        }
            //        if (searchBy.ToLower() == "Category")
            //        {
            //            var searchByProduct_Category = productlist.Where(p => p.Product_Category.ToLower().Contains(searchValue.ToLower()));
            //            return View(searchByProduct_Category);
            //        }
            //    }
                

                
            //}
            //catch(Exception ex)
            //{
            //    TempData["Error"] = ex.Message;
            //    return View();
            //}
            return View(db.tbl_Products.Where(x=>x.Product_Name.Contains(searching) || searching==null).ToList());

        }
        
        

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Products tbl_Products = db.tbl_Products.Find(id);
            if (tbl_Products == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_ID,Product_Name,Size,Price,MfgDate,Category")] tbl_Products tbl_Products)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Products.Add(tbl_Products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Products tbl_Products = db.tbl_Products.Find(id);
            if (tbl_Products == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_ID,Product_Name,Size,Price,MfgDate,Category")] tbl_Products tbl_Products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Products tbl_Products = db.tbl_Products.Find(id);
            if (tbl_Products == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Products tbl_Products = db.tbl_Products.Find(id);
            db.tbl_Products.Remove(tbl_Products);
            db.SaveChanges();
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
