// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Azure.Management.ResourceManager;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class IntegrationRuntimeScenarioTests : ScenarioTestBase<IntegrationRuntimeScenarioTests>
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task SelfHostedIntegrationRuntimeScenarioTest()
        {
            var integrationRuntimeName = "selfhostedintegrationruntime";

            var resource = new IntegrationRuntimeResource()
            {
                Properties = new SelfHostedIntegrationRuntime
                {
                    Description = "Self-Hosted integration runtime."
                }
            };

            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
                var factory = new Factory(location: FactoryLocation);
                await client.Factories.CreateOrUpdateAsync(this.ResourceGroupName, this.DataFactoryName, factory);

                var createResponse = await client.IntegrationRuntimes.CreateOrUpdateAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName,
                    resource);
                Assert.Equal(integrationRuntimeName, createResponse.Name);
                Assert.True(createResponse.Properties is SelfHostedIntegrationRuntime);

                var getResponse = await client.IntegrationRuntimes.GetAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName);
                Assert.True(getResponse.Properties is SelfHostedIntegrationRuntime);

                var status = await client.IntegrationRuntimes.GetStatusAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName);
                var selfHostedStatus = status.Properties as SelfHostedIntegrationRuntimeStatus;
                Assert.Equal(IntegrationRuntimeState.NeedRegistration, selfHostedStatus.State);

                var listByResourceGroupResponse = await client.IntegrationRuntimes.ListByFactoryAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName);
                var item = listByResourceGroupResponse.First();
                Assert.Equal(integrationRuntimeName, item.Name);
                Assert.True(item.Properties is SelfHostedIntegrationRuntime);
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
                await client.IntegrationRuntimes.DeleteAsync(this.ResourceGroupName, this.DataFactoryName, integrationRuntimeName);

                var deleteResponse = await client.IntegrationRuntimes.DeleteWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);

                await client.Factories.DeleteAsync(this.ResourceGroupName, this.DataFactoryName);
            };

            await this.RunTest(action, finallyAction);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task AzureIntegrationRuntimeScenarioTest()
        {
            var integrationRuntimeName = "azureintegrationruntime";

            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
                var factory = new Factory(location: FactoryLocation);
                await client.Factories.CreateOrUpdateAsync(this.ResourceGroupName, this.DataFactoryName, factory);

                var resource = new IntegrationRuntimeResource()
                {
                    Properties = new ManagedIntegrationRuntime
                    {
                        Description = "Azure integration runtime."
                    }
                };
                var createResponse = await client.IntegrationRuntimes.CreateOrUpdateAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName,
                    resource);
                Assert.Equal(integrationRuntimeName, createResponse.Name);
                Assert.True(createResponse.Properties is ManagedIntegrationRuntime);

                var getResponse = await client.IntegrationRuntimes.GetAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName);
                Assert.True(getResponse.Properties is ManagedIntegrationRuntime);

                var status = await client.IntegrationRuntimes.GetStatusAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName);
                var managedStatus = status.Properties as ManagedIntegrationRuntimeStatus;
                Assert.Equal(IntegrationRuntimeState.Online, managedStatus.State);

                var listByResourceGroupResponse = await client.IntegrationRuntimes.ListByFactoryAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName);
                var item = listByResourceGroupResponse.First();
                Assert.Equal(integrationRuntimeName, item.Name);
                Assert.True(item.Properties is ManagedIntegrationRuntime);
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
                await client.IntegrationRuntimes.DeleteAsync(this.ResourceGroupName, this.DataFactoryName, integrationRuntimeName);

                var deleteResponse = await client.IntegrationRuntimes.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, integrationRuntimeName);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);

                await client.Factories.DeleteAsync(this.ResourceGroupName, this.DataFactoryName);
            };

            await this.RunTest(action, finallyAction);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task SsisAzureIntegrationRuntimeScenarioTest()
        {
            var integrationRuntimeName = "ssisazureintegrationruntime";
            var resource = new IntegrationRuntimeResource()
            {
                Properties = new ManagedIntegrationRuntime
                {
                    Description = "SSIS-Azure integration runtime.",
                    ComputeProperties = new IntegrationRuntimeComputeProperties
                    {
                        NodeSize = "Standard_D1_v2",
                        MaxParallelExecutionsPerNode = 1,
                        NumberOfNodes = 1,
                        Location = "WestUS"
                    },
                    SsisProperties = new IntegrationRuntimeSsisProperties
                    {
                        CatalogInfo = new IntegrationRuntimeSsisCatalogInfo
                        {
                            CatalogAdminUserName = Environment.GetEnvironmentVariable("CatalogAdminUsername"),
                            CatalogAdminPassword = new SecureString(Environment.GetEnvironmentVariable("CatalogAdminPassword")),
                            CatalogServerEndpoint = Environment.GetEnvironmentVariable("CatalogServerEndpoint"),
                            CatalogPricingTier = "S1"
                        }
                    }
                }
            };

            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
                var factory = new Factory(location: FactoryLocation);
                await client.Factories.CreateOrUpdateAsync(this.ResourceGroupName, this.DataFactoryName, factory);

                var createResponse = await client.IntegrationRuntimes.CreateOrUpdateAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName,
                    resource);
                Assert.Equal(integrationRuntimeName, createResponse.Name);
                Assert.True(createResponse.Properties is ManagedIntegrationRuntime);

                var startResponse = await client.IntegrationRuntimes.StartAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName);
                var managedStatus = startResponse.Properties as ManagedIntegrationRuntimeStatus;
                Assert.Equal(IntegrationRuntimeState.Started, managedStatus.State);

                await client.IntegrationRuntimes.StopAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName);

                var status = await client.IntegrationRuntimes.GetStatusAsync(
                    this.ResourceGroupName,
                    this.DataFactoryName,
                    integrationRuntimeName);
                managedStatus = status.Properties as ManagedIntegrationRuntimeStatus;
                Assert.Equal(IntegrationRuntimeState.Stopped, managedStatus.State);
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
                await client.IntegrationRuntimes.DeleteAsync(this.ResourceGroupName, this.DataFactoryName, integrationRuntimeName);

                var deleteResponse = await client.IntegrationRuntimes.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, integrationRuntimeName);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);

                await client.Factories.DeleteAsync(this.ResourceGroupName, this.DataFactoryName);
            };

            await this.RunTest(action, finallyAction);
        }
    }
}
