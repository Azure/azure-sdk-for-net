// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{    public class VirtualNetworkTests : ConnectedVMwareTestBase
    {
        public VirtualNetworkTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<VirtualNetworkCollection> GetVirtualNetworkCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetVirtualNetworks();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            var vnetName = Recording.GenerateAssetName("testvnet");
            var _virtualNetworkCollection = await GetVirtualNetworkCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var vnetBody = new VirtualNetworkData(DefaultLocation);
            vnetBody.MoRefId = "network-o61";
            vnetBody.VCenterId = VcenterId;
            vnetBody.ExtendedLocation = _extendedLocation;
            // create virtual network
            VirtualNetworkResource vnet1 = (await _virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetBody)).Value;
            Assert.IsNotNull(vnet1);
            Assert.AreEqual(vnet1.Id.Name, vnetName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var vnetName = Recording.GenerateAssetName("testvnet");
            var _virtualNetworkCollection = await GetVirtualNetworkCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var vnetBody = new VirtualNetworkData(DefaultLocation);
            vnetBody.MoRefId = "network-o25797";
            vnetBody.VCenterId = VcenterId;
            vnetBody.ExtendedLocation = _extendedLocation;
            // create virtual network
            VirtualNetworkResource vnet1 = (await _virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetBody)).Value;
            Assert.IsNotNull(vnet1);
            Assert.AreEqual(vnet1.Id.Name, vnetName);
            // get virtual network
            vnet1 = await _virtualNetworkCollection.GetAsync(vnetName);
            Assert.AreEqual(vnet1.Id.Name, vnetName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var vnetName = Recording.GenerateAssetName("testvnet");
            var _virtualNetworkCollection = await GetVirtualNetworkCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var vnetBody = new VirtualNetworkData(DefaultLocation);
            vnetBody.MoRefId = "network-o114814";
            vnetBody.VCenterId = VcenterId;
            vnetBody.ExtendedLocation = _extendedLocation;
            // create virtual network
            VirtualNetworkResource vnet1 = (await _virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetBody)).Value;
            Assert.IsNotNull(vnet1);
            Assert.AreEqual(vnet1.Id.Name, vnetName);
            // check for exists virtual network
            bool exists = await _virtualNetworkCollection.ExistsAsync(vnetName);
            Assert.IsTrue(exists);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var vnetName = Recording.GenerateAssetName("testvnet");
            var _virtualNetworkCollection = await GetVirtualNetworkCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var vnetBody = new VirtualNetworkData(DefaultLocation);
            vnetBody.MoRefId = "network-o2286";
            vnetBody.VCenterId = VcenterId;
            vnetBody.ExtendedLocation = _extendedLocation;
            // create virtual network
            VirtualNetworkResource vnet1 = (await _virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetBody)).Value;
            Assert.IsNotNull(vnet1);
            Assert.AreEqual(vnet1.Id.Name, vnetName);
            int count = 0;
            await foreach (var vnet in _virtualNetworkCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var vnetName = Recording.GenerateAssetName("testvnet");
            var _virtualNetworkCollection = await GetVirtualNetworkCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var vnetBody = new VirtualNetworkData(DefaultLocation);
            vnetBody.MoRefId = "network-o85628";
            vnetBody.VCenterId = VcenterId;
            vnetBody.ExtendedLocation = _extendedLocation;
            // create virtual network
            VirtualNetworkResource vnet1 = (await _virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetBody)).Value;
            Assert.IsNotNull(vnet1);
            Assert.AreEqual(vnet1.Id.Name, vnetName);
            vnet1 = null;
            await foreach (var vnet in DefaultSubscription.GetVirtualNetworksAsync())
            {
                if (vnet.Data.Name == vnetName)
                {
                    vnet1 = vnet;
                }
            }
            Assert.NotNull(vnet1);
        }
    }
}
