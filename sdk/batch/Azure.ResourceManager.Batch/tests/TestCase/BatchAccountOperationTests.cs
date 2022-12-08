// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchAccountOperationTests : BatchManagementTestBase
    {
        private BatchAccountResource _batchAccount;

        public BatchAccountOperationTests(bool isAsync)
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
        public async Task AccountResourceApiTests()
        {
            //1.Get
            BatchAccountResource account = await _batchAccount.GetAsync();

            ResourceDataHelper.AssertAccount(_batchAccount.Data, account.Data);
            //2.Delete
            await _batchAccount.DeleteAsync(WaitUntil.Completed);
        }
    }
}
