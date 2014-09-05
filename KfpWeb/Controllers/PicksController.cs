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
using KfpWeb.Models;

namespace KfpWeb.Controllers
{
    public class PicksController : ApiController
    {
        private KfpWebContext db = new KfpWebContext();

        // GET: api/Picks
        public IQueryable<Pick> GetPicks()
        {
            return db.Picks;
        }

        // GET: api/Picks/5
        [ResponseType(typeof(Pick))]
        public async Task<IHttpActionResult> GetPick(int id)
        {
            Pick pick = await db.Picks.FindAsync(id);
            if (pick == null)
            {
                return NotFound();
            }

            return Ok(pick);
        }

        // GET: api/Picks
        [ResponseType(typeof(Pick))]
        public Pick GetPick([FromUri]int week, [FromUri]string username)
        {
            Pick pick = db.Picks.Where(p => p.userId == username && p.week == week).FirstOrDefault();
            
            if (pick == null)
            {
                // if none found, return an empty one
                pick = new Pick()
                {
                    week = week,
                    userId = username,
                };
            }

            return pick;
        }


        // PUT: api/Picks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPick(int id, Pick pick)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pick.id)
            {
                return BadRequest();
            }

            db.Entry(pick).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PickExists(id))
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

        // POST: api/Picks
        [ResponseType(typeof(Pick))]
        public async Task<IHttpActionResult> PostPick(Pick pick)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Picks.Add(pick);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pick.id }, pick);
        }

        // DELETE: api/Picks/5
        [ResponseType(typeof(Pick))]
        public async Task<IHttpActionResult> DeletePick(int id)
        {
            Pick pick = await db.Picks.FindAsync(id);
            if (pick == null)
            {
                return NotFound();
            }

            db.Picks.Remove(pick);
            await db.SaveChangesAsync();

            return Ok(pick);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PickExists(int id)
        {
            return db.Picks.Count(e => e.id == id) > 0;
        }
    }
}