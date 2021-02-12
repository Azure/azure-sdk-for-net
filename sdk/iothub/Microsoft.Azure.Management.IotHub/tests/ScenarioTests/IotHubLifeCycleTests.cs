// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using FluentAssertions;
using IotHub.Tests.Helpers;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.IotHub.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IotHub.Tests.ScenarioTests
{
    public class IotHubLifeCycleTests : IotHubTestBase
    {
        [Fact]
        public async Task TestIotHubCreateLifecycle()
        {
            try
            {
                using var context = MockContext.Start(GetType());
                Initialize(context);

                // Create Resource Group
                ResourceGroup resourceGroup = await CreateResourceGroupAsync(IotHubTestUtilities.DefaultResourceGroupName)
                    .ConfigureAwait(false);

                // Check if Hub Exists and Delete
                IotHubNameAvailabilityInfo iotHubNameAvailabilityInfo = await iotHubClient.IotHubResource
                    .CheckNameAvailabilityAsync(IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);

                if (!(bool)iotHubNameAvailabilityInfo.NameAvailable)
                {
                    _ = await iotHubClient.IotHubResource
                        .DeleteAsync(
                            IotHubTestUtilities.DefaultResourceGroupName,
                            IotHubTestUtilities.DefaultIotHubName)
                        .ConfigureAwait(false);

                    iotHubNameAvailabilityInfo = await iotHubClient.IotHubResource
                        .CheckNameAvailabilityAsync(IotHubTestUtilities.DefaultIotHubName)
                        .ConfigureAwait(false);
                    iotHubNameAvailabilityInfo.NameAvailable.Should().BeTrue();
                }

                // Create EH and AuthRule
                var properties = new IotHubProperties
                {
                    Routing = await GetIotHubRoutingPropertiesAsync(resourceGroup).ConfigureAwait(false)
                };

                IotHubDescription iotHub = await iotHubClient.IotHubResource
                    .CreateOrUpdateAsync(
                        resourceGroup.Name,
                        IotHubTestUtilities.DefaultIotHubName,
                        new IotHubDescription
                        {
                            Location = IotHubTestUtilities.DefaultLocation,
                            Sku = new IotHubSkuInfo
                            {
                                Name = IotHubSku.S1,
                                Capacity = 1,
                            },
                            Properties = properties,
                        })
                    .ConfigureAwait(false);

                iotHub.Name.Should().Be(IotHubTestUtilities.DefaultIotHubName);
                iotHub.Location.Should().Be(IotHubTestUtilities.DefaultLocation);
                iotHub.Sku.Name.Should().Be(IotHubSku.S1);
                iotHub.Sku.Capacity.Should().Be(1);

                // Add and Get Tags
                var tags = new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                };
                iotHub = await iotHubClient.IotHubResource
                    .UpdateAsync(IotHubTestUtilities.DefaultResourceGroupName, IotHubTestUtilities.DefaultIotHubName, tags)
                    .ConfigureAwait(false);

                iotHub.Should().NotBeNull();
                iotHub.Tags.Count().Should().Be(tags.Count);
                iotHub.Tags.Should().BeEquivalentTo(tags);

                UserSubscriptionQuotaListResult subscriptionQuota = await iotHubClient.ResourceProviderCommon
                    .GetSubscriptionQuotaAsync()
                    .ConfigureAwait(false);

                subscriptionQuota.Value.Count.Should().Be(2);
                subscriptionQuota.Value.FirstOrDefault(x => x.Name.Value.Equals("freeIotHubCount")).Limit.Should().BeGreaterThan(0);
                subscriptionQuota.Value.FirstOrDefault(x => x.Name.Value.Equals("paidIotHubCount")).Limit.Should().BeGreaterThan(0);

                IPage<EndpointHealthData> endpointHealth = await iotHubClient
                    .IotHubResource
                    .GetEndpointHealthAsync(IotHubTestUtilities.DefaultResourceGroupName, IotHubTestUtilities.DefaultIotHubName);
                endpointHealth.Count().Should().Be(4);
                Assert.Contains(endpointHealth, q => q.EndpointId.Equals("events", StringComparison.OrdinalIgnoreCase));

                var testAllRoutesInput = new TestAllRoutesInput(RoutingSource.DeviceMessages, new RoutingMessage(), new RoutingTwin());
                TestAllRoutesResult testAllRoutesResult = await iotHubClient.IotHubResource
                    .TestAllRoutesAsync(testAllRoutesInput, IotHubTestUtilities.DefaultIotHubName, IotHubTestUtilities.DefaultResourceGroupName)
                    .ConfigureAwait(false);
                testAllRoutesResult.Routes.Count.Should().Be(4);

                var testRouteInput = new TestRouteInput(properties.Routing.Routes[0], new RoutingMessage(), new RoutingTwin());
                TestRouteResult testRouteResult = await iotHubClient.IotHubResource
                    .TestRouteAsync(testRouteInput, IotHubTestUtilities.DefaultIotHubName, IotHubTestUtilities.DefaultResourceGroupName)
                    .ConfigureAwait(false);
                testRouteResult.Result.Should().Be("true");

                // Get quota metrics
                var quotaMetrics = await iotHubClient.IotHubResource
                    .GetQuotaMetricsAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);

                quotaMetrics.Count().Should().BeGreaterThan(0);
                Assert.Contains(quotaMetrics, q => q.Name.Equals("TotalMessages", StringComparison.OrdinalIgnoreCase)
                    && q.CurrentValue == 0
                    && q.MaxValue == 400000);

                Assert.Contains(quotaMetrics, q => q.Name.Equals("TotalDeviceCount", StringComparison.OrdinalIgnoreCase)
                    && q.CurrentValue == 0
                    && q.MaxValue == 1000000);

                // Get all Iot Hubs in a resource group
                IPage<IotHubDescription> iotHubs = await iotHubClient.IotHubResource
                    .ListByResourceGroupAsync(IotHubTestUtilities.DefaultResourceGroupName)
                    .ConfigureAwait(false);
                iotHubs.Count().Should().BeGreaterThan(0);

                // Get all Iot Hubs in a subscription
                IPage<IotHubDescription> iotHubBySubscription = await iotHubClient.IotHubResource
                    .ListBySubscriptionAsync()
                    .ConfigureAwait(false);
                iotHubBySubscription.Count().Should().BeGreaterThan(0);

                // Get Registry Stats on newly created hub
                RegistryStatistics regStats = await iotHubClient.IotHubResource
                    .GetStatsAsync(IotHubTestUtilities.DefaultResourceGroupName, IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);
                regStats.TotalDeviceCount.Value.Should().Be(0);
                regStats.EnabledDeviceCount.Value.Should().Be(0);
                regStats.DisabledDeviceCount.Value.Should().Be(0);

                // Get Valid Skus
                IPage<IotHubSkuDescription> skus = await iotHubClient.IotHubResource
                    .GetValidSkusAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);
                skus.Count().Should().Be(3);

                // Get All Iot Hub Keys
                IPage<SharedAccessSignatureAuthorizationRule> keys = await iotHubClient.IotHubResource
                    .ListKeysAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);
                keys.Count().Should().BeGreaterThan(0);
                Assert.Contains(keys, k => k.KeyName.Equals("iothubowner", StringComparison.OrdinalIgnoreCase));

                // Get specific IotHub Key
                SharedAccessSignatureAuthorizationRule key = await iotHubClient.IotHubResource
                    .GetKeysForKeyNameAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName,
                        "iothubowner")
                    .ConfigureAwait(false);
                key.KeyName.Should().Be("iothubowner");

                // Get All EH consumer groups
                IPage<EventHubConsumerGroupInfo> ehConsumerGroups = await iotHubClient.IotHubResource
                    .ListEventHubConsumerGroupsAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName,
                        IotHubTestUtilities.EventsEndpointName)
                    .ConfigureAwait(false);
                ehConsumerGroups.Count().Should().BeGreaterThan(0);
                Assert.Contains(ehConsumerGroups, e => e.Name.Equals("$Default", StringComparison.OrdinalIgnoreCase));

                // Add EH consumer group
                var ehConsumerGroup = await iotHubClient.IotHubResource
                    .CreateEventHubConsumerGroupAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName,
                        IotHubTestUtilities.EventsEndpointName,
                        "testConsumerGroup",
                        new EventHubConsumerGroupName("testConsumerGroup"))
                    .ConfigureAwait(false);

                ehConsumerGroup.Name.Should().Be("testConsumerGroup");


                // Get EH consumer group
                ehConsumerGroup = await iotHubClient.IotHubResource
                    .GetEventHubConsumerGroupAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName,
                        IotHubTestUtilities.EventsEndpointName,
                        "testConsumerGroup")
                    .ConfigureAwait(false);

                ehConsumerGroup.Name.Should().Be("testConsumerGroup");

                // Delete EH consumer group
                await iotHubClient.IotHubResource.DeleteEventHubConsumerGroupAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName,
                        IotHubTestUtilities.EventsEndpointName,
                        "testConsumerGroup")
                    .ConfigureAwait(false);

                // Get all of the available IoT Hub REST API operations
                IPage<Operation> operationList = iotHubClient.Operations.List();
                operationList.Count().Should().BeGreaterThan(0);
                Assert.Contains(operationList, e => e.Name.Equals("Microsoft.Devices/iotHubs/Read", StringComparison.OrdinalIgnoreCase));

                // Get IoT Hub REST API read operation
                IEnumerable<Operation> hubReadOperation = operationList.Where(e => e.Name.Equals("Microsoft.Devices/iotHubs/Read", StringComparison.OrdinalIgnoreCase));
                hubReadOperation.Count().Should().Be(1);
                hubReadOperation.First().Display.Provider.Should().Be("Microsoft Devices");
                hubReadOperation.First().Display.Operation.Should().Be("Get IotHub(s)");

                // Initiate manual failover
                IotHubDescription iotHubBeforeFailover = await iotHubClient.IotHubResource
                    .GetAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);
                await iotHubClient.IotHub
                    .ManualFailoverAsync(
                        IotHubTestUtilities.DefaultIotHubName,
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultFailoverLocation)
                    .ConfigureAwait(false);
                var iotHubAfterFailover = await iotHubClient.IotHubResource
                    .GetAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);
                iotHubBeforeFailover.Properties.Locations[0].Role.ToLower().Should().Be("primary");
                iotHubBeforeFailover.Properties.Locations[0].Location.Replace(" ", "").ToLower().Should().Be(IotHubTestUtilities.DefaultLocation.ToLower());
                iotHubBeforeFailover.Properties.Locations[1].Role.ToLower().Should().Be("secondary");
                iotHubBeforeFailover.Properties.Locations[1].Location.Replace(" ", "").ToLower().Should().Be(IotHubTestUtilities.DefaultFailoverLocation.ToLower());

                iotHubAfterFailover.Properties.Locations[0].Role.ToLower().Should().Be("primary");
                iotHubAfterFailover.Properties.Locations[0].Location.Replace(" ", "").ToLower().Should().Be(IotHubTestUtilities.DefaultFailoverLocation.ToLower());
                iotHubAfterFailover.Properties.Locations[1].Role.ToLower().Should().Be("secondary");
                iotHubAfterFailover.Properties.Locations[1].Location.Replace(" ", "").ToLower().Should().Be(IotHubTestUtilities.DefaultLocation.ToLower());
            }
            catch (ErrorDetailsException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [Fact]
        public async Task TestIotHubUpdateLifecycle()
        {
            using MockContext context = MockContext.Start(GetType());
            Initialize(context);

            // Create Resource Group
            ResourceGroup resourceGroup = await CreateResourceGroupAsync(IotHubTestUtilities.DefaultUpdateResourceGroupName);

            // Check if Hub Exists and Delete
            var iotHubNameAvailabilityInfo = await iotHubClient.IotHubResource
                .CheckNameAvailabilityAsync(IotHubTestUtilities.DefaultUpdateIotHubName)
                .ConfigureAwait(false);

            if (!(bool)iotHubNameAvailabilityInfo.NameAvailable)
            {
                await iotHubClient.IotHubResource
                    .DeleteAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultUpdateIotHubName)
                    .ConfigureAwait(false);

                iotHubNameAvailabilityInfo = await iotHubClient.IotHubResource
                    .CheckNameAvailabilityAsync(IotHubTestUtilities.DefaultUpdateIotHubName)
                    .ConfigureAwait(false);
                Assert.True(iotHubNameAvailabilityInfo.NameAvailable);
            }

            var iotHub = await CreateIotHubAsync(resourceGroup, IotHubTestUtilities.DefaultLocation, IotHubTestUtilities.DefaultUpdateIotHubName, null)
                .ConfigureAwait(false);

            Assert.NotNull(iotHub);
            Assert.Equal(IotHubSku.S1, iotHub.Sku.Name);
            Assert.Equal(IotHubTestUtilities.DefaultUpdateIotHubName, iotHub.Name);

            // Update capacity
            iotHub.Sku.Capacity += 1;
            var retIotHub = await UpdateIotHubAsync(resourceGroup, iotHub, IotHubTestUtilities.DefaultUpdateIotHubName)
                .ConfigureAwait(false);

            Assert.NotNull(retIotHub);
            Assert.Equal(IotHubSku.S1, retIotHub.Sku.Name);
            Assert.Equal(iotHub.Sku.Capacity, retIotHub.Sku.Capacity);
            Assert.Equal(IotHubTestUtilities.DefaultUpdateIotHubName, retIotHub.Name);

            // Update IotHub with routing rules

            iotHub.Properties.Routing = await GetIotHubRoutingPropertiesAsync(resourceGroup);
            retIotHub = await UpdateIotHubAsync(resourceGroup, iotHub, IotHubTestUtilities.DefaultUpdateIotHubName);

            Assert.NotNull(retIotHub);
            Assert.Equal(IotHubTestUtilities.DefaultUpdateIotHubName, retIotHub.Name);
            Assert.Equal(4, retIotHub.Properties.Routing.Routes.Count);
            Assert.Equal(1, retIotHub.Properties.Routing.Endpoints.EventHubs.Count);
            Assert.Equal(1, retIotHub.Properties.Routing.Endpoints.ServiceBusTopics.Count);
            Assert.Equal(1, retIotHub.Properties.Routing.Endpoints.ServiceBusQueues.Count);
            Assert.Equal("route1", retIotHub.Properties.Routing.Routes[0].Name);

            // Get an Iot Hub
            var iotHubDesc = iotHubClient.IotHubResource.Get(
                IotHubTestUtilities.DefaultUpdateResourceGroupName,
                IotHubTestUtilities.DefaultUpdateIotHubName);


            Assert.NotNull(iotHubDesc);
            Assert.Equal(IotHubSku.S1, iotHubDesc.Sku.Name);
            Assert.Equal(iotHub.Sku.Capacity, iotHubDesc.Sku.Capacity);
            Assert.Equal(IotHubTestUtilities.DefaultUpdateIotHubName, iotHubDesc.Name);

            // Update Again
            // perform a dummy update
            iotHubDesc.Properties.Routing.Endpoints.EventHubs[0].ResourceGroup = "1";
            retIotHub = await UpdateIotHubAsync(resourceGroup, iotHubDesc, IotHubTestUtilities.DefaultUpdateIotHubName);

            Assert.NotNull(retIotHub);
            Assert.Equal(IotHubTestUtilities.DefaultUpdateIotHubName, retIotHub.Name);
            Assert.Equal(4, retIotHub.Properties.Routing.Routes.Count);
            Assert.Equal(1, retIotHub.Properties.Routing.Endpoints.EventHubs.Count);
            Assert.Equal(1, retIotHub.Properties.Routing.Endpoints.ServiceBusTopics.Count);
            Assert.Equal(1, retIotHub.Properties.Routing.Endpoints.ServiceBusQueues.Count);
            Assert.Equal("route1", retIotHub.Properties.Routing.Routes[0].Name);
        }

        [Fact]
        public async Task TestIotHubCertificateLifecycle()
        {
            using var context = MockContext.Start(GetType());
            Initialize(context);

            // Create Resource Group
            var resourceGroup = await CreateResourceGroupAsync(IotHubTestUtilities.DefaultCertificateResourceGroupName);

            // Check if Hub Exists and Delete
            var iotHubNameAvailabilityInfo = iotHubClient.IotHubResource.CheckNameAvailability(IotHubTestUtilities.DefaultCertificateIotHubName);

            if (!(bool)iotHubNameAvailabilityInfo.NameAvailable)
            {
                iotHubClient.IotHubResource.Delete(
                    IotHubTestUtilities.DefaultCertificateResourceGroupName,
                    IotHubTestUtilities.DefaultCertificateIotHubName);

                iotHubNameAvailabilityInfo = iotHubClient.IotHubResource.CheckNameAvailability(IotHubTestUtilities.DefaultCertificateIotHubName);
                Assert.True(iotHubNameAvailabilityInfo.NameAvailable);
            }

            // Create Hub
            var iotHub = await CreateIotHubAsync(resourceGroup, IotHubTestUtilities.DefaultLocation, IotHubTestUtilities.DefaultCertificateIotHubName, null);

            // Upload Certificate to the Hub
            var newCertificateDescription = await CreateCertificateAsync(
                resourceGroup,
                IotHubTestUtilities.DefaultCertificateIotHubName,
                IotHubTestUtilities.DefaultIotHubCertificateName);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateName, newCertificateDescription.Name);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateSubject, newCertificateDescription.Properties.Subject);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateThumbprint, newCertificateDescription.Properties.Thumbprint);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateType, newCertificateDescription.Type);
            Assert.False(newCertificateDescription.Properties.IsVerified);

            // Get all certificates
            var certificateList = await GetCertificatesAsync(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName);
            Assert.True(certificateList.Value.Count().Equals(1));

            // Get certificate
            var certificate = await GetCertificateAsync(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName, IotHubTestUtilities.DefaultIotHubCertificateName);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateName, certificate.Name);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateSubject, certificate.Properties.Subject);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateThumbprint, certificate.Properties.Thumbprint);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateType, certificate.Type);
            Assert.False(certificate.Properties.IsVerified);

            var certificateWithNonceDescription = await GenerateVerificationCodeAsync(
                resourceGroup,
                IotHubTestUtilities.DefaultCertificateIotHubName,
                IotHubTestUtilities.DefaultIotHubCertificateName,
                certificate.Etag);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateName, certificateWithNonceDescription.Name);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateSubject, certificateWithNonceDescription.Properties.Subject);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateThumbprint, certificateWithNonceDescription.Properties.Thumbprint);
            Assert.Equal(IotHubTestUtilities.DefaultIotHubCertificateType, certificateWithNonceDescription.Type);
            Assert.False(certificateWithNonceDescription.Properties.IsVerified);
            Assert.NotNull(certificateWithNonceDescription.Properties.VerificationCode);

            // Delete certificate
            await DeleteCertificateAsync(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName, IotHubTestUtilities.DefaultIotHubCertificateName, certificateWithNonceDescription.Etag);

            // Get all certificate after delete
            var certificateListAfterDelete = await GetCertificatesAsync(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName);
            Assert.True(certificateListAfterDelete.Value.Count().Equals(0));
        }

        private async Task<RoutingProperties> GetIotHubRoutingPropertiesAsync(ResourceGroup resourceGroup)
        {
            string ehConnectionString = await CreateExternalEhAsync(resourceGroup, location);
            Tuple<string, string> sbTopicConnectionString = await CreateExternalQueueAndTopicAsync(resourceGroup, location);
            string sbConnectionString = sbTopicConnectionString.Item1;
            string topicConnectionString = sbTopicConnectionString.Item2;

            // Create Hub

            var routingProperties = new RoutingProperties
            {
                Endpoints = new RoutingEndpoints
                {
                    EventHubs = new List<RoutingEventHubProperties>
                    {
                        new RoutingEventHubProperties
                        {
                            Name = "eh1",
                            ConnectionString = ehConnectionString
                        }
                    },
                    ServiceBusQueues = new List<RoutingServiceBusQueueEndpointProperties>
                    {
                        new RoutingServiceBusQueueEndpointProperties
                        {
                            Name = "sb1",
                            ConnectionString = sbConnectionString
                        }
                    },
                    ServiceBusTopics = new List<RoutingServiceBusTopicEndpointProperties>
                    {
                        new RoutingServiceBusTopicEndpointProperties
                        {
                            Name = "tp1",
                            ConnectionString = topicConnectionString
                        }
                    }
                },
                Routes = new List<RouteProperties>
                {
                    new RouteProperties
                    {
                        Condition = "true",
                        EndpointNames = new List<string> {"events"},
                        IsEnabled = true,
                        Name = "route1",
                        Source = "DeviceMessages"
                    },
                    new RouteProperties
                    {
                        Condition = "true",
                        EndpointNames = new List<string> {"eh1"},
                        IsEnabled = true,
                        Name = "route2",
                        Source = "DeviceMessages"
                    },
                    new RouteProperties
                    {
                        Condition = "true",
                        EndpointNames = new List<string> {"sb1"},
                        IsEnabled = true,
                        Name = "route3",
                        Source = "DeviceMessages"
                    },
                    new RouteProperties
                    {
                        Condition = "true",
                        EndpointNames = new List<string> {"tp1"},
                        IsEnabled = true,
                        Name = "route4",
                        Source = "DeviceMessages"
                    },
                }
            };

            return routingProperties;
        }
    }
}
