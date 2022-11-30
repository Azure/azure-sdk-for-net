// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaTransformJobTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaTransformIdentifier;
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaTransformResource _mediaTransform;
        private MediaServicesAccountResource _mediaService;

        private MediaJobCollection mediaTransformJobCollection => _mediaTransform.GetMediaJobs();

        public MediaTransformJobTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);
            var storageAccountName = SessionRecording.GenerateAssetName(StorageAccountNamePrefix);
            var mediaServiceName = SessionRecording.GenerateAssetName("dotnetsdkmediatest");
            var mediaTransformName = SessionRecording.GenerateAssetName("randomtransfer");
            if (Mode == RecordedTestMode.Playback)
            {
                _mediaServiceIdentifier = MediaServicesAccountResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, mediaServiceName);
                _mediaTransformIdentifier = MediaTransformResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, mediaServiceName, mediaTransformName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    var mediaService = await CreateMediaService(rgLro.Value, mediaServiceName, storage.Id);
                    var mediaTransform = await CreateMediaTransfer(mediaService.GetMediaTransforms(), mediaTransformName);
                    _mediaServiceIdentifier = mediaService.Id;
                    _mediaTransformIdentifier = mediaTransform.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaService = await Client.GetMediaServicesAccountResource(_mediaServiceIdentifier).GetAsync();
            _mediaTransform = await Client.GetMediaTransformResource(_mediaTransformIdentifier).GetAsync();
        }

        private async Task<MediaJobResource> CreateDefautMediaTransferJob(string jobName)
        {
            // create two asset
            var inputAsset = await _mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("empty-asset-input"), new MediaAssetData());
            var outputAsset = await _mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("empty-asset-output"), new MediaAssetData());

            MediaJobData data = new MediaJobData();
            data.Input = new MediaJobInputAsset(inputAsset.Value.Data.Name);
            data.Outputs.Add(new MediaJobOutputAsset(outputAsset.Value.Data.Name));
            var job = await mediaTransformJobCollection.CreateOrUpdateAsync(WaitUntil.Completed, jobName, data);
            return job.Value;
        }

        [Test]
        [RecordedTest]
        public async Task MediaTransformJobBasicTests()
        {
            // Create
            string jobName = Recording.GenerateAssetName("job");
            var job = await CreateDefautMediaTransferJob(jobName);
            Assert.IsNotNull(job);
            Assert.AreEqual(jobName, job.Data.Name);
            // Check exists
            bool flag = await mediaTransformJobCollection.ExistsAsync(jobName);
            Assert.IsTrue(flag);
            // Get
            var result = await mediaTransformJobCollection.GetAsync(jobName);
            Assert.IsNotNull(result);
            Assert.AreEqual(jobName, result.Value.Data.Name);
            // Get all
            var list = await mediaTransformJobCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            // Cancel
            while (result.Value.Data.State != MediaJobState.Canceled)
            {
                var cancelResult = await job.CancelJobAsync();
                Assert.IsTrue(cancelResult.Status == 200);
                result = await mediaTransformJobCollection.GetAsync(jobName);
                Assert.IsNotNull(result);
            }
            // Delete
            await job.DeleteAsync(WaitUntil.Completed);
            flag = await mediaTransformJobCollection.ExistsAsync(jobName);
            Assert.IsFalse(flag);
        }
    }
}
