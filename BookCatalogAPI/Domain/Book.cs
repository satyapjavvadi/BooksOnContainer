using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogAPI.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string ISBN { get; set; }
        public string PublishedDate { get; set; }
        public int CategoryId { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public int AuthorId { get; set; }
        public virtual BookAuthor BookAuthor { get; set; }
    }
}
