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
    public class SubBlocksController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/SubBlocks
        public IQueryable<SubBlock> GetSubBlocks()
        {
            return db.SubBlocks;
        }

        // GET: api/SubBlocks/5
        [ResponseType(typeof(SubBlock))]
        public IHttpActionResult GetSubBlock(int id)
        {
            SubBlock subBlock = db.SubBlocks.Find(id);
            if (subBlock == null)
            {
                return NotFound();
            }

            return Ok(subBlock);
        }

        // PUT: api/SubBlocks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubBlock(int id, SubBlock subBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subBlock.SubBlockID)
            {
                return BadRequest();
            }

            db.Entry(subBlock).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubBlockExists(id))
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

        // POST: api/SubBlocks
        [ResponseType(typeof(SubBlock))]
        public IHttpActionResult PostSubBlock(SubBlock subBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubBlocks.Add(subBlock);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subBlock.SubBlockID }, subBlock);
        }

        // DELETE: api/SubBlocks/5
        [ResponseType(typeof(SubBlock))]
        public IHttpActionResult DeleteSubBlock(int id)
        {
            SubBlock subBlock = db.SubBlocks.Find(id);
            if (subBlock == null)
            {
                return NotFound();
            }

            db.SubBlocks.Remove(subBlock);
            db.SaveChanges();

            return Ok(subBlock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubBlockExists(int id)
        {
            return db.SubBlocks.Count(e => e.SubBlockID == id) > 0;
        }
    }
}