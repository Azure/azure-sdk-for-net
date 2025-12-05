// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Security.Cryptography.X509Certificates;

//using System.Text;
//using System.Threading.Tasks;
//using Azure.Core;
//using Azure.Core.TestFramework;
//using Azure.ResourceManager.NetApp.Models;
//using Azure.ResourceManager.NetApp.Tests.Helpers;
//using Azure.ResourceManager.Resources;
//using FluentAssertions;
//using NUnit.Framework;

//namespace Azure.ResourceManager.NetApp.Tests
//{
//    public class ANFCacheTests : NetAppTestBase
//    {
//        private string _pool1Name = "pool1";
//        private NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts(); }
//        internal NetAppCacheCollection _cacheCollection;

//        //private NetAppBucketCollection _netAppBucketCollection { get => _resourceGroup.GetNetAppBuckets(); }
//        public ANFCacheTests(bool isAsync) : base(isAsync)
//        {
//        }

//        [SetUp]
//        public async Task SetUp()
//        {
//            Console.WriteLine("ANFBucketTests Setup");
//            string volumeName = Recording.GenerateAssetName("volumeName-");
//            _resourceGroup = await CreateResourceGroupAsync();
//            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
//            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;

//            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
//            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
//            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;

//            _cacheCollection = _capacityPool.GetNetAppCaches();

//            await CreateVirtualNetwork();
//            Console.WriteLine("VolumeTEST Setup create vnet");
//            Console.WriteLine("ANFBucketTests Setup complete");
//        }

//        [TearDown]
//        public async Task ClearCaches()
//        {
//            //remove all buckets under current netAppAccount and remove netAppAccount
//            if (_resourceGroup != null)
//            {
//                await foreach (NetAppCacheResource cache in _cacheCollection.GetAllAsync())
//                {
//                    // invoke the operation
//                    await cache.DeleteAsync(WaitUntil.Completed);
//                }
//                //remove capacityPools
//                await LiveDelay(40000);
//                await foreach (CapacityPoolResource capacityPool in _capacityPoolCollection.GetAllAsync())
//                {
//                    // invoke the operation
//                    await capacityPool.DeleteAsync(WaitUntil.Completed);
//                }
//                //remove account
//                await LiveDelay(40000);
//                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
//            }
//            _resourceGroup = null;
//        }

//        [RecordedTest]
//        public async Task CreateGetDeleteCache()
//        {
//            //create snapshot
//            var cacheName = Recording.GenerateAssetName("cache-");
//            //await SetUp();

//            NetAppCacheData data = new NetAppCacheData(DefaultLocation, new CacheProperties()
//            {
//                Filepath = cacheName,
//                Size = 107374182400L,
//                CacheSubnetResourceId = DefaultSubnetId,
//            });

//            ArmOperation<NetAppCacheResource> lro = await _cacheCollection.CreateOrUpdateAsync(WaitUntil.Completed, cacheName, data);
//            NetAppCacheResource result = lro.Value;

//            // the variable result is a resource
//            Assert.IsNotNull(result.Data);
//            Assert.AreEqual($"{_netAppAccount.Data.Name}/{cacheName}", result.Data.Name);
//            Console.WriteLine($"Create Succeeded on id: {result.Data.Id}");

//            // get the created resource
//            NetAppCacheResource netAppCache = Client.GetNetAppCacheResource(result.Data.Id);
//            // invoke the operation
//            NetAppCacheResource cacheResult = await netAppCache.GetAsync();
//            string cacheResourceName = cacheResult.Data.Name;

//            Assert.IsNotNull(cacheResult.Data);
//            Assert.AreEqual($"{_netAppAccount.Data.Name}/{cacheName}", cacheResult.Data.Name);
//            Console.WriteLine($"GET Succeeded on id: {cacheResult.Data.Id}");

//            // invoke the delete operation
//            await netAppCache.DeleteAsync(WaitUntil.Completed);
//            Console.WriteLine($"Delete Succeeded on id: {cacheResult.Data.Id}");

//            Console.WriteLine($"Check if exists: {cacheResourceName}");
//            //check if the cache exists
//            await LiveDelay(30000);
//            bool existsResult = await _cacheCollection.ExistsAsync(cacheResourceName);
//            existsResult.Should().BeFalse();
//            Console.WriteLine($"Succeeded: {existsResult}");
//        }

//        [RecordedTest]
//        public async Task ListCaches()
//        {
//            //create cache
//            var cacheName = Recording.GenerateAssetName("cache-");
//            var cache2Name = Recording.GenerateAssetName("cache-2");
//            await SetUp();
//            NetAppCacheData data = new NetAppCacheData(DefaultLocation, new CacheProperties()
//            {
//                Filepath = cacheName,
//                Size = 107374182400L,
//                CacheSubnetResourceId = DefaultSubnetId,
//            });

//            ArmOperation<NetAppCacheResource> lro = await _cacheCollection.CreateOrUpdateAsync(WaitUntil.Completed, cacheName, data);
//            NetAppCacheResource result = lro.Value;

//            //ArmOperation<NetAppBucketResource> lro2 = await _bucketCollection.CreateOrUpdateAsync(WaitUntil.Completed, bucket2Name, data2);
//            //NetAppBucketResource result2 = lro2.Value;

//            // Define a list to store results
//            List<NetAppCacheResource> caches = new List<NetAppCacheResource>();
//            // invoke the List operation and iterate over the result
//            await foreach (NetAppCacheResource item in _cacheCollection.GetAllAsync())
//            {
//                caches.Add(item);
//                // for demo we just print out the id
//                Console.WriteLine($"Succeeded on id: {item.Id}");
//            }
//            Assert.GreaterOrEqual(caches.Count, 1);
//            Assert.IsTrue(caches.Any(r => r.Data.Name.Split('/').Last() == cacheName));
//        }

//        [RecordedTest]
//        public async Task PatchCache()
//        {
//            //create snapshot
//            var cacheName = Recording.GenerateAssetName("cache-");
//            await SetUp();

//            NetAppCacheData data = new NetAppCacheData(DefaultLocation, new CacheProperties()
//            {
//                Filepath = cacheName,
//                Size = 107374182400L,
//                CacheSubnetResourceId = DefaultSubnetId,
//            });

//            ArmOperation<NetAppCacheResource> lro = await _cacheCollection.CreateOrUpdateAsync(WaitUntil.Completed, cacheName, data);
//            NetAppCacheResource result = lro.Value;

//            // the variable result is a resource
//            Assert.IsNotNull(result.Data);
//            Assert.AreEqual(cacheName, result.Data.Name.Split('/').Last());
//            Console.WriteLine($"Create Succeeded on id: {result.Data.Id}");

//            // get the created resource
//            NetAppCacheResource netAppCache = Client.GetNetAppCacheResource(result.Data.Id);
//            // invoke the operation
//            NetAppCacheResource cacheResult = await netAppCache.GetAsync();
//            Assert.IsNotNull(cacheResult.Data);
//            Assert.AreEqual(cacheName, cacheResult.Data.Name.Split('/').Last());
//            Console.WriteLine($"GET Succeeded on id: {cacheResult.Data.Id}");

//            // invoke the operation
//            NetAppCachePatch patch = new NetAppCachePatch
//            {
//                Tags =
//                {
//                    { "patchkey", "patchvalue" }
//                },
//            };
//            ArmOperation<NetAppCacheResource> lroUpdate = await netAppCache.UpdateAsync(WaitUntil.Completed, patch);
//            NetAppCacheResource updateResult = lroUpdate.Value;
//            Assert.IsNotNull(updateResult.Data);
//            await LiveDelay(30000);
//            NetAppCacheResource updateResultData = await netAppCache.GetAsync();

//            updateResultData.Id.Should().Be(cacheResult.Data.Id);
//            updateResult.Data.Name.Should().Be(cacheResult.Data.Name);
//            updateResult.Data.Properties.ProvisioningState.Should().Be(NetAppProvisioningState.Succeeded);
//            //updateResultData.Data.Permissions.Should().Be(NetAppBucketPatchPermission.ReadWrite);
//        }
//    }
//}
