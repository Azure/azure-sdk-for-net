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
    public class StreamingJobInputOperationTests : StreamAnalyticsManagementTestBase
    {
        public StreamingJobInputOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<StreamingJobInputResource> CreateStreamingJobInputResourceAsync(string Name)
        {
            var container = (await CreateResourceGroupAsync()).GetStreamingJobs();
            var input = ResourceDataHelpers.GetStreamingJobData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Name, input);
            var jobInput = lro.Value;
            var jobInputContainer = jobInput.GetStreamingJobInputs();
            var jobInputInput = ResourceDataHelpers.GetStreamingJobInputData();
            var lroEP = await jobInputContainer.CreateOrUpdateAsync(WaitUntil.Completed, Name, jobInputInput);
            return lroEP.Value;
        }

        [TestCase]
        public async Task StreamingJobInputOperationApiTests()
        {
            //1.Get
            var Name = Recording.GenerateAssetName("testJobInput-");
            var jobInput1 = await CreateStreamingJobInputResourceAsync(Name);
            StreamingJobInputResource jobInput2 = await jobInput1.GetAsync();

            ResourceDataHelpers.AssertInput(jobInput1.Data, jobInput2.Data);
            //2.Delete
            await jobInput1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
