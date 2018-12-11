using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EP10Final.Models;

namespace EP10Final.Controllers
{
    public class donadoresMVCController : Controller
    {
        private DonacionesEntities db = new DonacionesEntities();

        // GET: donadoresMVC
        public ActionResult Index()
        {
            //var donadores = db.donadores.Include(d => d.continente).Include(d => d.pais).Include(d => d.porcentajes).Include(d => d.productos);
            //var venta = db.venta.Include(v => v.cliente).Include(v => v.producto);
            //return View(venta.ToList());
            IEnumerable<donadores> alumno = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62116/api/");
                //GET ALUMNOS
                //obtiene asincronamente y espera hasta obetener la data
                var responseTask = client.GetAsync("donadores");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var leer = result.Content.ReadAsAsync<IList<donadores>>();
                    leer.Wait();
                    alumno = leer.Result;
                }
                else
                {
                    alumno = Enumerable.Empty<donadores>();
                    ModelState.AddModelError(string.Empty, "Error .... Try Again");
                }
            }
            return View(alumno.ToList());
            //return View(donadores.ToList());
        }

        // GET: donadoresMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donadores donadores = db.donadores.Find(id);
            if (donadores == null)
            {
                return HttpNotFound();
            }
            return View(donadores);
        }

        // GET: donadoresMVC/Detalles/5
        public ActionResult Detalle(int? id)
        {
            IEnumerable<donadores> alumno = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62116/api/");
                //GET ALUMNOS
                //obtiene asincronamente y espera hasta obetener la data
                var responseTask = client.GetAsync("donadores");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var leer = result.Content.ReadAsAsync<IList<donadores>>();
                    leer.Wait();
                    alumno = leer.Result;
                }
                else
                {
                    alumno = Enumerable.Empty<donadores>();
                    ModelState.AddModelError(string.Empty, "Error .... Try Again");
                }
            }
            return View(alumno.ToList());
        }



        // GET: donadoresMVC/Create
        public ActionResult Create()
        {
            ViewBag.id_continente_donador = new SelectList(db.continente, "id_continente", "nombre");
            ViewBag.id_pais_donador = new SelectList(db.pais, "id_pais", "nombre");
            ViewBag.id_porcentaje_donador = new SelectList(db.porcentajes, "id_porcentaje", "nombre");
            ViewBag.id_producto_donador = new SelectList(db.productos, "id_producto", "nombre");
            return View();
        }

        // POST: donadoresMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_donador,nombre,aporte_pib,id_porcentaje_donador,id_producto_donador,fecha,id_pais_donador,id_continente_donador,total")] donadores donadores)
        {
            if (ModelState.IsValid)
            {
                if (donadores.id_porcentaje_donador == 1)
                {
                    donadores.total = ((donadores.aporte_pib * 5) / 100);
                }
                else
                {
                    donadores.total = ((donadores.aporte_pib * 10) / 100);
                }
                donadores.fecha = DateTime.Now;
                db.donadores.Add(donadores);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.id_continente_donador = new SelectList(db.continente, "id_continente", "nombre", donadores.id_continente_donador);
            ViewBag.id_pais_donador = new SelectList(db.pais, "id_pais", "nombre", donadores.id_pais_donador);
            ViewBag.id_porcentaje_donador = new SelectList(db.porcentajes, "id_porcentaje", "nombre", donadores.id_porcentaje_donador);
            ViewBag.id_producto_donador = new SelectList(db.productos, "id_producto", "nombre", donadores.id_producto_donador);
            return View(donadores);
        }

        // GET: donadoresMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donadores donadores = db.donadores.Find(id);
            if (donadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_continente_donador = new SelectList(db.continente, "id_continente", "nombre", donadores.id_continente_donador);
            ViewBag.id_pais_donador = new SelectList(db.pais, "id_pais", "nombre", donadores.id_pais_donador);
            ViewBag.id_porcentaje_donador = new SelectList(db.porcentajes, "id_porcentaje", "nombre", donadores.id_porcentaje_donador);
            ViewBag.id_producto_donador = new SelectList(db.productos, "id_producto", "nombre", donadores.id_producto_donador);
            return View(donadores);
        }

        // POST: donadoresMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_donador,nombre,aporte_pib,id_porcentaje_donador,id_producto_donador,fecha,id_pais_donador,id_continente_donador,total")] donadores donadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_continente_donador = new SelectList(db.continente, "id_continente", "nombre", donadores.id_continente_donador);
            ViewBag.id_pais_donador = new SelectList(db.pais, "id_pais", "nombre", donadores.id_pais_donador);
            ViewBag.id_porcentaje_donador = new SelectList(db.porcentajes, "id_porcentaje", "nombre", donadores.id_porcentaje_donador);
            ViewBag.id_producto_donador = new SelectList(db.productos, "id_producto", "nombre", donadores.id_producto_donador);
            return View(donadores);
        }

        // GET: donadoresMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donadores donadores = db.donadores.Find(id);
            if (donadores == null)
            {
                return HttpNotFound();
            }
            return View(donadores);
        }

        // POST: donadoresMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            donadores donadores = db.donadores.Find(id);
            db.donadores.Remove(donadores);
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
