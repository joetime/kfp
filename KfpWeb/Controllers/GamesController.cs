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
    //[RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        private KfpWebContext db = new KfpWebContext();

        /// GET: api/Games
        public IQueryable<Game> GetGames()
        {
            return db.Games
                .OrderBy(game => game.kickoff);
        }

        /// GET: api/Games/Week/1
        [Route("api/games/week/{weekId}")]
        public IQueryable<Game> GetGames(int weekId)
        {
            return db.Games
                .Where(game => game.week == weekId)
                .OrderBy(game => game.kickoff);
        }

        /// GET: api/Games/team/NYG
        [Route("api/games/team/{teamId}")]
        public IQueryable<Game> GetGames(string teamId)
        {
            return db.Games
                .Where(game => game.homeTeamId == teamId || game.awayTeamId == teamId)
                .OrderBy(game => game.kickoff);
        }

        /// GET: api/Games/5
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> GetGame(int id)
        {
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.id == id) > 0;
        }
    }
}

/*
// PUT: api/Games/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGame(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.id)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> PostGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(game);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = game.id }, game);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> DeleteGame(int id)
        {
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            await db.SaveChangesAsync();

            return Ok(game);
        }
*/