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
    public class BatchAccountPoolOperationTests : BatchManagementTestBase
    {
        private ResourceIdentifier _batchAccountPoolId;
        private BatchAccountPoolResource _batchAccountPoolResource;

        public BatchAccountPoolOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgName = SessionRecording.GenerateAssetName("testrg-batch");
            var storageAccountName = SessionRecording.GenerateAssetName("azstorageforbatch");
            var batchAccountName = SessionRecording.GenerateAssetName("testaccount");
            var poolName = SessionRecording.GenerateAssetName("testPool-");
            if (Mode == RecordedTestMode.Playback)
            {
                _batchAccountPoolId = BatchAccountPoolResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, batchAccountName, poolName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    var batchAccount = await CreateBatchAccount(rgLro.Value, batchAccountName, storage.Id);
                    var poolInput = ResourceDataHelper.GetBatchAccountPoolData();
                    var lro = await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, poolName, poolInput);
                    _batchAccountPoolId = lro.Value.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _batchAccountPoolResource = await Client.GetBatchAccountPoolResource(_batchAccountPoolId).GetAsync();
        }

        [TestCase]
        public async Task PoolResourceApiTests()
        {
            //1.Get
            BatchAccountPoolResource pool2 = await _batchAccountPoolResource.GetAsync();

            ResourceDataHelper.AssertPoolData(_batchAccountPoolResource.Data, pool2.Data);
            //2.Delete
            await _batchAccountPoolResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
