using System.ComponentModel.DataAnnotations;

namespace shelve_app.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string MainImage { get; set; }
        public float Price { get; set; }
        public float VatRate { get; set; }
        public string Thumbnail { get; set; }

    }
}
