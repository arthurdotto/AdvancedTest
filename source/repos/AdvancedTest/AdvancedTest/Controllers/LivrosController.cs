using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdvancedTest.Contexto;
using AdvancedTest.Models;

namespace AdvancedTest.Controllers
{
    public class LivrosController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Livros
        public ActionResult Index()
        {
            return View(db.Livros.ToList());
        }

        // GET: Livros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livros livros = db.Livros.Find(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            return View(livros);
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero_cadastro,Titulo,Autor,Genero,Numero_de_paginas,Ilustrado")] Livros livros)
        {
            if (ModelState.IsValid)
            {
                db.Livros.Add(livros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livros);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livros livros = db.Livros.Find(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            return View(livros);
        }

        // POST: Livros/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero_cadastro,Titulo,Autor,Genero,Numero_de_paginas,Ilustrado")] Livros livros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livros);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livros livros = db.Livros.Find(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            return View(livros);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livros livros = db.Livros.Find(id);
            db.Livros.Remove(livros);
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
