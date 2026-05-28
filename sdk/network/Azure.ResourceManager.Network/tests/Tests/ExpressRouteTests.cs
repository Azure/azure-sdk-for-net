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

namespace Azure.ResourceManager.Network.Tests
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
        [RecordedTest]
        public async Task BGPCommunityApiTest()
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            AsyncPageable<BgpServiceCommunity> communitiesAsync = subscription.GetBgpServiceCommunitiesAsync();
            List<BgpServiceCommunity> communities = await communitiesAsync.ToEnumerableAsync();
            Assert.IsNotEmpty(communities);
            Assert.That(communities.Any(c => c.BgpCommunities.Any(b => b.IsAuthorizedToUse.HasValue ? b.IsAuthorizedToUse.Value : false)));
        }

        [Test]
        [RecordedTest]
        [Ignore("Track2: The corresponding configuration is needed, and the account is missing the key configuration")]
        public async Task ExpressRouteMicrosoftPeeringApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = "westus";
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);

            string circuitName = "circuit";

            ExpressRouteCircuitResource circuit = await CreateDefaultExpressRouteCircuit(resourceGroup, circuitName, location);

            Assert.AreEqual(circuit.Data.Name, circuitName);
            Assert.AreEqual(circuit.Data.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));

            circuit = await UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(resourceGroup,circuitName);

            Assert.AreEqual(circuit.Data.Name, circuitName);
            Assert.AreEqual(circuit.Data.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));
            Assert.NotNull(circuit.Data.Peerings);
        }

        [Test]
        [RecordedTest]
        [Ignore("Track2: The corresponding configuration is needed, and the account is missing the key configuration")]
        public async Task ExpressRouteMicrosoftPeeringApiWithIpv6Test()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = "westus";
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);

            string circuitName = "circuit";

            ExpressRouteCircuitResource circuit = await CreateDefaultExpressRouteCircuit(resourceGroup, circuitName, location);

            Assert.AreEqual(circuit.Data.Name, circuitName);
            Assert.AreEqual(circuit.Data.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));

            circuit = await UpdateDefaultExpressRouteCircuitWithIpv6MicrosoftPeering(resourceGroup,
                circuitName);

            Assert.AreEqual(circuit.Data.Name, circuitName);
            Assert.AreEqual(circuit.Data.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));
            Assert.NotNull(circuit.Data.Peerings);
        }
    }
}
