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

namespace Azure.ResourceManager.Network.Tests
{
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/24577")]
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

            List<NetworkWatcher> allWatchers = await ArmClient.DefaultSubscription.GetNetworkWatchersAsync().ToEnumerableAsync();
            foreach (var w in allWatchers)
            {
                if (w.Data.Location == TestEnvironment.Location)
                {
                    await w.DeleteAsync();
                }
            }
        }

        private async Task<NetworkWatcherContainer> GetContainer()
        {
            var resourceGroup = await CreateResourceGroup(Recording.GenerateAssetName("nw"));
            return resourceGroup.GetNetworkWatchers();
        }

        [Test]
        [RecordedTest]
        public async Task NetworkWatcherApiTest()
        {
            List<NetworkWatcher> allWatchers = await ArmClient.DefaultSubscription.GetNetworkWatchersAsync().ToEnumerableAsync();
            int countBeforeTest = allWatchers.Count;

            string networkWatcherName = Recording.GenerateAssetName("azsmnet");

            //Create Network Watcher in the resource group
            var networkWatcherContainer = await GetContainer();
            var location = TestEnvironment.Location;
            var properties = new NetworkWatcherData { Location = location };
            var createResponse = await networkWatcherContainer.CreateOrUpdateAsync(networkWatcherName, properties);
            Assert.AreEqual(networkWatcherName, createResponse.Value.Data.Name);
            Assert.AreEqual(location, createResponse.Value.Data.Location);
            Assert.IsEmpty(createResponse.Value.Data.Tags);

            //Get Network Watcher by name in the resource group
            Response<NetworkWatcher> getResponse = await networkWatcherContainer.GetAsync(networkWatcherName);
            Assert.AreEqual(location, getResponse.Value.Data.Location);
            Assert.AreEqual(networkWatcherName, getResponse.Value.Data.Name);
            Assert.AreEqual("Succeeded", getResponse.Value.Data.ProvisioningState.ToString());
            Assert.IsEmpty(getResponse.Value.Data.Tags);

            properties.Tags.Add("test", "test");
            var updateResponse = await networkWatcherContainer.CreateOrUpdateAsync(networkWatcherName, properties);
            Assert.AreEqual(networkWatcherName, updateResponse.Value.Data.Name);
            Assert.AreEqual(location, updateResponse.Value.Data.Location);
            Has.One.Equals(updateResponse.Value.Data.Tags);
            Assert.That(updateResponse.Value.Data.Tags, Does.ContainKey("test").WithValue("test"));

            //Get all Network Watchers in the resource group
            List<NetworkWatcher> listResponse = await networkWatcherContainer.GetAllAsync().ToEnumerableAsync();
            Has.One.EqualTo(listResponse);
            Assert.AreEqual(networkWatcherName, listResponse[0].Data.Name);
            Assert.AreEqual(location, listResponse[0].Data.Location);
            Has.One.Equals(listResponse[0].Data.Tags);
            Assert.That(listResponse[0].Data.Tags, Does.ContainKey("test").WithValue("test"));

            //Get all Network Watchers in the subscription
            List<NetworkWatcher> listAllResponse = await ArmClient.DefaultSubscription.GetNetworkWatchersAsync().ToEnumerableAsync();
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
            await getResponse.Value.DeleteAsync();

            //Get all Network Watchers in the subscription
            List<NetworkWatcher> listAllAfterDeletingResponse = await ArmClient.DefaultSubscription.GetNetworkWatchersAsync().ToEnumerableAsync();
            Assert.AreEqual(countBeforeTest, listAllAfterDeletingResponse.Count);
            Assert.False(listAllAfterDeletingResponse.Any(w => w.Data.Name == networkWatcherName));
        }
    }
}
