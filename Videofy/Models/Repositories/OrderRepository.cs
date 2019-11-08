using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videofy.Data;
using Videofy.Models.Interface;


/// <summary>
/// This will be used to inject the order item and its detail from  sql databse
/// into the OrderDetails sql db.
/// </summary>
namespace Videofy.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MvcMovieContext _mvcMovieContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(MvcMovieContext mvcMovieContext, ShoppingCart shoppingCart)
        {
            _mvcMovieContext = mvcMovieContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            _mvcMovieContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    MovieId = item.Movie.Id,
                    OrderId = order.OrderId,
                    Price = item.Movie.Price,
                };

                _mvcMovieContext.OrderDetails.Add(orderDetail);
            }
            _mvcMovieContext.SaveChanges();
        }
    }
}

//public int OrderDetailId { get; set; }
//public int OrderId { get; set; }
//public int MovieId { get; set; }

//[DataType(DataType.Currency)] //Format input to currency data type
//[Column(TypeName = "decimal(18, 2)")] //Round decimal to 2 places
//public decimal Price { get; set; }
//public virtual Movie Movie { get; set; }
//public virtual Order Order { get; set; }