// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class NetAppResource_NetworkSiblingSetTests: NetAppTestBase
    {
        private NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts(); }
        private readonly string _pool1Name = "pool1";
        public static new AzureLocation DefaultLocation = AzureLocation.EastUS2;
        public static new AzureLocation DefaultLocationString = DefaultLocation;
        internal NetAppVolumeResource _volumeResource;

        public NetAppResource_NetworkSiblingSetTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync(location: DefaultLocation);
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters(location: DefaultLocation))).Value;

            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetNetAppVolumes();
            var volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork(location: DefaultLocation);
            _volumeResource = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName, subnetId: DefaultSubnetId);
        }

        [TearDown]
        public async Task ClearVolumes()
        {
            //remove all volumes under current capcityPool, remove pool and netAppAccount
            if (_resourceGroup != null)
            {
                _ = await _capacityPoolCollection.ExistsAsync(_capacityPool.Id.Name);
                CapacityPoolCollection poolCollection = _netAppAccount.GetCapacityPools();
                List<CapacityPoolResource> poolList = await poolCollection.GetAllAsync().ToEnumerableAsync();
                foreach (CapacityPoolResource pool in poolList)
                {
                    NetAppVolumeCollection volumeCollection = pool.GetNetAppVolumes();
                    List<NetAppVolumeResource> volumeList = await volumeCollection.GetAllAsync().ToEnumerableAsync();
                    foreach (NetAppVolumeResource volume in volumeList)
                    {
                        await volume.DeleteAsync(WaitUntil.Completed);
                    }
                    await LiveDelay(30000);
                    await pool.DeleteAsync(WaitUntil.Completed);
                }
                await LiveDelay(40000);
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [RecordedTest]
        public async Task QueryNetworkSiblingSet()
        {
            QueryNetworkSiblingSetContent queryNetworkSiblingSetContent = new QueryNetworkSiblingSetContent(_volumeResource.Data.NetworkSiblingSetId.ToString(), DefaultSubnetId);
            Response<NetworkSiblingSet> networkSiblingSet = await DefaultSubscription.QueryNetworkSiblingSetNetAppResourceAsync(DefaultLocation, queryNetworkSiblingSetContent);
            Assert.IsNotNull(networkSiblingSet);
            Assert.IsNotNull(networkSiblingSet.Value.NetworkSiblingSetId);
            Assert.IsNotNull(networkSiblingSet.Value.SubnetId);
        }

        [RecordedTest]
        public async Task UpdateNetworkSiblingSet()
        {
            QueryNetworkSiblingSetContent queryNetworkSiblingSetContent = new QueryNetworkSiblingSetContent(_volumeResource.Data.NetworkSiblingSetId.ToString(), DefaultSubnetId);
            Response<NetworkSiblingSet> networkSiblingSet = await DefaultSubscription.QueryNetworkSiblingSetNetAppResourceAsync(DefaultLocation, queryNetworkSiblingSetContent);

            Assert.AreEqual(NetAppNetworkFeature.Basic, _volumeResource.Data.NetworkFeatures);
            UpdateNetworkSiblingSetContent updateNetworkSiblingSetContent = new UpdateNetworkSiblingSetContent(networkSiblingSet.Value.NetworkSiblingSetId, networkSiblingSet.Value.SubnetId, networkSiblingSet.Value.NetworkSiblingSetStateId, NetAppNetworkFeature.Standard);
            ArmOperation<NetworkSiblingSet> networkSiblingSetLRO = await DefaultSubscription.UpdateNetworkSiblingSetNetAppResourceAsync(WaitUntil.Completed, DefaultLocation, updateNetworkSiblingSetContent);
            NetworkSiblingSet networkSiblingSetResult = networkSiblingSetLRO.Value;

            NetAppVolumeResource volumeResource2 = await _volumeCollection.GetAsync(_volumeResource.Id.Name);

            Assert.AreEqual(NetAppNetworkFeature.Standard, volumeResource2.Data.NetworkFeatures);
        }
    }
}
