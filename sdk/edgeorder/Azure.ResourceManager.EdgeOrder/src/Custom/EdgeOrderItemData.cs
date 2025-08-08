// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EdgeOrder
{
    public partial class EdgeOrderItemData
    {
        /// <summary> Initializes a new instance of <see cref="EdgeOrderItemData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="orderItemDetails"> Represents order item details. </param>
        /// <param name="addressDetails"> Represents shipping and return address for order item. </param>
        /// <param name="orderId"> Id of the order to which order item belongs to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="orderItemDetails"/>, <paramref name="addressDetails"/> or <paramref name="orderId"/> is null. </exception>
        public EdgeOrderItemData(AzureLocation location, EdgeOrderItemDetails orderItemDetails, EdgeOrderItemAddressDetails addressDetails, ResourceIdentifier orderId) : base(location)
        {
            Argument.AssertNotNull(orderItemDetails, nameof(orderItemDetails));
            Argument.AssertNotNull(addressDetails, nameof(addressDetails));
            Argument.AssertNotNull(orderId, nameof(orderId));

            OrderItemDetails = orderItemDetails;
            AddressDetails = addressDetails;
            OrderId = orderId;
        }
    }
}
