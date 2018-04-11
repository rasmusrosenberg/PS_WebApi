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
using PatriotiskSelskab_WEB.Models;

namespace PatriotiskSelskab_WEB.Controllers
{
    public class Treatment_ProductController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Treatment_Product
        public IQueryable<Treatment_Product> GetTreatment_Products()
        {
            return db.Treatment_Products;
        }

        // GET: api/Treatment_Product/5
        [ResponseType(typeof(Treatment_Product))]
        public IHttpActionResult GetTreatment_Product(int id)
        {
            Treatment_Product treatment_Product = db.Treatment_Products.Find(id);
            if (treatment_Product == null)
            {
                return NotFound();
            }

            return Ok(treatment_Product);
        }

        // PUT: api/Treatment_Product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTreatment_Product(int id, Treatment_Product treatment_Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != treatment_Product.TreatmentProductID)
            {
                return BadRequest();
            }

            db.Entry(treatment_Product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Treatment_ProductExists(id))
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

        // POST: api/Treatment_Product
        [ResponseType(typeof(Treatment_Product))]
        public IHttpActionResult PostTreatment_Product(Treatment_Product treatment_Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Treatment_Products.Add(treatment_Product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = treatment_Product.TreatmentProductID }, treatment_Product);
        }

        // DELETE: api/Treatment_Product/5
        [ResponseType(typeof(Treatment_Product))]
        public IHttpActionResult DeleteTreatment_Product(int id)
        {
            Treatment_Product treatment_Product = db.Treatment_Products.Find(id);
            if (treatment_Product == null)
            {
                return NotFound();
            }

            db.Treatment_Products.Remove(treatment_Product);
            db.SaveChanges();

            return Ok(treatment_Product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Treatment_ProductExists(int id)
        {
            return db.Treatment_Products.Count(e => e.TreatmentProductID == id) > 0;
        }
    }
}