// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Management.StorageCache.Tests.Fixtures;
    using Microsoft.Azure.Management.StorageCache.Tests.Utilities;
    using Microsoft.Azure.Test.HttpRecorder;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Defines the <see cref="StorageCacheTest" />.
    /// </summary>
    [Collection("StorageCacheCollection")]
    public class StorageCacheTest
    {
        /// <summary>
        /// Defines the testOutputHelper.
        /// </summary>
        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Defines the Fixture.
        /// </summary>
        private readonly StorageCacheTestFixture fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCacheTest"/> class.
        /// </summary>
        /// <param name="testOutputHelper">The testOutputHelper<see cref="ITestOutputHelper"/>.</param>
        /// <param name="fixture">The Fixture<see cref="StorageCacheTestFixture"/>.</param>
        public StorageCacheTest(ITestOutputHelper testOutputHelper, StorageCacheTestFixture fixture)
        {
            this.fixture = fixture;
            this.testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// The TestGetStorageCache.
        /// </summary>
        [Fact]
        public void TestGetStorageCache()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                Cache response = this.fixture.CacheHelper.Get(this.fixture.Cache.Name);
                Assert.Equal(this.fixture.Cache.Name, response.Name);
                Assert.Equal(this.fixture.Cache.CacheSizeGB, response.CacheSizeGB);
                Assert.Equal(this.fixture.Cache.Location, response.Location);
                Assert.Equal(this.fixture.Cache.Subnet, response.Subnet);
                Assert.Equal(this.fixture.Cache.Sku.Name, response.Sku.Name);
                Assert.Equal(this.fixture.Cache.Id, response.Id);
                Assert.Equal(this.fixture.Cache.Identity.Type, response.Identity.Type);
                Assert.Equal(this.fixture.Cache.Identity.PrincipalId, response.Identity.PrincipalId);
                Assert.Equal(this.fixture.Cache.Identity.TenantId, response.Identity.TenantId);
                Assert.Equal(this.fixture.Cache.SecuritySettings.RootSquash, response.SecuritySettings.RootSquash);
            }
        }

        /// <summary>
        /// List storage cache under subscription.
        /// </summary>
        [Fact]
        public void TestListStorageCache()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                IList<Cache> cacheListResponse = client.Caches.List().Value;
                Assert.True(cacheListResponse.Count >= 1);
                bool found = false;
                foreach (Cache response in cacheListResponse)
                {
                    if (string.Equals(response.Name, this.fixture.Cache.Name))
                    {
                        found = true;
                        Assert.Equal(this.fixture.Cache.Id, response.Id, ignoreCase: true);
                        Assert.Equal(this.fixture.Cache.Name, response.Name);
                        Assert.Equal(this.fixture.Cache.CacheSizeGB, response.CacheSizeGB);
                        Assert.Equal(this.fixture.Cache.Location, response.Location);
                        Assert.Equal(this.fixture.Cache.Subnet, response.Subnet);
                        Assert.Equal(this.fixture.Cache.Sku.Name, response.Sku.Name);
                    }
                }

                Assert.True(found, string.Format("Cache {0} not found in the list response.", this.fixture.Cache.Name));
            }
        }

        /// <summary>
        /// List storage cache under resource group.
        /// </summary>
        [Fact]
        public void TestListStorageCacheByResourceGroup()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.testOutputHelper.WriteLine("Looking for cache in resource group {0}.", this.fixture.ResourceGroup.Name);
                IList<Cache> cacheListResponse = client.Caches.ListByResourceGroup(this.fixture.ResourceGroup.Name).Value;
                Assert.True(cacheListResponse.Count >= 1);
                bool found = false;
                foreach (Cache response in cacheListResponse)
                {
                    if (string.Equals(response.Name, this.fixture.Cache.Name))
                    {
                        found = true;
                        Assert.Equal(this.fixture.Cache.Id, response.Id, ignoreCase: true);
                        Assert.Equal(this.fixture.Cache.Name, response.Name);
                        Assert.Equal(this.fixture.Cache.CacheSizeGB, response.CacheSizeGB);
                        Assert.Equal(this.fixture.Cache.Location, response.Location);
                        Assert.Equal(this.fixture.Cache.Subnet, response.Subnet);
                        Assert.Equal(this.fixture.Cache.Sku.Name, response.Sku.Name);
                    }
                }

                Assert.True(found, "Cache {this.fixture.Cache.Name} not found in the list response.");
            }
        }

        /// <summary>
        /// Verify flush cache with no storage target attached.
        /// </summary>
        [Fact]
        public void TestFlushCacheWithoutStorageTarget()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                client.Caches.Flush(this.fixture.ResourceGroup.Name, this.fixture.Cache.Name);
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    this.fixture.CacheHelper.WaitForCacheState(
                        this.fixture.CacheHelper.GetCacheHealthState,
                        this.fixture.Cache.Name,
                        "Flushing",
                        timeout: 120,
                        polling_delay: 5).GetAwaiter().GetResult();
                    this.fixture.CacheHelper.WaitForCacheState(
                        this.fixture.CacheHelper.GetCacheHealthState,
                        this.fixture.Cache.Name,
                        "Healthy",
                        polling_delay: 5).GetAwaiter().GetResult();
                }
            }
        }

        /// <summary>
        /// The test invalid cache size.
        /// </summary>
        [Fact]
        public void TestInvalidCacheSize()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var cacheIdentity = new CacheIdentity() { Type = CacheIdentityType.SystemAssigned };
                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.Create("InvalidCache", this.fixture.Cache.Sku.Name, 10, identity: cacheIdentity));
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                Assert.Equal("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("cacheSizeGB", ex.Body.Error.Target);
            }
        }

        /// <summary>
        /// The test invalid sku.
        /// </summary>
        [Fact]
        public void TestInvalidSku()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var cacheIdentity = new CacheIdentity() { Type = CacheIdentityType.SystemAssigned };
                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.Create("InvalidCacheSku", "InvalidSku", 3072, identity: cacheIdentity));
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                Assert.Equal("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("sku", ex.Body.Error.Target);
            }
        }

        /// <summary>
        /// The test invalid subscription.
        /// </summary>
        [Fact]
        public void TestInvalidSubscription()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                client.SubscriptionId = "4525f627-2e14-411c-96b9-7df2be6eeb93";
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var cacheIdentity = new CacheIdentity() { Type = CacheIdentityType.SystemAssigned };
                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.Create("InvalidSubscriptionId", this.fixture.Cache.Sku.Name, 3072, identity: cacheIdentity, skipGet: true));
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                Assert.Equal("SubscriptionNotFound", ex.Body.Error.Code);
                client.SubscriptionId = this.fixture.SubscriptionID;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
            }
        }
    }
}
