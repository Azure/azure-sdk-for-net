// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchAccountPoolOperationTests : BatchManagementTestBase
    {
        private BatchAccountPoolResource _batchAccountPool;

        public BatchAccountPoolOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var batchAccountName = Recording.GenerateAssetName("testaccount");
            var poolName = Recording.GenerateAssetName("testPool-");
            var batchAccount = await CreateBatchAccount(ResourceGroup, batchAccountName, StorageAccountIdentifier);
            _batchAccountPool = await CreateBatchAccountPool(batchAccount, poolName);
        }

        [TestCase]
        public async Task PoolResourceApiTests()
        {
            //1.Get
            BatchAccountPoolResource pool = await _batchAccountPool.GetAsync();

            ResourceDataHelper.AssertPoolData(_batchAccountPool.Data, pool.Data);
            //2.Delete
            await _batchAccountPool.DeleteAsync(WaitUntil.Completed);
        }
    }
}
