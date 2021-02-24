using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksOnPage { get; set; }
        public int CurrentPage { get; set; }
        // TotalPages is a method called at every instance of PageingInfo
        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumBooks / BooksOnPage));
    }
}
