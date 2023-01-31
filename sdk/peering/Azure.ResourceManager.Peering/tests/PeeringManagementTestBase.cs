// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Peering.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Peering.Tests
{
    public class PeeringManagementTestBase : ManagementRecordedTestBase<PeeringManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected const string DefaultResourceGroupPrefix = "PeeringRG";
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;

        protected PeeringManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected PeeringManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            var subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(DefaultResourceGroupPrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<PeeringServiceResource> CreateAtmanPeeringService(ResourceGroupResource resourceGroup, string peeringServiceName)
        {
            PeeringServiceData data = new PeeringServiceData(resourceGroup.Data.Location)
            {
                PeeringServiceLocation = "South Australia",
                PeeringServiceProvider = "Atman",
                ProviderPrimaryPeeringLocation = "Warsaw",
            };
            var peeringservice = await resourceGroup.GetPeeringServices().CreateOrUpdateAsync(WaitUntil.Completed, peeringServiceName, data);
            return peeringservice.Value;
        }

        protected async Task<PeerAsnResource> CreatePeerAsn(string peerAsnName)
        {
            Random random = new Random();
            var subscription = await Client.GetDefaultSubscriptionAsync();
            var peerAsnCollection = subscription.GetPeerAsns();
            PeerAsnData data = new PeerAsnData()
            {
                PeerName = peerAsnName,
                PeerAsn = Recording.Random.Next(1, 94967295), // The value must be at most 4294967295.
                PeerContactDetail =
                {
                    new PeerAsnContactDetail()
                    {
                        Role = "Noc",
                        Email = "noc65003@contoso.com",
                        Phone = "8888988888"
                    }
                }
            };
            var peerAsn = await peerAsnCollection.CreateOrUpdateAsync(WaitUntil.Completed, peerAsnName, data);
            return peerAsn.Value;
        }
    }
}
