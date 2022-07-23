using Microsoft.EntityFrameworkCore;

namespace shelve_app.Models
{
    [Keyless]
    public class Basket
    {
        public Product Product { get; set; }
    }
}
