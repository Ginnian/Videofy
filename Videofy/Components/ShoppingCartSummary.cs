using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videofy.Models;

namespace Videofy.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;    // access ShoppingCart
        public ShoppingCartSummary(ShoppingCart shoppingCart)   // constructor for this file
        {
            _shoppingCart = shoppingCart;   // Inject ShoppingCart into constructor
        }


        
        public IViewComponentResult Invoke()    // IViewComponentResult used for reusable component that returns a view
        {
            //var items = new List<ShoppingCartItem>() { new ShoppingCartItem(), new ShoppingCartItem() }; // Dummy items to test item count in cart
            var items = _shoppingCart.GetShoppingCartItems();    // assign GetShoppingCartItems() method return value into this variable
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel   // Instantiate new Object and initialise poperties
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);     // Return view with shoppingCartViewModel arg
        }
    }
}
