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
    public class FieldBlocksController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/FieldBlocks
        public IQueryable<FieldBlock> GetFieldBlocks()
        {
            return db.FieldBlocks;
        }

        // GET: api/FieldBlocks/5
        [ResponseType(typeof(FieldBlock))]
        public IHttpActionResult GetFieldBlock(int id)
        {
            FieldBlock fieldBlock = db.FieldBlocks.Find(id);
            if (fieldBlock == null)
            {
                return NotFound();
            }

            return Ok(fieldBlock);
        }

        // PUT: api/FieldBlocks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFieldBlock(int id, FieldBlock fieldBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fieldBlock.FieldBlockID)
            {
                return BadRequest();
            }

            db.Entry(fieldBlock).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FieldBlockExists(id))
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

        // POST: api/FieldBlocks
        [ResponseType(typeof(FieldBlock))]
        public IHttpActionResult PostFieldBlock(FieldBlock fieldBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FieldBlocks.Add(fieldBlock);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fieldBlock.FieldBlockID }, fieldBlock);
        }

        // DELETE: api/FieldBlocks/5
        [ResponseType(typeof(FieldBlock))]
        public IHttpActionResult DeleteFieldBlock(int id)
        {
            FieldBlock fieldBlock = db.FieldBlocks.Find(id);
            if (fieldBlock == null)
            {
                return NotFound();
            }

            db.FieldBlocks.Remove(fieldBlock);
            db.SaveChanges();

            return Ok(fieldBlock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FieldBlockExists(int id)
        {
            return db.FieldBlocks.Count(e => e.FieldBlockID == id) > 0;
        }
    }
}