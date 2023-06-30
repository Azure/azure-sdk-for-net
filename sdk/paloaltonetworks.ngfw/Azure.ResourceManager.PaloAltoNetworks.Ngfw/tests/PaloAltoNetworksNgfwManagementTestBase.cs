// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Tests
{
    public class PaloAltoNetworksNgfwManagementTestBase : ManagementRecordedTestBase<PaloAltoNetworksNgfwManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected AzureLocation Location { get; set; }
        protected string ResourceGroupPrefix { get; set; }

        protected PaloAltoNetworksNgfwManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected PaloAltoNetworksNgfwManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Location = AzureLocation.EastUS2;
            ResourceGroupPrefix = "dotnetSdkTest-";
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }

            if (rgNamePrefix == null)
            {
                throw new ArgumentNullException(nameof(rgNamePrefix));
            }
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<FirewallResource> CreateDefaultFirewallResource(ResourceGroupResource resourceGroup, AzureLocation location, string firewallName)
        {
            IEnumerable<IPAddress> ipAddresses = new IPAddress[] { new IPAddress("/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.Network/publicIPAddresses/dotnetSdkTest-public-ip-default", "20.22.147.20") };

            VnetConfiguration vnetConfiguration = new VnetConfiguration(
                new IPAddressSpace("/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.Network/virtualNetworks/dotnetsSdkTest-vnet-default", "10.162.0.0/16"),
                new IPAddressSpace("/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.Network/virtualNetworks/dotnetsSdkTest-vnet-default/subnets/subnet1", "10.162.1.0/26"),
                new IPAddressSpace("/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.Network/virtualNetworks/dotnetsSdkTest-vnet-default/subnets/subnet2", "10.162.0.0/26"));
            NetworkProfile np = new NetworkProfile(NetworkType.Vnet, ipAddresses, EgressNat.Disabled);
            np.VnetConfiguration = vnetConfiguration;

            DnsSettings dnsSettings = new DnsSettings();
            dnsSettings.EnableDnsProxy = DnsProxy.Disabled;
            dnsSettings.EnabledDnsType = EnabledDnsType.Custom;

            PlanData planData = new PlanData(BillingCycle.Monthly, "cloud-ngfw-payg-test");
            MarketplaceDetails mpDetails = new MarketplaceDetails("pan_swfw_cloud_ngfw", "paloaltonetworks");
            FirewallResourceData data = new FirewallResourceData(location, np, dnsSettings,  planData, mpDetails);
            data.AssociatedRulestack = new RulestackDetails("/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/PaloAltoNetworks.Cloudngfw/localRulestacks/dotnetSdkTest-lrs-default", "", AzureLocation.EastUS2);
            var lro = await resourceGroup.GetFirewallResources().CreateOrUpdateAsync(WaitUntil.Completed, firewallName, data);
            return lro.Value;
        }
    }
}
