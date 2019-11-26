using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Compute;
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
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Network.Tests.Helpers;

    public class NextHopTests
    {
        [Fact(Skip="Disable tests")]
        public void NextHopApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "westcentralus";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string virtualMachineName = TestUtilities.GenerateName();
                string networkSecurityGroupName = virtualMachineName + "-nsg";
                string networkInterfaceName = TestUtilities.GenerateName();

                //Deploy VM wih VNet,Subnet and Route Table from template
                Deployments.CreateVm(
                    resourcesClient: resourcesClient,
                    resourceGroupName: resourceGroupName,
                    location: location,
                    virtualMachineName: virtualMachineName,
                    storageAccountName: TestUtilities.GenerateName(),
                    networkInterfaceName: networkInterfaceName,
                    networkSecurityGroupName: networkSecurityGroupName,
                    diagnosticsStorageAccountName: TestUtilities.GenerateName(),
                    deploymentName: TestUtilities.GenerateName()
                    );

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher();
                properties.Location = location;

                //Create Network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);
                string sourceIPAddress = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, networkInterfaceName).IpConfigurations.FirstOrDefault().PrivateIPAddress;

                var getVm = computeManagementClient.VirtualMachines.Get(resourceGroupName, virtualMachineName);

                //Use DestinationIPAddress from Route Table
                NextHopParameters nhProperties1 = new NextHopParameters()
                {
                    TargetResourceId = getVm.Id,
                    SourceIPAddress = sourceIPAddress,
                    DestinationIPAddress = "10.1.3.6"
                };

                NextHopParameters nhProperties2 = new NextHopParameters()
                {
                    TargetResourceId = getVm.Id,
                    SourceIPAddress = sourceIPAddress,
                    DestinationIPAddress = "12.11.12.14"
                };

                var getNextHop1 = networkManagementClient.NetworkWatchers.GetNextHop(resourceGroupName, networkWatcherName, nhProperties1);
                var getNextHop2 = networkManagementClient.NetworkWatchers.GetNextHop(resourceGroupName, networkWatcherName, nhProperties2);

                var routeTable = networkManagementClient.RouteTables.Get(resourceGroupName, resourceGroupName + "RT");

                //Validation
                Assert.Equal("10.0.1.2", getNextHop1.NextHopIpAddress);
                Assert.Equal(routeTable.Id, getNextHop1.RouteTableId);

                Assert.Equal("Internet", getNextHop2.NextHopType);
                Assert.Equal("System Route", getNextHop2.RouteTableId);
            }
        }
    }
}

