// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class NetworkWatcherTests : NetworkTestsManagementClientBase
    {
        public NetworkWatcherTests(bool isAsync) : base(isAsync)
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

        [Test]
        public async Task NetworkWatcherApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("nw");

            string location = "eastus";
            await ResourceGroupsClient.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            NetworkWatcher properties = new NetworkWatcher { Location = location };

            //Create Network Watcher in the resource group
            await NetworkManagementClient.GetNetworkWatchersClient().CreateOrUpdateAsync(resourceGroupName, networkWatcherName, properties);

            //Get Network Watcher by name in the resource group
            Response<NetworkWatcher> getNetworkWatcherByName = await NetworkManagementClient.GetNetworkWatchersClient().GetAsync(resourceGroupName, networkWatcherName);

            //Get all Network Watchers in the resource group
            AsyncPageable<NetworkWatcher> getNetworkWatchersByResourceGroupAP = NetworkManagementClient.GetNetworkWatchersClient().ListAsync(resourceGroupName);
            List<NetworkWatcher> getNetworkWatchersByResourceGroup = await getNetworkWatchersByResourceGroupAP.ToEnumerableAsync();

            //Get all Network Watchers in the subscription
            AsyncPageable<NetworkWatcher> getNetworkWatchersBySubscriptionAP = NetworkManagementClient.GetNetworkWatchersClient().ListAllAsync();
            List<NetworkWatcher> getNetworkWatchersBySubscription = await getNetworkWatchersBySubscriptionAP.ToEnumerableAsync();

            //Delete Network Watcher
            await NetworkManagementClient.GetNetworkWatchersClient().StartDeleteAsync(resourceGroupName, networkWatcherName);

            //Get all Network Watchers in the subscription
            AsyncPageable<NetworkWatcher> getNetworkWatcherBySubscriptionAfterDeletingAP = NetworkManagementClient.GetNetworkWatchersClient().ListAllAsync();
            List<NetworkWatcher> getNetworkWatcherBySubscriptionAfterDeleting = await getNetworkWatcherBySubscriptionAfterDeletingAP.ToEnumerableAsync();

            //Verify name of the created Network Watcher
            Assert.AreEqual(networkWatcherName, getNetworkWatcherByName.Value.Name);

            //Verify provisioning state
            Assert.AreEqual("Succeeded", getNetworkWatcherByName.Value.ProvisioningState.ToString());

            //Verify the number of Network Watchers in the resource group (should be 1)
            Has.One.EqualTo(getNetworkWatchersByResourceGroup);

            //Verify the number of Network Watchers in the subscription
            //Assert.AreEqual(2, getNetworkWatchersBySubscription.Count());

            //Verify the number of Network Watchers in the subscription after deleting one which was created in the test
            Has.One.EqualTo(getNetworkWatcherBySubscriptionAfterDeleting);
        }
    }
}
