// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchApplicationPackageCollectionTests : BatchManagementTestBase
    {
        private ResourceIdentifier _batchApplicationId;
        private BatchApplicationResource _batchApplicationResource;

        public BatchApplicationPackageCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("https://fakeaccount.blob.core.windows.net") { JsonPath = "properties.storageUrl" });
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgName = SessionRecording.GenerateAssetName("testrg-batch");
            var storageAccountName = SessionRecording.GenerateAssetName("azstorageforbatch");
            var batchAccountName = SessionRecording.GenerateAssetName("testaccount");
            var applicationName = SessionRecording.GenerateAssetName("testApplication-");
            if (Mode == RecordedTestMode.Playback)
            {
                _batchApplicationId = BatchApplicationResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, batchAccountName, applicationName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    var batchAccount = await CreateBatchAccount(rgLro.Value, batchAccountName, storage.Id);
                    var applicationInput = ResourceDataHelper.GetBatchApplicationData();
                    var lro = await batchAccount.GetBatchApplications().CreateOrUpdateAsync(WaitUntil.Completed, applicationName, applicationInput);
                    _batchApplicationId = lro.Value.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _batchApplicationResource = await Client.GetBatchApplicationResource(_batchApplicationId).GetAsync();
        }

        [TestCase]
        public async Task ApplicationPackageCollectionApiTests()
        {
            //1.CreateOrUpdate
            var container = _batchApplicationResource.GetBatchApplicationPackages();
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
            //4Exists
            Assert.IsTrue(await container.ExistsAsync(name));
            Assert.IsFalse(await container.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
