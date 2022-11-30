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
    public class StreamingJobFunctionOperationTests : StreamAnalyticsManagementTestBase
    {
        public StreamingJobFunctionOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<StreamingJobFunctionResource> CreateStreamingJobFunctionResourceAsync(string Name)
        {
            var container = (await CreateResourceGroupAsync()).GetStreamingJobs();
            var input = ResourceDataHelpers.GetStreamingJobData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Name, input);
            var job = lro.Value;
            var jobContainer = job.GetStreamingJobFunctions();
            var jobInput = ResourceDataHelpers.GetStreamingJobFunctionData();
            var lroEP = await jobContainer.CreateOrUpdateAsync(WaitUntil.Completed, Name, jobInput);
            return lroEP.Value;
        }

        [TestCase]
        public async Task StreamingJobFunctionApiTests()
        {
            //1.Get
            var Name = Recording.GenerateAssetName("testJob-");
            var function1 = await CreateStreamingJobFunctionResourceAsync(Name);
            StreamingJobFunctionResource function2 = await function1.GetAsync();

            ResourceDataHelpers.AssertFunction(function1.Data, function2.Data);
            //2.Delete
            await function1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
