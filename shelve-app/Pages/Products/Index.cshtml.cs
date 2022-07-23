using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shelve_app.Data;
using shelve_app.Models;

namespace shelve_app.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly shelve_app.Data.ApplicationDbContext _context;

        public IndexModel(shelve_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Product = await _context.Product.ToListAsync();
            }
        }
    }
}
