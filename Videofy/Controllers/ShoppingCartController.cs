using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Videofy.Data;
using Videofy.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Videofy.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly MvcMovieContext _context;
        public ShoppingCartController(ShoppingCart shoppingCart, MvcMovieContext context )
        {
            _shoppingCart = shoppingCart;
            _context = context;
        }



        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(sCVM);
        }


        // ADD to Cart:
        public RedirectToActionResult AddToShoppingCart(int movieId)
        {
            var selectedMovie = _context.Movie.FirstOrDefault(p => p.Id == movieId);
            if (selectedMovie != null)
            {
                _shoppingCart.AddToCart(selectedMovie);
            }
            return RedirectToAction("Index");
        }


        // REMOVE from Cart:
        public RedirectToActionResult RemoveFromShoppingCart(int movieId)
        {
            var selectedMovie = _context.Movie.FirstOrDefault(p => p.Id == movieId);
            if (selectedMovie != null)
            {
                _shoppingCart.RemoveFromCart(selectedMovie);
            }
            return RedirectToAction("Index");
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
