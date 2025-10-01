// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> PrivateIpAddress resource properties. </summary>
    public partial class PrivateIPAddressResult
    {
        /// <summary> PrivateIpAddresses Id. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(PrivateIPAddressesOcid); }
        /// <summary> PrivateIpAddresses subnetId. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier SubnetId { get => new ResourceIdentifier(SubnetOcid); }
    }
}
