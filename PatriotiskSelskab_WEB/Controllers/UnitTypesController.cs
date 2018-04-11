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
    public class UnitTypesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/UnitTypes
        public IQueryable<UnitType> GetUnitTypes()
        {
            return db.UnitTypes;
        }

        // GET: api/UnitTypes/5
        [ResponseType(typeof(UnitType))]
        public IHttpActionResult GetUnitType(string id)
        {
            UnitType unitType = db.UnitTypes.Find(id);
            if (unitType == null)
            {
                return NotFound();
            }

            return Ok(unitType);
        }

        // PUT: api/UnitTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUnitType(string id, UnitType unitType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unitType.UnitTypeName)
            {
                return BadRequest();
            }

            db.Entry(unitType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitTypeExists(id))
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

        // POST: api/UnitTypes
        [ResponseType(typeof(UnitType))]
        public IHttpActionResult PostUnitType(UnitType unitType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UnitTypes.Add(unitType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UnitTypeExists(unitType.UnitTypeName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = unitType.UnitTypeName }, unitType);
        }

        // DELETE: api/UnitTypes/5
        [ResponseType(typeof(UnitType))]
        public IHttpActionResult DeleteUnitType(string id)
        {
            UnitType unitType = db.UnitTypes.Find(id);
            if (unitType == null)
            {
                return NotFound();
            }

            db.UnitTypes.Remove(unitType);
            db.SaveChanges();

            return Ok(unitType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnitTypeExists(string id)
        {
            return db.UnitTypes.Count(e => e.UnitTypeName == id) > 0;
        }
    }
}