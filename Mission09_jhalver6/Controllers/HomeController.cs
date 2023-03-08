using Microsoft.AspNetCore.Mvc;
using Mission09_jhalver6.Models;
using Mission09_jhalver6.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jhalver6.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string BookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == BookCategory || BookCategory == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                        (BookCategory == null 
                            ? repo.Books.Count() 
                            : repo.Books.Where(x => x.Category == BookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
          

            return View(x);
        }
    }
}
