// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchApplicationOperationTests : BatchManagementTestBase
    {
        private BatchApplicationResource _batchApplication;

        public BatchApplicationOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
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
        public async Task ApplicationResourceApiTests()
        {
            //1.Get
            BatchApplicationResource application = await _batchApplication.GetAsync();

            ResourceDataHelper.AssertApplicationData(_batchApplication.Data, application.Data);
            //2.Delete
            await _batchApplication.DeleteAsync(WaitUntil.Completed);
        }
    }
}
