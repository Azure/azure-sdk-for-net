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
    public class DataFlowScenarioTests : ScenarioTestBase<DataFlowScenarioTests>
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task DataFlowCrud()
        {
            string dataFlowName = "TestDataFlow";
            string datasetName = "TestDataFlowDataset";
            string linkedServiceName = "TestDataFlowLinkedService";

            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
                await DataFactoryScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, new Factory(location: FactoryLocation));

                var expectedLinkedService = LinkedServiceScenarioTests.GetLinkedServiceResource(null);
                await LinkedServiceScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName, expectedLinkedService);
                var expectedDataset = DatasetScenarioTests.GetDatasetResource(null, linkedServiceName);
                await DatasetScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, datasetName, expectedDataset);

                DataFlowResource expectedDataFlow = GetDataFlowResource(null, datasetName);
                await Create(client, this.ResourceGroupName, this.DataFactoryName, dataFlowName, expectedDataFlow);
                await GetList(client, this.ResourceGroupName, this.DataFactoryName, dataFlowName, expectedDataFlow);

                DataFlowResource updatedDataFlow = GetDataFlowResource("data flow description", datasetName);
                await Update(client, this.ResourceGroupName, this.DataFactoryName, dataFlowName, updatedDataFlow);
                await GetList(client, this.ResourceGroupName, this.DataFactoryName, dataFlowName, updatedDataFlow);

                await Delete(client, this.ResourceGroupName, this.DataFactoryName, dataFlowName);
                await DatasetScenarioTests.Delete(client, this.ResourceGroupName, this.DataFactoryName, datasetName);
                await LinkedServiceScenarioTests.Delete(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName);
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
                await client.Factories.DeleteAsync(this.ResourceGroupName, this.DataFactoryName);
            };

            await this.RunTest(action, finallyAction);
        }

        internal static DataFlowResource GetDataFlowResource(string description, string datasetName)
        {
            DataFlowResource resource = new DataFlowResource
            {
                Properties = new MappingDataFlow
                {
                    Description = description,
                    Sources = new List<DataFlowSource>() {
                        new DataFlowSource()
                        {
                            Name = "source",
                            Description = "source 1",
                            Dataset = new DatasetReference()
                            {
                                ReferenceName = datasetName,
                                Parameters = new Dictionary<string, object>
                                {
                                    { "JobId", new Expression("@pipeline().parameters.JobId") }
                                }
                            }
                        }
                    },
                    Sinks = new List<DataFlowSink>() {
                        new DataFlowSink()
                        {
                            Name = "sink",
                            Description = "sink 1",
                            Dataset = new DatasetReference()
                            {
                                ReferenceName = datasetName,
                                Parameters = new Dictionary<string, object>
                                {
                                    { "JobId", new Expression("@pipeline().parameters.JobId") }
                                }
                            }
                        }
                    },
                    Transformations = new List<Transformation>() {
                        new Transformation()
                        {
                            Name = "transformation",
                            Description = "transformation 1"
                        }
                    }
                }
            };

            return resource;
        }

        internal static async Task Create(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string dataFlowName, DataFlowResource expectedDataFlow)
        {
            AzureOperationResponse<DataFlowResource> createDataFlowResponse = await client.DataFlows.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, dataFlowName, expectedDataFlow);
            ValidateDataFlow(client, resourceGroupName, dataFactoryName, expectedDataFlow, createDataFlowResponse.Body, dataFlowName);
            Assert.Equal(HttpStatusCode.OK, createDataFlowResponse.Response.StatusCode);
        }

        internal static async Task Update(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string dataFlowName, DataFlowResource expectedDataFlow)
        {
            AzureOperationResponse<DataFlowResource> updateDataFlowResponse = await client.DataFlows.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, dataFlowName, expectedDataFlow);
            ValidateDataFlow(client, resourceGroupName, dataFactoryName, expectedDataFlow, updateDataFlowResponse.Body, dataFlowName);
            Assert.Equal(HttpStatusCode.OK, updateDataFlowResponse.Response.StatusCode);
        }

        internal static async Task Delete(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string dataFlowName)
        {
            AzureOperationResponse deleteDataFlowResponse = await client.DataFlows.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName, dataFlowName);
            Assert.Equal(HttpStatusCode.OK, deleteDataFlowResponse.Response.StatusCode);
            deleteDataFlowResponse = await client.DataFlows.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName, dataFlowName);
            Assert.Equal(HttpStatusCode.NoContent, deleteDataFlowResponse.Response.StatusCode);
        }

        internal static async Task GetList(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string dataFlowName, DataFlowResource expectedDataFlow)
        {
            AzureOperationResponse<DataFlowResource> getDataFlowResponse = await client.DataFlows.GetWithHttpMessagesAsync(resourceGroupName, dataFactoryName, dataFlowName);
            ValidateDataFlow(client, resourceGroupName, dataFactoryName, expectedDataFlow, getDataFlowResponse.Body, dataFlowName);
            Assert.Equal(HttpStatusCode.OK, getDataFlowResponse.Response.StatusCode);

            AzureOperationResponse<IPage<DataFlowResource>> listDataFlowResponse = await client.DataFlows.ListByFactoryWithHttpMessagesAsync(resourceGroupName, dataFactoryName);
            ValidateDataFlow(client, resourceGroupName, dataFactoryName, expectedDataFlow, listDataFlowResponse.Body.First(), dataFlowName);
            Assert.Equal(HttpStatusCode.OK, listDataFlowResponse.Response.StatusCode);
        }

        private static void ValidateDataFlow(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, DataFlowResource expected, DataFlowResource actual, string expectedName)
        {
            ValidateSubResource(client, resourceGroupName, actual, dataFactoryName, expectedName, "dataflows");
            Assert.IsType<MappingDataFlow>(actual.Properties);
        }
    }
}

