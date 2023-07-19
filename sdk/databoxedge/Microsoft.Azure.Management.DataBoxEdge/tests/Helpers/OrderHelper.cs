using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBoxEdge.Tests
{
    public static partial class TestUtilities
    {
        /// <summary>
        /// Gets an order object
        /// </summary>
        /// <returns>Order</returns>
        public static Order GetOrderObject()
        {
            ContactDetails contactDetails = new ContactDetails("John Mcclane", "Microsoft", "8004269400", new List<string>() { "example@microsoft.com" });

            //Address shippingAddress = new Address("Microsoft Corporation", "98052", "Redmond", "WA", "United States");
            var shippingAddress = new Address(
                    addressLine1: "38 Malibu St",
                    addressLine2: "101 Tusker",
                    addressLine3: "Bellandur",
                    city: "Bengaluru",
                    state: "Karnataka",
                    postalCode: "560103",
                    country: "India"
                );
            Order order = new Order(contactInformation: contactDetails, shippingAddress: shippingAddress);
            return order;
        }

        /// <summary>
        /// Gets storage account credentials in the device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns>List of order</returns>
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
