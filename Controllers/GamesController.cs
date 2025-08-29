using game_reviews_app.Data;
using game_reviews_app.DTOs;
using game_reviews_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace game_reviews_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly DBContext _context;

        public GamesController(DBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _context.Games.ToListAsync();
            return Ok(games);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }
        /// <summary>
        /// Creates a game.
        /// </summary>
        /// <param name="_game"></param>
        /// <returns>Created game with the new game's location</returns>
        [HttpPost]
        public async Task<IActionResult> PostGame(GamesDTO _game)
        {
            var game = new Game
            {
                Title = _game.Title,
                Genre = _game.Genre,
                Platform = Enum.TryParse<Platform>(_game.Platform, out var platform) ? platform : Platform.Other,
                ReleaseDate = _game.ReleaseDate,
                Rating = _game.Rating
            };
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGameById), new { id = game.Id }, game);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }
            _context.Entry(game).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
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
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
