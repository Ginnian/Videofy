using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videofy.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
