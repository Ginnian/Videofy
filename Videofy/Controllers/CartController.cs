using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Videofy.Models;
using Videofy.Models.Exteneded;
using Videofy.Controllers.Infrastructure;

namespace Videofy.Controllers
{
    public class CartController : Controller
    {
        public ViewResult Index()
        {
            Cart cart = new Cart { Movies = Movie.GetMovies() };
            decimal cartTotal = cart.TotalPrices(); //calculate the total price
            return View("Index", new string[] { $"Total: {cartTotal:c2}" }); //display the total price
        }

        private IMovieRepository repository;
        public CartController(IMovieRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        //Add item to the cart
        public RedirectToActionResult AddToCart(int moviceId, string returnUrl)
        {
            Movie movie = repository.Movies.FirstOrDefault(p => p.Id == moviceId);
            if(movie != null)
            {
                Cart cart = GetCart();
                cart.AddItem(movie, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //Remove item from the cart
        public RedirectToActionResult RemoveFromCart(int movieId, string returnUrl)
        {
            Movie movie = repository.Movies.FirstOrDefault(p => p.Id == movieId);
            if(movie != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(movie); //remove item by the item id
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}