// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class VolumeGroupTests : NetAppTestBase
    {
        private readonly string _pool1Name = "pool1";
        // For now we need those prerequisite resources specifically as they are manually pinned to an supporting cluster in the datacenter, untill this becomes dynamic where we can pin in code here we use this.
        // see for more detail https://docs.microsoft.com/en-us/azure/azure-netapp-files/application-volume-group-considerations#best-practices-about-proximity-placement-groups
        private readonly string _volumeGroupLocation = "northeurope";
        private readonly string _volumeGroupResourceGroupName = "sdk-net-test-qa2";
        private readonly string _vgVnet = "vnetnortheurope-anf";
        private readonly string _proximityPlacementGroup = "/subscriptions/69a75bda-882e-44d5-8431-63421204132a/resourceGroups/sdk-net-test-qa2/providers/Microsoft.Compute/proximityPlacementGroups/sdk_test_northeurope_ppg";
        //private readonly string _gENPOPDeploymentSpecID = "30542149-bfca-5618-1879-9863dc6767f1";
        private readonly string _sAPHANAOnGENPOPDeploymentSpecID = "20542149-bfca-5618-1879-9863dc6767f1";
        private ResourceGroupResource _volumeGroupResourceGroup;
        private NetAppAccountCollection _netAppAccountCollection { get => _volumeGroupResourceGroup.GetNetAppAccounts(); }
        private VolumeGroupDetailsCollection _volumeGroupCollection { get => _netAppAccount.GetVolumeGroupDetails(); }

        public VolumeGroupTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            ResourceGroupCollection resourceGroupCollection = DefaultSubscription.GetResourceGroups();
            _volumeGroupResourceGroup = await resourceGroupCollection.GetAsync(_volumeGroupResourceGroupName);
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _volumeGroupResourceGroup, _volumeGroupLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters(_volumeGroupLocation))).Value;
            CapacityPoolData capactiyPoolData = new(_volumeGroupLocation, _poolSize.Value, ServiceLevel.Premium);
            capactiyPoolData.QosType = QosType.Manual;
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetVolumes();
            VirtualNetworkCollection vnetColletion = _volumeGroupResourceGroup.GetVirtualNetworks();
        }

        [TearDown]
        public async Task ClearVolumeGroups()
        {
            //remove all volumes under current capcityPool, remove pool and netAppAccount
            if (_resourceGroup != null)
            {
                bool exists = await _capacityPoolCollection.ExistsAsync(_capacityPool.Data.Name.Split('/').Last());
                CapacityPoolCollection poolCollection = _netAppAccount.GetCapacityPools();
                List<CapacityPoolResource> poolList = await poolCollection.GetAllAsync().ToEnumerableAsync();
                foreach (CapacityPoolResource pool in poolList)
                {
                    VolumeCollection volumeCollection = pool.GetVolumes();
                    List<VolumeResource> volumeList = await volumeCollection.GetAllAsync().ToEnumerableAsync();
                    foreach (VolumeResource volume in volumeList)
                    {
                        await volume.DeleteAsync(WaitUntil.Completed);
                    }
                    if (Mode != RecordedTestMode.Playback)
                    {
                        await Task.Delay(30000);
                    }
                    await pool.DeleteAsync(WaitUntil.Completed);
                }

                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                //remove
                //await _capacityPool.DeleteAsync(WaitUntil.Completed);
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [Test]
        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task CreateDeleteVolumeGroup()
        {
            // create a volumeGroup
            string volumeGroupName = Recording.GenerateAssetName("volumeGroupName-");
            VolumeGroupDetailsResource volumeGroupDetailsResource1 = await CreateVolumeGroup(_volumeGroupCollection, volumeGroupName);
            Assert.IsNotNull(volumeGroupDetailsResource1);

            //validate
            VolumeGroupDetailsResource volumeGroupDetailsResource2 = await _volumeGroupCollection.GetAsync(volumeGroupName);
            Assert.IsNotNull(volumeGroupDetailsResource2);
            Assert.AreEqual(volumeGroupDetailsResource1.Data.Name, volumeGroupDetailsResource2.Data.Name);
            Assert.AreEqual(volumeGroupDetailsResource1.Data.GroupMetaData.DeploymentSpecId, volumeGroupDetailsResource2.Data.GroupMetaData.DeploymentSpecId);
            Assert.AreEqual(volumeGroupDetailsResource1.Data.GroupMetaData.GroupDescription, volumeGroupDetailsResource2.Data.GroupMetaData.GroupDescription);

            //check non existance and exitance
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeCollection.GetAsync(volumeGroupName+"1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeGroupCollection.ExistsAsync(volumeGroupName));
            Assert.IsFalse(await _volumeGroupCollection.ExistsAsync(volumeGroupName+"1"));

            //delete VolumeGroup
            await volumeGroupDetailsResource2.DeleteAsync(WaitUntil.Completed);
            //validate if deleted successfully
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(volumeGroupName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(volumeGroupName); });
            Assert.AreEqual(404, exception.Status);
        }

        private async Task<VolumeGroupDetailsResource> CreateVolumeGroup(VolumeGroupDetailsCollection volumeGroupCollection = null, string volumeGroupName = "")
        {
            if (volumeGroupCollection == null)
            {
                volumeGroupCollection = _volumeGroupCollection;
            }
            if (string.IsNullOrWhiteSpace(volumeGroupName))
            {
                volumeGroupName = Recording.GenerateAssetName("volumeGroupName-");
            }
            List<VolumeGroupVolumeProperties> volumeGroupVolumeProperties = new();
            string subnetId = $"{DefaultSubscription.Id}/resourceGroups/{_volumeGroupResourceGroup.Id.Name}/providers/Microsoft.Network/virtualNetworks/{_vgVnet}/subnets/default";
            long logUsageThreshold = 100 * _gibibyte;
            string logVolumeName = $"{volumeGroupName}-log-1";

            VolumeGroupVolumeProperties logVolumeProperties = new(logVolumeName, logUsageThreshold, subnetId);
            logVolumeProperties.Name = logVolumeName;
            logVolumeProperties.VolumeSpecName = "log";
            logVolumeProperties.CapacityPoolResourceId = _capacityPool.Id;
            logVolumeProperties.ProximityPlacementGroup = _proximityPlacementGroup;
            logVolumeProperties.UsageThreshold = 100 * _gibibyte;
            logVolumeProperties.ThroughputMibps = 6;
            logVolumeProperties.ProtocolTypes.InitializeFrom(_defaultProtocolTypes);
            logVolumeProperties.Tags.InitializeFrom(DefaultTags);
            logVolumeProperties.ExportPolicy = new VolumePropertiesExportPolicy(_defaultExportPolicyRuleList);
            volumeGroupVolumeProperties.Add(logVolumeProperties);

            string dataVolumeName = $"{volumeGroupName}-data-1";
            VolumeGroupVolumeProperties dataVolumeProperties = new(dataVolumeName, logUsageThreshold, subnetId);
            dataVolumeProperties.Name = dataVolumeName;
            dataVolumeProperties.VolumeSpecName = "data";
            dataVolumeProperties.CapacityPoolResourceId = _capacityPool.Id;
            dataVolumeProperties.ProximityPlacementGroup = _proximityPlacementGroup;
            dataVolumeProperties.UsageThreshold = 100 * _gibibyte;
            dataVolumeProperties.ThroughputMibps = 6;
            dataVolumeProperties.ProtocolTypes.InitializeFrom(_defaultProtocolTypes);
            dataVolumeProperties.Tags.InitializeFrom(DefaultTags);
            dataVolumeProperties.ExportPolicy = new VolumePropertiesExportPolicy(_defaultExportPolicyRuleList);
            volumeGroupVolumeProperties.Add(dataVolumeProperties);

            string sharedVolumeName = $"{volumeGroupName}-shared-1";
            VolumeGroupVolumeProperties sharedVolumeProperties = new(sharedVolumeName, logUsageThreshold, subnetId);
            sharedVolumeProperties.Name = sharedVolumeName;
            sharedVolumeProperties.VolumeSpecName = "shared";
            sharedVolumeProperties.CapacityPoolResourceId = _capacityPool.Id;
            sharedVolumeProperties.ProximityPlacementGroup = _proximityPlacementGroup;
            sharedVolumeProperties.UsageThreshold = 100 * _gibibyte;
            sharedVolumeProperties.ThroughputMibps = 6;
            sharedVolumeProperties.ProtocolTypes.InitializeFrom(_defaultProtocolTypes);
            sharedVolumeProperties.Tags.InitializeFrom(DefaultTags);
            sharedVolumeProperties.ExportPolicy = new VolumePropertiesExportPolicy(_defaultExportPolicyRuleList);
            volumeGroupVolumeProperties.Add(sharedVolumeProperties);

            IList<PlacementKeyValuePairs> globalPlacementRules = new List<PlacementKeyValuePairs> { new PlacementKeyValuePairs("key1", "value1") };

            VolumeGroupDetailsData volumeGroupDetailsData = new();
            volumeGroupDetailsData.Location = _volumeGroupLocation;
            volumeGroupDetailsData.GroupMetaData = new("group description", ApplicationType.SAPHana, "SH1", globalPlacementRules, _sAPHANAOnGENPOPDeploymentSpecID, null);
            volumeGroupDetailsData.Volumes.InitializeFrom(volumeGroupVolumeProperties);

            VolumeGroupDetailsResource volumeGroupDetails = (await volumeGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, volumeGroupDetailsData)).Value;
            return volumeGroupDetails;
        }
    }
}
