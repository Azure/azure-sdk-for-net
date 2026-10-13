// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkVirtualApplianceData type. </summary>
    [CodeGenSuppress("InternetIngressPublicIPs")]
    public partial class NetworkVirtualApplianceData
    {
        /// <summary> Compatibility member. </summary>
        public IList<WritableSubResource> InternetIngressPublicIPs { get; } = new List<WritableSubResource>();
        // PrivateIPAddress is generated natively; preserve the separately deferred ingress collection.
    }
}
