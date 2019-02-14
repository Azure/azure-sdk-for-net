using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgeGateway.Tests
{
    public static partial class TestUtilities
    {
        public static Order GetOrderObject()
        {
            ContactDetails contact = new ContactDetails("John Mcclane", "Microsoft", "8004269400", new List<string>() { "john@microsoft.com" });
            Address shippingAddress = new Address("Microsoft Corporation", "98052", "Redmond", "WA", "USA");
            Order order = new Order(contact, shippingAddress);
            return order;
        }

        /// <summary>
        /// Gets storage account credentials in the device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<Order> ListOrders(
            DataBoxEdgeManagementClient client,
             string deviceName,
            string resourceGroupName,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<Order> orderList = client.Orders.ListByDataBoxEdgeDevice(deviceName, resourceGroupName);
            continuationToken = orderList.NextPageLink;
            return orderList;
        }

    }
}
