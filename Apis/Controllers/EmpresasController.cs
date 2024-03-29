﻿using Apis.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Apis.Controllers
{
    public class EmpresasController : ApiController
    {
        private TouchSecurityEntities db = new TouchSecurityEntities();

        // GET: api/Empresas
        public IQueryable<Empresas> GetEmpresas()
        {
            return db.Empresas;
        }
 

        // GET: api/Empresas/5
        [ResponseType(typeof(Empresas))]
        public IHttpActionResult GetEmpresas(int id)
        {
            Empresas empresas = db.Empresas.Find(id);
            if (empresas == null)
            {
                return NotFound();
            }

            return Ok(empresas);
        }

        public List<Empresas> GetEmpresas(string ruc)
        {
            List<Empresas> empresa = db.Empresas.Where(x => x.Ruc == ruc).ToList();
            if (empresa == null)
            {
                return null;
            }

            return empresa;
        }
        
        public List<Empresas> GetEmpresas(string ruc, string contraseña)
        {
            List<Empresas> empresa = db.Empresas.Where(x => (x.Ruc == ruc) && (x.Contrasenia == contraseña)).ToList();
            if (empresa == null)
            {
                return null;
            }

            return empresa;
        }

        // PUT: api/Empresas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpresas(int id, Empresas empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empresas.Id)
            {
                return BadRequest();
            }

            db.Entry(empresas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresasExists(id))
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

        // POST: api/Empresas
        [ResponseType(typeof(Empresas))]
        public IHttpActionResult PostEmpresas(Empresas empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empresas.Add(empresas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empresas.Id }, empresas);
        }

        // DELETE: api/Empresas/5
        [ResponseType(typeof(Empresas))]
        public IHttpActionResult DeleteEmpresas(int id)
        {
            Empresas empresas = db.Empresas.Find(id);
            if (empresas == null)
            {
                return NotFound();
            }

            db.Empresas.Remove(empresas);
            db.SaveChanges();

            return Ok(empresas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpresasExists(int id)
        {
            return db.Empresas.Count(e => e.Id == id) > 0;
        }
    }
}