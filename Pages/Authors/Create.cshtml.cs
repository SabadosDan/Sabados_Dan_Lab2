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

namespace Sabados_Dan_Lab2.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly Sabados_Dan_Lab2.Data.Sabados_Dan_Lab2Context _context;

        public CreateModel(Sabados_Dan_Lab2.Data.Sabados_Dan_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Authors { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var existingFirstName = await _context.Authors.FirstOrDefaultAsync(b => b.FirstName == Authors.FirstName);

            var existingLastName = await _context.Authors.FirstOrDefaultAsync(b => b.LastName == Authors.LastName);

            if (existingFirstName != null && existingLastName != null)
            {
                throw new Exception("This author already exists.");
            }
            _context.Authors.Add(Authors);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
