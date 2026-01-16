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
            Assert.That(createResponse.Value.Data.Name, Is.EqualTo(networkWatcherName));
            Assert.That(createResponse.Value.Data.Location.ToString(), Is.EqualTo(location));
            Assert.That(createResponse.Value.Data.Tags, Is.Empty);

            //Get Network Watcher by name in the resource group
            Response<NetworkWatcherResource> getResponse = await networkWatcherCollection.GetAsync(networkWatcherName);
            Assert.That(getResponse.Value.Data.Location.ToString(), Is.EqualTo(location));
            Assert.That(getResponse.Value.Data.Name, Is.EqualTo(networkWatcherName));
            Assert.That(getResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(getResponse.Value.Data.Tags, Is.Empty);

            properties.Tags.Add("test", "test");
            var updateResponse = await networkWatcherCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkWatcherName, properties);
            Assert.That(updateResponse.Value.Data.Name, Is.EqualTo(networkWatcherName));
            Assert.That(updateResponse.Value.Data.Location.ToString(), Is.EqualTo(location));
            Has.One.Equals(updateResponse.Value.Data.Tags);
            Assert.That(updateResponse.Value.Data.Tags, Does.ContainKey("test").WithValue("test"));

            //Get all Network Watchers in the resource group
            List<NetworkWatcherResource> listResponse = await networkWatcherCollection.GetAllAsync().ToEnumerableAsync();
            Has.One.EqualTo(listResponse);
            Assert.That(listResponse[0].Data.Name, Is.EqualTo(networkWatcherName));
            Assert.That(listResponse[0].Data.Location.ToString(), Is.EqualTo(location));
            Has.One.Equals(listResponse[0].Data.Tags);
            Assert.That(listResponse[0].Data.Tags, Does.ContainKey("test").WithValue("test"));

            //Get all Network Watchers in the subscription
            List<NetworkWatcherResource> listAllResponse = await subscription.GetNetworkWatchersAsync().ToEnumerableAsync();
            Assert.That(listAllResponse, Is.Not.Empty);
            Assert.That(listAllResponse.Any(w => networkWatcherName == w.Data.Name), Is.True);

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
            Assert.That(listAllAfterDeletingResponse.Count, Is.EqualTo(countBeforeTest));
            Assert.That(listAllAfterDeletingResponse.Any(w => w.Data.Name == networkWatcherName), Is.False);
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
            Assert.That(connectivityResult.Value.NetworkConnectionStatus, Is.Not.Null);
            Assert.That(connectivityResult.Value.Hops.First().Links.First().ResourceId, Is.Null);
        }
    }
}
