// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class DataFactoryE2EScenarioTests : ScenarioTestBase<DataFactoryE2EScenarioTests>
    {
        private const string linkedServiceName = "TestDataLakeStore";
        private const string datasetName = "TestDataset";
        private const string pipelineName = "TestPipeline";
        private const string triggerName = "TestTrigger";
        private const string outputBlobName = "TestOutput.csv";

        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task DataFactoryE2E()
        {
            Factory expectedFactory = new Factory(location: FactoryLocation);

            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
#region DataFactoryTests
                await DataFactoryScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, expectedFactory);

                var tags = new Dictionary<string, string>
                {
                    { "exampleTag", "exampleValue" }
                };
                await DataFactoryScenarioTests.Update(client, this.ResourceGroupName, this.DataFactoryName, expectedFactory, new FactoryUpdateParameters { Tags = tags });
#endregion

#region LinkedServiceTests
                var expectedLinkedService = LinkedServiceScenarioTests.GetLinkedServiceResource(null);
                await LinkedServiceScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName, expectedLinkedService);

                var updatedLinkedService = LinkedServiceScenarioTests.GetLinkedServiceResource("linkedService description");
                await LinkedServiceScenarioTests.Update(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName, updatedLinkedService);

                await LinkedServiceScenarioTests.GetList(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName, updatedLinkedService);
#endregion

#region DatasetTests
                DatasetResource expectedDataset = DatasetScenarioTests.GetDatasetResource(null, linkedServiceName);
                await DatasetScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, datasetName, expectedDataset);
                await DatasetScenarioTests.GetList(client, this.ResourceGroupName, this.DataFactoryName, datasetName, expectedDataset);

                DatasetResource updatedDataset = DatasetScenarioTests.GetDatasetResource("dataset description", linkedServiceName);
                await DatasetScenarioTests.Update(client, this.ResourceGroupName, this.DataFactoryName, datasetName, updatedDataset);
                await DatasetScenarioTests.GetList(client, this.ResourceGroupName, this.DataFactoryName, datasetName, updatedDataset);
#endregion

#region PipelineTests
                PipelineResource expectedPipeline = PipelineScenarioTests.GetPipelineResource(null, datasetName);

                await PipelineScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, pipelineName, expectedPipeline);
                await PipelineScenarioTests.GetList(client, this.ResourceGroupName, this.DataFactoryName, pipelineName, expectedPipeline);

                PipelineResource updatedPipeline = PipelineScenarioTests.GetPipelineResource("pipeline description", datasetName);
                await PipelineScenarioTests.Update(client, this.ResourceGroupName, this.DataFactoryName, pipelineName, updatedPipeline);
                await PipelineScenarioTests.GetList(client, this.ResourceGroupName, this.DataFactoryName, pipelineName, updatedPipeline);
#endregion

#region TriggerTests
                TriggerResource expectedTrigger = TriggerScenarioTests.GetTriggerResource(null, pipelineName, outputBlobName);
                await TriggerScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, triggerName, expectedTrigger);
                await TriggerScenarioTests.GetList(client, this.ResourceGroupName, this.DataFactoryName, triggerName, expectedTrigger);

                TriggerResource updatedTrigger = TriggerScenarioTests.GetTriggerResource("trigger description", pipelineName, outputBlobName);
                await TriggerScenarioTests.Update(client, this.ResourceGroupName, this.DataFactoryName, triggerName, updatedTrigger);
                await TriggerScenarioTests.GetList(client, this.ResourceGroupName, this.DataFactoryName, triggerName, updatedTrigger);
                #endregion

#region TestCleanup

                await TriggerScenarioTests.Delete(client, this.ResourceGroupName, this.DataFactoryName, triggerName);

                await PipelineScenarioTests.Delete(client, this.ResourceGroupName, this.DataFactoryName, pipelineName);

                await DatasetScenarioTests.Delete(client, this.ResourceGroupName, this.DataFactoryName, datasetName);

                await LinkedServiceScenarioTests.Delete(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName);

                await DataFactoryScenarioTests.Delete(client, this.ResourceGroupName, this.DataFactoryName);

#endregion
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
            };

            await this.RunTest(action, finallyAction);
        }
    }
}

