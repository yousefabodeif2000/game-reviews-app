namespace game_reviews_app.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int GameId { get; set; } // Foreign key
        public string UserId { get; set; } // Foreign key (string because IdentityUser uses string Ids)
        public DateTime CreatedAt { get; set; }


        // Navigation properties
        public Game Game { get; set; }
        public User User { get; set; }
    }
}
