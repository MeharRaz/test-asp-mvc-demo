using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationDBApproach.Models;
using System.IO;

namespace MvcApplicationDBApproach.Controllers
{
    public class ProductController : Controller
    {
        private categoryandproductEntities db = new categoryandproductEntities();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            var tbl_product = db.tbl_product.Include(t => t.tbl_category);
            return View(tbl_product.ToList());
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.tbl_category, "CategoryId", "Name");
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(tbl_product tbl_product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file!= null && file.ContentLength > 0)
                    try
                    {
                        string PathToFolder = Server.MapPath("~/Images");
                        string fileName = Path.GetFileName(file.FileName);
                        string path = Path.Combine(PathToFolder, fileName);
                        file.SaveAs(path);
                        tbl_product.Image = file.FileName;

                    }
                    catch(Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    
                    }


                db.tbl_product.Add(tbl_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.tbl_category, "CategoryId", "Name", tbl_product.CategoryId);
            return View(tbl_product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.tbl_category, "CategoryId", "Name", tbl_product.CategoryId);
            return View(tbl_product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(tbl_product tbl_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.tbl_category, "CategoryId", "Name", tbl_product.CategoryId);
            return View(tbl_product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_product tbl_product = db.tbl_product.Find(id);
            db.tbl_product.Remove(tbl_product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}