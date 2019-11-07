using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videofy.Data;

namespace Videofy.Models
{
    public class ShoppingCart
    {
        private readonly MvcMovieContext _mvcMovieContext;

        public ShoppingCart(MvcMovieContext mvcMovieContext)
        {
            _mvcMovieContext = mvcMovieContext;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        //---------------- METHODS -----------------//

        // GET Cart:
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<MvcMovieContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }


        // ADD to Cart:
        public void AddToCart(Movie movie)
        {
            var shoppingCartItem =
                    _mvcMovieContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie
                };

                _mvcMovieContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            ///else
            ///{
            ///    shoppingCartItem.Amount++;
            ///}

            _mvcMovieContext.SaveChanges();
        }


        // REMOVE from Cart:
        //public int RemoveFromCart(Movie movie)
        public void RemoveFromCart(Movie movie)
        {
            var shoppingCartItem =
                    _mvcMovieContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);

            ///var localAmount = 0;
            ///if (shoppingCartItem != null)
            ///{
            ///    if (shoppingCartItem.Amount > 1)
            ///    {
            ///        shoppingCartItem.Amount--;
            ///        localAmount = shoppingCartItem.Amount;
            ///    }
            ///    else
            ///    {
            ///        _mvcMovieContext.ShoppingCartItems.Remove(shoppingCartItem);
            ///    }
            ///}

            if (shoppingCartItem != null)
            {
                _mvcMovieContext.ShoppingCartItems.Remove(shoppingCartItem);
            }

            _mvcMovieContext.SaveChanges();

            //return localAmount;
        }


        // GET Items:
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _mvcMovieContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Movie)
                           .ToList());
        }


        // CLEAR Cart:
        public void ClearCart()
        {
            var cartItems = _mvcMovieContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _mvcMovieContext.ShoppingCartItems.RemoveRange(cartItems);

            _mvcMovieContext.SaveChanges();
        }


        // GET TOTAL Pice:
        public decimal GetShoppingCartTotal()
        {
            var total = _mvcMovieContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Movie.Price).Sum();
            return total;
        }


    }
}
