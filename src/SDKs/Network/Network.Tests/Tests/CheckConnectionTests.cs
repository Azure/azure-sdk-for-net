using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;


namespace Network.Tests.Tests
{
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Helpers;

    public class CheckConnectionTests
    {
        [Fact]
        public void CheckConnectionTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "westus";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher();
                properties.Location = location;
                
                //Create network Watcher

                ConnectivityParameters parameters = new ConnectivityParameters();
                parameters.Source = new ConnectivitySource();
                parameters.Source.ResourceId = "/subscriptions/6926fc75-ce7d-4c9e-a87f-c4e38c594eb5/resourceGroups/NwRgStage1/providers/Microsoft.Compute/virtualMachines/MultiTierApp0";
                parameters.Destination = new ConnectivityDestination();
                parameters.Destination.Address = "204.79.197.200";
                parameters.Destination.Port = 80;
                
                var connectionCheck = networkManagementClient.NetworkWatchers.CheckConnectivity(resourceGroupName, networkWatcherName, parameters);
                
                //Validation
                Assert.Equal(connectionCheck.ConnectionStatus, "Reachable");
                Assert.Equal(connectionCheck.ProbesFailed, 0);
                Assert.Equal(connectionCheck.Hops.FirstOrDefault().Type, "Source");
            }
        }
    }
}
