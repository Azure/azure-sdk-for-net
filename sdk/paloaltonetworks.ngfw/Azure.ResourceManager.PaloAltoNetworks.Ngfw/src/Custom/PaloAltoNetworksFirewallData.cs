// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    public partial class PaloAltoNetworksFirewallData
    {
        /// <summary> Initializes a new instance of <see cref="PaloAltoNetworksFirewallData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="networkProfile"> Network settings. </param>
        /// <param name="dnsSettings"> DNS settings for Firewall. </param>
        /// <param name="planData"> Billing plan information. </param>
        /// <param name="marketplaceDetails"> Marketplace details. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="networkProfile"/>, <paramref name="dnsSettings"/>, <paramref name="planData"/> or <paramref name="marketplaceDetails"/> is null. </exception>
        public PaloAltoNetworksFirewallData(AzureLocation location, FirewallNetworkProfile networkProfile, FirewallDnsSettings dnsSettings, FirewallBillingPlanInfo planData, PanFirewallMarketplaceDetails marketplaceDetails) : base(location)
        {
            Argument.AssertNotNull(networkProfile, nameof(networkProfile));
            Argument.AssertNotNull(dnsSettings, nameof(dnsSettings));
            Argument.AssertNotNull(planData, nameof(planData));
            Argument.AssertNotNull(marketplaceDetails, nameof(marketplaceDetails));

            NetworkProfile = networkProfile;
            DnsSettings = dnsSettings;
            PlanData = planData;
            MarketplaceDetails = marketplaceDetails;
        }
    }
}
