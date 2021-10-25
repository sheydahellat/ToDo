using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
namespace TodoApi.Dto
{
    public class DtoBookAndShelf
    {
        public string ShelfId { get; set; }
        public string ShelfName { get; set; }
        
        public List<BookShelves> bookOfShelf {get; set; }
        public UserEntity user  { get; set; }
        public DtoBookAndShelf()
        {
        }
        public DtoBookAndShelf(string shelfid,string shelfname)
        {
            this.ShelfId=shelfid;
            this.ShelfName=shelfname;
        }
 
    }
}