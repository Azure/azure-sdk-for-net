// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Resources.Models;
using Xunit;
using Microsoft.Azure.Management.Dns.Models;
using Microsoft.Azure.Management.Network.Models;
using SubResource = Microsoft.Azure.Management.Dns.Models.SubResource;

namespace Microsoft.Azure.Management.Dns.Testing
{
    using Resources;
    using Rest.Azure;
    using Rest.ClientRuntime.Azure.TestFramework;

    public class ZoneScenarioTests
    {
        [Fact]
        public void CrudPublicZoneFullCycle()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
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

                void AssertZoneInvariants(Zone zone)
                {
                    if (zone == null) throw new ArgumentNullException(nameof(zone));
                    Assert.Equal(zoneName, zone.Name);
                    Assert.False(string.IsNullOrEmpty(zone.Etag));
                }

                // Create the zone clean, verify response
                var createdZone = dnsClient.Zones.CreateOrUpdate(
                    resourceGroup.Name,
                    zoneName,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: new Zone
                    {
                        Location = location,
                        ZoneType = ZoneType.Public,
                        Tags =
                            new Dictionary<string, string> {{"tag1", "value1"}},
                    });

                AssertZoneInvariants(createdZone);
                Assert.Equal(1, createdZone.Tags.Count);
                Assert.True(
                    createdZone.NameServers != null &&
                    createdZone.NameServers.Any(
                        nameServer => !string.IsNullOrWhiteSpace(nameServer)));

                // Ensure that Id is parseable into resourceGroup
                string resourceGroupName =
                    ExtractNameFromId(createdZone.Id, "resourceGroups");
                Assert.True(resourceGroupName.Equals(resourceGroup.Name));

                // Retrieve the zone after create, verify response
                var retrievedZone = dnsClient.Zones.Get(
                    resourceGroup.Name,
                    zoneName);

                AssertZoneInvariants(retrievedZone);
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

                AssertZoneInvariants(updateResponse);
                Assert.Equal(2, updateResponse.Tags.Count);

                // Retrieve the zone after create, verify response
                retrievedZone = dnsClient.Zones.Get(
                    resourceGroup.Name,
                    zoneName);

                AssertZoneInvariants(retrievedZone);
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

                AssertZoneInvariants(updateResponse);
                Assert.Equal(3, updateResponse.Tags.Count);

                // Delete the zone
                DeleteZones(dnsClient, resourceGroup, new List<string> {zoneName});
            }
        }

        [Fact]
        public void ListZones()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
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

                DnsManagementClient dnsClient =
                    ResourceGroupHelper.GetDnsClient(context, dnsHandler);

                var publicZoneNames = new List<string>
                {
                    TestUtilities.GenerateName("hydratest.dnszone.com"),
                    TestUtilities.GenerateName("hydratest.dnszone.com")
                };

                var privateZoneName = new List<string>
                {
                    TestUtilities.GenerateName("hydratest.privatednszone.com"),
                    TestUtilities.GenerateName("hydratest.privatednszone.com")
                };

                var resourceManagementClient =
                    ResourceGroupHelper.GetResourcesClient(
                        context,
                        resourcesHandler);
                ResourceGroup resourceGroup =
                    ResourceGroupHelper.CreateResourceGroup(
                        resourceManagementClient);

                var networkManagementClient =
                    ResourceGroupHelper.GetNetworkClient(
                        context, networkHandler);

                var registrationVnet = new List<VirtualNetwork>
                {
                    ResourceGroupHelper.CreateVirtualNetwork(resourceGroup.Name, networkManagementClient)
                };

                var resolutionVnet = new List<VirtualNetwork>
                {
                    ResourceGroupHelper.CreateVirtualNetwork(resourceGroup.Name, networkManagementClient)
                };

                ZoneScenarioTests.CreateZones(
                    dnsClient,
                    resourceGroup,
                    publicZoneNames,
                    resourceManagementClient);

                ZoneScenarioTests.CreatePrivateZones(
                    dnsClient,
                    resourceGroup,
                    privateZoneName,
                    registrationVnet,
                    resolutionVnet,
                    resourceManagementClient);

                var listresponse =
                    dnsClient.Zones.ListByResourceGroup(resourceGroup.Name);

                Assert.NotNull(listresponse);
                Assert.Equal(4, listresponse.Count());
                Assert.True(
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(publicZoneNames[0], zoneReturned.Name))
                    &&
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(publicZoneNames[1], zoneReturned.Name))
                    &&
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(privateZoneName[0], zoneReturned.Name))
                    &&
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(privateZoneName[1], zoneReturned.Name)),
                    "The response of the List request does not meet expectations.");

                ZoneScenarioTests.DeleteZones(
                    dnsClient,
                    resourceGroup,
                    publicZoneNames.Concat(privateZoneName).ToList());
            }
        }

        [Fact]
        public void ListZonesInSubscription()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
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

                DnsManagementClient dnsClient =
                    ResourceGroupHelper.GetDnsClient(context, dnsHandler);

                var publicZoneNames = new List<string>
                {
                    TestUtilities.GenerateName("hydratest.dnszone.com"),
                    TestUtilities.GenerateName("hydratest.dnszone.com")
                };
                var privateZoneNames = new List<string>
                {
                    TestUtilities.GenerateName("hydratest.privatednszone.com"),
                    TestUtilities.GenerateName("hydratest.privatednszone.com")
                };

                var resourceManagementClient =
                    ResourceGroupHelper.GetResourcesClient(
                        context,
                        resourcesHandler);
                ResourceGroup resourceGroup =
                    ResourceGroupHelper.CreateResourceGroup(
                        resourceManagementClient);

                var networkManagementClient = ResourceGroupHelper.GetNetworkClient(context, networkHandler);

                var registationVnets = new List<VirtualNetwork>
                {
                    ResourceGroupHelper.CreateVirtualNetwork(resourceGroup.Name, networkManagementClient)
                };

                var resolutionVnets = new List<VirtualNetwork>
                {
                    ResourceGroupHelper.CreateVirtualNetwork(resourceGroup.Name, networkManagementClient)
                };


                ZoneScenarioTests.CreateZones(
                    dnsClient,
                    resourceGroup,
                    publicZoneNames,
                    resourceManagementClient);
                ZoneScenarioTests.CreatePrivateZones(
                    dnsClient,
                    resourceGroup,
                    privateZoneNames,
                    registationVnets,
                    resolutionVnets,
                    resourceManagementClient);

                var listresponse = dnsClient.Zones.List();

                Assert.NotNull(listresponse);
                Assert.True(listresponse.Count() > 2);
                Assert.True(
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(publicZoneNames[0], zoneReturned.Name))
                    &&
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(publicZoneNames[1], zoneReturned.Name))
                    &&
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(privateZoneNames[0], zoneReturned.Name))
                    &&
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(privateZoneNames[1], zoneReturned.Name)),
                    "The response of the List request does not meet expectations.");

                ZoneScenarioTests.DeleteZones(
                    dnsClient,
                    resourceGroup,
                    publicZoneNames.Concat(privateZoneNames).ToList());
            }
        }

        [Fact]
        public void ListZonesWithTopParameter()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
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

                var zoneNames = new List<string>
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
                Assert.Equal(1, listresponse.Count());
                Assert.True(
                    zoneNames.Any(
                        zoneName => zoneName == listresponse.ElementAt(0).Name));

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
                MockContext context = MockContext.Start(this.GetType().FullName)
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

                var zoneNames = new List<string>
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
                    dnsClient.Zones.ListByResourceGroup(resourceGroup.Name,1);

                Assert.NotNull(listresponse.NextPageLink);

                listresponse =
                    dnsClient.Zones.ListByResourceGroupNext(
                        (listresponse.NextPageLink));

                Assert.Equal(1, listresponse.Count());

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
                MockContext context = MockContext.Start(this.GetType().FullName)
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

                var result = dnsClient.Zones.Delete(
                    resourceGroup.Name,
                    zoneName,
                    ifMatch: null);
                Assert.Equal(result.Status, OperationStatus.Succeeded);

                result = dnsClient.Zones.Delete(
                    resourceGroup.Name,
                    "hiya.com",
                    ifMatch: null);
                Assert.Null(result);
            }
        }

        [Fact]
        public void GetNonExistingZoneFailsAsExpected()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
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
                MockContext context = MockContext.Start(this.GetType().FullName)
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
                        ZoneType = ZoneType.Public,
                        MaxNumberOfRecordSets = 42,
                        // Test that specifying this value does not break Create (it must be ignored on server side).
                        NumberOfRecordSets = 65,
                        // Test that specifying this value does not break Create (it must be ignored on server side).
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
                retrievedZone.NumberOfRecordSets = null;
                retrievedZone.MaxNumberOfRecordSets = null;

                // Delete the zone
                DeleteZones(dnsClient, resourceGroup, new List<string> {zoneName});
            }
        }


        [Fact]
        public void CrudPrivateZoneFullCycle()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
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

                var dnsClient = ResourceGroupHelper.GetDnsClient(
                    context,
                    dnsHandler);
                var resourceManagementClient = 
                    ResourceGroupHelper.GetResourcesClient(
                        context,
                        resourcesHandler);
                var networkManagementClient = 
                    ResourceGroupHelper.GetNetworkClient(
                        context, networkHandler);

                string zoneName =
                    TestUtilities.GenerateName("hydratest.privatednszone.com");
                string location =
                    ResourceGroupHelper.GetResourceLocation(
                        resourceManagementClient,
                        "microsoft.network/dnszones");
                ResourceGroup resourceGroup =
                    ResourceGroupHelper.CreateResourceGroup(
                        resourceManagementClient);
                VirtualNetwork registrationVnet =
                    ResourceGroupHelper.CreateVirtualNetwork(resourceGroup.Name, networkManagementClient);
                VirtualNetwork resolutionVnet =
                    ResourceGroupHelper.CreateVirtualNetwork(resourceGroup.Name, networkManagementClient);

                void AssertPrivateZoneInvariants(Zone zone)
                {
                    if (zone == null) throw new ArgumentNullException(nameof(zone));
                    Assert.Equal(zoneName, zone.Name);
                    Assert.Equal(ZoneType.Private, zone.ZoneType);
                    Assert.False(string.IsNullOrEmpty(zone.Etag));
                }

                //Create private zone clean, verify reponse
                var createdPrivateZone = dnsClient.Zones.CreateOrUpdate(
                    resourceGroup.Name,
                    zoneName,
                    new Zone
                    {
                        Location = location,
                        ZoneType = ZoneType.Private,
                        Tags = new Dictionary<string, string> {{"tag1", "value1"}},
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
                Assert.True(
                    !createdPrivateZone.NameServers.IsAny());

                // Ensure that Id is parseable into resourceGroup
                string resourceGroupName =
                    ExtractNameFromId(createdPrivateZone.Id, "resourceGroups");
                Assert.True(resourceGroupName.Equals(resourceGroup.Name));

                var virtualNetworkName = 
                    ExtractNameFromId(createdPrivateZone.RegistrationVirtualNetworks[0].Id, "virtualNetworks");
                Assert.True(virtualNetworkName.Equals(registrationVnet.Name));

                virtualNetworkName =
                    ExtractNameFromId(createdPrivateZone.ResolutionVirtualNetworks[0].Id, "virtualNetworks");
                Assert.True(virtualNetworkName.Equals(resolutionVnet.Name));


                // Retrieve the zone after create, verify response
                var retrievedPrivateZone = dnsClient.Zones.Get(
                    resourceGroup.Name,
                    zoneName);

                AssertPrivateZoneInvariants(retrievedPrivateZone);
                Assert.Equal(1, retrievedPrivateZone.Tags.Count);

                Assert.True(
                    !retrievedPrivateZone.NameServers.IsAny());

                // Call Update on the object returned by Create (important distinction from Get below)
                createdPrivateZone.Tags = new Dictionary<string, string>
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
                        parameters: createdPrivateZone);

                AssertPrivateZoneInvariants(updateResponse);
                Assert.Equal(2, updateResponse.Tags.Count);

                // Retrieve the zone after create, verify response
                retrievedPrivateZone = dnsClient.Zones.Get(
                    resourceGroup.Name,
                    zoneName);

                AssertPrivateZoneInvariants(retrievedPrivateZone);
                Assert.Equal(2, retrievedPrivateZone.Tags.Count);

                // Call Update on the object returned by Get (important distinction from Create above)
                retrievedPrivateZone.Tags = new Dictionary<string, string>
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
                        parameters: retrievedPrivateZone);

                AssertPrivateZoneInvariants(updateResponse);
                Assert.Equal(3, updateResponse.Tags.Count);

                // Delete the zone
                DeleteZones(dnsClient, resourceGroup, new List<string> { zoneName });
            }
        }

        #region Helper methods

        public static void CreateZones(
            DnsManagementClient dnsClient,
            ResourceGroup resourceGroup,
            IList<string> zoneNames,
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

        public static void CreatePrivateZones(
            DnsManagementClient dnsClient,
            ResourceGroup resourceGroup,
            IList<string> zonesNames,
            IList<VirtualNetwork> registrationVnets,
            IList<VirtualNetwork> resolutionVnets,
            ResourceManagementClient resourcesClient)
        {
            string location =
                ResourceGroupHelper.GetResourceLocation(
                    resourcesClient,
                    "microsoft.network/dnszones");
            foreach (var zonesName in zonesNames)
            {
                ResourceGroupHelper.CreatePrivateZone(
                    dnsClient,
                    zonesName,
                    location,
                    registrationVnets.Select(vNet => new SubResource() { Id = vNet.Id }).ToList(),
                    resolutionVnets.Select(vNet => new SubResource() { Id = vNet.Id }).ToList(),
                    resourceGroup);
            }
        }

        public static void DeleteZones(
            DnsManagementClient dnsClient,
            ResourceGroup resourceGroup,
            IList<string> zoneNames)
        {
            foreach (string zoneName in zoneNames)
            {
                var response = dnsClient.Zones.Delete(
                    resourceGroup.Name,
                    zoneName);
                Assert.True(response.Status == OperationStatus.Succeeded);
            }
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