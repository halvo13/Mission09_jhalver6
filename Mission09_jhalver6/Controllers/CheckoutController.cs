using Microsoft.AspNetCore.Mvc;
using Mission09_jhalver6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jhalver6.Controllers
{
    public class CheckoutController : Controller
    {
        private ICheckoutRepository repo { get; set; }
        private Cart cart { get; set; }
        public CheckoutController(ICheckoutRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Checkout(Checkout checkout)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty");
            }
            if (ModelState.IsValid)
            {
                checkout.Lines = cart.Items.ToArray();
                repo.SaveCheckout(checkout);
                cart.ClearCart();

                return RedirectToPage("/Confirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
