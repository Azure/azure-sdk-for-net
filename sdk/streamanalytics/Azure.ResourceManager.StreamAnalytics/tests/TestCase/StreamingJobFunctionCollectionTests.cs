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
    public class StreamingJobFunctionCollectionTests : StreamAnalyticsManagementTestBase
    {
        public StreamingJobFunctionCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<StreamingJobFunctionCollection> GetStreamingJobFunctionCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetStreamingJobs();
            var input = ResourceDataHelpers.GetStreamingJobData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, "testJob-", input);
            var job = lro.Value;
            return job.GetStreamingJobFunctions();
        }

        [TestCase]
        [RecordedTest]
        public async Task StreamingJobFunctionApiTests()
        {
            //1.CreateorUpdate
            var container = await GetStreamingJobFunctionCollectionAsync();
            var name = Recording.GenerateAssetName("streamingFunction-");
            var input = ResourceDataHelpers.GetStreamingJobFunctionData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            StreamingJobFunctionResource function1 = lro.Value;
            Assert.AreEqual(name, function1.Data.Name);
            //2.Get
            StreamingJobFunctionResource function2 = await container.GetAsync(name);
            ResourceDataHelpers.AssertFunction(function1.Data, function2.Data);
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
