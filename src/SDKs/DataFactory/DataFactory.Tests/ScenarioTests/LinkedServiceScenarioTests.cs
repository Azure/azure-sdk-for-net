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
            var expectedLinkedService = new LinkedServiceResource()
            {
                Properties = new AzureDataLakeStoreLinkedService()
                {
                    DataLakeStoreUri = "adl://test.azuredatalakestore.net/"
                }
            };

            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
                client.Factories.CreateOrUpdate(this.ResourceGroupName, this.DataFactoryName, new Factory(location: FactoryLocation));

                AzureOperationResponse<LinkedServiceResource> createResponse = await client.LinkedServices.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, linkedServiceName, expectedLinkedService);
                this.ValidateLinkedService(expectedLinkedService, createResponse.Body, linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);

                AzureOperationResponse<LinkedServiceResource> getResponse = await client.LinkedServices.GetWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, linkedServiceName);
                this.ValidateLinkedService(expectedLinkedService, getResponse.Body, linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);

                AzureOperationResponse<IPage<LinkedServiceResource>> listResponse = await client.LinkedServices.ListByFactoryWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName);
                this.ValidateLinkedService(expectedLinkedService, listResponse.Body.First(), linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, listResponse.Response.StatusCode);

                AzureOperationResponse deleteResponse = await client.LinkedServices.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
                await client.Factories.DeleteAsync(this.ResourceGroupName, this.DataFactoryName);
            };

            await this.RunTest(action, finallyAction);
        }

        private void ValidateLinkedService(LinkedServiceResource expected, LinkedServiceResource actual, string expectedName)
        {
            this.ValidateSubResource(actual, this.DataFactoryName, expectedName, "linkedservices");
            Assert.IsType<AzureDataLakeStoreLinkedService>(actual.Properties);
            Assert.Equal(((AzureDataLakeStoreLinkedService)expected.Properties).DataLakeStoreUri, ((AzureDataLakeStoreLinkedService)actual.Properties).DataLakeStoreUri);
        }
    }
}
