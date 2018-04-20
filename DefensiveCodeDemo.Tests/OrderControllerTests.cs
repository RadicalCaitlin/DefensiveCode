using DefensiveCodeDemo.Contracts;
using DefensiveCodeDemo.Contracts.Repositories;
using DefensiveCodeDemo.Controllers;
using DefensiveCodeDemo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveCodeDemo.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void GetOrderTotalTestValid()
        {
            //-- Arrange
            OrderController orderController = new OrderController();
            decimal[] inventoryPrices = { 1.27m, 2.44m, 3.75m };
            int[] quantities = { 4, 9, 11 };
            decimal expected = 68.29m;

            //-- Act
            var orderTotal = orderController.GetOrderTotalUnitTestDemo(inventoryPrices, quantities);

            //-- Assert
            Assert.AreEqual(expected, orderTotal);
        }
    }
}
