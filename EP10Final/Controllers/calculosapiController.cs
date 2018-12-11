using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EP10Final.Models;

namespace EP10Final.Controllers
{
    public class calculosapiController : ApiController
    {
        private DonacionesEntities db = new DonacionesEntities();

        // GET: api/calculosapi
        public IQueryable<calculos> Getcalculos()
        {
            return db.calculos;
            //return db.calculos.Include(t => t.fecha).Include(t => t.total).Include(t => t.donadores.id_donador);
        }

        // GET: api/calculosapi/5
        [ResponseType(typeof(calculos))]
        public IHttpActionResult Getcalculos(int id)
        {
            calculos calculos = db.calculos.Find(id);
            if (calculos == null)
            {
                return NotFound();
            }

            return Ok(calculos);
        }

        // PUT: api/calculosapi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcalculos(int id, calculos calculos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calculos.id_calculo)
            {
                return BadRequest();
            }

            db.Entry(calculos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!calculosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/calculosapi
        [ResponseType(typeof(calculos))]
        public IHttpActionResult Postcalculos(calculos calculos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.calculos.Add(calculos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calculos.id_calculo }, calculos);
        }

        // DELETE: api/calculosapi/5
        [ResponseType(typeof(calculos))]
        public IHttpActionResult Deletecalculos(int id)
        {
            calculos calculos = db.calculos.Find(id);
            if (calculos == null)
            {
                return NotFound();
            }

            db.calculos.Remove(calculos);
            db.SaveChanges();

            return Ok(calculos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool calculosExists(int id)
        {
            return db.calculos.Count(e => e.id_calculo == id) > 0;
        }
    }
}