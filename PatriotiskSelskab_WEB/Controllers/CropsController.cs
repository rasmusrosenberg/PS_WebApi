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
    public class CropsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Crops
        public IQueryable<Crop> GetCrops()
        {
            return db.Crops;
        }

        // GET: api/Crops/5
        [ResponseType(typeof(Crop))]
        public IHttpActionResult GetCrop(int id)
        {
            Crop crop = db.Crops.Find(id);
            if (crop == null)
            {
                return NotFound();
            }

            return Ok(crop);
        }

        // PUT: api/Crops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCrop(int id, Crop crop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crop.CropID)
            {
                return BadRequest();
            }

            db.Entry(crop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CropExists(id))
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

        // POST: api/Crops
        [ResponseType(typeof(Crop))]
        public IHttpActionResult PostCrop(Crop crop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Crops.Add(crop);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = crop.CropID }, crop);
        }

        // DELETE: api/Crops/5
        [ResponseType(typeof(Crop))]
        public IHttpActionResult DeleteCrop(int id)
        {
            Crop crop = db.Crops.Find(id);
            if (crop == null)
            {
                return NotFound();
            }

            db.Crops.Remove(crop);
            db.SaveChanges();

            return Ok(crop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CropExists(int id)
        {
            return db.Crops.Count(e => e.CropID == id) > 0;
        }
    }
}