using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Web.Mvc;
using Videofy.Controllers;
using Videofy.Data;
using Videofy.Models;
using Videofy.Models.Interface;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        //
        // Home /// 
        //

        [Fact]
        public void Home()
        {
            //Arrange           
            var mockRepo = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockRepo.Object);
            //Act
            IActionResult result = controller.Index();
            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
           //Assert.IsAssignableFrom<IEquatable<ErrorViewModel>>(result);          
        }


        //
        //Movie ///
        //

        [Fact]
        public void Movie()
        {
            //Arrange
            var mockRepo = new Mock<MvcMovieContext>();
            var controller = new MoviesController(mockRepo.Object);
            //Act
            IActionResult result = controller.Create();
            //Assert
            Assert.NotNull(result);
        }

        //
        // Account ///
        //
        [Fact]
        public void Account()
        {
            //Arrange
            var mockRepo = new Mock<UserManager<IdentityUser>>();
            var mock = new Mock<SignInManager<IdentityUser>>();
            //Act
            var controller = new AccountController(mockRepo.Object, mock.Object);
            IActionResult result = controller.Register();
            Assert.NotNull(result);
        }



        //
        //// Order ///
        //

        [Fact]
        public void Order()
        {
            //Arrange
            var mockRepo = new Mock<IOrderRepository>();
            var mock = new Mock<ShoppingCart>();
            var controller = new OrderController(mockRepo.Object, mock.Object);
            //Act
            IActionResult result = controller.Checkout();
            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

 
     

        //
        // Shoppint Cart ///
        //

        //add item to the shopping cart
        [Fact]
        public void ShoppingCart()
        {
            //Arrange - create the mock repository
            var mockRepo = new Mock<ShoppingCart>();
            var mock = new Mock<MvcMovieContext>();
            var controller = new ShoppingCartController(mockRepo.Object, mock.Object);
            IActionResult result = controller.Index();
            Assert.IsAssignableFrom<IActionResult>(result);

            
        }





    }
}
