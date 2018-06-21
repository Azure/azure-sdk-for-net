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
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task DataFactoryCrud()
        {
            var expectedFactory = new Factory(location: FactoryLocation);

            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
                AzureOperationResponse<Factory> createResponse = await client.Factories.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, expectedFactory);
                this.ValidateFactory(createResponse.Body, this.DataFactoryName);
                Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);

                AzureOperationResponse<Factory> getResponse = await client.Factories.GetWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName);
                this.ValidateFactory(getResponse.Body, this.DataFactoryName);
                Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);

                AzureOperationResponse<IPage<Factory>> listByResourceGroupResponse = await client.Factories.ListByResourceGroupWithHttpMessagesAsync(this.ResourceGroupName);
                this.ValidateFactory(listByResourceGroupResponse.Body.First(), this.DataFactoryName);
                Assert.Equal(HttpStatusCode.OK, listByResourceGroupResponse.Response.StatusCode);
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
                AzureOperationResponse deleteResponse = await client.Factories.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);

                deleteResponse = await client.Factories.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
            };

            await this.RunTest(action, finallyAction);
        }

        private void ValidateFactory(Factory actualFactory, string expectedFactoryName)
        {
            Assert.Equal(expectedFactoryName, actualFactory.Name);
            Assert.Equal(FactoryLocation, actualFactory.Location);
            Assert.Equal("Succeeded", actualFactory.ProvisioningState);
        }
    }
}
