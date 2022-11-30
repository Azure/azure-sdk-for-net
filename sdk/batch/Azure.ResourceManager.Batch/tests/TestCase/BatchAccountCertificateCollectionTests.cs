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
    public class BatchAccountCertificateCollectionTests : BatchManagementTestBase
    {
        private ResourceIdentifier _batchAccountId;
        private BatchAccountResource _batchAccountResource;

        public BatchAccountCertificateCollectionTests(bool isAsync)
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
        public async Task CertificateCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = _batchAccountResource.GetBatchAccountCertificates();
            var name = "sha1-cff2ab63c8c955aaf71989efa641b906558d9fb7";
            var input = ResourceDataHelper.GetBatchAccountCertificateData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountCertificateResource certificate1 = lro.Value;
            Assert.AreEqual(name, certificate1.Data.Name);
            //2.Get
            BatchAccountCertificateResource certificate2 = await collection.GetAsync(name);
            ResourceDataHelper.AssertCertificate(certificate1.Data, certificate2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            int count = 0;
            await foreach (var account in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync("sha1-cff2ab63c8c955aaf71989efa641b906558d9fb8"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
