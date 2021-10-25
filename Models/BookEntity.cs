using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApi.Models
{
    public class BookEntity
    {
        public string Id { get; set; }
        public string BookId { get; set; }
        public string Title { get; set; }
        public List<BookShelves> BookShelves  { get; set; }

    }
}