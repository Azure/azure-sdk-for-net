using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System;
using Xunit;
using Xunit.Abstractions;

namespace DataBoxEdge.Tests
{
    /// <summary>
    /// Contains the tests for order APIs
    /// </summary>
    public class OrderTests : DataBoxEdgeTestBase
    {
        #region Constructor
        /// <summary>
        ///Creates an instance to test order API
        /// </summary>
        public OrderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests order create, update, get, list and delete APIs
        /// </summary>
        [Fact]
        public void Test_DeviceOrders()
        {
            var resourceName = TestConstants.EdgeResourceName;

            Order order = TestUtilities.GetOrderObject();
            bool exceptionThrown = false;

            try
            {
                // Create an order
                Client.Orders.CreateOrUpdate(resourceName, order, TestConstants.DefaultResourceGroupName);
            }
            catch (CloudException ex)
            {
                if (ex.Message.Contains("Create or Update order is not supported"))
                {
                    exceptionThrown = true;
                }
            }
            Assert.True(exceptionThrown);

            exceptionThrown = false;
            try
            {
                // Get an order
                Client.Orders.Get(resourceName, TestConstants.DefaultResourceGroupName);
            }
            catch (CloudException ex)
            {
                if (ex.Message.Contains("Could not find the entity default"))
                {
                    Console.WriteLine(ex.Message);
                    exceptionThrown = true;
                }
            }
            Assert.True(exceptionThrown);



            // List all orders in the device (We support only one order for now)
            string continuationToken = null;
            TestUtilities.ListOrders(Client, TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, out continuationToken);

            // Delete an order
            Client.Orders.Delete(resourceName, TestConstants.DefaultResourceGroupName);
        }
        #endregion  Test Methods

    }
}

