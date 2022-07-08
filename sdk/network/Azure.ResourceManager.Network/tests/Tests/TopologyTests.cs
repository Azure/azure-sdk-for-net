// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
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

        [Test]
        [RecordedTest]
        [Ignore("Review after preview")]
        public async Task TopologyApiTest()
        {
            string resourceGroupName1 = Recording.GenerateAssetName("azsmnet");
            string resourceGroupName2 = Recording.GenerateAssetName("azsmnet");

            string location = TestEnvironment.Location;
            var resourceGroup1 = await CreateResourceGroup(resourceGroupName1, location);

            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");

            //Deploy Vm from template
            var vm = await CreateWindowsVM(virtualMachineName, networkInterfaceName, location, resourceGroup1);

            // TODO: where is this used?
            var resourceGropu2  = await CreateResourceGroup(resourceGroupName2, location);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create NetworkWatcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcherResource properties = new NetworkWatcherResource { Location = location };
            //await networkWatcherCollection.CreateOrUpdateAsync(true, resourceGroupName2, networkWatcherName, properties);

            TopologyContent tpProperties = new TopologyContent() { TargetResourceGroupName = resourceGroupName1 };

            //Get the current network topology of the resourceGroupName1
            var networkWatcherCollection = GetNetworkWatcherCollection("NetworkWatcherRG");
            Response<NetworkTopology> getTopology = await networkWatcherCollection.Get("NetworkWatcher_westus2").Value.GetTopologyAsync(tpProperties);

            //Getting infromation about VM from topology
            TopologyResourceInfo vmResource = getTopology.Value.Resources[0];

            //Verify that topology contain right number of resources (9 resources from template)
            Assert.AreEqual(9, getTopology.Value.Resources.Count);

            //Verify that topology contain information about acreated VM
            Assert.AreEqual(virtualMachineName, vmResource.Name);
            Assert.AreEqual(vm.Id, vmResource.Id);
            Assert.AreEqual(networkInterfaceName, vmResource.Associations.FirstOrDefault().Name);
            //Assert.AreEqual(vm.Data.NetworkProfile.NetworkInterfaces.FirstOrDefault().Id, vmResource.Associations.FirstOrDefault().ResourceId);
            Assert.AreEqual("Contains", vmResource.Associations.FirstOrDefault().AssociationType.ToString());
        }
    }
}
