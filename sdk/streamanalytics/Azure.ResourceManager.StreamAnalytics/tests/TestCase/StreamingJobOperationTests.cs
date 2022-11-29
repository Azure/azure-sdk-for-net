// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class StreamingJobOperationTests : StreamAnalyticsManagementTestBase
    {
        public StreamingJobOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<StreamingJobResource> CreateStreamingJobResourceAsync(string Name)
        {
            var container = (await CreateResourceGroupAsync()).GetStreamingJobs();
            var input = ResourceDataHelpers.GetStreamingJobData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Name, input);
            return lro.Value;
        }

        [TestCase]
        public async Task StreamingJobOperationApiTests()
        {
            //1.Get
            var Name = Recording.GenerateAssetName("testStreamingJob-");
            var job1 = await CreateStreamingJobResourceAsync(Name);
            StreamingJobResource job2 = await job1.GetAsync();

            ResourceDataHelpers.AssertJob(job1.Data, job2.Data);
            //2.Delete
            await job1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
