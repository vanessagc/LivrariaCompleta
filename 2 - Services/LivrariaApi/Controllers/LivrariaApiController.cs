using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using LivrariaMvc.Infra.Data.Context;
using LivrariaMvc.Infra.Data.Models;
using LivrariaMvc.Infra.Data.UoW;

namespace LivrariaApi.Controllers
{
    [RoutePrefix("api/LivrariaApi")]
    public class LivrariaApiController : ApiController
    {
        private LivrariaEntityContext db = new LivrariaEntityContext();

        // GET: api/LivrariaApi
        public List<Livraria> GetLivrarias(string PropertyName)
        {
            // Meu teste via Postman = http://localhost:55695/api/LivrariaAPI?PropertyName=Nome
            List<Livraria> list;
            if (PropertyName == null)
                list =  db.Livrarias.ToList();
            else
                list = db.Livrarias.AsQueryable().OrderByPropertyName(PropertyName, true).ToList();

            return list;
        }


        // GET: api/LivrariaApi/5
        [ResponseType(typeof(Livraria))]
        public IHttpActionResult GetLivraria(int id)
        {
            Livraria livraria = db.Livrarias.Find(id);
            if (livraria == null)
            {
                return NotFound();
            }

            return Ok(livraria);
        }

        // PUT: api/LivrariaApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLivraria(int id, Livraria livraria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livraria.LivrariaID)
            {
                return BadRequest();
            }

            db.Entry(livraria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivrariaExists(id))
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

        // POST: api/LivrariaApi
        [ResponseType(typeof(Livraria))]
        public IHttpActionResult PostLivraria(Livraria livraria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Livrarias.Add(livraria);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = livraria.LivrariaID }, livraria);
        }

        // DELETE: api/LivrariaApi/5
        [ResponseType(typeof(Livraria))]
        public IHttpActionResult DeleteLivraria(int id)
        {
            Livraria livraria = db.Livrarias.Find(id);
            if (livraria == null)
            {
                return NotFound();
            }

            db.Livrarias.Remove(livraria);
            db.SaveChanges();

            return Ok(livraria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LivrariaExists(int id)
        {
            return db.Livrarias.Count(e => e.LivrariaID == id) > 0;
        }
    }
}