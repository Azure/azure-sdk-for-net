// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Dns.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using SubResource = Microsoft.Azure.Management.Dns.Models.SubResource;

namespace Microsoft.Azure.Management.Dns.Testing
{
    public class ZoneScenarioTests
    {
        [Fact]
        public void CrudZoneFullCycle()
        {
            using (
                MockContext context = MockContext.Start(this.GetType())
                )
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var dnsClient = ResourceGroupHelper.GetDnsClient(
                    context,
                    dnsHandler);
                var resourceManagementClient =
                    ResourceGroupHelper.GetResourcesClient(
                        context,
                        resourcesHandler);

                string zoneName =
                    TestUtilities.GenerateName("hydratest.dnszone.com");
                string location =
                    ResourceGroupHelper.GetResourceLocation(
                        resourceManagementClient,
                        "microsoft.network/dnszones");
                ResourceGroup resourceGroup =
                    ResourceGroupHelper.CreateResourceGroup(
                        resourceManagementClient);

                Action<Zone> assertZoneInvariants = zone =>
                {
                    Assert.Equal(zoneName, zone.Name);
                    Assert.False(string.IsNullOrEmpty(zone.Etag));
                };

                // Create the zone clean, verify response
                var createdZone = dnsClient.Zones.CreateOrUpdate(
                    resourceGroup.Name,
                    zoneName,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: new Zone
                    {
                        Location = location,
                        Tags =
                            new Dictionary<string, string> { { "tag1", "value1" } },
                    });

                assertZoneInvariants(createdZone);
                Assert.Equal(1, createdZone.Tags.Count);
                Assert.True(
                    createdZone.NameServers != null &&
                    createdZone.NameServers.Any(
                        nameServer => !string.IsNullOrWhiteSpace(nameServer)));

                // Ensure that Id is parseable into resourceGroup
                string resourceGroupName =
                    ExtractResourceGroupNameFromId(createdZone.Id);
                Assert.Equal(resourceGroupName, resourceGroup.Name);

                // Retrieve the zone after create, verify response
                var retrievedZone = dnsClient.Zones.Get(
                    resourceGroup.Name,
                    zoneName);

                assertZoneInvariants(retrievedZone);
                Assert.Equal(1, retrievedZone.Tags.Count);

                Assert.True(
                    retrievedZone.NameServers != null &&
                    retrievedZone.NameServers.Any(
                        nameServer => !string.IsNullOrWhiteSpace(nameServer)));

                // Call Update on the object returned by Create (important distinction from Get below)
                createdZone.Tags = new Dictionary<string, string>
                {
                    {"tag1", "value1"},
                    {"tag2", "value2"}
                };

                var updateResponse =
                    dnsClient.Zones.CreateOrUpdate(
                        resourceGroup.Name,
                        zoneName,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: createdZone);

                assertZoneInvariants(updateResponse);
                Assert.Equal(2, updateResponse.Tags.Count);

                // Retrieve the zone after create, verify response
                retrievedZone = dnsClient.Zones.Get(
                    resourceGroup.Name,
                    zoneName);

                assertZoneInvariants(retrievedZone);
                Assert.Equal(2, retrievedZone.Tags.Count);

                // Call Update on the object returned by Get (important distinction from Create above)
                retrievedZone.Tags = new Dictionary<string, string>
                {
                    {"tag1", "value1"},
                    {"tag2", "value2"},
                    {"tag3", "value3"}
                };

                updateResponse =
                    dnsClient.Zones.CreateOrUpdate(
                        resourceGroup.Name,
                        zoneName,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: retrievedZone);

                assertZoneInvariants(updateResponse);
                Assert.Equal(3, updateResponse.Tags.Count);

                // Call Patch operation
                retrievedZone.Tags = new Dictionary<string, string>
                {
                    {"tag1", "value1"},
                    {"tag2", "value2"},
                    {"tag3", "value3"},
                    {"tag4", "value4"}
                };

                updateResponse =
                    dnsClient.Zones.Update(
                        resourceGroup.Name,
                        zoneName,
                        ifMatch: null,
                        tags: retrievedZone.Tags);

                assertZoneInvariants(updateResponse);
                Assert.Equal(4, updateResponse.Tags.Count);

                // Delete the zone
                DeleteZones(dnsClient, resourceGroup, new[] { zoneName });
            }
        }

        [Fact]
        public void CrudPrivateZoneFullCycle()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
                };
                var networkHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
                };

                var dnsClient = ResourceGroupHelper.GetDnsClient(context, dnsHandler);
                var resourceManagementClient = ResourceGroupHelper.GetResourcesClient(context, resourcesHandler);
                var networkManagementClient = ResourceGroupHelper.GetNetworkClient(context, networkHandler);

                var zoneName = TestUtilities.GenerateName("hydratest.privatednszone.com");
                var location = ResourceGroupHelper.GetResourceLocation(resourceManagementClient, "microsoft.network/dnszones");
                var resourceGroup = ResourceGroupHelper.CreateResourceGroup(resourceManagementClient);
                var registrationVnet = ResourceGroupHelper.CreateVirtualNetwork(resourceGroup.Name, networkManagementClient);
                var resolutionVnet = ResourceGroupHelper.CreateVirtualNetwork(resourceGroup.Name, networkManagementClient);

                void AssertPrivateZoneInvariants(Zone zone)
                {
                    if (zone == null)
                    {
                        throw new ArgumentNullException(nameof(zone));
                    }

                    Assert.Equal(zoneName, zone.Name);
                    Assert.Equal(ZoneType.Private, zone.ZoneType);
                    Assert.False(string.IsNullOrEmpty(zone.Etag));
                }

                // Create private zone clean, verify reponse
                var createdPrivateZone = dnsClient.Zones.CreateOrUpdate(
                    resourceGroup.Name,
                    zoneName,
                    new Zone
                    {
                        Location = location,
                        ZoneType = ZoneType.Private,
                        Tags = new Dictionary<string, string> { { "tag1", "value1" } },
                        RegistrationVirtualNetworks = new List<SubResource>
                        {
                            new SubResource(registrationVnet.Id)
                        },
                        ResolutionVirtualNetworks = new List<SubResource>
                        {
                            new SubResource(resolutionVnet.Id)
                        }
                    });

                AssertPrivateZoneInvariants(createdPrivateZone);
                Assert.Equal(1, createdPrivateZone.Tags.Count);
                Assert.True(!createdPrivateZone.NameServers.IsAny());

                // Ensure that Id is parseable into resourceGroup
                var resourceGroupName = ExtractResourceGroupNameFromId(createdPrivateZone.Id);
                Assert.Equal(resourceGroupName, resourceGroup.Name);

                var regVirtualNetworkName = ExtractVirtualNetworkNameFromId(createdPrivateZone.RegistrationVirtualNetworks[0].Id);
                Assert.Equal(regVirtualNetworkName, registrationVnet.Name);

                var resVirtualNetworkName = ExtractVirtualNetworkNameFromId(createdPrivateZone.ResolutionVirtualNetworks[0].Id);
                Assert.Equal(resVirtualNetworkName, resolutionVnet.Name);

                // Retrieve the zone after create, verify response
                var retrievedPrivateZone = dnsClient.Zones.Get(resourceGroup.Name, zoneName);
                AssertPrivateZoneInvariants(retrievedPrivateZone);
                Assert.Equal(1, retrievedPrivateZone.Tags.Count);
                Assert.True(!retrievedPrivateZone.NameServers.IsAny());

                // Call Update on the object returned by Create (important distinction from Get below)
                createdPrivateZone.Tags = new Dictionary<string, string>
                {
                    {"tag1", "value1"},
                    {"tag2", "value2"}
                };

                var updateResponse = dnsClient.Zones.CreateOrUpdate(resourceGroup.Name, zoneName, ifMatch: null, ifNoneMatch: null, parameters: createdPrivateZone);
                AssertPrivateZoneInvariants(updateResponse);
                Assert.Equal(2, updateResponse.Tags.Count);

                // Retrieve the zone after create, verify response
                retrievedPrivateZone = dnsClient.Zones.Get(resourceGroup.Name, zoneName);
                AssertPrivateZoneInvariants(retrievedPrivateZone);
                Assert.Equal(2, retrievedPrivateZone.Tags.Count);

                // Call Update on the object returned by Get (important distinction from Create above)
                retrievedPrivateZone.Tags = new Dictionary<string, string>
                {
                    {"tag1", "value1"},
                    {"tag2", "value2"},
                    {"tag3", "value3"}
                };

                updateResponse = dnsClient.Zones.CreateOrUpdate(resourceGroup.Name, zoneName, ifMatch: null, ifNoneMatch: null, parameters: retrievedPrivateZone);
                AssertPrivateZoneInvariants(updateResponse);
                Assert.Equal(3, updateResponse.Tags.Count);

                // Delete the zone
                DeleteZones(dnsClient, resourceGroup, new[] { zoneName });
            }
        }

        [Fact]
        public void ListZones()
        {
            using (
                MockContext context = MockContext.Start(this.GetType())
                )
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var networkHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };

                var dnsClient = ResourceGroupHelper.GetDnsClient(context, dnsHandler);

                var numPublicZones = 2;
                var numPrivateZones = 2;
                var publicZoneNames = Enumerable.Range(0, numPublicZones).Select(i => TestUtilities.GenerateName("hydratest.dnszone.com")).ToArray();
                var privateZoneNames = Enumerable.Range(0, numPrivateZones).Select(i => TestUtilities.GenerateName("hydratest.privatednszone.com")).ToArray();

                var resourceManagementClient = ResourceGroupHelper.GetResourcesClient(context, resourcesHandler);
                var networkManagementClient = ResourceGroupHelper.GetNetworkClient(context, networkHandler);

                var resourceGroup = ResourceGroupHelper.CreateResourceGroup(resourceManagementClient);
                CreateZones(dnsClient, resourceGroup, publicZoneNames, resourceManagementClient);
                CreatePrivateZones(dnsClient, resourceGroup, privateZoneNames, resourceManagementClient, networkManagementClient);

                var expectedZoneNames = publicZoneNames.Concat(privateZoneNames).ToArray();
                var listresponse = dnsClient.Zones.ListByResourceGroup(resourceGroup.Name);

                Assert.NotNull(listresponse);
                Assert.Equal(numPublicZones + numPrivateZones, listresponse.Count());
                Assert.True(expectedZoneNames.All(expectedZoneName => listresponse.Any(resp => string.Equals(resp.Name, expectedZoneName))), "The response of the List request does not meet expectations.");

                DeleteZones(dnsClient, resourceGroup, expectedZoneNames);
            }
        }

        [Fact]
        public void ListZonesInSubscription()
        {
            using (
                MockContext context = MockContext.Start(this.GetType())
                )
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var networkHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };

                var dnsClient = ResourceGroupHelper.GetDnsClient(context, dnsHandler);

                var numPublicZones = 2;
                var numPrivateZones = 2;
                var publicZoneNames = Enumerable.Range(0, numPublicZones).Select(i => TestUtilities.GenerateName("hydratest.dnszone.com")).ToArray();
                var privateZoneNames = Enumerable.Range(0, numPrivateZones).Select(i => TestUtilities.GenerateName("hydratest.privatednszone.com")).ToArray();

                var resourceManagementClient = ResourceGroupHelper.GetResourcesClient(context, resourcesHandler);
                var networkManagementClient = ResourceGroupHelper.GetNetworkClient(context, networkHandler);

                var resourceGroup = ResourceGroupHelper.CreateResourceGroup(resourceManagementClient);
                CreateZones(dnsClient, resourceGroup, publicZoneNames, resourceManagementClient);
                CreatePrivateZones(dnsClient, resourceGroup, privateZoneNames, resourceManagementClient, networkManagementClient);

                var expectedZoneNames = publicZoneNames.Concat(privateZoneNames).ToArray();
                var listresponse = dnsClient.Zones.List();

                Assert.NotNull(listresponse);
                Assert.True(listresponse.Count() >= (numPublicZones + numPrivateZones));
                Assert.True(expectedZoneNames.All(expectedZoneName => listresponse.Any(resp => string.Equals(resp.Name, expectedZoneName))), "The response of the List request does not meet expectations.");

                DeleteZones(dnsClient, resourceGroup, expectedZoneNames);
            }
        }

        [Fact]
        public void ListZonesWithTopParameter()
        {
            using (
                MockContext context = MockContext.Start(this.GetType())
                )
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                DnsManagementClient dnsClient =
                    ResourceGroupHelper.GetDnsClient(context, dnsHandler);

                var zoneNames = new[]
                {
                    TestUtilities.GenerateName("hydratest.dnszone") + ".com",
                    TestUtilities.GenerateName("hydratest.dnszone") + ".com"
                };
                var resourceManagementClient =
                    ResourceGroupHelper.GetResourcesClient(
                        context,
                        resourcesHandler);
                ResourceGroup resourceGroup =
                    ResourceGroupHelper.CreateResourceGroup(
                        resourceManagementClient);
                ZoneScenarioTests.CreateZones(
                    dnsClient,
                    resourceGroup,
                    zoneNames,
                    resourceManagementClient);

                var listresponse =
                    dnsClient.Zones.ListByResourceGroup(resourceGroup.Name, 1);

                Assert.NotNull(listresponse);
                Assert.Single(listresponse);
                Assert.Contains(zoneNames, zoneName => zoneName == listresponse.ElementAt(0).Name);

                ZoneScenarioTests.DeleteZones(
                    dnsClient,
                    resourceGroup,
                    zoneNames);
            }
        }

        [Fact]
        public void ListZonesWithListNext()
        {
            using (
                MockContext context = MockContext.Start(this.GetType())
                )
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                DnsManagementClient dnsClient =
                    ResourceGroupHelper.GetDnsClient(context, dnsHandler);

                var zoneNames = new[]
                {
                    TestUtilities.GenerateName("hydratest.dnszone.com"),
                    TestUtilities.GenerateName("hydratest.dnszone.com")
                };
                var resourceManagementClient =
                    ResourceGroupHelper.GetResourcesClient(
                        context,
                        resourcesHandler);
                ResourceGroup resourceGroup =
                    ResourceGroupHelper.CreateResourceGroup(
                        resourceManagementClient);
                ZoneScenarioTests.CreateZones(
                    dnsClient,
                    resourceGroup,
                    zoneNames,
                    resourceManagementClient);

                var listresponse =
                    dnsClient.Zones.ListByResourceGroup(resourceGroup.Name, 1);

                Assert.NotNull(listresponse.NextPageLink);

                listresponse =
                    dnsClient.Zones.ListByResourceGroupNext(
                        (listresponse.NextPageLink));

                Assert.Single(listresponse);

                ZoneScenarioTests.DeleteZones(
                    dnsClient,
                    resourceGroup,
                    zoneNames);
            }
        }

        [Fact]
        public void UpdateZonePreconditionFailed()
        {
            using (
                MockContext context = MockContext.Start(this.GetType())
                )
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                DnsManagementClient dnsClient =
                    ResourceGroupHelper.GetDnsClient(context, dnsHandler);

                string zoneName =
                    TestUtilities.GenerateName("hydratest.dnszone.com");
                var resourceManagementClient =
                    ResourceGroupHelper.GetResourcesClient(
                        context,
                        resourcesHandler);
                string location =
                    ResourceGroupHelper.GetResourceLocation(
                        resourceManagementClient,
                        "microsoft.network/dnszones");

                ResourceGroup resourceGroup =
                    ResourceGroupHelper.CreateResourceGroup(
                        resourceManagementClient);
                var createdZone = ResourceGroupHelper.CreateZone(
                    dnsClient,
                    zoneName,
                    location,
                    resourceGroup);

                // expect Precondition Failed 412
                TestHelpers.AssertThrows<CloudException>(
                    () =>
                        dnsClient.Zones.CreateOrUpdate(
                            resourceGroup.Name,
                            zoneName,
                            createdZone,
                            "somegibberish",
                            null),
                    ex => ex.Body.Code == "PreconditionFailed");

                dnsClient.Zones.Delete(
                    resourceGroup.Name,
                    zoneName,
                    ifMatch: null);

                dnsClient.Zones.Delete(
                    resourceGroup.Name,
                    "hiya.com",
                    ifMatch: null);
                //Assert.Null(result);
            }
        }

        [Fact]
        public void GetNonExistingZoneFailsAsExpected()
        {
            using (
                MockContext context = MockContext.Start(this.GetType())
                )
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                DnsManagementClient dnsClient =
                    ResourceGroupHelper.GetDnsClient(context, dnsHandler);

                string zoneName =
                    TestUtilities.GenerateName("hydratest.dnszone.com");
                var resourceManagementClient =
                    ResourceGroupHelper.GetResourcesClient(
                        context,
                        resourcesHandler);
                string location =
                    ResourceGroupHelper.GetResourceLocation(
                        resourceManagementClient,
                        "microsoft.network/dnszones");

                ResourceGroup resourceGroup =
                    ResourceGroupHelper.CreateResourceGroup(
                        resourceManagementClient);

                TestHelpers.AssertThrows<CloudException>(
                    () => dnsClient.Zones.Get(resourceGroup.Name, zoneName),
                    ex => ex.Body.Code == "ResourceNotFound");
            }
        }

        [Fact]
        public void CrudZoneSetsTheCurrentAndMaxRecordSetNumbersInResponse()
        {
            using (
                MockContext context = MockContext.Start(this.GetType())
                )
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = System.Net.HttpStatusCode.OK
                };
                DnsManagementClient dnsClient =
                    ResourceGroupHelper.GetDnsClient(context, dnsHandler);

                string zoneName =
                    TestUtilities.GenerateName("hydratest.dnszone.com");
                var resourceManagementClient =
                    ResourceGroupHelper.GetResourcesClient(
                        context,
                        resourcesHandler);
                string location =
                    ResourceGroupHelper.GetResourceLocation(
                        resourceManagementClient,
                        "microsoft.network/dnszones");

                ResourceGroup resourceGroup =
                    ResourceGroupHelper.CreateResourceGroup(
                        resourceManagementClient);

                // Create the zone clean
                dnsClient.Zones.CreateOrUpdate(
                    resourceGroup.Name,
                    zoneName,
                    new Zone
                    {
                        Location = location,
                    });

                // Retrieve the zone after create
                Zone retrievedZone = dnsClient.Zones.Get(
                    resourceGroup.Name,
                    zoneName);

                // Verify RecordSet numbers in the response.
                Assert.True(retrievedZone.NumberOfRecordSets == 2);

                retrievedZone.Tags = new Dictionary<string, string>
                {
                    {"tag1", "value1"}
                };

                // Delete the zone
                DeleteZones(dnsClient, resourceGroup, new[] { zoneName });
            }
        }

        #region Helper methods

        internal static void CreateZones(
            DnsManagementClient dnsClient,
            ResourceGroup resourceGroup,
            string[] zoneNames,
            ResourceManagementClient resourcesClient)
        {
            string location =
                ResourceGroupHelper.GetResourceLocation(
                    resourcesClient,
                    "microsoft.network/dnszones");

            foreach (string zoneName in zoneNames)
            {
                ResourceGroupHelper.CreateZone(
                    dnsClient,
                    zoneName,
                    location,
                    resourceGroup);
            }
        }

        internal static void CreatePrivateZones(
            DnsManagementClient dnsClient,
            ResourceGroup resourceGroup,
            IList<string> zonesNames,
            ResourceManagementClient resourcesClient,
            NetworkManagementClient networkManagementClient)
        {
            var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "microsoft.network/dnszones");
            foreach (var zonesName in zonesNames)
            {
                var registrationVnets = Enumerable.Range(0, 1).Select(i => ResourceGroupHelper.CreateVirtualNetwork(resourceGroup.Name, networkManagementClient)).ToList();
                var resolutionVnets = Enumerable.Range(0, 1).Select(i => ResourceGroupHelper.CreateVirtualNetwork(resourceGroup.Name, networkManagementClient)).ToList();

                ResourceGroupHelper.CreatePrivateZone(
                    dnsClient,
                    zonesName,
                    location,
                    registrationVnets.Select(vNet => new SubResource { Id = vNet.Id }).ToList(),
                    resolutionVnets.Select(vNet => new SubResource { Id = vNet.Id }).ToList(),
                    resourceGroup);
            }
        }

        internal static void DeleteZones(
            DnsManagementClient dnsClient,
            ResourceGroup resourceGroup,
            string[] zoneNames)
        {
            foreach (string zoneName in zoneNames)
            {
                dnsClient.Zones.Delete(
                    resourceGroup.Name,
                    zoneName);
            }
        }

        private static string ExtractResourceGroupNameFromId(string id)
        {
            return ExtractNameFromId(id, "resourceGroups");
        }

        private static string ExtractVirtualNetworkNameFromId(string id)
        {
            return ExtractNameFromId(id, "virtualNetworks");
        }

        private static string ExtractNameFromId(string id, string key)
        {
            var parts = id.Split(
                new[] { '/' },
                StringSplitOptions.RemoveEmptyEntries);
            int rgIndex = -1;
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Equals(
                    key,
                    StringComparison.OrdinalIgnoreCase))
                {
                    rgIndex = i;
                    break;
                }
            }

            if (rgIndex != -1 && rgIndex + 1 < parts.Length)
            {
                return parts[rgIndex + 1];
            }

            throw new FormatException(
                string.Format(
                    "Unable to extract resource group name from {0} ",
                    id));
        }

        #endregion
    }
}
