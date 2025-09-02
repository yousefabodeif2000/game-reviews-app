using game_reviews_app.Data;
using game_reviews_app.DTOs;
using game_reviews_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace game_reviews_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly DBContext _context;

        public ReviewsController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostReview(ReviewsDTO reviewDTO)
        {
            var review = new Review
            {
                GameId = reviewDTO.GameId,
                UserId = reviewDTO.UserId,
                Rating = reviewDTO.Rating,
                Body = reviewDTO.Body,
                CreatedAt = DateTime.UtcNow
            };
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound();
            return review;
        }

        [HttpGet("game/{gameId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByGame(int gameId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.GameId == gameId)
                .ToListAsync();
            return reviews;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
