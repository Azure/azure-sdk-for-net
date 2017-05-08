﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;

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
        public void TestIotHubCreateLifeCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                // Create Resource Group
                var resourceGroup = this.CreateResourceGroup(IotHubTestUtilities.DefaultResourceGroupName);

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

                //CreateEH and AuthRule
                var properties = new IotHubProperties();
                properties.Routing = this.GetIotHubRoutingProperties(resourceGroup);
                var iotHub = this.CreateIotHub(resourceGroup, IotHubTestUtilities.DefaultLocation, IotHubTestUtilities.DefaultIotHubName, properties);

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
            }
        }

        [Fact]
        public void TestIotHubUpdateLifeCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                // Create Resource Group
                var resourceGroup = this.CreateResourceGroup(IotHubTestUtilities.DefaultUpdateResourceGroupName);

                // Check if Hub Exists and Delete
                var operationInputs = new OperationInputs()
                {
                    Name = IotHubTestUtilities.DefaultUpdateIotHubName
                };

                var iotHubNameAvailabilityInfo = this.iotHubClient.IotHubResource.CheckNameAvailability(operationInputs);

                if (!(bool)iotHubNameAvailabilityInfo.NameAvailable)
                {
                    this.iotHubClient.IotHubResource.Delete(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultUpdateIotHubName);

                    iotHubNameAvailabilityInfo = this.iotHubClient.IotHubResource.CheckNameAvailability(operationInputs);
                    Assert.Equal(true, iotHubNameAvailabilityInfo.NameAvailable);
                }

                var iotHub = this.CreateIotHub(resourceGroup, IotHubTestUtilities.DefaultLocation, IotHubTestUtilities.DefaultUpdateIotHubName, null);

                Assert.NotNull(iotHub);
                Assert.Equal(IotHubSku.S1, iotHub.Sku.Name);
                Assert.Equal(IotHubTestUtilities.DefaultUpdateIotHubName, iotHub.Name);

                // Update capacity
                iotHub.Sku.Capacity += 1;
                var retIotHub = this.UpdateIotHub(resourceGroup, iotHub, IotHubTestUtilities.DefaultUpdateIotHubName);

                Assert.NotNull(retIotHub);
                Assert.Equal(IotHubSku.S1, retIotHub.Sku.Name);
                Assert.Equal(iotHub.Sku.Capacity, retIotHub.Sku.Capacity);
                Assert.Equal(IotHubTestUtilities.DefaultUpdateIotHubName, retIotHub.Name);

                // Update IotHub with routing rules

                iotHub.Properties.Routing = this.GetIotHubRoutingProperties(resourceGroup);
                retIotHub = this.UpdateIotHub(resourceGroup, iotHub, IotHubTestUtilities.DefaultUpdateIotHubName);

                Assert.NotNull(retIotHub);
                Assert.Equal(IotHubTestUtilities.DefaultUpdateIotHubName, retIotHub.Name);
                Assert.Equal(retIotHub.Properties.Routing.Routes.Count, 4);
                Assert.Equal(retIotHub.Properties.Routing.Endpoints.EventHubs.Count, 1);
                Assert.Equal(retIotHub.Properties.Routing.Endpoints.ServiceBusTopics.Count, 1);
                Assert.Equal(retIotHub.Properties.Routing.Endpoints.ServiceBusQueues.Count, 1);
                Assert.Equal(retIotHub.Properties.Routing.Routes[0].Name, "route1");

                // Get an Iot Hub
                var iotHubDesc = this.iotHubClient.IotHubResource.Get(
                    IotHubTestUtilities.DefaultUpdateResourceGroupName,
                    IotHubTestUtilities.DefaultUpdateIotHubName);


                Assert.NotNull(iotHubDesc);
                Assert.Equal(IotHubSku.S1, iotHubDesc.Sku.Name);
                Assert.Equal(iotHub.Sku.Capacity, iotHubDesc.Sku.Capacity);
                Assert.Equal(IotHubTestUtilities.DefaultUpdateIotHubName, iotHubDesc.Name);

                //Update Again
                // perform a dummy update
                iotHubDesc.Properties.Routing.Endpoints.EventHubs[0].ResourceGroup = "1";
                retIotHub = this.UpdateIotHub(resourceGroup, iotHubDesc, IotHubTestUtilities.DefaultUpdateIotHubName);
                Assert.NotNull(retIotHub);
                Assert.Equal(IotHubTestUtilities.DefaultUpdateIotHubName, retIotHub.Name);
                Assert.Equal(retIotHub.Properties.Routing.Routes.Count, 4);
                Assert.Equal(retIotHub.Properties.Routing.Endpoints.EventHubs.Count, 1);
                Assert.Equal(retIotHub.Properties.Routing.Endpoints.ServiceBusTopics.Count, 1);
                Assert.Equal(retIotHub.Properties.Routing.Endpoints.ServiceBusQueues.Count, 1);
                Assert.Equal(retIotHub.Properties.Routing.Routes[0].Name, "route1");
            }
        }

        RoutingProperties GetIotHubRoutingProperties(ResourceGroup resourceGroup)
        {
            var ehConnectionString = this.CreateExternalEH(resourceGroup, location);
            var sbTopicConnectionString = this.CreateExternalQueueAndTopic(resourceGroup, location);
            var sbConnectionString = sbTopicConnectionString.Item1;
            var topicConnectionString = sbTopicConnectionString.Item2;

            // Create Hub

            var routingProperties = new RoutingProperties()
            {
                Endpoints = new RoutingEndpoints()
                {
                    EventHubs = new List<RoutingEventHubProperties>()
                    {
                        new RoutingEventHubProperties()
                        {
                            Name = "eh1",
                            ConnectionString = ehConnectionString
                        }
                    },
                    ServiceBusQueues = new List<RoutingServiceBusQueueEndpointProperties>()
                    {
                        new RoutingServiceBusQueueEndpointProperties()
                        {
                            Name = "sb1",
                            ConnectionString = sbConnectionString
                        }
                    },
                    ServiceBusTopics = new List<RoutingServiceBusTopicEndpointProperties>()
                    {
                        new RoutingServiceBusTopicEndpointProperties()
                        {
                            Name = "tp1",
                            ConnectionString = topicConnectionString
                        }
                    }
                },
                Routes = new List<RouteProperties>()
                {
                    new RouteProperties()
                    {
                        Condition = "true",
                        EndpointNames = new List<string>() {"events"},
                        IsEnabled = true,
                        Name = "route1",
                        Source = "DeviceMessages"
                    },
                    new RouteProperties()
                    {
                        Condition = "true",
                        EndpointNames = new List<string>() {"eh1"},
                        IsEnabled = true,
                        Name = "route2",
                        Source = "DeviceMessages"
                    },
                    new RouteProperties()
                    {
                        Condition = "true",
                        EndpointNames = new List<string>() {"sb1"},
                        IsEnabled = true,
                        Name = "route3",
                        Source = "DeviceMessages"
                    },
                    new RouteProperties()
                    {
                        Condition = "true",
                        EndpointNames = new List<string>() {"tp1"},
                        IsEnabled = true,
                        Name = "route4",
                        Source = "DeviceMessages"
                    }
                }
            };

            return routingProperties;

        }
    }
}
