// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class ExpressRouteTests : NetworkTestsManagementClientBase
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

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
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

        public const string Filter_Commmunity = "12076:5010";
        public const string Filter_Access = "allow";
        public const string Filter_Type = "Community";

        public const string Peering_Microsoft = "MicrosoftPeering";

        [Test]
        public async Task BGPCommunityApiTest()
        {
            _ = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/routefilters");
            AsyncPageable<Models.BgpServiceCommunity> communitiesAsync = NetworkManagementClient.BgpServiceCommunities.ListAsync();
            Task<List<Models.BgpServiceCommunity>> communities = communitiesAsync.ToEnumerableAsync();
            Assert.NotNull(communities);
            Assert.True(communities.Result.First().BgpCommunities.First().IsAuthorizedToUse);
        }

        [Test]
        public async Task RouteFilterApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/routefilters");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create route filter
            string filterName = "filter";
            string ruleName = "rule";

            Models.RouteFilter filter = await CreateDefaultRouteFilter(resourceGroupName,
                filterName, location, NetworkManagementClient);

            Assert.AreEqual(filter.Name, filterName);
            Assert.IsEmpty(filter.Rules);

            // Update route filter with rule by put on parent resources
            filter = await CreateDefaultRouteFilter(resourceGroupName,
                filterName, location, NetworkManagementClient, true);

            Assert.AreEqual(filter.Name, filterName);
            Assert.IsNotEmpty(filter.Rules);

            // Update route filter and delete rules
            filter = await CreateDefaultRouteFilter(resourceGroupName,
               filterName, location, NetworkManagementClient);

            Assert.AreEqual(filter.Name, filterName);
            Assert.IsEmpty(filter.Rules);

            filter = await CreateDefaultRouteFilterRule(resourceGroupName,
                filterName, ruleName, location, NetworkManagementClient);

            Assert.AreEqual(filter.Name, filterName);
            Assert.IsNotEmpty(filter.Rules);
        }

        [Test]
        [Ignore("Track2: The corresponding configuration is needed, and the account is missing the key configuration")]
        public async Task ExpressRouteMicrosoftPeeringApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = "westus";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            string circuitName = "circuit";

            Models.ExpressRouteCircuit circuit = await CreateDefaultExpressRouteCircuit(resourceGroupName,
                circuitName, location, NetworkManagementClient);

            Assert.AreEqual(circuit.Name, circuitName);
            Assert.AreEqual(circuit.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));

            circuit = await UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(resourceGroupName,
                circuitName, NetworkManagementClient);

            Assert.AreEqual(circuit.Name, circuitName);
            Assert.AreEqual(circuit.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));
            Assert.NotNull(circuit.Peerings);
        }

        [Test]
        [Ignore("Track2: The corresponding configuration is needed, and the account is missing the key configuration")]
        public async Task ExpressRouteMicrosoftPeeringApiWithIpv6Test()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = "westus";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            string circuitName = "circuit";

            Models.ExpressRouteCircuit circuit = await CreateDefaultExpressRouteCircuit(resourceGroupName,
                circuitName, location, NetworkManagementClient);

            Assert.AreEqual(circuit.Name, circuitName);
            Assert.AreEqual(circuit.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));

            circuit = await UpdateDefaultExpressRouteCircuitWithIpv6MicrosoftPeering(resourceGroupName,
                circuitName, NetworkManagementClient);

            Assert.AreEqual(circuit.Name, circuitName);
            Assert.AreEqual(circuit.ServiceProviderProperties.BandwidthInMbps, Convert.ToInt32(Circuit_BW));
            Assert.NotNull(circuit.Peerings);
        }
    }
}
