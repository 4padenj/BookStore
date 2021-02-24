using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IStoreRepository _repository;
        // Determine the number of Books listed on each page
        public int BooksPerPage = 5;
        public HomeController(ILogger<HomeController> logger, IStoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(int page = 1)
        {
            return View(new BookListViewModel
            {
                //returning a view model that contains information for the Books and Paging Info
                // Books runs a query-like statement (using Linq) to pull books
                Books = _repository.Books
                    .OrderBy(b => b.BookID)
                    .Skip((page - 1) * BooksPerPage)
                    .Take(BooksPerPage),
                // Paging info allows us to use pagination links - passes the data into the viewModel
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    BooksOnPage = BooksPerPage,
                    TotalNumBooks = _repository.Books.Count()
                }
            });   
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
