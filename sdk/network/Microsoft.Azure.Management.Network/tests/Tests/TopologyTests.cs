using System.Collections.Generic;
using System.Linq;
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
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Network.Tests.Helpers;

    public class TopologyTests
    {
        [Fact(Skip="Disable tests")]
        public void TopologyApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "eastus";

                string resourceGroupName1 = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName1,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string virtualMachineName = TestUtilities.GenerateName();
                string networkSecurityGroupName = virtualMachineName + "-nsg";
                string networkInterfaceName = TestUtilities.GenerateName();

                //Deploy Vm from template
                Deployments.CreateVm(
                    resourcesClient: resourcesClient,
                    resourceGroupName: resourceGroupName1,
                    location: location,
                    virtualMachineName: virtualMachineName,
                    storageAccountName: TestUtilities.GenerateName(),
                    networkInterfaceName: networkInterfaceName,
                    networkSecurityGroupName: networkSecurityGroupName,
                    diagnosticsStorageAccountName: TestUtilities.GenerateName(),
                    deploymentName: TestUtilities.GenerateName()
                    );

                string resourceGroupName2 = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName2,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher();
                properties.Location = location;

                //Create NetworkWatcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName2, networkWatcherName, properties);

                TopologyParameters tpProperties = new TopologyParameters()
                {
                    TargetResourceGroupName = resourceGroupName1
                };

                var getVm = computeManagementClient.VirtualMachines.Get(resourceGroupName1, virtualMachineName);

                //Get the current network topology of the resourceGroupName1 
                var getTopology = networkManagementClient.NetworkWatchers.GetTopology(resourceGroupName2, networkWatcherName, tpProperties);


                //Getting infromation about VM from topology
                TopologyResource vmResource = getTopology.Resources[2];

                //Verify that topology contain right number of resources (9 resources from template)
                Assert.Equal(9, getTopology.Resources.Count);

                //Verify that topology contain information about acreated VM
                Assert.Equal(virtualMachineName, vmResource.Name);
                Assert.Equal(getVm.Id, vmResource.Id);
                Assert.Equal(networkInterfaceName, vmResource.Associations.FirstOrDefault().Name);
                Assert.Equal(getVm.NetworkProfile.NetworkInterfaces.FirstOrDefault().Id, vmResource.Associations.FirstOrDefault().ResourceId);
                Assert.Equal("Contains", vmResource.Associations.FirstOrDefault().AssociationType);
            }
        }
    }
}

