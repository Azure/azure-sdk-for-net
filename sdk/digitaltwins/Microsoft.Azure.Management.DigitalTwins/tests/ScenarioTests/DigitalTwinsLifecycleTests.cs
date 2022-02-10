// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using FluentAssertions;
using Microsoft.Azure.Management.DigitalTwins;
using Microsoft.Azure.Management.DigitalTwins.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DigitalTwins.Tests.ScenarioTests
{
    public class DigitalTwinsLifecycleTests : DigitalTwinsTestBase
    {
        [Fact]
        [Trait("Type", "E2E")]
        public async Task TestDigitalTwinsLifecycle()
        {
            using var context = MockContext.Start(GetType());

            Initialize(context);

            // Create Resource Group
            ResourceGroup rg = await ResourcesClient.ResourceGroups.CreateOrUpdateAsync(
                DefaultResourceGroupName,
                new ResourceGroup
                {
                    Location = DefaultLocation,
                });

            try
            {
                // Check if instance exists and delete
                CheckNameResult dtNameCheck = await DigitalTwinsClient.DigitalTwins.CheckNameAvailabilityAsync(
                    DefaultLocation,
                    DefaultInstanceName);

                if (!dtNameCheck.NameAvailable.Value)
                {
                    DigitalTwinsDescription dtDelete = await DigitalTwinsClient.DigitalTwins.DeleteAsync(
                        rg.Name,
                        DefaultInstanceName);
                    dtDelete.ProvisioningState.Should().Be(ProvisioningState.Deleted);

                    dtNameCheck = await DigitalTwinsClient.DigitalTwins.CheckNameAvailabilityAsync(
                        DefaultLocation,
                        DefaultInstanceName);
                    dtNameCheck.NameAvailable.Should().BeTrue();
                }

                // Create DigitalTwins resource
                var dtInstance = await DigitalTwinsClient.DigitalTwins.CreateOrUpdateAsync(
                    rg.Name,
                    DefaultInstanceName,
                    new DigitalTwinsDescription
                    {
                        Location = DefaultLocation,
                    });

                try
                {
                    dtInstance.Should().NotBeNull();
                    dtInstance.Name.Should().Be(DefaultInstanceName);
                    dtInstance.Location.Should().Be(DefaultLocation);

                    // Add and Get Tags
                    const string key2 = "key2";
                    const string value2 = "value2";
                    var patch = new DigitalTwinsPatchDescription(
                        tags: new Dictionary<string, string>
                        {
                            { "key1", "value1" },
                            { key2, value2 },
                        });
                    dtInstance = await DigitalTwinsClient.DigitalTwins.UpdateAsync(
                        rg.Name,
                        dtInstance.Name,
                        patch);

                    dtInstance.Should().NotBeNull();
                    dtInstance.Tags.Count().Should().Be(2);
                    dtInstance.Tags[key2].Should().Be(value2);

                    // List DigitalTwins instances in Resource Group
                    var twinsResources = await DigitalTwinsClient.DigitalTwins.ListByResourceGroupAsync(rg.Name);
                    twinsResources.Count().Should().BeGreaterThan(0);

                    // Get all of the available operations, ensure CRUD
                    var operationList = await DigitalTwinsClient.Operations.ListAsync();
                    operationList.Count().Should().BeGreaterThan(0);
                    Assert.Contains(operationList, e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/read", StringComparison.OrdinalIgnoreCase));
                    Assert.Contains(operationList, e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/write", StringComparison.OrdinalIgnoreCase));
                    Assert.Contains(operationList, e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/delete", StringComparison.OrdinalIgnoreCase));

                    // Test other operations

                    // Register Operation
                    var registerOperations = operationList.Where(e => e.Name.Contains($"Microsoft.DigitalTwins/register"));
                    registerOperations.Count().Should().BeGreaterThan(0);

                    // Twin Operations
                    var twinOperations = operationList.Where(e => e.Name.Contains($"Microsoft.DigitalTwins/digitaltwins"));
                    twinOperations.Count().Should().BeGreaterThan(0);

                    // Event Route Operations
                    var eventRouteOperations = operationList.Where(e => e.Name.Contains($"Microsoft.DigitalTwins/eventroutes"));
                    eventRouteOperations.Count().Should().BeGreaterThan(0);

                    // Model operations
                    var modelOperations = operationList.Where(e => e.Name.Contains($"Microsoft.DigitalTwins/models"));
                    modelOperations.Count().Should().BeGreaterThan(0);
                }
                finally
                {
                    // Delete instance
                    DigitalTwinsDescription deleteOp = await DigitalTwinsClient.DigitalTwins.BeginDeleteAsync(
                        rg.Name,
                        dtInstance.Name);
                    deleteOp.ProvisioningState.Should().Be(ProvisioningState.Deleting);
                }
            }
            finally
            {
                await ResourcesClient.ResourceGroups.DeleteAsync(rg.Name);
            }
        }

        [Fact]
        [Trait("Type", "E2E")]
        public async Task TestDigitalTwinsWithIdentityLifecycle()
        {
            using var context = MockContext.Start(GetType());

            Initialize(context);

            // Create Resource Group
            ResourceGroup rg = await ResourcesClient.ResourceGroups.CreateOrUpdateAsync(
                DefaultResourceGroupName,
                new ResourceGroup
                {
                    Location = DefaultLocation,
                });

            try
            {
                // Create DigitalTwins resource with managed identity
                var dtInstance = await DigitalTwinsClient.DigitalTwins.CreateOrUpdateAsync(
                    rg.Name,
                    DefaultInstanceName,
                    new DigitalTwinsDescription
                    {
                        Location = DefaultLocation,
                        Identity = new DigitalTwinsIdentity
                        {
                            Type = "SystemAssigned"
                        },
                    });

                dtInstance.Should().NotBeNull();
                dtInstance.Name.Should().Be(DefaultInstanceName);
                dtInstance.Location.Should().Be(DefaultLocation);
                dtInstance.Identity.Should().NotBeNull();
                dtInstance.Identity.Type.Should().Be("SystemAssigned");

                // Delete instance
                DigitalTwinsDescription deleteOp = await DigitalTwinsClient.DigitalTwins.BeginDeleteAsync(
                    rg.Name,
                    dtInstance.Name);
                deleteOp.ProvisioningState.Should().Be(ProvisioningState.Deleting);
            }
            finally
            {
                await ResourcesClient.ResourceGroups.DeleteAsync(rg.Name);
            }
        }

        [Fact]
        [Trait("Type", "E2E")]
        public async Task TestDigitalTwinsWithTimeSeriesDatabaseLifecycle()
        {
            using var context = MockContext.Start(GetType());

            Initialize(context);

            // Create Resource Group
            ResourceGroup rg = await ResourcesClient.ResourceGroups.CreateOrUpdateAsync(
                DefaultResourceGroupName,
                new ResourceGroup
                {
                    Location = DefaultLocation,
                });

            try
            {
                // Create DigitalTwins resource with managed identity
                var dtInstance = await DigitalTwinsClient.DigitalTwins.CreateOrUpdateAsync(
                    rg.Name,
                    DefaultInstanceName,
                    new DigitalTwinsDescription
                    {
                        Location = DefaultLocation,
                        Identity = new DigitalTwinsIdentity
                        {
                            Type = "SystemAssigned"
                        },
                    });

                try
                {
                    dtInstance.Should().NotBeNull();

                    // Create a time series database connection
                    var tsdbConnection = await DigitalTwinsClient.TimeSeriesDatabaseConnections.BeginCreateOrUpdateAsync(
                        rg.Name,
                        DefaultInstanceName,
                        DefaultTsdbConnectionName,
                        new AzureDataExplorerConnectionProperties
                        {
                            AdxDatabaseName = DefaultAdxDatabaseName,
                            AdxEndpointUri = DefaultAdxEndpointUri,
                            AdxResourceId = DefaultAdxResourceId,
                            AdxTableName = DefaultAdxTableName,
                            EventHubEndpointUri = DefaultEventHubEndpointUri,
                            EventHubEntityPath = DefaultEventHubName,
                            EventHubNamespaceResourceId = DefaultEventHubNamespaceResourceId,
                        });

                    tsdbConnection.Should().NotBeNull();
                    tsdbConnection.Properties.Should().NotBeNull();
                    tsdbConnection.Properties.ProvisioningState.Should().Be(TimeSeriesDatabaseConnectionState.Provisioning);

                    // Attempting to create another time series database connection should fail
                    Func<Task> createAction = async () => await DigitalTwinsClient.TimeSeriesDatabaseConnections.CreateOrUpdateAsync(
                        rg.Name,
                        DefaultInstanceName,
                        "OtherConnection",
                        new AzureDataExplorerConnectionProperties
                        {
                            AdxDatabaseName = DefaultAdxDatabaseName,
                            AdxEndpointUri = DefaultAdxEndpointUri,
                            AdxResourceId = DefaultAdxResourceId,
                            AdxTableName = DefaultAdxTableName,
                            EventHubEndpointUri = DefaultEventHubEndpointUri,
                            EventHubEntityPath = DefaultEventHubName,
                            EventHubNamespaceResourceId = DefaultEventHubNamespaceResourceId,
                        });
                    createAction.Should().Throw<ErrorResponseException>();

                    // Get time series database connection
                    var retrievedTsdbConnection = await DigitalTwinsClient.TimeSeriesDatabaseConnections.GetAsync(
                        rg.Name,
                        DefaultInstanceName,
                        DefaultTsdbConnectionName);

                    retrievedTsdbConnection.Should().NotBeNull();
                    retrievedTsdbConnection.Name.Should().Be(DefaultTsdbConnectionName);

                    // List time series database connections
                    var tsdbConnectionsList = await DigitalTwinsClient.TimeSeriesDatabaseConnections.ListAsync(
                        rg.Name,
                        DefaultInstanceName);

                    tsdbConnectionsList.Should().NotBeNull();
                    tsdbConnectionsList.Should().ContainSingle();
                    tsdbConnectionsList.First().Name.Should().Be(DefaultTsdbConnectionName);

                    // Delete time series database connection
                    var deletedTsdbConnection = await DigitalTwinsClient.TimeSeriesDatabaseConnections.BeginDeleteAsync(
                        rg.Name,
                        DefaultInstanceName,
                        DefaultTsdbConnectionName);

                    deletedTsdbConnection.Should().NotBeNull();
                    deletedTsdbConnection.Properties.Should().NotBeNull();
                    deletedTsdbConnection.Properties.ProvisioningState.Should().Be(TimeSeriesDatabaseConnectionState.Deleting);
                }
                finally
                {
                    // Delete instance
                    DigitalTwinsDescription deleteOp = await DigitalTwinsClient.DigitalTwins.BeginDeleteAsync(
                        rg.Name,
                        dtInstance.Name);
                    deleteOp.ProvisioningState.Should().Be(ProvisioningState.Deleting);
                }
            }
            finally
            {
                await ResourcesClient.ResourceGroups.DeleteAsync(rg.Name);
            }
        }
    }
}
