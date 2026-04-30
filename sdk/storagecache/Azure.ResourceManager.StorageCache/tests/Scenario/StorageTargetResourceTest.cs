// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class StorageTargetResourceTest : StorageCacheManagementTestBase
    {
        private StorageCacheResource DefaultStorageCache { get; set; }
        public StorageTargetResourceTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task StorageTargetSetup()
        {
            // it's very heavy to create storage cache (~20 minutes), so provide an option to use precreated resource
            //   set preCreated to true and updated the resourceGroup, cacheName below to use pre created resource
            //   set preCreated to false to create new one
            bool preCreated = false;
            this.DefaultStorageCache = preCreated ?
                await this.RetrieveExistingStorageCache(
                    resourceGroupName: this.DefaultResourceGroup.Id.Name,
                    cacheName: @"testsc5594") :
                await this.CreateOrUpdateStorageCache();
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Delete()
        {
            await AzureResourceTestHelper.TestDelete(
                async () => await this.CreateOrUpdateStorageTarget(this.DefaultStorageCache),
                async (res) => await res.DeleteAsync(WaitUntil.Completed),
                async (res) => await res.GetAsync());
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Update()
        {
            int newVerificationDelayInSeconds = 20;
            StorageTargetResource str = await this.CreateOrUpdateStorageTarget(this.DefaultStorageCache, verificationDelayInSeconds: 10);
            str.Data.Nfs3.VerificationDelayInSeconds = newVerificationDelayInSeconds;
            var lro = await str.UpdateAsync(WaitUntil.Completed, str.Data);
            this.VerifyStorageTarget(lro.Value, str.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task OtherOperations()
        {
            StorageTargetResource str = await this.CreateOrUpdateStorageTarget(this.DefaultStorageCache);
            await str.FlushAsync(WaitUntil.Completed);
            await str.RefreshDnsAsync(WaitUntil.Completed);
            await str.RestoreDefaultsAsync(WaitUntil.Completed);
            await str.InvalidateAsync(WaitUntil.Completed);
            await str.SuspendAsync(WaitUntil.Completed);
            await str.ResumeAsync(WaitUntil.Completed);
        }
    }
}
