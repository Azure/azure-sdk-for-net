// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the LoadBalancerInboundNatPoolProperties type. </summary>
    public partial class LoadBalancerInboundNatPoolProperties
    {
        /// <summary> Gets or sets the BinaryData compatibility property. </summary>
        public IDictionary<string, BinaryData> AdditionalProperties { get; } = new ChangeTrackingDictionary<string, BinaryData>();
    }
}
