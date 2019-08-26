using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Network.Tests.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class NetworkWatcherTests
    {
        [Fact(Skip="Disable tests")]
        public void NetworkWatcherApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = "eastus";

                string resourceGroupName = TestUtilities.GenerateName("nw");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher();

                properties.Location = location;
                //Create Network Watcher in the resource group
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                //Get Network Watcher by name in the resource group
                var getNetworkWatcherByName = networkManagementClient.NetworkWatchers.Get(resourceGroupName, networkWatcherName);

                //Get all Network Watchers in the resource group
                var getNetworkWatchersByResourceGroup = networkManagementClient.NetworkWatchers.List(resourceGroupName);

                //Get all Network Watchers in the subscription
                var getNetworkWatchersBySubscription = networkManagementClient.NetworkWatchers.ListAll();

                //Delete Network Watcher
                networkManagementClient.NetworkWatchers.Delete(resourceGroupName, networkWatcherName);

                //Get all Network Watchers in the subscription
                var getNetworkWatcherBySubscriptionAfterDeleting = networkManagementClient.NetworkWatchers.ListAll();

                //Verify name of the created Network Watcher
                Assert.Equal(networkWatcherName, getNetworkWatcherByName.Name);

                //Verify provisioning state
                Assert.Equal("Succeeded", getNetworkWatcherByName.ProvisioningState);

                //Verify the number of Network Watchers in the resource group (should be 1)
                Assert.Single(getNetworkWatchersByResourceGroup);

                //Verify the number of Network Watchers in the subscription
                Assert.Equal(2, getNetworkWatchersBySubscription.Count());

                //Verify the number of Network Watchers in the subscription after deleting one which was created in the test
                Assert.Single(getNetworkWatcherBySubscriptionAfterDeleting);
            }
        }
    }
}

