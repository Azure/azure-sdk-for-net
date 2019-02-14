using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;

namespace EdgeGateway.Tests
{
    public class OrderTests : EdgeGatewayTestBase
    {
        #region Constructor
        public OrderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        [Fact]
        public void Test_DeviceOrders()
        {
            Order order = TestUtilities.GetOrderObject();
            // Create an order
            Client.Orders.CreateOrUpdate(TestConstants.EdgeResourceName, order, TestConstants.DefaultResourceGroupName);

            // Get an order
            Client.Orders.Get(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName);

            // List all orders in the device (We support only one order for now)
            string continuationToken = null;
            TestUtilities.ListOrders(Client, TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, out continuationToken);

            // Delete an order
            Client.Orders.Delete(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName);
        }
        #endregion  Test Methods

    }
}
