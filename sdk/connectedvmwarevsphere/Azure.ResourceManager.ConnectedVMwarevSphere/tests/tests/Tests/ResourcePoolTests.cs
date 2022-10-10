// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{
    public class ResourcePoolTests : ConnectedVMwareTestBase
    {
        public ResourcePoolTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<ResourcePoolCollection> GetResourcePoolCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetResourcePools();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            var resourcePoolName = Recording.GenerateAssetName("testresourcepool");
            var _resourcePoolCollection = await GetResourcePoolCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var resourcePoolBody = new ResourcePoolData(DefaultLocation);
            resourcePoolBody.MoRefId = "resgroup-87733";
            resourcePoolBody.VCenterId = VcenterId;
            resourcePoolBody.ExtendedLocation = _extendedLocation;
            // create resource pool
            ResourcePoolResource resourcePool1 = (await _resourcePoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourcePoolName, resourcePoolBody)).Value;
            Assert.IsNotNull(resourcePool1);
            Assert.AreEqual(resourcePool1.Id.Name, resourcePoolName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var resourcePoolName = Recording.GenerateAssetName("testresourcepool");
            var _resourcePoolCollection = await GetResourcePoolCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var resourcePoolBody = new ResourcePoolData(DefaultLocation);
            resourcePoolBody.MoRefId = "resgroup-87735";
            resourcePoolBody.VCenterId = VcenterId;
            resourcePoolBody.ExtendedLocation = _extendedLocation;
            // create resource pool
            ResourcePoolResource resourcePool1 = (await _resourcePoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourcePoolName, resourcePoolBody)).Value;
            Assert.IsNotNull(resourcePool1);
            Assert.AreEqual(resourcePool1.Id.Name, resourcePoolName);
            // get resource pool
            resourcePool1 = await _resourcePoolCollection.GetAsync(resourcePoolName);
            Assert.AreEqual(resourcePool1.Id.Name, resourcePoolName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var resourcePoolName = Recording.GenerateAssetName("testresourcepool");
            var _resourcePoolCollection = await GetResourcePoolCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var resourcePoolBody = new ResourcePoolData(DefaultLocation);
            resourcePoolBody.MoRefId = "resgroup-87730";
            resourcePoolBody.VCenterId = VcenterId;
            resourcePoolBody.ExtendedLocation = _extendedLocation;
            // create resource pool
            ResourcePoolResource resourcePool1 = (await _resourcePoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourcePoolName, resourcePoolBody)).Value;
            Assert.IsNotNull(resourcePool1);
            Assert.AreEqual(resourcePool1.Id.Name, resourcePoolName);
            // check for exists resource pool
            bool exists = await _resourcePoolCollection.ExistsAsync(resourcePoolName);
            Assert.IsTrue(exists);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var resourcePoolName = Recording.GenerateAssetName("testresourcepool");
            var _resourcePoolCollection = await GetResourcePoolCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var resourcePoolBody = new ResourcePoolData(DefaultLocation);
            resourcePoolBody.MoRefId = "resgroup-119001";
            resourcePoolBody.VCenterId = VcenterId;
            resourcePoolBody.ExtendedLocation = _extendedLocation;
            // create resource pool
            ResourcePoolResource resourcePool1 = (await _resourcePoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourcePoolName, resourcePoolBody)).Value;
            Assert.IsNotNull(resourcePool1);
            Assert.AreEqual(resourcePool1.Id.Name, resourcePoolName);
            int count = 0;
            await foreach (var resourcePool in _resourcePoolCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var resourcePoolName = Recording.GenerateAssetName("testresourcepool");
            var _resourcePoolCollection = await GetResourcePoolCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var resourcePoolBody = new ResourcePoolData(DefaultLocation);
            resourcePoolBody.MoRefId = "resgroup-89261";
            resourcePoolBody.VCenterId = VcenterId;
            resourcePoolBody.ExtendedLocation = _extendedLocation;
            // create resource pool
            ResourcePoolResource resourcePool1 = (await _resourcePoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourcePoolName, resourcePoolBody)).Value;
            Assert.IsNotNull(resourcePool1);
            Assert.AreEqual(resourcePool1.Id.Name, resourcePoolName);
            resourcePool1 = null;
            await foreach (var resourcePool in DefaultSubscription.GetResourcePoolsAsync())
            {
                if (resourcePool.Data.Name == resourcePoolName)
                {
                    resourcePool1 = resourcePool;
                }
            }
            Assert.NotNull(resourcePool1);
        }
    }
}
