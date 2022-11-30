// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchApplicationCollectionTests : BatchManagementTestBase
    {
        private ResourceIdentifier _batchAccountId;
        private BatchAccountResource _batchAccountResource;

        public BatchApplicationCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgName = SessionRecording.GenerateAssetName("testrg-batch");
            var storageAccountName = SessionRecording.GenerateAssetName("azstorageforbatch");
            var batchAccountName = SessionRecording.GenerateAssetName("testaccount");
            if (Mode == RecordedTestMode.Playback)
            {
                _batchAccountId = BatchAccountResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, batchAccountName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    var batchAccount = await CreateBatchAccount(rgLro.Value, batchAccountName, storage.Id);
                    _batchAccountId = batchAccount.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _batchAccountResource = await Client.GetBatchAccountResource(_batchAccountId).GetAsync();
        }

        [TestCase]
        public async Task ApplicationCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = _batchAccountResource.GetBatchApplications();
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
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
