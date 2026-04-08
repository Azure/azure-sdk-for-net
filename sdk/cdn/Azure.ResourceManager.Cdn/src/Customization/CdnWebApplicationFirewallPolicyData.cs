// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Cdn.Models;

namespace Azure.ResourceManager.Cdn
{
    /// <summary> Defines web application firewall policy for Azure CDN. </summary>
    public partial class CdnWebApplicationFirewallPolicyData
    {
        /// <summary> Initializes a new instance of <see cref="CdnWebApplicationFirewallPolicyData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The pricing tier (defines a CDN provider, feature list and rate) of the CdnWebApplicationFirewallPolicy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public CdnWebApplicationFirewallPolicyData(AzureLocation location, CdnSku sku) : base(location)
        {
            Argument.AssertNotNull(sku, nameof(sku));

            Sku = sku;
        }
    }
}
