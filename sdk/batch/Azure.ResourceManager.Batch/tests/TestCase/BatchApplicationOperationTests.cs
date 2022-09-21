// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;
namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchApplicationOperationTests : BatchManagementTestBase
    {
        public BatchApplicationOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<BatchApplicationResource> CreateAccountResourceAsync(string accountName)
        {
            ResourceIdentifier storageAccountId = (await GetStorageAccountResource()).Id;
            var collection = (await CreateResourceGroupAsync()).GetBatchAccounts();
            var input = ResourceDataHelper.GetBatchAccountData(storageAccountId);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testaccount"), input);
            var account = lro.Value;
            var applicationContainer = account.GetBatchApplications();
            var applicationInput = ResourceDataHelper.GetBatchApplicationData();
            var lroc = await applicationContainer.CreateOrUpdateAsync(WaitUntil.Completed, accountName, applicationInput);
            return lroc.Value;
        }

        [TestCase]
        public async Task ApplicationResourceApiTests()
        {
            //1.Get
            var applicationName = Recording.GenerateAssetName("testApplication-");
            var application1 = await CreateAccountResourceAsync(applicationName);
            BatchApplicationResource application2 = await application1.GetAsync();

            ResourceDataHelper.AssertApplicationData(application1.Data, application2.Data);
            //2.Delete
            await application1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
