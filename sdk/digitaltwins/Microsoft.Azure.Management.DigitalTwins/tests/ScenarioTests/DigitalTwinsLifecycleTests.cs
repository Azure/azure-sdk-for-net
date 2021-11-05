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
    }
}
