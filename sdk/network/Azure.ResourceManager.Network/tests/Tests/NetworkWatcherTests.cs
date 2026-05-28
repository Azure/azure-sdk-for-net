// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Network.Tests
{
    public class NetworkWatcherTests : NetworkServiceClientTestBase
    {
        public NetworkWatcherTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            List<NetworkWatcherResource> allWatchers = await subscription.GetNetworkWatchersAsync().ToEnumerableAsync();
            foreach (var w in allWatchers)
            {
                if (w.Data.Location == TestEnvironment.Location)
                {
                    await w.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        private async Task<NetworkWatcherCollection> GetCollection()
        {
            var resourceGroup = await CreateResourceGroup(Recording.GenerateAssetName("nw"));
            return resourceGroup.GetNetworkWatchers();
        }

        [Test]
        [RecordedTest]
        public async Task NetworkWatcherApiTest()
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            List<NetworkWatcherResource> allWatchers = await subscription.GetNetworkWatchersAsync().ToEnumerableAsync();
            int countBeforeTest = allWatchers.Count;

            string networkWatcherName = Recording.GenerateAssetName("azsmnet");

            //Create Network Watcher in the resource group
            var networkWatcherCollection = await GetCollection();
            var location = TestEnvironment.Location;
            var properties = new NetworkWatcherData { Location = location };
            var createResponse = await networkWatcherCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkWatcherName, properties);
            Assert.AreEqual(networkWatcherName, createResponse.Value.Data.Name);
            Assert.AreEqual(location, createResponse.Value.Data.Location.ToString());
            Assert.IsEmpty(createResponse.Value.Data.Tags);

            //Get Network Watcher by name in the resource group
            Response<NetworkWatcherResource> getResponse = await networkWatcherCollection.GetAsync(networkWatcherName);
            Assert.AreEqual(location, getResponse.Value.Data.Location.ToString());
            Assert.AreEqual(networkWatcherName, getResponse.Value.Data.Name);
            Assert.AreEqual("Succeeded", getResponse.Value.Data.ProvisioningState.ToString());
            Assert.IsEmpty(getResponse.Value.Data.Tags);

            properties.Tags.Add("test", "test");
            var updateResponse = await networkWatcherCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkWatcherName, properties);
            Assert.AreEqual(networkWatcherName, updateResponse.Value.Data.Name);
            Assert.AreEqual(location, updateResponse.Value.Data.Location.ToString());
            Has.One.Equals(updateResponse.Value.Data.Tags);
            Assert.That(updateResponse.Value.Data.Tags, Does.ContainKey("test").WithValue("test"));

            //Get all Network Watchers in the resource group
            List<NetworkWatcherResource> listResponse = await networkWatcherCollection.GetAllAsync().ToEnumerableAsync();
            Has.One.EqualTo(listResponse);
            Assert.AreEqual(networkWatcherName, listResponse[0].Data.Name);
            Assert.AreEqual(location, listResponse[0].Data.Location.ToString());
            Has.One.Equals(listResponse[0].Data.Tags);
            Assert.That(listResponse[0].Data.Tags, Does.ContainKey("test").WithValue("test"));

            //Get all Network Watchers in the subscription
            List<NetworkWatcherResource> listAllResponse = await subscription.GetNetworkWatchersAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(listAllResponse);
            Assert.True(listAllResponse.Any(w => networkWatcherName == w.Data.Name));

            // TODO: need to create cases
            //await getResponse.Value.GetTopologyAsync();
            //await getResponse.Value.VerifyIPFlowAsync();
            //await getResponse.Value.GetNextHopAsync();
            //await getResponse.Value.GetVMSecurityRulesAsync();
            //await getResponse.Value.GetTroubleshootingAsync();
            //await getResponse.Value.GetTroubleshootingResultAsync();
            //await getResponse.Value.SetFlowLogConfigurationAsync();
            //await getResponse.Value.GetFlowLogStatusAsync();
            //await getResponse.Value.CheckConnectivityAsync();
            //await getResponse.Value.GetAzureReachabilityReportAsync();
            //await getResponse.Value.GetAvailableProvidersAsync();
            //await getResponse.Value.GetNetworkConfigurationDiagnosticAsync();

            //Delete Network Watcher
            await getResponse.Value.DeleteAsync(WaitUntil.Completed);

            //Get all Network Watchers in the subscription
            List<NetworkWatcherResource> listAllAfterDeletingResponse = await subscription.GetNetworkWatchersAsync().ToEnumerableAsync();
            Assert.AreEqual(countBeforeTest, listAllAfterDeletingResponse.Count);
            Assert.False(listAllAfterDeletingResponse.Any(w => w.Data.Name == networkWatcherName));
        }

        [Test]
        [RecordedTest]
        public async Task NetworkWatcherCheckConnectivityTest()
        {
            var location = AzureLocation.EastUS2;

            string rgName = Recording.GenerateAssetName("networkRG");
            var resourceGroup = await CreateResourceGroup(rgName, location);

            // Create Network Watcher in the resource group
            string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            var properties = new NetworkWatcherData { Location = location };
            var networkWatcherLro = await resourceGroup.GetNetworkWatchers().CreateOrUpdateAsync(WaitUntil.Completed, networkWatcherName, properties);
            NetworkWatcherResource networkWatcher = networkWatcherLro.Value;

            // Create two VMs for test vm connectivity
            var vm1 = await CreateWindowsVM(Recording.GenerateAssetName("vm"), Recording.GenerateAssetName("nic"), location, resourceGroup);
            var vm2 = await CreateWindowsVM(Recording.GenerateAssetName("vm"), Recording.GenerateAssetName("nic"), location, resourceGroup);
            await deployWindowsNetworkAgent(vm1.Data.Name, location, resourceGroup);
            await deployWindowsNetworkAgent(vm2.Data.Name, location, resourceGroup);

            // Test connectivity
            ConnectivityContent content = new ConnectivityContent(
                new ConnectivitySource(vm1.Id),
                new ConnectivityDestination() { Port = 22, ResourceId = vm2.Id });
            var connectivityResult = await networkWatcher.CheckConnectivityAsync(WaitUntil.Completed, content);
            Assert.IsNotNull(connectivityResult.Value.NetworkConnectionStatus);
            Assert.IsNull(connectivityResult.Value.Hops.First().Links.First().ResourceId);
        }
    }
}
