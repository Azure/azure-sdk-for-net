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
    public class StreamingJobOutputOperationTests : StreamAnalyticsManagementTestBase
    {
        public StreamingJobOutputOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<StreamingJobOutputResource> CreateStreamingJobOutputResourceAsync(string Name)
        {
            var container = (await CreateResourceGroupAsync()).GetStreamingJobs();
            var input = ResourceDataHelpers.GetStreamingJobData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Name, input);
            var job = lro.Value;
            var jobContainer = job.GetStreamingJobOutputs();
            var jobOutput = ResourceDataHelpers.GetStreamingJobOutputData();
            var lroEP = await jobContainer.CreateOrUpdateAsync(WaitUntil.Completed, Name, jobOutput);
            return lroEP.Value;
        }

        [TestCase]
        public async Task StreamingJobOutputOperationApiTests()
        {
            //1.Get
            var Name = Recording.GenerateAssetName("testJobOutput-");
            var output1 = await CreateStreamingJobOutputResourceAsync(Name);
            StreamingJobOutputResource output2 = await output1.GetAsync();

            ResourceDataHelpers.AssertOutput(output1.Data, output2.Data);
            //2.Delete
            await output1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
