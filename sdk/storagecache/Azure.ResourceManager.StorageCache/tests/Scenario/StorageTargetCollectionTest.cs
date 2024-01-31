// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class StorageTargetCollectionTest : StorageCacheManagementTestBase
    {
        private StorageCacheResource DefaultStorageCache { get; set; }
        public StorageTargetCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task StorageTargetSetup()
        {
            // it's very heavy to create storage cache (~20 minutes), so provide an option to use precreated resource
            //   set preCreated to true and updated the resourceGroup, cacheName below to use pre created resource
            //   set preCreated to false to create new one
            bool preCreated = true;
            this.DefaultStorageCache = preCreated ?
                await this.RetrieveExistingStorageCache(
                    resourceGroupName: this.DefaultResourceGroup.Id.Name,
                    cacheName: @"testsc8739") :
                await this.CreateOrUpdateStorageCache();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var str = await this.CreateOrUpdateStorageTarget(this.DefaultStorageCache, verifyResult: true);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string targetName = "gettarget";
            StorageTargetResource str = await this.CreateOrUpdateStorageTarget(this.DefaultStorageCache, targetName);

            StorageTargetResource result = await this.DefaultStorageCache.GetStorageTargets().GetAsync(targetName);

            this.VerifyStorageTarget(result, str.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            string name = Recording.GenerateAssetName("storagetarget");
            await AzureResourceTestHelper.TestExists<StorageTargetResource>(
                async () => await this.CreateOrUpdateStorageTarget(this.DefaultStorageCache, name),
                async () => await this.DefaultStorageCache.GetStorageTargets().ExistsAsync(name));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            await AzureResourceTestHelper.TestGetAll<StorageTargetResource>(
                count: 3,
                async (i) => await this.CreateOrUpdateStorageTarget(this.DefaultStorageCache, name: "st" + i, targetIpAddress: $"10.0.2.{100 + i}"),
                () => this.DefaultStorageCache.GetStorageTargets().GetAllAsync()
                );
        }
    }
}
