using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videofy.Models.Exteneded
{
    public static class ExtenedCartClass
    {
        public static decimal TotalPrices(this Cart cart)
        {
            decimal total = 0;
            foreach(Movie movie in cart.Movies)
            {
                total += movie?.Price ?? 0;
            }
            return total;
        }
    }
}
