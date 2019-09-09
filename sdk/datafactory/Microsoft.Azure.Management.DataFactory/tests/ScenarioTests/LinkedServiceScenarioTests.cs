// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class LinkedServiceScenarioTests : ScenarioTestBase<LinkedServiceScenarioTests>
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task LinkedServiceCrud()
        {
            string linkedServiceName = "TestDataLakeStore";
            var expectedLinkedService = GetLinkedServiceResource(null);

            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
                await DataFactoryScenarioTests.Create(client, this.ResourceGroupName, this.DataFactoryName, new Factory(location: FactoryLocation));

                await Create(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName, expectedLinkedService);
                await GetList(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName, expectedLinkedService);

                await Delete(client, this.ResourceGroupName, this.DataFactoryName, linkedServiceName);
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
                await client.Factories.DeleteAsync(this.ResourceGroupName, this.DataFactoryName);
            };

            await this.RunTest(action, finallyAction);
        }

        internal static LinkedServiceResource GetLinkedServiceResource(string description)
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

        internal static async Task Create(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string linkedServiceName, LinkedServiceResource expectedLinkedService)
        {
            AzureOperationResponse<LinkedServiceResource> createResponse = await client.LinkedServices.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, linkedServiceName, expectedLinkedService);
            ValidateLinkedService(client, resourceGroupName, dataFactoryName, expectedLinkedService, createResponse.Body, linkedServiceName);
            Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);

        }

        internal static async Task Update(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string linkedServiceName, LinkedServiceResource expectedLinkedService)
        {
            AzureOperationResponse<LinkedServiceResource> createResponse = await client.LinkedServices.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, linkedServiceName, expectedLinkedService);
            ValidateLinkedService(client, resourceGroupName, dataFactoryName, expectedLinkedService, createResponse.Body, linkedServiceName);
            Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);

        }

        internal static async Task Delete(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string linkedServiceName)
        {
            AzureOperationResponse deleteResponse = await client.LinkedServices.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName, linkedServiceName);
            Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);
        }

        internal static async Task GetList(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string linkedServiceName, LinkedServiceResource expectedLinkedService)
        {
            AzureOperationResponse<LinkedServiceResource> getResponse = await client.LinkedServices.GetWithHttpMessagesAsync(resourceGroupName, dataFactoryName, linkedServiceName);
            ValidateLinkedService(client, resourceGroupName, dataFactoryName, expectedLinkedService, getResponse.Body, linkedServiceName);
            Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);

            AzureOperationResponse<IPage<LinkedServiceResource>> listResponse = await client.LinkedServices.ListByFactoryWithHttpMessagesAsync(resourceGroupName, dataFactoryName);
            ValidateLinkedService(client, resourceGroupName, dataFactoryName, expectedLinkedService, listResponse.Body.First(), linkedServiceName);
            Assert.Equal(HttpStatusCode.OK, listResponse.Response.StatusCode);
        }
        private static void ValidateLinkedService(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, LinkedServiceResource expected, LinkedServiceResource actual, string expectedName)
        {
            ValidateSubResource(client, resourceGroupName, actual, dataFactoryName, expectedName, "linkedservices");
            Assert.IsType<AzureDataLakeStoreLinkedService>(actual.Properties);
            Assert.Equal(((AzureDataLakeStoreLinkedService)expected.Properties).DataLakeStoreUri, ((AzureDataLakeStoreLinkedService)actual.Properties).DataLakeStoreUri);
        }
    }
}

