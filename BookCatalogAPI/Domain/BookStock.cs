using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogAPI.Domain
{
    public class BookStock
    {
        public int Id { get; set; }
        public string BookId { get; set; }
        public int Quantity { get; set; }
    }
}
