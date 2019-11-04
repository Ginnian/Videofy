using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videofy.Models
{
    public class CartIndexViewModel
    {
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
