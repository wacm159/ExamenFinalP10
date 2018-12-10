using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EP10Final.Models;

namespace EP10Final.Controllers
{
    public class calculosMVCController : Controller
    {
        private DonacionesEntities db = new DonacionesEntities();

        // GET: calculosMVC
        public ActionResult Index()
        {
            var calculos = db.calculos.Include(c => c.donadores).Include(c => c.gasto).Include(c => c.gasto1).Include(c => c.gasto2);
            return View(calculos.ToList());
        }

        // GET: calculosMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calculos calculos = db.calculos.Find(id);
            if (calculos == null)
            {
                return HttpNotFound();
            }
            return View(calculos);
        }

        // GET: calculosMVC/Create
        public ActionResult Create()
        {
            ViewBag.id_donador_calculos = new SelectList(db.donadores, "id_donador", "nombre");
            ViewBag.id_gasto_calculos = new SelectList(db.gasto, "id_gasto", "nombre");
            ViewBag.id_gasto1_calculos = new SelectList(db.gasto1, "id_gasto1", "nombre");
            ViewBag.id_gasto2_calculos = new SelectList(db.gasto2, "id_gasto2", "nombre");
            return View();
        }

        // POST: calculosMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_calculo,id_donador_calculos,id_gasto_calculos,id_gasto1_calculos,id_gasto2_calculos,fecha,total")] calculos calculos)
        {
            if (ModelState.IsValid)
            {
                db.calculos.Add(calculos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_donador_calculos = new SelectList(db.donadores, "id_donador", "nombre", calculos.id_donador_calculos);
            ViewBag.id_gasto_calculos = new SelectList(db.gasto, "id_gasto", "nombre", calculos.id_gasto_calculos);
            ViewBag.id_gasto1_calculos = new SelectList(db.gasto1, "id_gasto1", "nombre", calculos.id_gasto1_calculos);
            ViewBag.id_gasto2_calculos = new SelectList(db.gasto2, "id_gasto2", "nombre", calculos.id_gasto2_calculos);
            return View(calculos);
        }

        // GET: calculosMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calculos calculos = db.calculos.Find(id);
            if (calculos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_donador_calculos = new SelectList(db.donadores, "id_donador", "nombre", calculos.id_donador_calculos);
            ViewBag.id_gasto_calculos = new SelectList(db.gasto, "id_gasto", "nombre", calculos.id_gasto_calculos);
            ViewBag.id_gasto1_calculos = new SelectList(db.gasto1, "id_gasto1", "nombre", calculos.id_gasto1_calculos);
            ViewBag.id_gasto2_calculos = new SelectList(db.gasto2, "id_gasto2", "nombre", calculos.id_gasto2_calculos);
            return View(calculos);
        }

        // POST: calculosMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_calculo,id_donador_calculos,id_gasto_calculos,id_gasto1_calculos,id_gasto2_calculos,fecha,total")] calculos calculos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calculos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_donador_calculos = new SelectList(db.donadores, "id_donador", "nombre", calculos.id_donador_calculos);
            ViewBag.id_gasto_calculos = new SelectList(db.gasto, "id_gasto", "nombre", calculos.id_gasto_calculos);
            ViewBag.id_gasto1_calculos = new SelectList(db.gasto1, "id_gasto1", "nombre", calculos.id_gasto1_calculos);
            ViewBag.id_gasto2_calculos = new SelectList(db.gasto2, "id_gasto2", "nombre", calculos.id_gasto2_calculos);
            return View(calculos);
        }

        // GET: calculosMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calculos calculos = db.calculos.Find(id);
            if (calculos == null)
            {
                return HttpNotFound();
            }
            return View(calculos);
        }

        // POST: calculosMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            calculos calculos = db.calculos.Find(id);
            db.calculos.Remove(calculos);
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
