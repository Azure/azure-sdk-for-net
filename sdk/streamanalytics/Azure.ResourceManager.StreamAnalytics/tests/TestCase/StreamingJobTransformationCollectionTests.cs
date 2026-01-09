// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.StreamAnalytics.Models;
using Azure.ResourceManager.StreamAnalytics.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.StreamAnalytics.Tests.TestCase
{
    public class StreamingJobTransformationCollectionTests : StreamAnalyticsManagementTestBase
    {
        public StreamingJobTransformationCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<StreamingJobTransformationCollection> GetStreamingJobTransformationCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetStreamingJobs();
            var input = ResourceDataHelpers.GetStreamingJobData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, "testJob-", input);
            var job = lro.Value;
            return job.GetStreamingJobTransformations();
        }

        [TestCase]
        [RecordedTest]
        public async Task StreamingJobTransformationApiTests()
        {
            //1.CreateorUpdate
            var container = await GetStreamingJobTransformationCollectionAsync();
            var name = Recording.GenerateAssetName("streamingTransformation-");
            var input = ResourceDataHelpers.GetStreamingJobTransformation();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            StreamingJobTransformationResource transform1 = lro.Value;
            Assert.That(transform1.Data.Name, Is.EqualTo(name));
            //2.Get
            StreamingJobTransformationResource transform2 = await container.GetAsync(name);
            ResourceDataHelpers.AssertTransformation(transform1.Data, transform2.Data);
            Assert.Multiple(async () =>
            {
                //3.Exists
                Assert.That((bool)await container.ExistsAsync(name), Is.True);
                Assert.That((bool)await container.ExistsAsync(name + "1"), Is.False);
            });

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
