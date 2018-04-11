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
    public class TrialGroupsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/TrialGroups
        public IQueryable<TrialGroup> GetTrialGroups()
        {
            return db.TrialGroups;
        }

        // GET: api/TrialGroups/5
        [ResponseType(typeof(TrialGroup))]
        public IHttpActionResult GetTrialGroup(int id)
        {
            TrialGroup trialGroup = db.TrialGroups.Find(id);
            if (trialGroup == null)
            {
                return NotFound();
            }

            return Ok(trialGroup);
        }

        // PUT: api/TrialGroups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrialGroup(int id, TrialGroup trialGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trialGroup.TrialGroupID)
            {
                return BadRequest();
            }

            db.Entry(trialGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrialGroupExists(id))
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

        // POST: api/TrialGroups
        [ResponseType(typeof(TrialGroup))]
        public IHttpActionResult PostTrialGroup(TrialGroup trialGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrialGroups.Add(trialGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trialGroup.TrialGroupID }, trialGroup);
        }

        // DELETE: api/TrialGroups/5
        [ResponseType(typeof(TrialGroup))]
        public IHttpActionResult DeleteTrialGroup(int id)
        {
            TrialGroup trialGroup = db.TrialGroups.Find(id);
            if (trialGroup == null)
            {
                return NotFound();
            }

            db.TrialGroups.Remove(trialGroup);
            db.SaveChanges();

            return Ok(trialGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrialGroupExists(int id)
        {
            return db.TrialGroups.Count(e => e.TrialGroupID == id) > 0;
        }
    }
}