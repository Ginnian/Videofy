using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Videofy.Controllers;
using Videofy.Models;
using Xunit;
using static Videofy.Models.Cart;

namespace VideofyUnitTestProject
{
    public class UnitTest1
    {
        //test Cart class
        [Fact]
        public void AddLine()
        {
            //Arrange 
            //Create some test movice
            Movie movie1 = new Movie
            {
                Id = 1,
                Title = "My Life",
                ReleaseDate = DateTime.Parse("1991-1-18"),
                Genre = "Comedy",
                Price = 7.99M
            };
            Movie movice2 = new Movie
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                ReleaseDate = DateTime.Parse("1994-3-13"),
                Genre = "Drama",
                Price = 8.99M
            };
            //create a cart
            Cart target = new Cart();

            //Act
            target.AddItem(movie1, 1);
            target.AddItem(movice2, 2);
            CartLine[] result = target.Lines.ToArray();
        }

        //if increase item quantity
        [Fact]
        public void AddQuantity()
        {
            //Arrange 
            //Create some test movice
            Movie movie1 = new Movie
            {
                Id = 1,
                Title = "My Life",
                ReleaseDate = DateTime.Parse("1991-1-18"),
                Genre = "Comedy",
                Price = 7.99M
            };
            Movie movice2 = new Movie
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                ReleaseDate = DateTime.Parse("1994-3-13"),
                Genre = "Drama",
                Price = 8.99M
            };
            //create a cart
            Cart target = new Cart();

            //Act
            target.AddItem(movie1, 1);
            target.AddItem(movice2, 1);
            target.AddItem(movie1, 9);
            CartLine[] results = target.Lines.OrderBy(c => c.Movie.Id).ToArray();
        }


        //remove item from the cart
        [Fact]
        public void RemoveLine()
        {
            Movie movie1 = new Movie
            {
                Id = 1,
                Title = "My Life",
                ReleaseDate = DateTime.Parse("1991-1-18"),
                Genre = "Comedy",
                Price = 7.99M
            };
            Movie movice2 = new Movie
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                ReleaseDate = DateTime.Parse("1994-3-13"),
                Genre = "Drama",
                Price = 8.99M
            };
            Movie movie3 = new Movie
            {
                Title = "The GodFather",
                ReleaseDate = DateTime.Parse("1991-4-16"),
                Genre = "Crime",
                Price = 9.99M
            };
            //create a cart
            Cart target = new Cart();
            //add some item to the cart
            target.AddItem(movie1, 1);
            target.AddItem(movice2, 2);
            target.AddItem(movie3, 4);
            target.AddItem(movice2, 1);

            //act
            target.RemoveLine(movice2);
            //Assert
            Assert.Equal(0, target.Lines.Where(c => c.Movie == movice2).Count());
            Assert.Equal(2, target.Lines.Count());
        }

        //calculate the total cost
        [Fact]
        public void CartTotal()
        {
            Movie movie1 = new Movie
            {
                Id = 1,
                Title = "My Life",
                ReleaseDate = DateTime.Parse("1991-1-18"),
                Genre = "Comedy",
                Price = 7.99M
            };
            Movie movice2 = new Movie
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                ReleaseDate = DateTime.Parse("1994-3-13"),
                Genre = "Drama",
                Price = 8.99M
            };
            //create a cart
            Cart target = new Cart();

            //Act
            target.AddItem(movie1, 1);
            target.AddItem(movice2, 1);
            target.AddItem(movie1, 3);
            decimal results = target.TotalValue();
            //Assert
            Assert.Equal(40.95M, results);
        }

        //properly removed when reset
        [Fact]
        public void ClearContent()
        {
            Movie movie1 = new Movie
            {
                Id = 1,
                Title = "My Life",
                ReleaseDate = DateTime.Parse("1991-1-18"),
                Genre = "Comedy",
                Price = 7.99M
            };
            Movie movice2 = new Movie
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                ReleaseDate = DateTime.Parse("1994-3-13"),
                Genre = "Drama",
                Price = 8.99M
            };
            //create a cart
            Cart target = new Cart();

            //Act
            target.AddItem(movie1, 1);
            target.AddItem(movice2, 1);
            //Act 
            //Reset the cart
            target.Clear();
            //Assert
            Assert.Equal(0, target.Lines.Count());
        }

        //test Movie database
        [Fact]
        public void MovieUnitTest()
        {
            //Arrange
            MovieUnitTestController controller = new MovieUnitTestController();
            //Act
            IActionResult result = controller.Index() as IActionResult;
            //Assert
            Assert.NotNull(result);
        }

    }
}
