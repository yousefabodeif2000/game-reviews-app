namespace game_reviews_app.DTOs
{
    public class GamesDTO
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; } // Average rating from reviews
    }
}
