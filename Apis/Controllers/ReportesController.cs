using Apis.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Apis.Controllers
{
    public class ReportesController : ApiController
    {
        private TouchSecurityEntities db = new TouchSecurityEntities();

        // GET: api/Reportes
        public IQueryable<Reportes> GetReportes()
        {
            return db.Reportes;
        }

        public List<Reportes> GetReportesByRange(DateTime FechaIni, DateTime FechaFin)
        {
            List<Reportes> reportes = db.Reportes.Where(x => (x.Fecha >= FechaIni) && (x.Fecha <= FechaFin)).ToList();
            return reportes;
        }

        // GET: api/Reportes/5
        [ResponseType(typeof(Reportes))]
        public IHttpActionResult GetReportes(int id)
        {
            Reportes reportes = db.Reportes.Find(id);
            if (reportes == null)
            {
                return NotFound();
            }

            return Ok(reportes);
        }

        // PUT: api/Reportes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReportes(int id, Reportes reportes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reportes.Id)
            {
                return BadRequest();
            }

            db.Entry(reportes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportesExists(id))
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

        // POST: api/Reportes
        [ResponseType(typeof(Reportes))]
        public IHttpActionResult PostReportes(Reportes reportes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reportes.Add(reportes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reportes.Id }, reportes);
        }

        // DELETE: api/Reportes/5
        [ResponseType(typeof(Reportes))]
        public IHttpActionResult DeleteReportes(int id)
        {
            Reportes reportes = db.Reportes.Find(id);
            if (reportes == null)
            {
                return NotFound();
            }

            db.Reportes.Remove(reportes);
            db.SaveChanges();

            return Ok(reportes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReportesExists(int id)
        {
            return db.Reportes.Count(e => e.Id == id) > 0;
        }
    }
}