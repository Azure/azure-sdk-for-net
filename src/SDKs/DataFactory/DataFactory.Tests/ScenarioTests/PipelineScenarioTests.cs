// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class PipelineScenarioTests : ScenarioTestBase<PipelineScenarioTests>
    {
        public static PipelineResource GetPipelineResource(string description, string datasetName)
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
                DataIntegrationUnits = 32,
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

        internal static async Task Create(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string pipelineName, PipelineResource expectedPipeline)
        {
            AzureOperationResponse<PipelineResource> createPipelineResponse = await client.Pipelines.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, pipelineName, expectedPipeline);
            ValidatePipeline(client, resourceGroupName, dataFactoryName, expectedPipeline, createPipelineResponse.Body, pipelineName);
            Assert.Equal(HttpStatusCode.OK, createPipelineResponse.Response.StatusCode);
        }

        internal static async Task Update(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string pipelineName, PipelineResource expectedPipeline)
        {
            AzureOperationResponse<PipelineResource> updatePipelineResponse = await client.Pipelines.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, pipelineName, expectedPipeline);
            ValidatePipeline(client, resourceGroupName, dataFactoryName, expectedPipeline, updatePipelineResponse.Body, pipelineName);
            Assert.Equal(HttpStatusCode.OK, updatePipelineResponse.Response.StatusCode);
        }

        internal static async Task Delete(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string pipelineName)
        {
            AzureOperationResponse deletePipelineResponse = await client.Pipelines.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName, pipelineName);
            Assert.Equal(HttpStatusCode.OK, deletePipelineResponse.Response.StatusCode);
            deletePipelineResponse = await client.Pipelines.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName, pipelineName);
            Assert.Equal(HttpStatusCode.NoContent, deletePipelineResponse.Response.StatusCode);
        }

        internal static async Task GetList(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string pipelineName, PipelineResource expectedPipeline)
        {
            AzureOperationResponse<PipelineResource> getPipelineResponse = await client.Pipelines.GetWithHttpMessagesAsync(resourceGroupName, dataFactoryName, pipelineName);
            ValidatePipeline(client, resourceGroupName, dataFactoryName, expectedPipeline, getPipelineResponse.Body, pipelineName);
            Assert.Equal(HttpStatusCode.OK, getPipelineResponse.Response.StatusCode);

            AzureOperationResponse<IPage<PipelineResource>> listPipelineResponse = await client.Pipelines.ListByFactoryWithHttpMessagesAsync(resourceGroupName, dataFactoryName);
            ValidatePipeline(client, resourceGroupName, dataFactoryName, expectedPipeline, listPipelineResponse.Body.First(), pipelineName);
            Assert.Equal(HttpStatusCode.OK, listPipelineResponse.Response.StatusCode);
        }

        private static void ValidatePipeline(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, PipelineResource expected, PipelineResource actual, string expectedName)
        {
            ValidateSubResource(client, resourceGroupName, actual, dataFactoryName, expectedName, "pipelines");
            Assert.IsType<List<Activity>> (actual.Activities);
            Activity activity = expected.Activities.First();
            Assert.Equal(((Activity)expected.Activities.First()).Name, ((Activity)actual.Activities.First()).Name);

        }
    }
}
