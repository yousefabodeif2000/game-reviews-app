namespace game_reviews_app.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int GameId { get; set; } // Foreign key
        public string UserId { get; set; } // Foreign key (string because IdentityUser uses string Ids)
        public int Rating { get; set; } // 1-10 scale
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Game Game { get; set; }
        public User User { get; set; }
    }
}
