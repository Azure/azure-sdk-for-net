// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class LoadBalancerFrontendIPConfiguration
    {
        /// <summary> Initializes a new instance of LoadBalancerFrontendIPConfiguration. </summary>
        /// <param name="name"> The name. </param>
        public LoadBalancerFrontendIPConfiguration(string name)
        {
            Name = name;
        }

        /// <summary> The name. </summary>
        public string Name { get; set; }

        /// <summary> The private IP address. </summary>
        public string PrivateIPAddress { get; set; }

        /// <summary> The public IP address ID. </summary>
        public ResourceIdentifier PublicIPAddressId { get; set; }

        /// <summary> The subnet ID. </summary>
        public ResourceIdentifier SubnetId { get; set; }
    }
}
