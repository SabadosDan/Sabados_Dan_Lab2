﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sabados_Dan_Lab2.Data;
using Sabados_Dan_Lab2.Models;

namespace Sabados_Dan_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Sabados_Dan_Lab2.Data.Sabados_Dan_Lab2Context _context;

        public IndexModel(Sabados_Dan_Lab2.Data.Sabados_Dan_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.Include(b=>b.Publisher).Include(b=>b.Author).ToListAsync();
        }
    }
}
