using Microsoft.AspNetCore.Identity;

namespace game_reviews_app.Models
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; } = "Anonymous";
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    }
}
