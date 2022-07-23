using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shelve_app.Data;
using shelve_app.Models;
using Newtonsoft.Json.Linq;

namespace shelve_app.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly shelve_app.Data.ApplicationDbContext _context;

        public DetailsModel(shelve_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Product Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public RedirectToPageResult OnPostCart(int? id)
        {
            
            dynamic cart = HttpContext.Request.Cookies["Cart"];
            if (cart == null) {
                


                Response.Cookies.Append("Cart", "{\"" + id.ToString() + "\"" + ":" + "1}");
                return RedirectToPage("./Index");
            }
            cart = JObject.Parse(cart);
            
            if (cart.ContainsKey(id.ToString()))
            {
                dynamic temp = cart[id.ToString()].Value + 1;
                cart[id.ToString()] = temp;
                Response.Cookies.Append("Cart", cart.ToString());
                return RedirectToPage("./Index");
            }

            cart.Add(new JProperty(id.ToString(), 1));
            Response.Cookies.Append("Cart", cart.ToString());
            return RedirectToPage("./Index");
        }
    }
}
