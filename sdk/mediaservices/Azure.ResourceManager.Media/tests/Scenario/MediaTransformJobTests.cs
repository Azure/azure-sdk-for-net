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
        private MediaServicesAccountResource _mediaService;
        private MediaTransformResource _mediaTransform;

        private MediaJobCollection mediaTransformJobCollection => _mediaTransform.GetMediaJobs();

        public MediaTransformJobTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName(MediaServiceAccountPrefix);
            var mediaTransformName = Recording.GenerateAssetName("randomtransfer");
            _mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
            _mediaTransform = await CreateMediaTransfer(_mediaService, mediaTransformName);
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
            Assert.That(job, Is.Not.Null);
            Assert.That(job.Data.Name, Is.EqualTo(jobName));
            // Check exists
            bool flag = await mediaTransformJobCollection.ExistsAsync(jobName);
            Assert.That(flag, Is.True);
            // Get
            var result = await mediaTransformJobCollection.GetAsync(jobName);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.Data.Name, Is.EqualTo(jobName));
            // Get all
            var list = await mediaTransformJobCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            // Cancel
            while (result.Value.Data.State != MediaJobState.Canceled)
            {
                var cancelResult = await job.CancelJobAsync();
                Assert.That(cancelResult.Status, Is.EqualTo(200));
                result = await mediaTransformJobCollection.GetAsync(jobName);
                Assert.That(result, Is.Not.Null);
            }
            // Delete
            await job.DeleteAsync(WaitUntil.Completed);
            flag = await mediaTransformJobCollection.ExistsAsync(jobName);
            Assert.That(flag, Is.False);
        }
    }
}
