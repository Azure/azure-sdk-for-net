// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class NetworkManagerRoutingTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;

        public NetworkManagerRoutingTests(bool isAsync, string apiVersion)
        : base(isAsync, SecurityRuleResource.ResourceType, apiVersion)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
            _subscription = await ArmClient.GetDefaultSubscriptionAsync();
        }

        [Test]
        [RecordedTest]
        public async Task RoutingCrudTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("testRG");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            NetworkManagerPropertiesNetworkManagerScopes scope = new NetworkManagerPropertiesNetworkManagerScopes();
            string subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52";
            scope.Subscriptions.Add(subscriptionId);

            var networkManager = new NetworkManagerData()
            {
                Location = location,
                NetworkManagerScopes = scope,
            };
            networkManager.NetworkManagerScopeAccesses.Add(NetworkConfigurationDeploymentType.Routing);

            string networkManagerName = Recording.GenerateAssetName("ANM");

            // Put networkManager
            var networkManagerCollection = resourceGroup.GetNetworkManagers();
            var putNMResponse = networkManagerCollection.CreateOrUpdate(WaitUntil.Completed, networkManagerName, networkManager);
            Assert.AreEqual(networkManagerName, putNMResponse.Value.Data.Name);
            Assert.AreEqual("Succeeded", putNMResponse.Value.Data.ProvisioningState);

            // Create NetworkGroup
            string groupName = Recording.GenerateAssetName("ANMNG");
            var networkManagerGroup = new NetworkGroupData();

            var nmResource = putNMResponse.Value;
            var ngCollection = nmResource.GetNetworkGroups();
            /*
            networkManagerGroupCollection = resourceGroup.GetNetworkMan
            // Put NetworkManagerGroup
            var networkGrCollection = resourceGroup.GetNetworkG();
            var putNMResponse = networkManagerCollection.CreateOrUpdate(WaitUntil.Completed, networkManagerName, networkManager);
            Assert.Equal(groupName, putNmGroupResponse.Name);
            Assert.Equal("Succeeded", putNmGroupResponse.ProvisioningState);
            */
        }
    }
}