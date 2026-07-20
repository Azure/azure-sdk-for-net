// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Cdn.Models;

namespace Azure.ResourceManager.Cdn
{
    // Customization: This file customizes the CdnWebApplicationFirewallPolicyData constructor to maintain backward API compatibility with the previous SDK.
    // Reason: The old SDK (AutoRest-generated) provided a constructor with the signature (AzureLocation, CdnSku), allowing users to pass a CdnSku object directly.
    // The TypeSpec generator no longer generates this signature (it uses CdnSkuName? and other spread parameters instead).
    // This constructor is manually preserved to avoid breaking user code that depends on the old constructor.

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
