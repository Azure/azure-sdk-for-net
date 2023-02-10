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
    public class StreamingJobOutputCollectionTests : StreamAnalyticsManagementTestBase
    {
        public StreamingJobOutputCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<StreamingJobOutputCollection> GetStreamingJobOutputCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetStreamingJobs();
            var input = ResourceDataHelpers.GetStreamingJobData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, "testJob-", input);
            var job = lro.Value;
            return job.GetStreamingJobOutputs();
        }

        [TestCase]
        [RecordedTest]
        public async Task StreamingJobOutputApiTests()
        {
            //1.CreateorUpdate
            var container = await GetStreamingJobOutputCollectionAsync();
            var name = Recording.GenerateAssetName("streamingJobOutput-");
            var input = ResourceDataHelpers.GetStreamingJobOutputData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            StreamingJobOutputResource output1 = lro.Value;
            Assert.AreEqual(name, output1.Data.Name);
            //2.Get
            StreamingJobOutputResource output2 = await container.GetAsync(name);
            ResourceDataHelpers.AssertOutput(output1.Data, output2.Data);
            //3.GetAll
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            int count = 0;
            await foreach (var account in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4Exists
            Assert.IsTrue(await container.ExistsAsync(name));
            Assert.IsFalse(await container.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
