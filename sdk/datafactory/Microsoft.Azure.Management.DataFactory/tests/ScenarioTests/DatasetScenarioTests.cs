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
    public class DatasetScenarioTests : ScenarioTestBase<DatasetScenarioTests>
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task DatasetCrud()
        {
            string datasetName = "TestDataset";
            string linkedServiceName = "TestDataLakeStore";

            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
                await DataFactoryScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, new Factory(location: FactoryLocation));

                var expectedLinkedService = LinkedServiceScenarioTests.GetLinkedServiceResource(null);
                await LinkedServiceScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName, expectedLinkedService);

                DatasetResource expectedDataset = GetDatasetResource(null, linkedServiceName);
                await Create(client, this.ResourceGroupName, this.DataFactoryName, datasetName, expectedDataset);
                await GetList(client, this.ResourceGroupName, this.DataFactoryName, datasetName, expectedDataset);

                DatasetResource updatedDataset = GetDatasetResource("dataset description", linkedServiceName);
                await Update(client, this.ResourceGroupName, this.DataFactoryName, datasetName, updatedDataset);
                await GetList(client, this.ResourceGroupName, this.DataFactoryName, datasetName, updatedDataset);

                await Delete(client, this.ResourceGroupName, this.DataFactoryName, datasetName);
                await LinkedServiceScenarioTests.Delete(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName);
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
                await client.Factories.DeleteAsync(this.ResourceGroupName, this.DataFactoryName);
            };

            await this.RunTest(action, finallyAction);
        }

        internal static DatasetResource GetDatasetResource(string description, string linkedServiceName)
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

        internal static async Task Create(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string datasetName, DatasetResource expectedDataset)
        {
            AzureOperationResponse<DatasetResource> createDatasetResponse = await client.Datasets.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, datasetName, expectedDataset);
            ValidateDataset(client, resourceGroupName, dataFactoryName, expectedDataset, createDatasetResponse.Body, datasetName);
            Assert.Equal(HttpStatusCode.OK, createDatasetResponse.Response.StatusCode);
        }

        internal static async Task Update(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string datasetName, DatasetResource expectedDataset)
        {
            AzureOperationResponse<DatasetResource> updateDatasetResponse = await client.Datasets.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, datasetName, expectedDataset);
            ValidateDataset(client, resourceGroupName, dataFactoryName, expectedDataset, updateDatasetResponse.Body, datasetName);
            Assert.Equal(HttpStatusCode.OK, updateDatasetResponse.Response.StatusCode);
        }

        internal static async Task Delete(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string datasetName)
        {
            AzureOperationResponse deleteDatasetResponse = await client.Datasets.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName, datasetName);
            Assert.Equal(HttpStatusCode.OK, deleteDatasetResponse.Response.StatusCode);
            deleteDatasetResponse = await client.Datasets.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName, datasetName);
            Assert.Equal(HttpStatusCode.NoContent, deleteDatasetResponse.Response.StatusCode);
        }

        internal static async Task GetList(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string datasetName, DatasetResource expectedDataset)
        {
            AzureOperationResponse<DatasetResource> getDatasetResponse = await client.Datasets.GetWithHttpMessagesAsync(resourceGroupName, dataFactoryName, datasetName);
            ValidateDataset(client, resourceGroupName, dataFactoryName, expectedDataset, getDatasetResponse.Body, datasetName);
            Assert.Equal(HttpStatusCode.OK, getDatasetResponse.Response.StatusCode);

            AzureOperationResponse<IPage<DatasetResource>> listDatasetResponse = await client.Datasets.ListByFactoryWithHttpMessagesAsync(resourceGroupName, dataFactoryName);
            ValidateDataset(client, resourceGroupName, dataFactoryName, expectedDataset, listDatasetResponse.Body.First(), datasetName);
            Assert.Equal(HttpStatusCode.OK, listDatasetResponse.Response.StatusCode);
        }

        private static void ValidateDataset(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, DatasetResource expected, DatasetResource actual, string expectedName)
        {
            ValidateSubResource(client, resourceGroupName, actual, dataFactoryName, expectedName, "datasets");
            Assert.IsType<AzureBlobDataset>(actual.Properties);
        }
    }
}

