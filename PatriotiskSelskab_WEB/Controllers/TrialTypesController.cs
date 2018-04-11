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
    public class TrialTypesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/TrialTypes
        public IQueryable<TrialType> GetTrialTypes()
        {
            return db.TrialTypes;
        }

        // GET: api/TrialTypes/5
        [ResponseType(typeof(TrialType))]
        public IHttpActionResult GetTrialType(int id)
        {
            TrialType trialType = db.TrialTypes.Find(id);
            if (trialType == null)
            {
                return NotFound();
            }

            return Ok(trialType);
        }

        // PUT: api/TrialTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrialType(int id, TrialType trialType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trialType.TrialTypeID)
            {
                return BadRequest();
            }

            db.Entry(trialType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrialTypeExists(id))
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

        // POST: api/TrialTypes
        [ResponseType(typeof(TrialType))]
        public IHttpActionResult PostTrialType(TrialType trialType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrialTypes.Add(trialType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trialType.TrialTypeID }, trialType);
        }

        // DELETE: api/TrialTypes/5
        [ResponseType(typeof(TrialType))]
        public IHttpActionResult DeleteTrialType(int id)
        {
            TrialType trialType = db.TrialTypes.Find(id);
            if (trialType == null)
            {
                return NotFound();
            }

            db.TrialTypes.Remove(trialType);
            db.SaveChanges();

            return Ok(trialType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrialTypeExists(int id)
        {
            return db.TrialTypes.Count(e => e.TrialTypeID == id) > 0;
        }
    }
}