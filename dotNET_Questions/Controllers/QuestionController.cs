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

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Question obj)
        {
            if (ModelState.IsValid)
            {
                _db.Questions.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var questionFromDb = _db.Questions.Find(id);

            if(questionFromDb == null)
            {
                return NotFound();
            }
            return View(questionFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Question obj)
        {
            if (ModelState.IsValid)
            {
                _db.Questions.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The question edited successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var questionFromDb = _db.Questions.Find(id);

            if (questionFromDb == null)
            {
                return NotFound();
            }
            return View(questionFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Questions.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Questions.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "The question deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
