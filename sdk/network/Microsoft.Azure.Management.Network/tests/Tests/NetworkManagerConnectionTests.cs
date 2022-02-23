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
    public class NetworkManagerConnectionTests
    {
        [Fact(Skip = "Disable tests")]
        public void NetworkManagerConnectionManagementGroup()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler1);

                var networkManagerId = "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/TeamMembers/providers/Microsoft.Network/networkManagers/jaredgorthy";

                var networkManagerConnection = new NetworkManagerConnection()
                {
                    NetworkManagerId = networkManagerId
                };

                string networkManagerConnectionName = TestUtilities.GenerateName("NetworkManagerConnectionMG");
                var managementGroupName = "jaredgorthy";

                var putNetworkManagerConnectionResponse = networkManagementClient.ManagementGroupNetworkManagerConnections.CreateOrUpdate(networkManagerConnection, managementGroupName, networkManagerConnectionName);
                Assert.Equal(networkManagerConnectionName, putNetworkManagerConnectionResponse.Name);

                var listNetworkManagerConnectionResponse = networkManagementClient.ManagementGroupNetworkManagerConnections.List(managementGroupName);
                Assert.Single(listNetworkManagerConnectionResponse);
                Assert.Equal(listNetworkManagerConnectionResponse.First().Name, networkManagerConnectionName);
                Assert.Equal(listNetworkManagerConnectionResponse.First().NetworkManagerId, networkManagerId);

                // Delete ScopeConnections
                networkManagementClient.ManagementGroupNetworkManagerConnections.Delete(managementGroupName, networkManagerConnectionName);

                // Confirm Delete
                listNetworkManagerConnectionResponse = networkManagementClient.ManagementGroupNetworkManagerConnections.List(managementGroupName);
                Assert.Empty(listNetworkManagerConnectionResponse);
            }
        }

        [Fact(Skip = "Disable tests")]
        public void NetworkManagerConnectionSubscriptionTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler1);

                var networkManagerId = "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/TeamMembers/providers/Microsoft.Network/networkManagers/jaredgorthy";

                var networkManagerConnection = new NetworkManagerConnection()
                {
                    NetworkManagerId = networkManagerId
                };

                string networkManagerConnectionName = TestUtilities.GenerateName("NetworkManagerConnectionSub1");

                var putNetworkManagerConnectionResponse = networkManagementClient.SubscriptionNetworkManagerConnections.CreateOrUpdate(networkManagerConnection, networkManagerConnectionName);
                Assert.Equal(networkManagerConnectionName, putNetworkManagerConnectionResponse.Name);

                var listNetworkManagerConnectionResponse = networkManagementClient.SubscriptionNetworkManagerConnections.List();
                Assert.Single(listNetworkManagerConnectionResponse);
                Assert.Equal(listNetworkManagerConnectionResponse.First().Name, networkManagerConnectionName);
                Assert.Equal(listNetworkManagerConnectionResponse.First().NetworkManagerId, networkManagerId);
                Assert.Equal("Pending", listNetworkManagerConnectionResponse.First().ConnectionState);

                // Delete ScopeConnections
                networkManagementClient.SubscriptionNetworkManagerConnections.Delete(networkManagerConnectionName);

                // Confirm Delete
                listNetworkManagerConnectionResponse = networkManagementClient.SubscriptionNetworkManagerConnections.List();
                Assert.Empty(listNetworkManagerConnectionResponse);
            }
        }
    }
}