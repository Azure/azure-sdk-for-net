// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchApplicationPackageOperationTests : BatchManagementTestBase
    {
        private BatchApplicationPackageResource _batchApplicationPackage;

        public BatchApplicationPackageOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("properties.storageUrl") { Value = "https://fakeaccount.blob.core.windows.net" });
        }

        [SetUp]
        public async Task SetUp()
        {
            var batchAccountName = Recording.GenerateAssetName("testaccount");
            var applicationName = Recording.GenerateAssetName("testApplication-");
            var applicationPackageName = Recording.GenerateAssetName("testApplicationPackage-");
            var batchAccount = await CreateBatchAccount(ResourceGroup, batchAccountName, StorageAccountIdentifier);
            var batchApplication = await CreateBatchApplication(batchAccount, applicationName);
            _batchApplicationPackage = await CreateBatchApplicationPackage(batchApplication, applicationPackageName);
        }

        [TestCase]
        public async Task ApplicationPackageResourceApiTests()
        {
            //1.Get
            BatchApplicationPackageResource applicationPackage = await _batchApplicationPackage.GetAsync();

            ResourceDataHelper.AssertApplicationPckageData(_batchApplicationPackage.Data, applicationPackage.Data);
            //2.Delete
            await _batchApplicationPackage.DeleteAsync(WaitUntil.Completed);
        }
    }
}
