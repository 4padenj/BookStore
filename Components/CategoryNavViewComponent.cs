using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Components
{
    public class CategoryNavViewComponent : ViewComponent
    {
        private IStoreRepository repository;
        public CategoryNavViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            // This line is for highlighting the Active Category
            ViewBag.activeCat = RouteData?.Values["category"];

            // this line queries the repo of books to return all the categories.
            return View(repository.Books.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}
