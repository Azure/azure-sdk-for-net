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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions(AzureLocation location, string publisherName, string offer, string skus, GetVirtualMachineImagesWithPropertiesExpand expand)
        {
            Argument.AssertNotNull(publisherName, nameof(publisherName));
            Argument.AssertNotNull(offer, nameof(offer));
            Argument.AssertNotNull(skus, nameof(skus));
            Argument.AssertNotNull(expand, nameof(expand));

            string expandValue = expand.ToString();

            Location = location;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
            Expand = expandValue;
        }
    }
}
