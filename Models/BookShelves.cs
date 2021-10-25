using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApi.Models
{
    public class BookShelves
    {
        public string Id { get; set; }

        public string BookShelveId { get; set; }
        public string BookId { get; set; }
        public string ShelfId { get; set; }
        public string OwnerId { get; set; }

        public string UserrId { get; set; }
        public ShelfEntity ShelfEntity { get; set; }
        
        public BookEntity bookEntity {get; set;}
    }
}
