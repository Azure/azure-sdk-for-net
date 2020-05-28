using DigitalTwins.Tests.ScenarioTests;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalTwins.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DigitalTwins.Tests.Helpers;
    using Microsoft.Azure.Management.DigitalTwins;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class DigitalTwinsLifecycleTests: DigitalTwinsTestBase
    {
        [Fact]
        public void TestDigitalTwinsLifecycle()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
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

                // Add an endpoint
                var digitalTwinsEndpoint = digitalTwinsClient.DigitalTwinsEndpoint.CreateOrUpdate(DigitalTwinsTestUtilities.DefaultResourceGroupName, DigitalTwinsTestUtilities.DefaultInstanceName, DigitalTwinsTestUtilities.DefaultEndpointName);
                Assert.NotNull(digitalTwinsEndpoint);

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

                // Get all of the available DigitalTwins REST API operations
                var operationList = this.digitalTwinsClient.Operations.List();
                Assert.True(operationList.Count() > 0);
                Assert.Contains(operationList, e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/{DigitalTwinsTestUtilities.DefaultInstanceName}", StringComparison.OrdinalIgnoreCase));
                Assert.Contains(operationList, e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/{DigitalTwinsTestUtilities.DefaultInstanceName}/endpoints", StringComparison.OrdinalIgnoreCase));
                Assert.Contains(operationList, e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/{DigitalTwinsTestUtilities.DefaultInstanceName}/endpoints/{DigitalTwinsTestUtilities.DefaultEndpointName}", StringComparison.OrdinalIgnoreCase));

                // Get DigitalTwins REST API operations
                var digitalTwinOperations = operationList.Where(e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/{DigitalTwinsTestUtilities.DefaultInstanceName}", StringComparison.OrdinalIgnoreCase));
                Assert.True(digitalTwinOperations.Count().Equals(4));
                Assert.Equal("Microsoft DigitalTwins", digitalTwinOperations.First().Display.Provider, ignoreCase: true);

                // Get DigitalTwins REST API Endpoint list operation
                digitalTwinOperations = operationList.Where(e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/{DigitalTwinsTestUtilities.DefaultInstanceName}/endpoints", StringComparison.OrdinalIgnoreCase));
                Assert.True(digitalTwinOperations.Count().Equals(1));

                // Get Endpoint operations
                digitalTwinOperations = operationList.Where(e => e.Name.Equals($"Microsoft.DigitalTwins/digitalTwinsInstances/{DigitalTwinsTestUtilities.DefaultInstanceName}/endpoints/{DigitalTwinsTestUtilities.DefaultEndpointName}", StringComparison.OrdinalIgnoreCase));
                Assert.True(digitalTwinOperations.Count().Equals(3));

            }
        }

    }
}
