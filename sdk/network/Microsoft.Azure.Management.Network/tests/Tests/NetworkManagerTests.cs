using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;

namespace Networks.Tests
{
    public class NetworkworkManagerTests
    {
        [Fact(Skip = "Disable tests")]
        public void NetworkManagerTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = "jioindiacentral";

                string resourceGroupName = TestUtilities.GenerateName("ANMRG");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                NetworkManagerPropertiesNetworkManagerScopes scope = new NetworkManagerPropertiesNetworkManagerScopes();
                string subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52";
                List<string> subList = new List<string>();
                subList.Add(subscriptionId);
                scope.Subscriptions = subList;

                IList<string> networkManagerScopeAccesses = new List<string>();
                networkManagerScopeAccesses.Add("SecurityAdmin");

                var networkManager = new NetworkManager()
                {
                    DisplayName = "SampleName",
                    Description = "Sample Description",
                    Location = location,
                    NetworkManagerScopes = scope,
                    NetworkManagerScopeAccesses = networkManagerScopeAccesses
                };

                string networkManagerName = TestUtilities.GenerateName();

                // Put networkManager
                var putNMResponse = networkManagementClient.NetworkManagers.CreateOrUpdate(networkManager, resourceGroupName, networkManagerName);
                Assert.Equal(networkManagerName, putNMResponse.Name);
                Assert.Equal("Succeeded", putNMResponse.ProvisioningState);

                // Get networkManager
                var getNMResponse = networkManagementClient.NetworkManagers.Get(resourceGroupName, networkManagerName);
                Assert.Equal(networkManagerName, getNMResponse.Name);
                Assert.Equal(location, getNMResponse.Location);

                // List networkManager
                var listNMResponse = networkManagementClient.NetworkManagers.List(resourceGroupName);
                Assert.Single(listNMResponse);
                Assert.Equal(networkManagerName, listNMResponse.First().Name);

                // Delete networkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);

                // List networkManager
                listNMResponse = networkManagementClient.NetworkManagers.List(resourceGroupName);
                Assert.Empty(listNMResponse);
            }
        }

    }
}
