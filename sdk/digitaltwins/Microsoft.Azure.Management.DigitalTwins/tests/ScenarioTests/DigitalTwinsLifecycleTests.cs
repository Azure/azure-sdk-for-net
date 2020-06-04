namespace DigitalTwins.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DigitalTwins.Tests.Helpers;
    using Microsoft.Azure.Management.DigitalTwins;
    using Microsoft.Azure.Management.DigitalTwins.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class DigitalTwinsLifecycleTests: DigitalTwinsTestBase
    {
        [Fact]
        public void TestDigitalTwinsLifecycle()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var digitalTwinsDescription = new DigitalTwinsDescription()
                {
                    Location = location,
                };

                this.Initialize(context);

                // Create Resource Group
                var resourceGroup = this.CreateResourceGroup(DigitalTwinsTestUtilities.DefaultResourceGroupName);

                // Check if instance exists and delete
                var digitalTwinsAvailability = this.digitalTwinsClient.DigitalTwins.CheckNameAvailability(DigitalTwinsTestUtilities.DefaultLocation, DigitalTwinsTestUtilities.DefaultInstanceName);

                if (!(bool)digitalTwinsAvailability.NameAvailable)
                {
                    this.digitalTwinsClient.DigitalTwins.Delete(
                        DigitalTwinsTestUtilities.DefaultResourceGroupName,
                        DigitalTwinsTestUtilities.DefaultInstanceName);

                    digitalTwinsAvailability = this.digitalTwinsClient.DigitalTwins.CheckNameAvailability(DigitalTwinsTestUtilities.DefaultLocation, DigitalTwinsTestUtilities.DefaultInstanceName);
                    Assert.True(digitalTwinsAvailability.NameAvailable);
                }

                // Create DigitalTwins resource
                var digitalTwinsInstance = this.CreateDigitalTwinsInstance(resourceGroup, DigitalTwinsTestUtilities.DefaultLocation, DigitalTwinsTestUtilities.DefaultInstanceName);

                Assert.NotNull(digitalTwinsInstance);
                Assert.Equal(DigitalTwinsTestUtilities.DefaultInstanceName, digitalTwinsInstance.Name);
                Assert.Equal(DigitalTwinsTestUtilities.DefaultLocation, digitalTwinsInstance.Location);

                // Add and Get Tags
                IDictionary<string, string> tags = new Dictionary<string, string>();
                tags.Add("key1", "value1");
                tags.Add("key2", "value2");
                digitalTwinsInstance = this.digitalTwinsClient.DigitalTwins.Update(DigitalTwinsTestUtilities.DefaultResourceGroupName, DigitalTwinsTestUtilities.DefaultInstanceName, tags);

                Assert.NotNull(digitalTwinsInstance);
                Assert.True(digitalTwinsInstance.Tags.Count().Equals(2));
                Assert.Equal("value2", digitalTwinsInstance.Tags["key2"]);

                // List DigitalTwins instances in Resource Group
                var twinsResources = this.digitalTwinsClient.DigitalTwins.ListByResourceGroup(DigitalTwinsTestUtilities.DefaultResourceGroupName);
                Assert.True(twinsResources.Count() > 0);

                // Get all of the available operations, ensure CRUD
                var operationList = this.digitalTwinsClient.Operations.List();
                Assert.True(operationList.Count() > 0);
                Assert.Contains(operationList, e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/read", StringComparison.OrdinalIgnoreCase));
                Assert.Contains(operationList, e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/write", StringComparison.OrdinalIgnoreCase));
                Assert.Contains(operationList, e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/delete", StringComparison.OrdinalIgnoreCase));

                // Get other operations

                // Register Operation
                var registerOperations = operationList.Where(e => e.Name.Contains($"Microsoft.DigitalTwins/register"));
                Assert.True(registerOperations.Count() > 0);

                // Twin Operations
                var twinOperations = operationList.Where(e => e.Name.Contains($"Microsoft.DigitalTwins/digitaltwins"));
                Assert.True(twinOperations.Count() > 0);

                // Event Route Operations
                var eventRouteOperations =  operationList.Where(e => e.Name.Contains($"Microsoft.DigitalTwins/eventroutes"));
                Assert.True(eventRouteOperations.Count() > 0);

                // Model operations
                var modelOperations =  operationList.Where(e => e.Name.Contains($"Microsoft.DigitalTwins/models"));
                Assert.True(modelOperations.Count() > 0);

                // Delete instance
                var deleteOp = this.digitalTwinsClient.DigitalTwins.BeginDelete(DigitalTwinsTestUtilities.DefaultResourceGroupName, DigitalTwinsTestUtilities.DefaultInstanceName);
                Assert.True(deleteOp.ProvisioningState == ProvisioningState.Deleting);

            }
        }

    }
}
