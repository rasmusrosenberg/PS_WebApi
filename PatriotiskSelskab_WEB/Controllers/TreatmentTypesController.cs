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
    public class TreatmentTypesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/TreatmentTypes
        public IQueryable<TreatmentType> GetTreatmentTypes()
        {
            return db.TreatmentTypes;
        }

        // GET: api/TreatmentTypes/5
        [ResponseType(typeof(TreatmentType))]
        public IHttpActionResult GetTreatmentType(int id)
        {
            TreatmentType treatmentType = db.TreatmentTypes.Find(id);
            if (treatmentType == null)
            {
                return NotFound();
            }

            return Ok(treatmentType);
        }

        // PUT: api/TreatmentTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTreatmentType(int id, TreatmentType treatmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != treatmentType.TreatmentTypeID)
            {
                return BadRequest();
            }

            db.Entry(treatmentType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentTypeExists(id))
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

        // POST: api/TreatmentTypes
        [ResponseType(typeof(TreatmentType))]
        public IHttpActionResult PostTreatmentType(TreatmentType treatmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TreatmentTypes.Add(treatmentType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = treatmentType.TreatmentTypeID }, treatmentType);
        }

        // DELETE: api/TreatmentTypes/5
        [ResponseType(typeof(TreatmentType))]
        public IHttpActionResult DeleteTreatmentType(int id)
        {
            TreatmentType treatmentType = db.TreatmentTypes.Find(id);
            if (treatmentType == null)
            {
                return NotFound();
            }

            db.TreatmentTypes.Remove(treatmentType);
            db.SaveChanges();

            return Ok(treatmentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TreatmentTypeExists(int id)
        {
            return db.TreatmentTypes.Count(e => e.TreatmentTypeID == id) > 0;
        }
    }
}