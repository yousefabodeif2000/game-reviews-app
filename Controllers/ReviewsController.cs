using Microsoft.AspNetCore.Mvc;

namespace game_reviews_app.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
