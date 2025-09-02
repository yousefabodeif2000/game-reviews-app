using game_reviews_app.Data;
using game_reviews_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace game_reviews_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly DBContext _context;

        public FavoritesController(DBContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost("{userId}/{gameId}")]
        public async Task<IActionResult> PostFavorite(int userId, int gameId)
        {
            var favorite = new Favorite
            {
                UserId = userId.ToString(),
                GameId = gameId
            };
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFavorite), new { id = favorite.Id }, favorite);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null) return NotFound();
            return Ok(favorite);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetFavoritesByUser(string userId)
        {
            var favorites = await _context.Favorites
                .Where(f => f.UserId == userId)
                .ToListAsync();
            return Ok(favorites);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
