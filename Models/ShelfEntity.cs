using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApi.Models
{
    public class ShelfEntity
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }

        public List<BookShelves> BookShelves  { get; set; }
        public UserEntity user  { get; set; }

    }
}