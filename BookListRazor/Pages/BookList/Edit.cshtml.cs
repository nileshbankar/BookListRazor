using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {

            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int Id)
        {
            Book = await _db.Book.FindAsync(Id);

        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var bookFromDB = await _db.Book.FindAsync(Book.Id);
                bookFromDB.Author = Book.Author;
                bookFromDB.Name =  Book.Name;

                bookFromDB.ISBN = Book.ISBN;


              await  _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {

                return Page();
            }
        }

    }
}
