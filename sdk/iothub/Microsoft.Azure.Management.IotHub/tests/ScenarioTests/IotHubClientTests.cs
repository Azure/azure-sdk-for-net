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
    public class IotHubClientTests : IotHubTestBase
    {
        [Fact]
        public async Task IotHubClient_HubCreate()
        {
            try
            {
                using var context = MockContext.Start(GetType());
                Initialize(context);

                // Create resource group
                ResourceGroup resourceGroup = await CreateResourceGroupAsync(IotHubTestUtilities.DefaultResourceGroupName)
                    .ConfigureAwait(false);

                // Check if hub exists and delete
                IotHubNameAvailabilityInfo iotHubNameAvailabilityInfo = await _iotHubClient.IotHubResource
                    .CheckNameAvailabilityAsync(IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);

                if (!iotHubNameAvailabilityInfo.NameAvailable.Value)
                {
                    _ = await _iotHubClient.IotHubResource
                        .DeleteAsync(
                            IotHubTestUtilities.DefaultResourceGroupName,
                            IotHubTestUtilities.DefaultIotHubName)
                        .ConfigureAwait(false);

                    iotHubNameAvailabilityInfo = await _iotHubClient.IotHubResource
                        .CheckNameAvailabilityAsync(IotHubTestUtilities.DefaultIotHubName)
                        .ConfigureAwait(false);
                    iotHubNameAvailabilityInfo.NameAvailable.Should().BeTrue();
                }

                // Create EH and AuthRule
                var properties = new IotHubProperties
                {
                    Routing = await GetIotHubRoutingPropertiesAsync(resourceGroup).ConfigureAwait(false),
                    EnableDataResidency = false
                };

                IotHubDescription iotHub = await _iotHubClient.IotHubResource
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

                iotHub.Should().NotBeNull();
                iotHub.Name.Should().Be(IotHubTestUtilities.DefaultIotHubName);
                iotHub.Location.Should().Be(IotHubTestUtilities.DefaultLocation);
                iotHub.Sku.Name.Should().Be(IotHubSku.S1);
                iotHub.Sku.Capacity.Should().Be(1);
                iotHub.SystemData.CreatedAt.Should().NotBeNull();
                iotHub.Properties.EnableDataResidency.Should().BeFalse();

                // Add and get tags
                var tags = new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                };
                iotHub = await _iotHubClient.IotHubResource
                    .UpdateAsync(IotHubTestUtilities.DefaultResourceGroupName, IotHubTestUtilities.DefaultIotHubName, tags)
                    .ConfigureAwait(false);

                iotHub.Should().NotBeNull();
                iotHub.Tags.Count().Should().Be(tags.Count);
                iotHub.Tags.Should().BeEquivalentTo(tags);

                UserSubscriptionQuotaListResult subscriptionQuota = await _iotHubClient.ResourceProviderCommon
                    .GetSubscriptionQuotaAsync()
                    .ConfigureAwait(false);

                subscriptionQuota.Value.Count.Should().Be(2);
                subscriptionQuota.Value.FirstOrDefault(x => x.Name.Value.Equals("freeIotHubCount")).Limit.Should().BeGreaterThan(0);
                subscriptionQuota.Value.FirstOrDefault(x => x.Name.Value.Equals("paidIotHubCount")).Limit.Should().BeGreaterThan(0);

                IPage<EndpointHealthData> endpointHealth = await _iotHubClient
                    .IotHubResource
                    .GetEndpointHealthAsync(IotHubTestUtilities.DefaultResourceGroupName, IotHubTestUtilities.DefaultIotHubName);
                endpointHealth.Count().Should().Be(4);
                Assert.Contains(endpointHealth, q => q.EndpointId.Equals("events", StringComparison.OrdinalIgnoreCase));

                var testAllRoutesInput = new TestAllRoutesInput(RoutingSource.DeviceMessages, new RoutingMessage(), new RoutingTwin());
                TestAllRoutesResult testAllRoutesResult = await _iotHubClient.IotHubResource
                    .TestAllRoutesAsync(testAllRoutesInput, IotHubTestUtilities.DefaultIotHubName, IotHubTestUtilities.DefaultResourceGroupName)
                    .ConfigureAwait(false);
                testAllRoutesResult.Routes.Count.Should().Be(4);

                var testRouteInput = new TestRouteInput(properties.Routing.Routes[0], new RoutingMessage(), new RoutingTwin());
                TestRouteResult testRouteResult = await _iotHubClient.IotHubResource
                    .TestRouteAsync(testRouteInput, IotHubTestUtilities.DefaultIotHubName, IotHubTestUtilities.DefaultResourceGroupName)
                    .ConfigureAwait(false);
                testRouteResult.Result.Should().Be("true");

                // Get quota metrics
                var quotaMetrics = await _iotHubClient.IotHubResource
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

                // Get all IoT hubs in a resource group
                IPage<IotHubDescription> iotHubs = await _iotHubClient.IotHubResource
                    .ListByResourceGroupAsync(IotHubTestUtilities.DefaultResourceGroupName)
                    .ConfigureAwait(false);
                iotHubs.Count().Should().BeGreaterThan(0);

                // Get all IoT hubs in a subscription
                IPage<IotHubDescription> iotHubBySubscription = await _iotHubClient.IotHubResource
                    .ListBySubscriptionAsync()
                    .ConfigureAwait(false);
                iotHubBySubscription.Count().Should().BeGreaterThan(0);

                // Get registry stats on newly created hub
                RegistryStatistics regStats = await _iotHubClient.IotHubResource
                    .GetStatsAsync(IotHubTestUtilities.DefaultResourceGroupName, IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);
                regStats.TotalDeviceCount.Value.Should().Be(0);
                regStats.EnabledDeviceCount.Value.Should().Be(0);
                regStats.DisabledDeviceCount.Value.Should().Be(0);

                // Get valid skus
                IPage<IotHubSkuDescription> skus = await _iotHubClient.IotHubResource
                    .GetValidSkusAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);
                skus.Count().Should().Be(3);

                // Get all IoT hub keys
                const string hubOwnerRole = "iothubowner";
                IPage<SharedAccessSignatureAuthorizationRule> keys = await _iotHubClient.IotHubResource
                    .ListKeysAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);
                keys.Count().Should().BeGreaterThan(0);
                Assert.Contains(keys, k => k.KeyName.Equals(hubOwnerRole, StringComparison.OrdinalIgnoreCase));

                // Get specific IoT Hub key
                SharedAccessSignatureAuthorizationRule key = await _iotHubClient.IotHubResource
                    .GetKeysForKeyNameAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName,
                        hubOwnerRole)
                    .ConfigureAwait(false);
                key.KeyName.Should().Be(hubOwnerRole);

                // Get all EH consumer groups
                IPage<EventHubConsumerGroupInfo> ehConsumerGroups = await _iotHubClient.IotHubResource
                    .ListEventHubConsumerGroupsAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName,
                        IotHubTestUtilities.EventsEndpointName)
                    .ConfigureAwait(false);
                ehConsumerGroups.Count().Should().BeGreaterThan(0);
                Assert.Contains(ehConsumerGroups, e => e.Name.Equals("$Default", StringComparison.OrdinalIgnoreCase));

                // Add EH consumer group
                const string ehCgName = "testConsumerGroup";
                var ehConsumerGroup = await _iotHubClient.IotHubResource
                    .CreateEventHubConsumerGroupAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName,
                        IotHubTestUtilities.EventsEndpointName,
                        ehCgName,
                        new EventHubConsumerGroupName(ehCgName))
                    .ConfigureAwait(false);
                ehConsumerGroup.Name.Should().Be(ehCgName);

                // Get EH consumer group
                ehConsumerGroup = await _iotHubClient.IotHubResource
                    .GetEventHubConsumerGroupAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName,
                        IotHubTestUtilities.EventsEndpointName,
                        ehCgName)
                    .ConfigureAwait(false);
                ehConsumerGroup.Name.Should().Be(ehCgName);

                // Delete EH consumer group
                await _iotHubClient.IotHubResource.DeleteEventHubConsumerGroupAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName,
                        IotHubTestUtilities.EventsEndpointName,
                        ehCgName)
                    .ConfigureAwait(false);

                // Get all of the available IoT Hub REST API operations
                IPage<Operation> operationList = _iotHubClient.Operations.List();
                operationList.Count().Should().BeGreaterThan(0);
                Assert.Contains(operationList, e => e.Name.Equals("Microsoft.Devices/iotHubs/Read", StringComparison.OrdinalIgnoreCase));

                // Get IoT Hub REST API read operation
                IEnumerable<Operation> hubReadOperation = operationList.Where(e => e.Name.Equals("Microsoft.Devices/iotHubs/Read", StringComparison.OrdinalIgnoreCase));
                hubReadOperation.Count().Should().Be(1);
                hubReadOperation.First().Display.Provider.Should().Be("Microsoft Devices");
                hubReadOperation.First().Display.Operation.Should().Be("Get IotHub(s)");

                // Initiate manual failover
                IotHubDescription iotHubBeforeFailover = await _iotHubClient.IotHubResource
                    .GetAsync(
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultIotHubName)
                    .ConfigureAwait(false);

                await _iotHubClient.IotHub
                    .ManualFailoverAsync(
                        IotHubTestUtilities.DefaultIotHubName,
                        IotHubTestUtilities.DefaultResourceGroupName,
                        IotHubTestUtilities.DefaultFailoverLocation)
                    .ConfigureAwait(false);

                var iotHubAfterFailover = await _iotHubClient.IotHubResource
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
                Console.WriteLine($"{ex.Body.Message}: {ex.Body.Details}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [Fact]
        public async Task IotHubClient_HubUpdate()
        {
            try
            {
                using MockContext context = MockContext.Start(GetType());
                Initialize(context);

                // Create resource group
                ResourceGroup resourceGroup = await CreateResourceGroupAsync(IotHubTestUtilities.DefaultUpdateResourceGroupName);

                // Check if hub exists and delete
                var iotHubNameAvailabilityInfo = await _iotHubClient.IotHubResource
                    .CheckNameAvailabilityAsync(IotHubTestUtilities.DefaultUpdateIotHubName)
                    .ConfigureAwait(false);

                if (!iotHubNameAvailabilityInfo.NameAvailable.Value)
                {
                    _ = await _iotHubClient.IotHubResource
                        .DeleteAsync(
                            IotHubTestUtilities.DefaultResourceGroupName,
                            IotHubTestUtilities.DefaultUpdateIotHubName)
                        .ConfigureAwait(false);
                }

                var iotHub = await CreateIotHubAsync(resourceGroup, IotHubTestUtilities.DefaultLocation, IotHubTestUtilities.DefaultUpdateIotHubName, null)
                    .ConfigureAwait(false);

                iotHub.Should().NotBeNull();
                iotHub.Sku.Name.Should().Be(IotHubSku.S1);
                iotHub.Name.Should().Be(IotHubTestUtilities.DefaultUpdateIotHubName);

                // Update capacity
                iotHub.Sku.Capacity += 1;
                // Migrate RootCertificate to G2
                iotHub.Properties.RootCertificate = new RootCertificateProperties()
                {
                    EnableRootCertificateV2 = true
                };
                var retIotHub = await UpdateIotHubAsync(resourceGroup, iotHub, IotHubTestUtilities.DefaultUpdateIotHubName)
                    .ConfigureAwait(false);

                // Update Iot Hub with routing rules
                iotHub.Properties.Routing = await GetIotHubRoutingPropertiesAsync(resourceGroup).ConfigureAwait(false);
                retIotHub = await UpdateIotHubAsync(resourceGroup, iotHub, IotHubTestUtilities.DefaultUpdateIotHubName).ConfigureAwait(false);

                retIotHub.Should().NotBeNull();
                retIotHub.Name.Should().Be(IotHubTestUtilities.DefaultUpdateIotHubName);
                retIotHub.Properties.Routing.Routes.Count.Should().Be(4);
                retIotHub.Properties.Routing.Endpoints.EventHubs.Count.Should().Be(1);
                retIotHub.Properties.Routing.Endpoints.ServiceBusTopics.Count.Should().Be(1);
                retIotHub.Properties.Routing.Endpoints.ServiceBusQueues.Count.Should().Be(1);
                retIotHub.Properties.Routing.Routes[0].Name.Should().Be("route1");
                retIotHub.Properties.RootCertificate.EnableRootCertificateV2.Should().BeTrue();

                // Get an IoT Hub
                var iotHubDesc = await _iotHubClient.IotHubResource
                    .GetAsync(
                        IotHubTestUtilities.DefaultUpdateResourceGroupName,
                        IotHubTestUtilities.DefaultUpdateIotHubName)
                    .ConfigureAwait(false);

                iotHubDesc.Should().NotBeNull();
                iotHubDesc.Sku.Name.Should().Be(IotHubSku.S1);
                iotHubDesc.Sku.Capacity.Should().Be(iotHub.Sku.Capacity);
                iotHubDesc.Name.Should().Be(IotHubTestUtilities.DefaultUpdateIotHubName);

                // Update again
                // Perform a fake update
                iotHubDesc.Properties.Routing.Endpoints.EventHubs[0].ResourceGroup = "1";
                // Migrate RootCertificate to Baltimore
                iotHubDesc.Properties.RootCertificate = new RootCertificateProperties()
                {
                    EnableRootCertificateV2 = false
                };
                retIotHub = await UpdateIotHubAsync(resourceGroup, iotHubDesc, IotHubTestUtilities.DefaultUpdateIotHubName).ConfigureAwait(false);

                retIotHub.Should().NotBeNull();
                retIotHub.Name.Should().Be(IotHubTestUtilities.DefaultUpdateIotHubName);
                retIotHub.Properties.Routing.Routes.Count.Should().Be(4);
                retIotHub.Properties.Routing.Endpoints.EventHubs.Count.Should().Be(1);
                retIotHub.Properties.Routing.Endpoints.ServiceBusTopics.Count.Should().Be(1);
                retIotHub.Properties.Routing.Endpoints.ServiceBusQueues.Count.Should().Be(1);
                retIotHub.Properties.Routing.Routes[0].Name.Should().Be("route1");
                retIotHub.Properties.RootCertificate.EnableRootCertificateV2.Should().BeFalse();
            }
            catch (ErrorDetailsException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine($"{ex.Body.Message}: {ex.Body.Details}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [Fact]
        public async Task IotHubClient_HubCertificate()
        {
            try
            {
                using var context = MockContext.Start(GetType());
                Initialize(context);

                // Create resource group
                ResourceGroup resourceGroup = await CreateResourceGroupAsync(IotHubTestUtilities.DefaultCertificateResourceGroupName).ConfigureAwait(false);

                // Check if hub exists and delete
                IotHubNameAvailabilityInfo iotHubNameAvailabilityInfo = await _iotHubClient.IotHubResource
                    .CheckNameAvailabilityAsync(IotHubTestUtilities.DefaultCertificateIotHubName)
                    .ConfigureAwait(false);

                if (!iotHubNameAvailabilityInfo.NameAvailable.Value)
                {
                    _ = await _iotHubClient.IotHubResource
                        .DeleteAsync(
                            IotHubTestUtilities.DefaultCertificateResourceGroupName,
                            IotHubTestUtilities.DefaultCertificateIotHubName)
                        .ConfigureAwait(false);
                }

                // Create hub
                IotHubDescription iotHub = await CreateIotHubAsync(resourceGroup, IotHubTestUtilities.DefaultLocation, IotHubTestUtilities.DefaultCertificateIotHubName, null)
                    .ConfigureAwait(false);

                // Upload certificate to the hub
                CertificateDescription newCertificateDescription = await CreateCertificateAsync(
                        resourceGroup,
                        IotHubTestUtilities.DefaultCertificateIotHubName,
                        IotHubTestUtilities.DefaultIotHubCertificateName)
                    .ConfigureAwait(false);
                newCertificateDescription.Name.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateName);
                newCertificateDescription.Properties.Subject.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateSubject);
                newCertificateDescription.Properties.Thumbprint.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateThumbprint);
                newCertificateDescription.Type.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateType);
                newCertificateDescription.Properties.IsVerified.Should().BeFalse();

                // Get all certificates
                var certificateList = await GetCertificatesAsync(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName).ConfigureAwait(false);
                certificateList.Value.Count().Should().Be(1);

                // Get certificate
                CertificateDescription certificate = await GetCertificateAsync(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName, IotHubTestUtilities.DefaultIotHubCertificateName)
                    .ConfigureAwait(false);
                certificate.Name.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateName);
                certificate.Properties.Subject.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateSubject);
                certificate.Properties.Thumbprint.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateThumbprint);
                certificate.Type.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateType);
                certificate.Properties.IsVerified.Should().BeFalse();

                CertificateWithNonceDescription certificateWithNonceDescription = await GenerateVerificationCodeAsync(
                        resourceGroup,
                        IotHubTestUtilities.DefaultCertificateIotHubName,
                        IotHubTestUtilities.DefaultIotHubCertificateName,
                        certificate.Etag)
                    .ConfigureAwait(false);
                certificateWithNonceDescription.Name.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateName);
                certificateWithNonceDescription.Properties.Subject.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateSubject);
                certificateWithNonceDescription.Properties.Thumbprint.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateThumbprint);
                certificateWithNonceDescription.Type.Should().Be(IotHubTestUtilities.DefaultIotHubCertificateType);
                certificateWithNonceDescription.Properties.IsVerified.Should().BeFalse();
                certificateWithNonceDescription.Properties.VerificationCode.Should().NotBeNull();

                // Delete certificate
                await DeleteCertificateAsync(
                        resourceGroup,
                        IotHubTestUtilities.DefaultCertificateIotHubName,
                        IotHubTestUtilities.DefaultIotHubCertificateName,
                        certificateWithNonceDescription.Etag)
                    .ConfigureAwait(false);

                // Get all certificate after delete
                var certificateListAfterDelete = await GetCertificatesAsync(resourceGroup, IotHubTestUtilities.DefaultCertificateIotHubName)
                    .ConfigureAwait(false);
                certificateListAfterDelete.Value.Count().Should().Be(0);
            }
            catch (ErrorDetailsException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine($"{ex.Body.Message}: {ex.Body.Details}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private async Task<RoutingProperties> GetIotHubRoutingPropertiesAsync(ResourceGroup resourceGroup)
        {
            string ehConnectionString = await CreateExternalEhAsync(resourceGroup, _location);
            Tuple<string, string> sbTopicConnectionString = await CreateExternalQueueAndTopicAsync(resourceGroup, _location);
            string sbConnectionString = sbTopicConnectionString.Item1;
            string topicConnectionString = sbTopicConnectionString.Item2;

            // Create hub
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
