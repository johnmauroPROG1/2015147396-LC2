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
using _2015104916.Entities.Entities;
using _2015104916.Persistence;

namespace _2015104916.API.Controllers
{
    public class CinturonController : ApiController
    {
        private _2015147396DbContext db = new _2015147396DbContext();

        // GET: api/Cinturon
        public IQueryable<Cinturon> GetCinturon()
        {
            return db.Cinturon;
        }

        // GET: api/Cinturon/5
        [ResponseType(typeof(Cinturon))]
        public IHttpActionResult GetCinturon(int id)
        {
            Cinturon cinturon = db.Cinturon.Find(id);
            if (cinturon == null)
            {
                return NotFound();
            }

            return Ok(cinturon);
        }

        // PUT: api/Cinturon/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCinturon(int id, Cinturon cinturon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cinturon.CinturonId)
            {
                return BadRequest();
            }

            db.Entry(cinturon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinturonExists(id))
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

        // POST: api/Cinturon
        [ResponseType(typeof(Cinturon))]
        public IHttpActionResult PostCinturon(Cinturon cinturon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cinturon.Add(cinturon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cinturon.CinturonId }, cinturon);
        }

        // DELETE: api/Cinturon/5
        [ResponseType(typeof(Cinturon))]
        public IHttpActionResult DeleteCinturon(int id)
        {
            Cinturon cinturon = db.Cinturon.Find(id);
            if (cinturon == null)
            {
                return NotFound();
            }

            db.Cinturon.Remove(cinturon);
            db.SaveChanges();

            return Ok(cinturon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CinturonExists(int id)
        {
            return db.Cinturon.Count(e => e.CinturonId == id) > 0;
        }
    }
}