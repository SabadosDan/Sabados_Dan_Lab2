using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sabados_Dan_Lab2.Data;
using Sabados_Dan_Lab2.Models;

namespace Sabados_Dan_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Sabados_Dan_Lab2.Data.Sabados_Dan_Lab2Context _context;

        public DetailsModel(Sabados_Dan_Lab2.Data.Sabados_Dan_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.Include(b => b.Author).FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
