// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class LoadBalancerInboundNatPoolProperties
    {
        public IDictionary<string, BinaryData> AdditionalProperties { get; } = new ChangeTrackingDictionary<string, BinaryData>();
    }
}
