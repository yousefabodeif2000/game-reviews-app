namespace game_reviews_app.DTOs
{
    public class ReviewsDTO
    {
        public int GameId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; } // e.g., 1 to 5
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
