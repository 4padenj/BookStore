using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class PurchaseModel : PageModel
    {
        private IStoreRepository repository;
        // Constructor to set the repository
        public PurchaseModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            // Allows us to set the cart from the session
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            //Selects the chosen book
            Book book = repository.Books.FirstOrDefault(b => b.BookID == bookId);
            // Adds the book to the current cart
            Cart.AddCartLine(book, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            //Removes the book with the mathing Id from the cartlines List
            Cart.RemoveCartLine(Cart.Lines.First(cl => cl.Book.BookID == bookId).Book);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
