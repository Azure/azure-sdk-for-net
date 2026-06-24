// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the PublicIPDdosProtectionStatusResult type. </summary>
    public partial class PublicIPDdosProtectionStatusResult
    {
        /// <summary> Public IP ARM resource ID. </summary>
        [WirePath("publicIpAddressId")]
        public ResourceIdentifier PublicIPAddressId => PublicIpAddressId;
    }
}
