// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> The SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions. </summary>
    public partial class SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions
    {
        /// <summary> Initializes a new instance of <see cref="SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions"/>. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="offer"/> or <paramref name="skus"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions(AzureLocation location, string publisherName, string offer, string skus, GetVirtualMachineImagesWithPropertiesExpand expand)
        {
            Argument.AssertNotNull(publisherName, nameof(publisherName));
            Argument.AssertNotNull(offer, nameof(offer));
            Argument.AssertNotNull(skus, nameof(skus));

            Location = location;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
            ExpandOption = expand.ToString();
        }

        public GetVirtualMachineImagesWithPropertiesExpand Expand => ExpandOption != null ? new GetVirtualMachineImagesWithPropertiesExpand(ExpandOption) : default;
    }
}
