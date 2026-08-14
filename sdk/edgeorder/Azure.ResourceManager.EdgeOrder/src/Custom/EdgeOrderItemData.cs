// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.EdgeOrder.Models;

namespace Azure.ResourceManager.EdgeOrder
{
    // Manually add to maintain its backward compatibility
    public partial class EdgeOrderItemData
    {
        /// <summary> Initializes a new instance of <see cref="EdgeOrderItemData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="orderItemDetails"> Represents order item details. </param>
        /// <param name="addressDetails"> Represents shipping and return address for order item. </param>
        /// <param name="orderId"> Id of the order to which order item belongs to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="orderItemDetails"/>, <paramref name="addressDetails"/> or <paramref name="orderId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EdgeOrderItemData(AzureLocation location, EdgeOrderItemDetails orderItemDetails, EdgeOrderItemAddressDetails addressDetails, ResourceIdentifier orderId) : this(location, orderItemDetails, orderId)
        {
            Argument.AssertNotNull(addressDetails, nameof(addressDetails));

            AddressDetails = addressDetails;
        }
    }
}
