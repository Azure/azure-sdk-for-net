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
    public class BatchAccountCertificateOperationTests : BatchManagementTestBase
    {
        private ResourceIdentifier _batchAccountId;
        private BatchAccountResource _batchAccountResource;

        public BatchAccountCertificateOperationTests(bool isAsync)
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
        public async Task CertificateResourceApiTests()
        {
            //1.Get
            var certificateName = "sha1-cff2ab63c8c955aaf71989efa641b906558d9fb7";
            var certificateContainer = _batchAccountResource.GetBatchAccountCertificates();
            var certificateInput = ResourceDataHelper.GetBatchAccountCertificateData();
            var lro = await certificateContainer.CreateOrUpdateAsync(WaitUntil.Completed, certificateName, certificateInput);
            var certificate1 = lro.Value;
            BatchAccountCertificateResource certificate2 = await certificate1.GetAsync();

            ResourceDataHelper.AssertCertificate(certificate1.Data, certificate2.Data);
            //2.Delete
            await certificate1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
