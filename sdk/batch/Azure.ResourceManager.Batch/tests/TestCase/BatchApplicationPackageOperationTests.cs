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
    public class BatchApplicationPackageOperationTests : BatchManagementTestBase
    {
        private ResourceIdentifier _batchApplicationPackageId;
        private BatchApplicationPackageResource _batchApplicationPackageResource;

        public BatchApplicationPackageOperationTests(bool isAsync)
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
            var applicationPackageName = SessionRecording.GenerateAssetName("testApplicationPackage-");
            if (Mode == RecordedTestMode.Playback)
            {
                _batchApplicationPackageId = BatchApplicationPackageResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, batchAccountName, applicationName, applicationPackageName);
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
                    var applicationPackageInput = ResourceDataHelper.GetBatchApplicationPackageData();
                    var lrop = await lro.Value.GetBatchApplicationPackages().CreateOrUpdateAsync(WaitUntil.Completed, applicationPackageName, applicationPackageInput);
                    _batchApplicationPackageId = lrop.Value.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _batchApplicationPackageResource = await Client.GetBatchApplicationPackageResource(_batchApplicationPackageId).GetAsync();
        }

        [TestCase]
        public async Task ApplicationPackageResourceApiTests()
        {
            //1.Get
            BatchApplicationPackageResource applicationPackage2 = await _batchApplicationPackageResource.GetAsync();

            ResourceDataHelper.AssertApplicationPckageData(_batchApplicationPackageResource.Data, applicationPackage2.Data);
            //2.Delete
            await _batchApplicationPackageResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
