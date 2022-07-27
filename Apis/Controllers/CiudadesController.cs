using Apis.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Apis.Controllers
{
    public class CiudadesController : ApiController
    {
        private TouchSecurityEntities db = new TouchSecurityEntities();
        private Ciudades ciudades = new Ciudades();

        // GET: api/Ciudades
        /*public IQueryable<Ciudades> GetCiudades()
        {
            return db.Ciudades;
        }*/

        public List<string> GetCiudades()
        {
            List<string> lista = new List<string>();
            using (var context = new TouchSecurityEntities())
            {
                var result = context.Ciudades.ToList();
                foreach (var item in result)
                {
                    lista.Add(item.Ciudad);
                }
                return lista;
            }
        }

        // GET: api/Ciudades/5
        [ResponseType(typeof(Ciudades))]
        public IHttpActionResult GetCiudades(int id)
        {
            Ciudades ciudades = db.Ciudades.Find(id);
            if (ciudades == null)
            {
                return NotFound();
            }

            return Ok(ciudades.Ciudad);
        }

        public int GetCiudades(string name)
        {
            Ciudades ciudades = db.Ciudades.FirstOrDefault(x => x.Ciudad == name);

            return ciudades.Id;
        }

        // PUT: api/Ciudades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCiudades(int id, Ciudades ciudades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ciudades.Id)
            {
                return BadRequest();
            }

            db.Entry(ciudades).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadesExists(id))
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

        // POST: api/Ciudades
        [ResponseType(typeof(Ciudades))]
        public IHttpActionResult PostCiudades(Ciudades ciudades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ciudades.Add(ciudades);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ciudades.Id }, ciudades);
        }

        // DELETE: api/Ciudades/5
        [ResponseType(typeof(Ciudades))]
        public IHttpActionResult DeleteCiudades(int id)
        {
            Ciudades ciudades = db.Ciudades.Find(id);
            if (ciudades == null)
            {
                return NotFound();
            }

            db.Ciudades.Remove(ciudades);
            db.SaveChanges();

            return Ok(ciudades);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CiudadesExists(int id)
        {
            return db.Ciudades.Count(e => e.Id == id) > 0;
        }
    }
}