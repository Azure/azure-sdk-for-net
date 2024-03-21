// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryPipelineRunTests : DataFactoryManagementTestBase
    {
        public DataFactoryPipelineRunTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        [Ignore("Pending recording")]
        public async Task GetPipelineRuns()
        {
            string subscriptionId = "xxx";
            string resourceGroupName = "test";
            string factoryName = "test";
            ResourceIdentifier dataFactoryResourceId = DataFactoryResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, factoryName);
            DataFactoryResource dataFactory = GetArmClient().GetDataFactoryResource(dataFactoryResourceId);

            RunFilterContent content = new RunFilterContent(DateTimeOffset.Parse("2024-02-27T00:36:44.3345758Z"), DateTimeOffset.Parse("2024-06-16T00:49:48.3686473Z"));
            int count = 0;
            await foreach (DataFactoryPipelineRunInfo item in dataFactory.GetPipelineRunsAsync(content))
            {
                count++;
            }

            Console.WriteLine($"Total count: {count}");
        }
    }
}
