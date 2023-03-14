using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_jhalver6.Infrastructure;
using Mission09_jhalver6.Models;

namespace Mission09_jhalver6.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public CartModel (IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
           
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            double p = b.Price;
            cart.AddItem(b, 1, p);

            return RedirectToPage(new { ReturnUrl = returnUrl});
        }
        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
    }
}
