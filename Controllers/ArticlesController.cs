using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_AT9.Models;

namespace MVC_AT9.Controllers
{
    public class ArticlesController : Controller
    {
        private ModelGestionArticleContainer db = new ModelGestionArticleContainer();

        // GET: Articles
        public ActionResult Index()
        {
            var articleSet = db.ArticleSet.Include(a => a.Type);
            return View(articleSet.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.ArticleSet.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.Num_Type = new SelectList(db.TypeSet, "Num_Type", "Nom_Type");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ref_Article,Designation,Num_Type")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.ArticleSet.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Num_Type = new SelectList(db.TypeSet, "Num_Type", "Nom_Type", article.Num_Type);
            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.ArticleSet.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.Num_Type = new SelectList(db.TypeSet, "Num_Type", "Nom_Type", article.Num_Type);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ref_Article,Designation,Num_Type")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Num_Type = new SelectList(db.TypeSet, "Num_Type", "Nom_Type", article.Num_Type);
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.ArticleSet.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.ArticleSet.Find(id);
            db.ArticleSet.Remove(article);
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
