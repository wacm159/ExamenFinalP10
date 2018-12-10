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
    public class donadoresController : ApiController
    {
        private DonacionesEntities db = new DonacionesEntities();

        // GET: api/donadores
        public IQueryable<donadores> Getdonadores()
        {
            //return db.donadores.Include(v => v.nombre).Include(v => v.aporte_pib);
            return db.donadores;
        }

        // GET: api/donadores/5
        [ResponseType(typeof(donadores))]
        public IHttpActionResult Getdonadores(int id)
        {
            donadores donadores = db.donadores.Find(id);
            if (donadores == null)
            {
                return NotFound();
            }

            return Ok(donadores);
        }

        // PUT: api/donadores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdonadores(int id, donadores donadores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donadores.id_donador)
            {
                return BadRequest();
            }

            db.Entry(donadores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!donadoresExists(id))
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

        // POST: api/donadores
        [ResponseType(typeof(donadores))]
        public IHttpActionResult Postdonadores(donadores donadores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.donadores.Add(donadores);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donadores.id_donador }, donadores);
        }

        // DELETE: api/donadores/5
        [ResponseType(typeof(donadores))]
        public IHttpActionResult Deletedonadores(int id)
        {
            donadores donadores = db.donadores.Find(id);
            if (donadores == null)
            {
                return NotFound();
            }

            db.donadores.Remove(donadores);
            db.SaveChanges();

            return Ok(donadores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool donadoresExists(int id)
        {
            return db.donadores.Count(e => e.id_donador == id) > 0;
        }
    }
}