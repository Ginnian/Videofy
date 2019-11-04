using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videofy.Models
{
    public class Cart
    {
        public IEnumerable<Movie> Movies { get; set; }

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Movie Movie { get; set; }
            public int Quantity { get; set; }
        }

        private List<CartLine> lineOfCart = new List<CartLine>();

        //movice select by customer and the quantity the user want to rental
        //add an item to the cart
        public virtual void AddItem(Movie movie, int quantity)
        {
            CartLine line = lineOfCart.Where(p => p.Movie.Id == movie.Id).FirstOrDefault();

            if(line == null)
            {
                lineOfCart.Add(new CartLine
                {
                    Movie = movie,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //remove a previously added item from the cart
        public virtual void RemoveLine(Movie movie)
        {
            lineOfCart.RemoveAll(l => l.Movie.Id == movie.Id);
        }

        //calculate the total cost of the items in the cart
        public virtual decimal TotalValue() => lineOfCart.Sum(e => e.Movie.Price * e.Quantity);

        //reset the cart by removing all the item
        public virtual void Clear() => lineOfCart.Clear();

        //property that give access to the contents of the cart 
        public virtual IEnumerable<CartLine> Lines => lineOfCart;
    }
}
