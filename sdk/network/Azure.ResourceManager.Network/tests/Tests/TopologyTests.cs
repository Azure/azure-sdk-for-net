// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.ResourceManager.Compute;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class TopologyTests : NetworkServiceClientTestBase
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

        //[TearDown]
        //public async Task CleanupResourceGroup()
        //{
        //    await CleanupResourceGroupsAsync();
        //}

        [Test]
        public async Task TopologyApiTest()
        {
            string resourceGroupName1 = Recording.GenerateAssetName("azsmnet");
            string resourceGroupName2 = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            ResourceGroup rg1 = await ArmClient.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(resourceGroupName1, new ResourceGroupData(location));

            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");

            //Deploy Vm from template
            VirtualMachine vm1 = await CreateVm(
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

            ResourceGroup rg2 = await ArmClient.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(resourceGroupName2, new ResourceGroupData(location));

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create NetworkWatcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await networkWatcherContainer.CreateOrUpdateAsync(resourceGroupName2, networkWatcherName, properties);

            TopologyParameters tpProperties = new TopologyParameters() { TargetResourceGroupName = resourceGroupName1 };

            //Get the current network topology of the resourceGroupName1
            var networkWatcherContainer = GetNetworkWatcherContainer("NetworkWatcherRG");
            Response<Topology> getTopology = await networkWatcherContainer.Get("NetworkWatcher_westus2").Value.GetTopologyAsync(tpProperties);

            //Getting infromation about VM from topology
            TopologyResource vmResource = getTopology.Value.Resources[0];

            //Verify that topology contain right number of resources (9 resources from template)
            Assert.AreEqual(9, getTopology.Value.Resources.Count);

            //Verify that topology contain information about acreated VM
            Assert.AreEqual(virtualMachineName, vmResource.Name);
            Assert.AreEqual(vm1.Id, vmResource.Id);
            Assert.AreEqual(networkInterfaceName, vmResource.Associations.FirstOrDefault().Name);
            Assert.AreEqual(vm1.Data.NetworkProfile.NetworkInterfaces.FirstOrDefault().Id, vmResource.Associations.FirstOrDefault().ResourceId);
            Assert.AreEqual("Contains", vmResource.Associations.FirstOrDefault().AssociationType.ToString());
        }
    }
}
