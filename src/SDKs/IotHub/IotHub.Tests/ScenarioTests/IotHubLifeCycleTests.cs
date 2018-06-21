// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace IotHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using IotHub.Tests.Helpers;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

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

                // Add and Get Tags
                IDictionary<string, string> tags = new Dictionary<string, string>();
                tags.Add("key1", "value1");
                tags.Add("key2", "value2");
                var tag = new TagsResource(tags);
                iotHub = this.iotHubClient.IotHubResource.Update(IotHubTestUtilities.DefaultResourceGroupName, IotHubTestUtilities.DefaultIotHubName, tag);

                Assert.NotNull(iotHub);
                Assert.True(iotHub.Tags.Count().Equals(2));
                Assert.Equal("value2", iotHub.Tags["key2"]);

                var subscriptionQuota = this.iotHubClient.ResourceProviderCommon.GetSubscriptionQuota();

                Assert.Equal(2, subscriptionQuota.Value.Count);
                Assert.Equal(1, subscriptionQuota.Value.FirstOrDefault(x => x.Name.Value.Equals("freeIotHubCount")).Limit);
                Assert.Equal(100, subscriptionQuota.Value.FirstOrDefault(x => x.Name.Value.Equals("paidIotHubCount")).Limit);

                var endpointHealth = this.iotHubClient.IotHubResource.GetEndpointHealth(IotHubTestUtilities.DefaultResourceGroupName, IotHubTestUtilities.DefaultIotHubName);
                Assert.Equal(4, endpointHealth.Count());
                Assert.True(endpointHealth.Any(q => q.EndpointId.Equals("events", StringComparison.OrdinalIgnoreCase)));

                TestAllRoutesInput testAllRoutesInput = new TestAllRoutesInput(RoutingSource.DeviceMessages, new RoutingMessage());
                TestAllRoutesResult testAllRoutesResult = this.iotHubClient.IotHubResource.TestAllRoutes(testAllRoutesInput, IotHubTestUtilities.DefaultIotHubName, IotHubTestUtilities.DefaultResourceGroupName);
                Assert.Equal(4, testAllRoutesResult.Routes.Count);

                TestRouteInput testRouteInput = new TestRouteInput(properties.Routing.Routes[0], new RoutingMessage());
                TestRouteResult testRouteResult = this.iotHubClient.IotHubResource.TestRoute(testRouteInput, IotHubTestUtilities.DefaultIotHubName, IotHubTestUtilities.DefaultResourceGroupName);
                Assert.Equal("true", testRouteResult.Result);

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

                // Get all Iot Hubs in a subscription
                var iotHubBySubscription = this.iotHubClient.IotHubResource.ListBySubscription();
                Assert.True(iotHubBySubscription.Count() > 0);

                // Get Registry Stats
                var regStats = this.iotHubClient.IotHubResource.GetStats(IotHubTestUtilities.DefaultResourceGroupName, IotHubTestUtilities.DefaultIotHubName);
                Assert.True(regStats.TotalDeviceCount.Value.Equals(0));
                Assert.True(regStats.EnabledDeviceCount.Value.Equals(0));
                Assert.True(regStats.DisabledDeviceCount.Value.Equals(0));

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
                Assert.True(ehConsumerGroups.Any(e => e.Name.Equals("$Default", StringComparison.OrdinalIgnoreCase)));

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

                // Get all of the available IoT Hub REST API operations
                var operationList = this.iotHubClient.Operations.List();
                Assert.True(operationList.Count() > 0);
                Assert.True(operationList.Any(e => e.Name.Equals("Microsoft.Devices/iotHubs/Read", StringComparison.OrdinalIgnoreCase)));

                // Get IoT Hub REST API read operation
                var hubReadOperation = operationList.Where(e => e.Name.Equals("Microsoft.Devices/iotHubs/Read", StringComparison.OrdinalIgnoreCase));
                Assert.True(hubReadOperation.Count().Equals(1));
                Assert.True(hubReadOperation.First().Display.Provider.Equals("Microsoft Devices", StringComparison.OrdinalIgnoreCase));
                Assert.True(hubReadOperation.First().Display.Operation.Equals("Get IotHub(s)", StringComparison.OrdinalIgnoreCase));
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

                // Update Again
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

        [Fact]
        public void TestIotHubCertificateLifeCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                // Create Resource Group
                var resourceGroup = this.CreateResourceGroup(IotHubTestUtilities.DefaultCertificateResourceGroupName);

                // Check if Hub Exists and Delete
                var operationInputs = new OperationInputs()
                {
                    Name = IotHubTestUtilities.DefaultCertificateIotHubName
                };

                var iotHubNameAvailabilityInfo = this.iotHubClient.IotHubResource.CheckNameAvailability(operationInputs);

                if (!(bool)iotHubNameAvailabilityInfo.NameAvailable)
                {
                    this.iotHubClient.IotHubResource.Delete(
                        IotHubTestUtilities.DefaultCertificateResourceGroupName,
                        IotHubTestUtilities.DefaultCertificateIotHubName);

                    iotHubNameAvailabilityInfo = this.iotHubClient.IotHubResource.CheckNameAvailability(operationInputs);
                    Assert.Equal(true, iotHubNameAvailabilityInfo.NameAvailable);
                }

                // Create Hub
                var iotHub = this.CreateIotHub(resourceGroup, IotHubTestUtilities.DefaultLocation, IotHubTestUtilities.DefaultCertificateIotHubName, null);

                // Upload Certificate to the Hub
                var newCertificateDescription = this.CreateCertificate(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName, IotHubTestUtilities.DefaultIotHubCertificateName, IotHubTestUtilities.DefaultIotHubCertificateContent);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateName, newCertificateDescription.Name);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateSubject, newCertificateDescription.Properties.Subject);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateThumbprint, newCertificateDescription.Properties.Thumbprint);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateType, newCertificateDescription.Type);
                Assert.False(newCertificateDescription.Properties.IsVerified);

                // Get all certificates
                var certificateList = this.GetCertificates(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName);
                Assert.True(certificateList.Value.Count().Equals(1));

                // Get certificate
                var certificate = this.GetCertificate(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName, IotHubTestUtilities.DefaultIotHubCertificateName);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateName, certificate.Name);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateSubject, certificate.Properties.Subject);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateThumbprint, certificate.Properties.Thumbprint);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateType, certificate.Type);
                Assert.False(certificate.Properties.IsVerified);

                var certificateWithNonceDescription = this.GenerateVerificationCode(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName, IotHubTestUtilities.DefaultIotHubCertificateName, certificate.Etag);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateName, certificateWithNonceDescription.Name);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateSubject, certificateWithNonceDescription.Properties.Subject);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateThumbprint, certificateWithNonceDescription.Properties.Thumbprint);
                Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateType, certificateWithNonceDescription.Type);
                Assert.False(certificateWithNonceDescription.Properties.IsVerified);
                Assert.NotNull(certificateWithNonceDescription.Properties.VerificationCode);

                // Delete certificate
                this.DeleteCertificate(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName, IotHubTestUtilities.DefaultIotHubCertificateName, certificateWithNonceDescription.Etag);

                // Get all certificate after delete
                var certificateListAfterDelete = this.GetCertificates(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName);
                Assert.True(certificateListAfterDelete.Value.Count().Equals(0));
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
