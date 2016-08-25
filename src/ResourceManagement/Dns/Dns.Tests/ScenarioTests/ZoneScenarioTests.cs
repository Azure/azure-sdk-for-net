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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Management.Dns.Models;

namespace Microsoft.Azure.Management.Dns.Testing
{
    using Resources;
    using Rest.Azure;
    using Rest.ClientRuntime.Azure.TestFramework;

    public class ZoneScenarioTests
    {
        [Fact]
        public void CrudZoneFullCycle()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
                )
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
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
                            new Dictionary<string, string> {{"tag1", "value1"}},
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
                Assert.True(resourceGroupName.Equals(resourceGroup.Name));

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

                // Delete the zone
                DeleteZones(dnsClient, resourceGroup, new[] {zoneName});
            }
        }

        private string ExtractResourceGroupNameFromId(string id)
        {
            var parts = id.Split(
                new[] {'/'},
                StringSplitOptions.RemoveEmptyEntries);
            int rgIndex = -1;
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Equals(
                    "resourceGroups",
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

        [Fact]
        public void ListZones()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
                )
            {
                var resourcesHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
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
                    dnsClient.Zones.ListInResourceGroup(resourceGroup.Name);

                Assert.NotNull(listresponse);
                Assert.Equal(2, listresponse.Count());
                Assert.True(
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(zoneNames[0], zoneReturned.Name))
                    &&
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(zoneNames[1], zoneReturned.Name)),
                    "The response of the List request does not meet expectations.");

                ZoneScenarioTests.DeleteZones(
                    dnsClient,
                    resourceGroup,
                    zoneNames);
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
                    StatusCodeToReturn = HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
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

                var listresponse = dnsClient.Zones.ListInSubscription();

                Assert.NotNull(listresponse);
                Assert.True(listresponse.Count() > 2);
                Assert.True(
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(zoneNames[0], zoneReturned.Name))
                    &&
                    listresponse.Any(
                        zoneReturned =>
                            string.Equals(zoneNames[1], zoneReturned.Name)),
                    "The response of the List request does not meet expectations.");

                ZoneScenarioTests.DeleteZones(
                    dnsClient,
                    resourceGroup,
                    zoneNames);
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
                    StatusCodeToReturn = HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
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
                    dnsClient.Zones.ListInResourceGroup(resourceGroup.Name, "1");

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
                    StatusCodeToReturn = HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
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
                    dnsClient.Zones.ListInResourceGroup(resourceGroup.Name, "1");

                Assert.NotNull(listresponse.NextPageLink);

                listresponse =
                    dnsClient.Zones.ListInResourceGroupNext(
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
                    StatusCodeToReturn = HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
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
                    ifMatch: null,
                    ifNoneMatch: null);
                Assert.Equal(result.Status, OperationStatus.Succeeded);

                result = dnsClient.Zones.Delete(
                    resourceGroup.Name,
                    "hiya.com",
                    ifMatch: null,
                    ifNoneMatch: null);
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
                    StatusCodeToReturn = HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
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
                    StatusCodeToReturn = HttpStatusCode.OK
                };
                var dnsHandler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK
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
                DeleteZones(dnsClient, resourceGroup, new[] {zoneName});
            }
        }

        #region Helper methods

        public static void CreateZones(
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

        public static void DeleteZones(
            DnsManagementClient dnsClient,
            ResourceGroup resourceGroup,
            string[] zoneNames)
        {
            foreach (string zoneName in zoneNames)
            {
                var response = dnsClient.Zones.Delete(
                    resourceGroup.Name,
                    zoneName);
                Assert.True(response.Status == OperationStatus.Succeeded);
            }
        }

        #endregion
    }
}