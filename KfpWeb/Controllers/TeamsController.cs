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
    public class TeamsController : ApiController
    {
        private KfpWebContext db = new KfpWebContext();

        /// GET: api/Teams
        public IQueryable<Team> GetTeams()
        {
            return db.Teams;
        }

        /// GET: api/Teams/5
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> GetTeam(string id)
        {
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamExists(string id)
        {
            return db.Teams.Count(e => e.id == id) > 0;
        }
    }
}

/*
 * /// PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeam(string id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.id)
            {
                return BadRequest();
            }

            db.Entry(team).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        /// POST: api/Teams
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> PostTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teams.Add(team);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeamExists(team.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = team.id }, team);
        }

        /// DELETE: api/Teams/5
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> DeleteTeam(string id)
        {
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            await db.SaveChangesAsync();

            return Ok(team);
        }
*/