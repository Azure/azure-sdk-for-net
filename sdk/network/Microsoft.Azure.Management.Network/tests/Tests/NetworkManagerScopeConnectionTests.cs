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
using System;
using System.Threading;

namespace Networks.Tests
{
    public class NetworkManagerScopeConnectionTests
    {
        [Fact(Skip = "Disable tests")]
        public void NetworkManagerScopeConnectionTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkManagers");
                var location = "eastus2euap";

                string resourceGroupName = TestUtilities.GenerateName("ANMScopeConn");
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

                IList<string> networkManagerScopeAccess = new List<string>();
                networkManagerScopeAccess.Add("Connectivity");

                var networkManager = new NetworkManager()
                {
                    Location = location,
                    NetworkManagerScopes = scope,
                    NetworkManagerScopeAccesses = networkManagerScopeAccess
                };

                string networkManagerName = TestUtilities.GenerateName("ANMScopeConn");

                // Put networkManager
                var putNMResponse = networkManagementClient.NetworkManagers.CreateOrUpdate(networkManager, resourceGroupName, networkManagerName);
                Assert.Equal(networkManagerName, putNMResponse.Name);
                Assert.Equal("Succeeded", putNMResponse.ProvisioningState);

                var crossTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
                var crossTenantResourceId = "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359";

                // Put Scope Connection
                var scopeConnection = new ScopeConnection()
                {
                    TenantId = crossTenantId,
                    ResourceId = crossTenantResourceId
                };

                string scopeConnectionName = TestUtilities.GenerateName("ANMScopeConnection");

                // Put ScopeConnection
                var putScopeConnectionResponse = networkManagementClient.ScopeConnections.CreateOrUpdate(scopeConnection, resourceGroupName, networkManagerName, scopeConnectionName);
                Assert.Equal(scopeConnectionName, putScopeConnectionResponse.Name);

                // Get ScopeConnection
                var getScopeConnectionResponse = networkManagementClient.ScopeConnections.Get(resourceGroupName, networkManagerName, scopeConnectionName);
                Assert.Equal(scopeConnectionName, getScopeConnectionResponse.Name);
                Assert.Equal(crossTenantId, getScopeConnectionResponse.TenantId);
                Assert.Equal(crossTenantResourceId, getScopeConnectionResponse.ResourceId);

                // List ScopeConnection
                var listScopeConnectionResponse = networkManagementClient.ScopeConnections.List(resourceGroupName, networkManagerName);
                Assert.Single(listScopeConnectionResponse);
                Assert.Equal(scopeConnectionName, listScopeConnectionResponse.First().Name);

                // Delete ScopeConnections
                networkManagementClient.ScopeConnections.Delete(resourceGroupName, networkManagerName, scopeConnectionName);

                // List Scope Connection
                listScopeConnectionResponse = networkManagementClient.ScopeConnections.List(resourceGroupName, networkManagerName);
                Assert.Empty(listScopeConnectionResponse);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);
            }
        }
    }
}