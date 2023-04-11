// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.DataBoxEdge.Models;

namespace Azure.ResourceManager.DataBoxEdge.Tests.Helpers
{
    public static class DataboxEdgeOrderHelper
    {
        // <summary>
        /// Gets an order object
        /// </summary>
        /// <returns>Order</returns>
        public static DataBoxEdgeOrderData GetOrderObject()
        {
            var contactDetails = new DataBoxEdgeContactDetails("John Mcclane", "Microsoft", "8004269400", new List<string>() { "example@microsoft.com" });

            var shippingAddress = new DataBoxEdgeShippingAddress("United States");
            OrderProperties orderProperties = new OrderProperties();
            orderProperties.ShippingAddress = shippingAddress;
            orderProperties.ContactInformation= contactDetails;
            DataBoxEdgeOrderData order = new DataBoxEdgeOrderData();
            order.Properties= orderProperties;
            return order;
        }
    }
}
