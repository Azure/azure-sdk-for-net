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
            var expectedFactory = new Factory(location: FactoryLocation);

            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
#region DataFactoryTests
                AzureOperationResponse<Factory> createResponse = await client.Factories.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, expectedFactory);
                this.ValidateFactory(createResponse.Body, this.DataFactoryName);
                Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);

                var tags = new Dictionary<string, string>
                {
                    { "exampleTag", "exampleValue" }
                };
                AzureOperationResponse<Factory> updateResponse = await client.Factories.UpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, new FactoryUpdateParameters { Tags = tags });
                this.ValidateFactory(updateResponse.Body, this.DataFactoryName);
                Assert.Equal(HttpStatusCode.OK, updateResponse.Response.StatusCode);

                AzureOperationResponse<Factory> getResponse = await client.Factories.GetWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName);
                this.ValidateFactory(getResponse.Body, this.DataFactoryName);
                Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);

                AzureOperationResponse<IPage<Factory>> listByResourceGroupResponse = await client.Factories.ListByResourceGroupWithHttpMessagesAsync(this.ResourceGroupName);
                this.ValidateFactory(listByResourceGroupResponse.Body.First(), this.DataFactoryName);
                Assert.Equal(HttpStatusCode.OK, listByResourceGroupResponse.Response.StatusCode);

                AzureOperationResponse<IPage<Factory>> listResponse = await client.Factories.ListByResourceGroupWithHttpMessagesAsync(this.ResourceGroupName);
                this.ValidateFactory(listResponse.Body.First(), this.DataFactoryName);
                Assert.Equal(HttpStatusCode.OK, listResponse.Response.StatusCode);
#endregion

#region LinkedServiceTests
                var expectedLinkedService = GetLinkedServiceResource(null);

                AzureOperationResponse<LinkedServiceResource> createLinkServiceResponse = await client.LinkedServices.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, linkedServiceName, expectedLinkedService);
                this.ValidateLinkedService(expectedLinkedService, createLinkServiceResponse.Body, linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, createLinkServiceResponse.Response.StatusCode);

                var updatedLinkedService = GetLinkedServiceResource("linkedService description");
                AzureOperationResponse<LinkedServiceResource> updateLinkServiceResponse = await client.LinkedServices.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, linkedServiceName, updatedLinkedService);
                this.ValidateLinkedService(updatedLinkedService, updateLinkServiceResponse.Body, linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, updateLinkServiceResponse.Response.StatusCode);

                AzureOperationResponse<LinkedServiceResource> getLinkedServiceResponse = await client.LinkedServices.GetWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, linkedServiceName);
                this.ValidateLinkedService(updatedLinkedService, getLinkedServiceResponse.Body, linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);

                AzureOperationResponse<IPage<LinkedServiceResource>> listLinkedServiceResponse = await client.LinkedServices.ListByFactoryWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName);
                this.ValidateLinkedService(updatedLinkedService, listLinkedServiceResponse.Body.First(), linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, listLinkedServiceResponse.Response.StatusCode);
#endregion


#region DatasetTests
                DatasetResource expectedDataset = GetDatasetResource(null);

                AzureOperationResponse<DatasetResource> createDatasetResponse = await client.Datasets.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, datasetName, expectedDataset);
                this.ValidateDataset(expectedDataset, createDatasetResponse.Body, datasetName);
                Assert.Equal(HttpStatusCode.OK, createDatasetResponse.Response.StatusCode);

                DatasetResource updatedDataset = GetDatasetResource("dataset description");
                AzureOperationResponse<DatasetResource> updateDatasetResponse = await client.Datasets.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, datasetName, updatedDataset);
                this.ValidateDataset(updatedDataset, updateDatasetResponse.Body, datasetName);
                Assert.Equal(HttpStatusCode.OK, updateDatasetResponse.Response.StatusCode);

                AzureOperationResponse<DatasetResource> getDatasetResponse = await client.Datasets.GetWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, datasetName);
                this.ValidateDataset(updatedDataset, updateDatasetResponse.Body, datasetName);
                Assert.Equal(HttpStatusCode.OK, updateDatasetResponse.Response.StatusCode);

                AzureOperationResponse<IPage<DatasetResource>> listDatasetResponse = await client.Datasets.ListByFactoryWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName);
                this.ValidateDataset(updatedDataset, listDatasetResponse.Body.First(), datasetName);
                Assert.Equal(HttpStatusCode.OK, listDatasetResponse.Response.StatusCode);
#endregion

#region PipelineTests
                PipelineResource expectedPipeline = GetPipelineResource(null);
                AzureOperationResponse<PipelineResource> createPipelineResponse = await client.Pipelines.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, pipelineName, expectedPipeline);
                this.ValidatePipeline(expectedPipeline, createPipelineResponse.Body, pipelineName);
                Assert.Equal(HttpStatusCode.OK, createPipelineResponse.Response.StatusCode);

                PipelineResource updatedPipeline = GetPipelineResource("pipeline description");
                AzureOperationResponse<PipelineResource> updatePipelineResponse = await client.Pipelines.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, pipelineName, updatedPipeline);
                this.ValidatePipeline(updatedPipeline, createPipelineResponse.Body, pipelineName);
                Assert.Equal(HttpStatusCode.OK, createPipelineResponse.Response.StatusCode);

                AzureOperationResponse<PipelineResource> getPipelineResponse = await client.Pipelines.GetWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, pipelineName);
                this.ValidatePipeline(updatedPipeline, createPipelineResponse.Body, pipelineName);
                Assert.Equal(HttpStatusCode.OK, createPipelineResponse.Response.StatusCode);

                AzureOperationResponse<IPage<PipelineResource>> listPipelineResponse = await client.Pipelines.ListByFactoryWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName);
                this.ValidatePipeline(updatedPipeline, listPipelineResponse.Body.First(), pipelineName);
                Assert.Equal(HttpStatusCode.OK, listPipelineResponse.Response.StatusCode);
#endregion

#region TriggerTests
                TriggerResource expectedTrigger = this.GetTriggerResource(null);
                AzureOperationResponse<TriggerResource> createTriggerResponse = await client.Triggers.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, triggerName, expectedTrigger);
                this.ValidateTrigger(expectedTrigger, createTriggerResponse.Body, triggerName);
                Assert.Equal(HttpStatusCode.OK, createTriggerResponse.Response.StatusCode);

                TriggerResource updatedTrigger = GetTriggerResource("trigger description");
                AzureOperationResponse<TriggerResource> updateTriggerResponse = await client.Triggers.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, triggerName, updatedTrigger);
                this.ValidateTrigger(updatedTrigger, updateTriggerResponse.Body, triggerName);
                Assert.Equal(HttpStatusCode.OK, updateTriggerResponse.Response.StatusCode);

                AzureOperationResponse<TriggerResource> getTriggerResponse = await client.Triggers.GetWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, triggerName);
                this.ValidateTrigger(updatedTrigger, getTriggerResponse.Body, triggerName);
                Assert.Equal(HttpStatusCode.OK, getTriggerResponse.Response.StatusCode);
#endregion

#region TestCleanup
                // Triggers - delete
                AzureOperationResponse deleteTriggerResponse = await client.Triggers.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, triggerName);
                Assert.Equal(HttpStatusCode.OK, deleteTriggerResponse.Response.StatusCode);
                deleteTriggerResponse = await client.Triggers.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, triggerName);
                Assert.Equal(HttpStatusCode.NoContent, deleteTriggerResponse.Response.StatusCode);

                // Pipelines - delete
                AzureOperationResponse deletePipelineResponse = await client.Pipelines.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, pipelineName);
                Assert.Equal(HttpStatusCode.OK, deletePipelineResponse.Response.StatusCode);
                deletePipelineResponse = await client.Pipelines.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, pipelineName);
                Assert.Equal(HttpStatusCode.NoContent, deletePipelineResponse.Response.StatusCode);

                // Datasets - delete
                AzureOperationResponse deleteDatasetResponse = await client.Datasets.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, datasetName);
                Assert.Equal(HttpStatusCode.OK, deleteDatasetResponse.Response.StatusCode);
                deleteDatasetResponse = await client.Datasets.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, datasetName);
                Assert.Equal(HttpStatusCode.NoContent, deleteDatasetResponse.Response.StatusCode);

                // LinkedServices - delete
                AzureOperationResponse deleteLinkedResponse = await client.LinkedServices.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, deleteLinkedResponse.Response.StatusCode);
                deleteLinkedResponse = await client.LinkedServices.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, linkedServiceName);
                Assert.Equal(HttpStatusCode.NoContent, deleteLinkedResponse.Response.StatusCode);

                // Factories -- delete
                AzureOperationResponse deleteFactoriesResponse = await client.Factories.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName);
                Assert.Equal(HttpStatusCode.OK, deleteFactoriesResponse.Response.StatusCode);
                deleteFactoriesResponse = await client.Factories.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName);
                Assert.Equal(HttpStatusCode.NoContent, deleteFactoriesResponse.Response.StatusCode);

                // Factories -- list (again)
                IPage<Factory> page = client.Factories.List();
                AzureOperationResponse<IPage<Factory>> listFactoriesResponse = await client.Factories.ListWithHttpMessagesAsync();
                Assert.Equal(HttpStatusCode.OK, listFactoriesResponse.Response.StatusCode);
                #endregion
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
            };

            await this.RunTest(action, finallyAction);
        }

        private void ValidateFactory(Factory actualFactory, string expectedFactoryName)
        {
            Assert.Equal(expectedFactoryName, actualFactory.Name);
            Assert.Equal(FactoryLocation, actualFactory.Location);
            Assert.Equal("Succeeded", actualFactory.ProvisioningState);
        }

        private void ValidateLinkedService(LinkedServiceResource expected, LinkedServiceResource actual, string expectedName)
        {
            this.ValidateSubResource(actual, this.DataFactoryName, expectedName, "linkedservices");
            Assert.IsType<AzureDataLakeStoreLinkedService>(actual.Properties);
            Assert.Equal(((AzureDataLakeStoreLinkedService)expected.Properties).DataLakeStoreUri, ((AzureDataLakeStoreLinkedService)actual.Properties).DataLakeStoreUri);
        }

        private void ValidateDataset(DatasetResource expected, DatasetResource actual, string expectedName)
        {
            this.ValidateSubResource(actual, this.DataFactoryName, expectedName, "datasets");
            Assert.IsType<AzureBlobDataset>(actual.Properties);
        }

        private void ValidatePipeline(PipelineResource expected, PipelineResource actual, string expectedName)
        {
            this.ValidateSubResource(actual, this.DataFactoryName, expectedName, "pipelines");
            Assert.IsType<List<Activity>> (actual.Activities);
            Activity activity = expected.Activities.First();
            Assert.Equal(((Activity)expected.Activities.First()).Name, ((Activity)actual.Activities.First()).Name);
        }

        private void ValidateTrigger(TriggerResource expected, TriggerResource actual, string expectedName)
        {
            this.ValidateSubResource(actual, this.DataFactoryName, expectedName, "triggers");
            Assert.IsType<ScheduleTrigger>(actual.Properties);
            Assert.Equal(((ScheduleTrigger)expected.Properties).Recurrence.Frequency, ((ScheduleTrigger)actual.Properties).Recurrence.Frequency);
            Assert.Equal(((ScheduleTrigger)expected.Properties).Recurrence.Interval, ((ScheduleTrigger)actual.Properties).Recurrence.Interval);
        }

        private PipelineResource GetPipelineResource(string description)
        {
            PipelineResource resource = new PipelineResource
            {
                Description = description,
                Parameters = new Dictionary<string, ParameterSpecification>
                    {
                        { "OutputBlobNameList", new ParameterSpecification { Type = ParameterType.Array } }
                    },
                Activities = new List<Activity>()
            };
            CopyActivity copyActivity = new CopyActivity
            {
                Name = "ExampleCopyActivity",
                Inputs = new List<DatasetReference>
                            {
                                new DatasetReference
                                {
                                    ReferenceName = datasetName,
                                    Parameters = new Dictionary<string, object>()
                                    {
                                        { "MyFolderPath", "BlobContainerName"}, // todo: secrets.BlobContainerName
                                        { "MyFileName",  "entitylogs.csv"}
                                    }
                                }
                            },
                Outputs = new List<DatasetReference>
                            {
                                new DatasetReference
                                {
                                    ReferenceName = datasetName,
                                    Parameters = new Dictionary<string, object>()
                                    {
                                        { "MyFolderPath", "BlobContainerName"},
                                        { "MyFileName",  new Expression("@item()")}
                                    }
                                }
                            },
                Source = new BlobSource
                {
                },
                Sink = new BlobSink
                {
                }
            };
            ForEachActivity forEachActivity = new ForEachActivity
            {
                Name = "ExampleForeachActivity",
                IsSequential = true,
                Items = new Expression("@pipeline().parameters.OutputBlobNameList"),
                Activities = new List<Activity>() { copyActivity }
            };
            resource.Activities.Add(forEachActivity);
            return resource;
        }

        private DatasetResource GetDatasetResource(string description)
        {
            DatasetResource resource = new DatasetResource
            {
                Properties = new AzureBlobDataset
                {
                    Description = description,
                    FolderPath = new Expression { Value = "@dataset().MyFolderPath" },
                    FileName = new Expression { Value = "@dataset().MyFileName" },
                    Format = new TextFormat(),
                    LinkedServiceName = new LinkedServiceReference
                    {
                        ReferenceName = linkedServiceName
                    },
                }
            };

            resource.Properties.Parameters = new Dictionary<string, ParameterSpecification>()
            {
                { "MyFolderPath",  new ParameterSpecification { Type = ParameterType.String } },
                { "MyFileName",  new ParameterSpecification { Type = ParameterType.String } }
            };

            return resource;
        }

        private LinkedServiceResource GetLinkedServiceResource(string description)
        {
            LinkedServiceResource resource = new LinkedServiceResource
            {
                Properties = new AzureDataLakeStoreLinkedService()
                {
                    Description = description,
                    DataLakeStoreUri = "adl://test.azuredatalakestore.net/"
                }
            };
            return resource;
        }

        private TriggerResource GetTriggerResource(string description)
        {
            TriggerResource resource = new TriggerResource()
            {
                Properties = new ScheduleTrigger()
                {
                    Description = description,
                    Recurrence = new ScheduleTriggerRecurrence()
                    {
                        TimeZone = "UTC",
                        StartTime = DateTime.UtcNow.AddMinutes(-1),
                        EndTime = DateTime.UtcNow.AddMinutes(15),
                        Frequency = RecurrenceFrequency.Minute,
                        Interval = 4,
                        Schedule = null
                    },
                    Pipelines = new List<TriggerPipelineReference>()
                }
            };

            TriggerPipelineReference triggerPipelineReference = new TriggerPipelineReference()
            {
                PipelineReference = new PipelineReference(pipelineName),
                Parameters = new Dictionary<string, object>()
            };

            string[] outputBlobNameList = new string[1];
            outputBlobNameList[0] = outputBlobName;

            JArray outputBlobNameArray = JArray.FromObject(outputBlobNameList);

            triggerPipelineReference.Parameters.Add("OutputBlobNameList", outputBlobNameArray);

            resource.Properties.Pipelines.Add(triggerPipelineReference);

            return resource;
        }

    }

}
