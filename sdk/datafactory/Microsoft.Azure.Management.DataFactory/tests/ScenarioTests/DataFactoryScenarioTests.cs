// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class DataFactoryScenarioTests : ScenarioTestBase<DataFactoryScenarioTests>
    {
        public Factory expectedFactory = new Factory(location: FactoryLocation, publicNetworkAccess: "true", encryption: new EncryptionConfiguration() { VaultBaseUrl = "dummyurl", KeyName = "dummyName" });

        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task DataFactoryCrud()
        {
            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
                await Create(client, this.ResourceGroupName, this.DataFactoryName, expectedFactory);
                await GetList(client, this.ResourceGroupName, this.DataFactoryName, expectedFactory);
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
                await Delete(client, this.ResourceGroupName, this.DataFactoryName);
            };

            await this.RunTest(action, finallyAction);
        }

        internal static async Task Create(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, Factory expectedFactory)
        {
            AzureOperationResponse<Factory> createResponse = await client.Factories.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, expectedFactory);
            ValidateFactory(createResponse.Body, dataFactoryName);
            Assert.Equal(createResponse.Body.PublicNetworkAccess, expectedFactory.PublicNetworkAccess);
            Assert.Equal(createResponse.Body?.Encryption?.VaultBaseUrl, expectedFactory.Encryption?.VaultBaseUrl);
            Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);

            AzureOperationResponse<Factory> getResponse = await client.Factories.GetWithHttpMessagesAsync(resourceGroupName, dataFactoryName);
            ValidateFactory(getResponse.Body, dataFactoryName);
            Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);

            AzureOperationResponse<IPage<Factory>> listByResourceGroupResponse = await client.Factories.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName);
            ValidateFactory(listByResourceGroupResponse.Body.First(), dataFactoryName);
            Assert.Equal(HttpStatusCode.OK, listByResourceGroupResponse.Response.StatusCode);

        }

        internal static async Task Update(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, Factory expectedFactory, FactoryUpdateParameters tags)
        {
            AzureOperationResponse<Factory> updateResponse = await client.Factories.UpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, tags);
            ValidateFactory(updateResponse.Body, dataFactoryName);
            Assert.Equal(HttpStatusCode.OK, updateResponse.Response.StatusCode);

            AzureOperationResponse<Factory> getResponse = await client.Factories.GetWithHttpMessagesAsync(resourceGroupName, dataFactoryName);
            ValidateFactory(getResponse.Body, dataFactoryName);
            Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);

            AzureOperationResponse<IPage<Factory>> listByResourceGroupResponse = await client.Factories.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName);
            ValidateFactory(listByResourceGroupResponse.Body.First(), dataFactoryName);
            Assert.Equal(HttpStatusCode.OK, listByResourceGroupResponse.Response.StatusCode);

            AzureOperationResponse<IPage<Factory>> listResponse = await client.Factories.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName);
            ValidateFactory(listResponse.Body.First(), dataFactoryName);
            Assert.Equal(HttpStatusCode.OK, listResponse.Response.StatusCode);
        }

        internal static async Task Delete(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName)
        {
            AzureOperationResponse deleteResponse = await client.Factories.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName);
            Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);

            deleteResponse = await client.Factories.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName);
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
        }

        internal static async Task GetList(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, Factory expectedFactory)
        {
            AzureOperationResponse<Factory> createResponse = await client.Factories.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, expectedFactory);
            ValidateFactory(createResponse.Body, dataFactoryName);
            Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);

            AzureOperationResponse<Factory> getResponse = await client.Factories.GetWithHttpMessagesAsync(resourceGroupName, dataFactoryName);
            ValidateFactory(getResponse.Body, dataFactoryName);
            Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);

            AzureOperationResponse<IPage<Factory>> listByResourceGroupResponse = await client.Factories.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName);
            ValidateFactory(listByResourceGroupResponse.Body.First(), dataFactoryName);
            Assert.Equal(HttpStatusCode.OK, listByResourceGroupResponse.Response.StatusCode);

        }

        private static void ValidateFactory(Factory actualFactory, string expectedFactoryName)
        {
            Assert.Equal(expectedFactoryName, actualFactory.Name);
            Assert.Equal(FactoryLocation, actualFactory.Location);
            Assert.Equal("Succeeded", actualFactory.ProvisioningState);
        }
    }
}

