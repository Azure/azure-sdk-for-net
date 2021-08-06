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
    public class SwiftIntegrationRuntimeScenarioTests : ScenarioTestBase<SwiftIntegrationRuntimeScenarioTests>
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task SwiftSsisAzureIntegrationRuntimeScenarioTest()
        {
            var integrationRuntimeName = "siwftssisazureintegrationruntime";
            var description = "Azure-SSIS integration runtime.";
            var nodeSize = "Standard_D2_v3";
            var subnetId = "/subscriptions/cb715d05-3337-4640-8c43-4f943c50d06e/resourceGroups/Wamao/providers/Microsoft.Network/virtualNetworks/TestIntWestUsADMSWanli/subnets/TestDelegation";
            var resource = new IntegrationRuntimeResource()
            {
                Properties = new ManagedIntegrationRuntime
                {
                    Description = description,
                    ComputeProperties = new IntegrationRuntimeComputeProperties
                    {
                        NodeSize = nodeSize,
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
                            CatalogPricingTier = "S1",
                            DualStandbyPairName = "Name"
                        },
                        DataProxyProperties = new IntegrationRuntimeDataProxyProperties
                        {
                            ConnectVia = new EntityReference
                            {
                                ReferenceName = "azureSSISIR"
                            },
                            StagingLinkedService = new EntityReference
                            {
                                ReferenceName = "stagingLinkedService"
                            },
                            Path = "fakedPath"
                        }
                    },
                    CustomerVirtualNetwork = new IntegrationRuntimeCustomerVirtualNetwork
                    {
                        SubnetId = subnetId
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
                Assert.Equal(description, createResponse.Properties.Description);
                Assert.True(createResponse.Properties is ManagedIntegrationRuntime);
                var responseProperties = createResponse.Properties as ManagedIntegrationRuntime;
                Assert.Equal(subnetId, responseProperties.CustomerVirtualNetwork.SubnetId);

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
