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
    public class StreamingJobTransformationOperationTests : StreamAnalyticsManagementTestBase
    {
        public StreamingJobTransformationOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<StreamingJobTransformationResource> CreateStreamingJobTransformationResourceAsync(string Name)
        {
            var container = (await CreateResourceGroupAsync()).GetStreamingJobs();
            var input = ResourceDataHelpers.GetStreamingJobData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Name, input);
            var job = lro.Value;
            var jobContainer = job.GetStreamingJobTransformations();
            var jobInput = ResourceDataHelpers.GetStreamingJobTransformation();
            var lroEP = await jobContainer.CreateOrUpdateAsync(WaitUntil.Completed, Name, jobInput);
            return lroEP.Value;
        }

        [TestCase]
        public async Task StreamingJobFunctionOperationApiTests()
        {
            //1.Get
            var Name = Recording.GenerateAssetName("testTransformation-");
            var transformation1 = await CreateStreamingJobTransformationResourceAsync(Name);
            StreamingJobTransformationResource transformation2 = await transformation1.GetAsync();

            ResourceDataHelpers.AssertTransformation(transformation1.Data, transformation2.Data);
        }
    }
}
