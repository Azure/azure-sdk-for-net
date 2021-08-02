// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class ExpressRouteTests : NetworkServiceClientTestBase
    {
        public ExpressRouteTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        //[TearDown]
        //public async Task CleanupResourceGroup()
        //{
        //    await CleanupResourceGroupsAsync();
        //}

        public const string MS_PrimaryPrefix = "199.168.200.0/30";
        public const string MS_SecondaryPrefix = "199.168.202.0/30";
        public const string MS_PeerASN = "1000";
        public const string MS_PublicPrefix = "12.2.3.4/30";

        public const string MS_PrimaryPrefix_V6 = "fc00::/126";
        public const string MS_SecondaryPrefix_V6 = "fc01::/126";
        public const string MS_PublicPrefix_V6 = "fc02::1/128";

        public const string Circuit_Provider = "bvtazureixp01";
        public const string Circuit_Location = "boydton 1 dc";
        public const string Circuit_BW = "200";
        public const string MS_VlanId = "400";

        public const string Peering_Microsoft = "MicrosoftPeering";

        [Test]
        public async Task BGPCommunityApiTest()
        {
            _ = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/routefilters");
            AsyncPageable<BgpServiceCommunity> communitiesAsync = ArmClient.DefaultSubscription.GetBgpServiceCommunitiesAsync();
            List<BgpServiceCommunity> communities = await communitiesAsync.ToEnumerableAsync();
            Assert.IsNotEmpty(communities);
            Assert.True(communities.First().BgpCommunities.First().IsAuthorizedToUse);
        }

        [Test]
        [Ignore("Track2: The corresponding configuration is needed, and the account is missing the key configuration")]
        public async Task ExpressRouteMicrosoftPeeringApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = "westus";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));

            string circuitName = "circuit";

            ExpressRouteCircuit circuit = await CreateDefaultExpressRouteCircuit(resourceGroupName,
                circuitName, location);

            Assert.AreEqual(circuit.Data.Name, circuitName);
            Assert.AreEqual(circuit.Data.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));

            circuit = await UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(resourceGroupName,
                circuitName);

            Assert.AreEqual(circuit.Data.Name, circuitName);
            Assert.AreEqual(circuit.Data.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));
            Assert.NotNull(circuit.Data.Peerings);
        }

        [Test]
        [Ignore("Track2: The corresponding configuration is needed, and the account is missing the key configuration")]
        public async Task ExpressRouteMicrosoftPeeringApiWithIpv6Test()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = "westus";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));

            string circuitName = "circuit";

            ExpressRouteCircuit circuit = await CreateDefaultExpressRouteCircuit(resourceGroupName,
                circuitName, location);

            Assert.AreEqual(circuit.Data.Name, circuitName);
            Assert.AreEqual(circuit.Data.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));

            circuit = await UpdateDefaultExpressRouteCircuitWithIpv6MicrosoftPeering(resourceGroupName,
                circuitName);

            Assert.AreEqual(circuit.Data.Name, circuitName);
            Assert.AreEqual(circuit.Data.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));
            Assert.NotNull(circuit.Data.Peerings);
        }
    }
}
