using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplicationToken.Models;

namespace WebApplicationToken.Controllers
{
    [Authorize]
    public class PaisController : ApiController
    {
        private WebApplicationTokenContext db = new WebApplicationTokenContext();

        // GET: api/Pais
        public IQueryable<Pais> GetPais()
        {
            return db.Pais;
        }

        // GET: api/Pais/5
        [ResponseType(typeof(Pais))]
        public async Task<IHttpActionResult> GetPais(Guid id)
        {
            Pais pais = await db.Pais.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            return Ok(pais);
        }

        // PUT: api/Pais/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPais(Guid id, Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pais.Id)
            {
                return BadRequest();
            }

            db.Entry(pais).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
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

        // POST: api/Pais
        [ResponseType(typeof(Pais))]
        public async Task<IHttpActionResult> PostPais(Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pais.Add(pais);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaisExists(pais.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pais.Id }, pais);
        }

        // DELETE: api/Pais/5
        [ResponseType(typeof(Pais))]
        public async Task<IHttpActionResult> DeletePais(Guid id)
        {
            Pais pais = await db.Pais.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            db.Pais.Remove(pais);
            await db.SaveChangesAsync();

            return Ok(pais);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaisExists(Guid id)
        {
            return db.Pais.Count(e => e.Id == id) > 0;
        }
    }
}