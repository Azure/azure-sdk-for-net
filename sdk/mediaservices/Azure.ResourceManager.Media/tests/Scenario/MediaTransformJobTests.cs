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

        private MediaTransformJobCollection mediaTransformJobCollection => _mediaTransform.GetMediaTransformJobs();

        public MediaTransformJobTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(rgLro.Value, SessionRecording.GenerateAssetName("mediafortjob"), storage.Id);
            var mediaTransform = await CreateMediaTransfer(mediaService.GetMediaTransforms(), SessionRecording.GenerateAssetName("randomtransfer"));
            _mediaServiceIdentifier = mediaService.Id;
            _mediaTransformIdentifier = mediaTransform.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaService = await Client.GetMediaServicesAccountResource(_mediaServiceIdentifier).GetAsync();
            _mediaTransform = await Client.GetMediaTransformResource(_mediaTransformIdentifier).GetAsync();
        }

        private async Task<MediaTransformJobResource> CreateDefautMediaTransferJob(string jobName)
        {
            // create two asset
            var inputAsset = await _mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("empty-asset-input"), new MediaAssetData());
            var outputAsset = await _mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("empty-asset-output"), new MediaAssetData());

            MediaTransformJobData data = new MediaTransformJobData();
            data.Input = new MediaTransformJobInputAsset(inputAsset.Value.Data.Name);
            data.Outputs.Add(new MediaTransformJobOutputAsset(outputAsset.Value.Data.Name));
            var job = await mediaTransformJobCollection.CreateOrUpdateAsync(WaitUntil.Completed, jobName, data);
            return job.Value;
        }

        [Test]
        [RecordedTest]
        public async Task MediaTransformJobBasicTests()
        {
            // Create
            string jobName = SessionRecording.GenerateAssetName("job");
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
            while (result.Value.Data.State != JobState.Canceled)
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
