using BookListRazor.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json( new {data = _db.Book.ToList() });
        }

        public IActionResult DeleteBook(int id)
        {

            var bookFromDb = _db.Book.FirstOrDefault(b => b.Id == id);
            if (bookFromDb == null)
                return Json(new { success = false, message = "Error in deleting book." });

            _db.Book.Remove(bookFromDb);
            _db.SaveChanges();

            return Json(new { success = true, message = "Book deleted successfully" });

        }
    }
}
