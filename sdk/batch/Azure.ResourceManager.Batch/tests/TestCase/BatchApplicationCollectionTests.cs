// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchApplicationCollectionTests : BatchManagementTestBase
    {
        private BatchAccountResource _batchAccount;

        public BatchApplicationCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var batchAccountName = Recording.GenerateAssetName("testaccount");
            _batchAccount = await CreateBatchAccount(ResourceGroup, batchAccountName, StorageAccountIdentifier);
        }

        [TestCase]
        public async Task ApplicationCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = _batchAccount.GetBatchApplications();
            var name = Recording.GenerateAssetName("Application-");
            var name2 = Recording.GenerateAssetName("Application-");
            var name3 = Recording.GenerateAssetName("Application-");
            var input = ResourceDataHelper.GetBatchApplicationData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchApplicationResource application1 = lro.Value;
            Assert.AreEqual(name, application1.Data.Name);
            //2.Get
            BatchApplicationResource application2 = await collection.GetAsync(name);
            ResourceDataHelper.AssertApplicationData(application1.Data, application2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var account in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
