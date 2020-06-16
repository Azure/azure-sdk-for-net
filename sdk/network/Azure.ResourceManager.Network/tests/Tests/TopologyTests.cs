// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class TopologyTests : NetworkTestsManagementClientBase
    {
        public TopologyTests(bool isAsync) : base(isAsync)
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
        public async Task TopologyApiTest()
        {
            string resourceGroupName1 = Recording.GenerateAssetName("azsmnet");
            string resourceGroupName2 = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName1, new ResourceGroup(location));

            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");

            //Deploy Vm from template
            await CreateVm(
                resourcesClient: ResourceManagementClient,
                resourceGroupName: resourceGroupName1,
                location: location,
                virtualMachineName: virtualMachineName,
                storageAccountName: Recording.GenerateAssetName("azsmnet"),
                networkInterfaceName: networkInterfaceName,
                networkSecurityGroupName: networkSecurityGroupName,
                diagnosticsStorageAccountName: Recording.GenerateAssetName("azsmnet"),
                deploymentName: Recording.GenerateAssetName("azsmnet"),
                adminPassword: Recording.GenerateAlphaNumericId("AzureSDKNetworkTest#")
                );

            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName2, new ResourceGroup(location));

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create NetworkWatcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync(resourceGroupName2, networkWatcherName, properties);

            TopologyParameters tpProperties = new TopologyParameters() { TargetResourceGroupName = resourceGroupName1 };

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName1, virtualMachineName);

            //Get the current network topology of the resourceGroupName1
            Response<Topology> getTopology = await NetworkManagementClient.NetworkWatchers.GetTopologyAsync("NetworkWatcherRG", "NetworkWatcher_westus2", tpProperties);

            //Getting infromation about VM from topology
            TopologyResource vmResource = getTopology.Value.Resources[0];

            //Verify that topology contain right number of resources (9 resources from template)
            Assert.AreEqual(9, getTopology.Value.Resources.Count);

            //Verify that topology contain information about acreated VM
            Assert.AreEqual(virtualMachineName, vmResource.Name);
            Assert.AreEqual(getVm.Value.Id, vmResource.Id);
            Assert.AreEqual(networkInterfaceName, vmResource.Associations.FirstOrDefault().Name);
            Assert.AreEqual(getVm.Value.NetworkProfile.NetworkInterfaces.FirstOrDefault().Id, vmResource.Associations.FirstOrDefault().ResourceId);
            Assert.AreEqual("Contains", vmResource.Associations.FirstOrDefault().AssociationType.ToString());
        }
    }
}
