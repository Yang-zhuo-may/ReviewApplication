using Microsoft.AspNetCore.Mvc;
using dotNET_Questions.Data;
using dotNET_Questions.Models;

namespace dotNET_Questions.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public QuestionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Question> objQuestionList = _db.Questions;
            return View(objQuestionList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
