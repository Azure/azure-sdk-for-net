// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchAccountPoolCollectionTests : BatchManagementTestBase
    {
        private BatchAccountResource _batchAccount;

        public BatchAccountPoolCollectionTests(bool isAsync)
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
        public async Task PoolCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = _batchAccount.GetBatchAccountPools();
            var name = Recording.GenerateAssetName("Pool-");
            var name2 = Recording.GenerateAssetName("Pool-");
            var name3 = Recording.GenerateAssetName("Pool-");
            var input = ResourceDataHelper.GetBatchAccountPoolData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountPoolResource pool1 = lro.Value;
            Assert.That(pool1.Data.Name, Is.EqualTo(name));
            //2.Get
            BatchAccountPoolResource pool2 = await collection.GetAsync(name);
            ResourceDataHelper.AssertPoolData(pool1.Data, pool2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var account in collection.GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.GreaterThanOrEqualTo(3));
            //4.Exists
            Assert.That((bool)await collection.ExistsAsync(name), Is.True);
            Assert.That((bool)await collection.ExistsAsync(name + "1"), Is.False);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
