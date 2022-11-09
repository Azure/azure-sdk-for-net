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
    public class BatchApplicationPackageOperationTests : BatchManagementTestBase
    {
        public BatchApplicationPackageOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<BatchApplicationPackageResource> CreateAccountResourceAsync(string packageName)
        {
            ResourceIdentifier storageAccountId = (await GetStorageAccountResource()).Id;
            var collection = (await CreateResourceGroupAsync()).GetBatchAccounts();
            var input = ResourceDataHelper.GetBatchAccountData(storageAccountId);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testaccount"), input);
            var account = lro.Value;
            var applicationContainer = account.GetBatchApplications();
            var applicationInput = ResourceDataHelper.GetBatchApplicationData();
            var lroc = await applicationContainer.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testapplication-"), applicationInput);
            var applicationResource = lroc.Value;
            var applicationPackageContainer = applicationResource.GetBatchApplicationPackages();
            var applicationPackageInput = ResourceDataHelper.GetBatchApplicationPackageData();
            var lrop = await applicationPackageContainer.CreateOrUpdateAsync(WaitUntil.Completed, packageName, applicationPackageInput);
            return lrop.Value;
        }

        [TestCase]
        public async Task ApplicationPackageResourceApiTests()
        {
            //1.Get
            var applicationPackageName = Recording.GenerateAssetName("testApplicationPackage-");
            var applicationPackage1 = await CreateAccountResourceAsync(applicationPackageName);
            BatchApplicationPackageResource applicationPackage2 = await applicationPackage1.GetAsync();

            ResourceDataHelper.AssertApplicationPckageData(applicationPackage1.Data, applicationPackage2.Data);
            //2.Delete
            await applicationPackage1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
