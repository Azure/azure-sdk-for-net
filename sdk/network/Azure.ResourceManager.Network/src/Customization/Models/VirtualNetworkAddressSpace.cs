// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class VirtualNetworkAddressSpace
    {
        // Released flattened factories pass null for collections added in newer API versions.
        internal VirtualNetworkAddressSpace(
            IList<string> addressPrefixes,
            IList<IpamPoolPrefixAllocation> ipamPoolPrefixAllocations,
            IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            AddressPrefixes = addressPrefixes ?? new ChangeTrackingList<string>();
            IpamPoolPrefixAllocations = ipamPoolPrefixAllocations ?? new ChangeTrackingList<IpamPoolPrefixAllocation>();
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
