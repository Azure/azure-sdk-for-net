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
    public class BatchAccountOperationTests : BatchManagementTestBase
    {
        private ResourceIdentifier _batchAccountId;
        private BatchAccountResource _batchAccountResource;

        public BatchAccountOperationTests(bool isAsync)
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
        public async Task AccountResourceApiTests()
        {
            //1.Get
            BatchAccountResource account2 = await _batchAccountResource.GetAsync();

            ResourceDataHelper.AssertAccount(_batchAccountResource.Data, account2.Data);
            //2.Delete
            await _batchAccountResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
