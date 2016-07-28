//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace IotHub.Tests.ScenarioTests
{
    using System;
    using System.Net;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using IotHub.Tests.Helpers;
    using IotHub.Tests.ScenarioTests;
    using Xunit;
    using System.Linq;

    public class IotHubLifeCycleTests : IotHubTestBase
    {
        [Fact]
        public void TestIotHubLifeCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                // Create Resource Group
                var resourceGroup = this.CreateResourceGroup();

                // Check if Hub Exists and Delete
                var operationInputs = new OperationInputs()
                {
                    Name = IotHubTestUtilities.DefaultIotHubName
                };

                var iotHubNameAvailabilityInfo = this.iotHubClient.IotHubResource.CheckNameAvailability(operationInputs);

                if (!(bool)iotHubNameAvailabilityInfo.NameAvailable)
                {
                    this.iotHubClient.IotHubResource.Delete(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName);

                    iotHubNameAvailabilityInfo = this.iotHubClient.IotHubResource.CheckNameAvailability(operationInputs);
                    Assert.Equal(true, iotHubNameAvailabilityInfo.NameAvailable);
                }


                // Create Hub
                var iotHub = this.CreateDefaultIotHub(resourceGroup);

                Assert.NotNull(iotHub);
                Assert.Equal(IotHubSku.S1, iotHub.Sku.Name);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubName, iotHub.Name);

                // Get quota metrics
                var quotaMetrics = this.iotHubClient.IotHubResource.GetQuotaMetrics(
                    IotHubTestUtilities.DefaultResourceGroupName,
                    IotHubTestUtilities.DefaultIotHubName);

                Assert.True(quotaMetrics.Count() > 0);
                Assert.True(quotaMetrics.Any(q => q.Name.Equals("TotalMessages", StringComparison.OrdinalIgnoreCase) &&
                                                  q.CurrentValue == 0 &&
                                                  q.MaxValue == 400000));

                Assert.True(quotaMetrics.Any(q => q.Name.Equals("TotalDeviceCount", StringComparison.OrdinalIgnoreCase) &&
                                                  q.CurrentValue == 0 &&
                                                  q.MaxValue == 500000));

                // Update capacity
                iotHub.Sku.Capacity += 1;
                var retIotHub = this.UpdateIotHub(resourceGroup, iotHub);

                Assert.NotNull(retIotHub);
                Assert.Equal(IotHubSku.S1, retIotHub.Sku.Name);
                Assert.Equal(iotHub.Sku.Capacity, retIotHub.Sku.Capacity);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubName, retIotHub.Name);

                // Get an Iot Hub
                var iotHubDesc = this.iotHubClient.IotHubResource.Get(
                    IotHubTestUtilities.DefaultResourceGroupName,
                    IotHubTestUtilities.DefaultIotHubName);


                Assert.NotNull(iotHubDesc);
                Assert.Equal(IotHubSku.S1, iotHubDesc.Sku.Name);
                Assert.Equal(iotHub.Sku.Capacity, iotHubDesc.Sku.Capacity);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubName, iotHubDesc.Name);

                // Get all Iot Hubs in a resource group
                var iotHubs = this.iotHubClient.IotHubResource.ListByResourceGroup(IotHubTestUtilities.DefaultResourceGroupName);
                Assert.True(iotHubs.Count() > 0);

                // Get Valid Skus
                var skus = this.iotHubClient.IotHubResource.GetValidSkus(
                    IotHubTestUtilities.DefaultResourceGroupName,
                    IotHubTestUtilities.DefaultIotHubName);
                Assert.Equal(3, skus.Count());


                // Get All Iothub Keys
                var keys = this.iotHubClient.IotHubResource.ListKeys(
                    IotHubTestUtilities.DefaultResourceGroupName,
                    IotHubTestUtilities.DefaultIotHubName);
                Assert.True(keys.Count() > 0);
                Assert.True(keys.Any(k => k.KeyName.Equals("iothubowner", StringComparison.OrdinalIgnoreCase)));

                // Get specific IotHub Key
                var key = this.iotHubClient.IotHubResource.GetKeysForKeyName(
                    IotHubTestUtilities.DefaultResourceGroupName,
                    IotHubTestUtilities.DefaultIotHubName,
                    "iothubowner");
                Assert.Equal("iothubowner", key.KeyName);

                // Get All EH consumer groups
                var ehConsumerGroups = this.iotHubClient.IotHubResource.ListEventHubConsumerGroups(
                    IotHubTestUtilities.DefaultResourceGroupName,
                    IotHubTestUtilities.DefaultIotHubName,
                    IotHubTestUtilities.EventsEndpointName);
                Assert.True(ehConsumerGroups.Count() > 0);
                Assert.True(ehConsumerGroups.Any(e => e.Equals("$Default", StringComparison.OrdinalIgnoreCase)));

                // Add EH consumer group
                var ehConsumerGroup = this.iotHubClient.IotHubResource.CreateEventHubConsumerGroup(
                    IotHubTestUtilities.DefaultResourceGroupName,
                    IotHubTestUtilities.DefaultIotHubName,
                    IotHubTestUtilities.EventsEndpointName,
                    "testConsumerGroup");

                Assert.Equal("testConsumerGroup", ehConsumerGroup.Name);


                // Get EH consumer group
                ehConsumerGroup = this.iotHubClient.IotHubResource.GetEventHubConsumerGroup(
                    IotHubTestUtilities.DefaultResourceGroupName,
                    IotHubTestUtilities.DefaultIotHubName,
                    IotHubTestUtilities.EventsEndpointName,
                    "testConsumerGroup");

                Assert.Equal("testConsumerGroup", ehConsumerGroup.Name);

                // Delete EH consumer group
                this.iotHubClient.IotHubResource.DeleteEventHubConsumerGroup(
                    IotHubTestUtilities.DefaultResourceGroupName,
                    IotHubTestUtilities.DefaultIotHubName,
                    IotHubTestUtilities.EventsEndpointName,
                    "testConsumerGroup");

                // Delete Hub
                this.iotHubClient.IotHubResource.Delete(
                    IotHubTestUtilities.DefaultResourceGroupName,
                    IotHubTestUtilities.DefaultIotHubName);

                iotHubNameAvailabilityInfo = this.iotHubClient.IotHubResource.CheckNameAvailability(operationInputs);
                Assert.Equal(true, iotHubNameAvailabilityInfo.NameAvailable);
            }
        }
    }
}
