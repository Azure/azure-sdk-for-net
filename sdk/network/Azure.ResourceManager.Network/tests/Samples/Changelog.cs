// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Changelog_NewCode
            using System;
            using Azure.Identity;
            using Azure.ResourceManager.Network.Models;
            using Azure.ResourceManager.Resources;
            using Azure.ResourceManager.Resources.Models;

#if !SNIPPET
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Samples
{
    public class Changelog
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task NewCode()
        {
#endif
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync("abc");
            VirtualNetworkCollection virtualNetworkContainer = resourceGroup.GetVirtualNetworks();

            // Create VNet
            VirtualNetworkData vnet = new VirtualNetworkData()
            {
                Location = "westus",
            };
            vnet.AddressSpace.AddressPrefixes.Add("10.0.0.0/16");
            vnet.Subnets.Add(new SubnetData
            {
                Name = "mySubnet",
                AddressPrefix = "10.0.0.0/24",
            });

            ArmOperation<VirtualNetworkResource> vnetOperation = await virtualNetworkContainer.CreateOrUpdateAsync(WaitUntil.Completed, "_vent", vnet);
            VirtualNetworkResource virtualNetwork = vnetOperation.Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateModel()
        {
            #region Snippet:Changelog_CreateModel
            IPsecPolicy policy = new IPsecPolicy(
               300,
               1024,
               IPsecEncryption.AES128,
               IPsecIntegrity.SHA256,
               IkeEncryption.AES192,
               IkeIntegrity.SHA1,
               DhGroup.DHGroup2,
               PfsGroup.PFS1);
            #endregion
        }
    }
}
