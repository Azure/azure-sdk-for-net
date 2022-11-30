// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchAccountCollectionTests : BatchManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _storageAccountIdentifier;
        private ResourceGroupResource _resourceGroup;

        public BatchAccountCollectionTests(bool isAsync)
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
                _resourceGroupIdentifier = ResourceGroupResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName);
                _storageAccountIdentifier = StorageAccountResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, storageAccountName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    _resourceGroupIdentifier = rgLro.Value.Data.Id;
                    _storageAccountIdentifier = storage.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TestCase]
        public async Task AccountCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = _resourceGroup.GetBatchAccounts();
            var name = Recording.GenerateAssetName("account");
            var name2 = Recording.GenerateAssetName("account");
            var name3 = Recording.GenerateAssetName("account");
            var input = ResourceDataHelper.GetBatchAccountData(_storageAccountIdentifier);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountResource account1 = lro.Value;
            Assert.AreEqual(name, account1.Data.Name);
            //2.Get
            BatchAccountResource account2 = await collection.GetAsync(name);
            ResourceDataHelper.AssertAccount(account1.Data, account2.Data);
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
