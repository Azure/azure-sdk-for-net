// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    public static partial class ArmEdgeOrderModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.EdgeOrderItemDetails"/>. </summary>
        /// <param name="productDetails"> Unique identifier for configuration. </param>
        /// <param name="orderItemType"> Order item type. </param>
        /// <param name="currentStage"> Current Order item Status. </param>
        /// <param name="orderItemStageHistory"> Order item status history. </param>
        /// <param name="preferences"> Customer notification Preferences. </param>
        /// <param name="forwardShippingDetails"> Forward Package Shipping details. </param>
        /// <param name="reverseShippingDetails"> Reverse Package Shipping details. </param>
        /// <param name="notificationEmailList"> Additional notification email list. </param>
        /// <param name="cancellationReason"> Cancellation reason. </param>
        /// <param name="cancellationStatus"> Describes whether the order item is cancellable or not. </param>
        /// <param name="deletionStatus"> Describes whether the order item is deletable or not. </param>
        /// <param name="returnReason"> Return reason. </param>
        /// <param name="returnStatus"> Describes whether the order item is returnable or not. </param>
        /// <param name="firstOrDefaultManagementResourceProviderNamespace"> Parent RP details - this returns only the first or default parent RP from the entire list. </param>
        /// <param name="managementRPDetailsList"> List of parent RP details supported for configuration. </param>
        /// <param name="error"> Top level error for the job. </param>
        /// <returns> A new <see cref="Models.EdgeOrderItemDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EdgeOrderItemDetails EdgeOrderItemDetails(ProductDetails productDetails = null, OrderItemType orderItemType = default, EdgeOrderStageDetails currentStage = null, IEnumerable<EdgeOrderStageDetails> orderItemStageHistory = null, OrderItemPreferences preferences = null, ForwardShippingDetails forwardShippingDetails = null, ReverseShippingDetails reverseShippingDetails = null, IEnumerable<string> notificationEmailList = null, string cancellationReason = null, OrderItemCancellationStatus? cancellationStatus = null, EdgeOrderActionStatus? deletionStatus = null, string returnReason = null, OrderItemReturnStatus? returnStatus = null, string firstOrDefaultManagementResourceProviderNamespace = null, IEnumerable<ResourceProviderDetails> managementRPDetailsList = null, ResponseError error = null)
        {
            orderItemStageHistory ??= new List<EdgeOrderStageDetails>();
            notificationEmailList ??= new List<string>();
            managementRPDetailsList ??= new List<ResourceProviderDetails>();

            return new EdgeOrderItemDetails(
                productDetails,
                orderItemType,
                null,
                null,
                currentStage,
                orderItemStageHistory?.ToList(),
                preferences,
                forwardShippingDetails,
                reverseShippingDetails,
                notificationEmailList?.ToList(),
                cancellationReason,
                cancellationStatus,
                deletionStatus,
                returnReason,
                returnStatus,
                managementRPDetailsList?.ToList(),
                error,
                serializedAdditionalRawData: null);
        }
    }
}
