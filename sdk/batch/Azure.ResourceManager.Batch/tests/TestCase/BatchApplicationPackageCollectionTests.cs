// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchApplicationPackageCollectionTests : BatchManagementTestBase
    {
        private BatchApplicationResource _batchApplication;

        public BatchApplicationPackageCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("properties.storageUrl") { Value = "https://fakeaccount.blob.core.windows.net" });
        }

        [SetUp]
        public async Task SetUp()
        {
            var batchAccountName = Recording.GenerateAssetName("testaccount");
            var applicationName = Recording.GenerateAssetName("testApplication-");
            var batchAccount = await CreateBatchAccount(ResourceGroup, batchAccountName, StorageAccountIdentifier);
            _batchApplication = await CreateBatchApplication(batchAccount, applicationName);
        }

        [TestCase]
        public async Task ApplicationPackageCollectionApiTests()
        {
            //1.CreateOrUpdate
            var container = _batchApplication.GetBatchApplicationPackages();
            var name = Recording.GenerateAssetName("ApplicationPackage-");
            var name2 = Recording.GenerateAssetName("ApplicationPackage-");
            var name3 = Recording.GenerateAssetName("ApplicationPackage-");
            var input = ResourceDataHelper.GetBatchApplicationPackageData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchApplicationPackageResource applicationPackage1 = lro.Value;
            Assert.AreEqual(name, applicationPackage1.Data.Name);
            //2.Get
            BatchApplicationPackageResource applicationPackage2 = await container.GetAsync(name);
            ResourceDataHelper.AssertApplicationPckageData(applicationPackage1.Data, applicationPackage2.Data);
            //3.GetAll
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var account in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await container.ExistsAsync(name));
            Assert.IsFalse(await container.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
