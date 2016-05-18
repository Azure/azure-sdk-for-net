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
using Hyak.Common;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Management.Dns.Models;

namespace Microsoft.Azure.Management.Dns.Testing
{
    using System.Runtime.InteropServices;

    public class ZoneScenarioTests
    {
        [Fact]
        public void CrudZoneFullCycle()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                DnsManagementClient dnsClient = ResourceGroupHelper.GetDnsClient();

                string zoneName = TestUtilities.GenerateName("hydratestdnszone.com");
                string location = ResourceGroupHelper.GetResourceLocation(ResourceGroupHelper.GetResourcesClient(), "microsoft.network/dnszones");
                ResourceGroupExtended resourceGroup = ResourceGroupHelper.CreateResourceGroup();

                Action<Zone> assertZoneInvariants = zone =>
                {
                    Assert.Equal(zoneName, zone.Name);
                    Assert.False(string.IsNullOrEmpty(zone.ETag));
                    Assert.False(string.IsNullOrEmpty(zone.Properties.ParentResourceGroupName));
                };
                
                // Create the zone clean, verify response
                ZoneCreateOrUpdateResponse createResponse = dnsClient.Zones.CreateOrUpdate(
                    resourceGroup.Name, 
                    zoneName, 
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: new ZoneCreateOrUpdateParameters
                        {
                            Zone = new Microsoft.Azure.Management.Dns.Models.Zone
                            {
                                Location = location,
                                Name = zoneName,
                                Tags = new Dictionary<string, string> { { "tag1", "value1" } },
                                ETag = null,
                                Properties = new Microsoft.Azure.Management.Dns.Models.ZoneProperties
                                {
                                }
                            }
                        });

                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
                assertZoneInvariants(createResponse.Zone);
                Assert.Equal(1, createResponse.Zone.Tags.Count);
                Assert.True(createResponse.Zone.Properties.NameServers != null && createResponse.Zone.Properties.NameServers.Any(nameServer => !string.IsNullOrWhiteSpace(nameServer)));
                Assert.True(createResponse.Zone.Properties.ParentResourceGroupName == resourceGroup.Name);

                // Retrieve the zone after create, verify response
                var getresponse = dnsClient.Zones.Get(resourceGroup.Name, zoneName);

                Assert.Equal(HttpStatusCode.OK, getresponse.StatusCode);
                assertZoneInvariants(getresponse.Zone);
                Assert.Equal(1, getresponse.Zone.Tags.Count);
                
                Assert.True(getresponse.Zone.Properties.NameServers != null && getresponse.Zone.Properties.NameServers.Any(nameServer => !string.IsNullOrWhiteSpace(nameServer)));

                // Call Update on the object returned by Create (important distinction from Get below)
                Zone createdZone = createResponse.Zone;
                createdZone.Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" } };

                ZoneCreateOrUpdateResponse updateResponse = dnsClient.Zones.CreateOrUpdate(resourceGroup.Name, zoneName, ifMatch: null, ifNoneMatch: null, parameters: new ZoneCreateOrUpdateParameters { Zone = createdZone });

                Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
                assertZoneInvariants(updateResponse.Zone);
                Assert.Equal(2, updateResponse.Zone.Tags.Count);

                // Retrieve the zone after create, verify response
                getresponse = dnsClient.Zones.Get(resourceGroup.Name, zoneName);

                Assert.Equal(HttpStatusCode.OK, getresponse.StatusCode);
                assertZoneInvariants(getresponse.Zone);
                Assert.Equal(2, getresponse.Zone.Tags.Count);

                // Call Update on the object returned by Get (important distinction from Create above)
                Zone retrievedZone = getresponse.Zone;
                retrievedZone.Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" }, { "tag3", "value3" } };

                updateResponse = dnsClient.Zones.CreateOrUpdate(resourceGroup.Name, zoneName, ifMatch: null, ifNoneMatch: null, parameters: new ZoneCreateOrUpdateParameters { Zone = retrievedZone });

                Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
                assertZoneInvariants(updateResponse.Zone);
                Assert.Equal(3, updateResponse.Zone.Tags.Count);

                // Delete the zone
                AzureOperationResponse deleteResponse = dnsClient.Zones.Delete(resourceGroup.Name, zoneName, ifMatch: null, ifNoneMatch: null);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
            }
        }

        [Fact]
        public void ListZones()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                DnsManagementClient dnsClient = ResourceGroupHelper.GetDnsClient();

                var zoneNames = new[] { TestUtilities.GenerateName("hydratestdnszone.com"), TestUtilities.GenerateName("hydratestdnszone.com") };
                ResourceGroupExtended resourceGroup = ResourceGroupHelper.CreateResourceGroup();
                ZoneScenarioTests.CreateZones(dnsClient, resourceGroup, zoneNames);

                ZoneListResponse listresponse = dnsClient.Zones.ListZonesInResourceGroup(resourceGroup.Name, new ZoneListParameters());

                Assert.NotNull(listresponse);
                Assert.Equal(2, listresponse.Zones.Count);
                Assert.True(
                    listresponse.Zones.Any(zoneReturned => string.Equals(zoneNames[0], zoneReturned.Name))
                    && listresponse.Zones.Any(zoneReturned => string.Equals(zoneNames[1], zoneReturned.Name))
                    && listresponse.Zones.All(zoneReturned => string.Equals(resourceGroup.Name, zoneReturned.Properties.ParentResourceGroupName)),
                    "The response of the List request does not meet expectations.");

                ZoneScenarioTests.DeleteZones(dnsClient, resourceGroup, zoneNames);
            }
        }

        [Fact]
        public void ListZonesWithTopParameter()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                DnsManagementClient dnsClient = ResourceGroupHelper.GetDnsClient();

                var zoneNames = new[] { TestUtilities.GenerateName("hydratestdnszone") + ".com", TestUtilities.GenerateName("hydratestdnszone") + ".com" };
                ResourceGroupExtended resourceGroup = ResourceGroupHelper.CreateResourceGroup();
                ZoneScenarioTests.CreateZones(dnsClient, resourceGroup, zoneNames);

                ZoneListResponse listresponse = dnsClient.Zones.ListZonesInResourceGroup(resourceGroup.Name, new ZoneListParameters { Top = "1" });

                Assert.NotNull(listresponse);
                Assert.Equal(1, listresponse.Zones.Count);
                Assert.True(zoneNames.Any(zoneName => zoneName == listresponse.Zones[0].Name), string.Format(" did not find zone name {0} in list ", listresponse.Zones[0].Name));
                Assert.True(listresponse.Zones[0].Properties.ParentResourceGroupName == resourceGroup.Name, string.Format(" expected resource group name {0} is different from actual {1}", resourceGroup.Name, listresponse.Zones[0].Properties.ParentResourceGroupName));

                ZoneScenarioTests.DeleteZones(dnsClient, resourceGroup, zoneNames);
            }
        }

        [Fact]
        public void ListZonesWithListNext()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                DnsManagementClient dnsClient = ResourceGroupHelper.GetDnsClient();

                var zoneNames = new[] { TestUtilities.GenerateName("hydratestdnszone.com"), TestUtilities.GenerateName("hydratestdnszone.com") };
                ResourceGroupExtended resourceGroup = ResourceGroupHelper.CreateResourceGroup();
                ZoneScenarioTests.CreateZones(dnsClient, resourceGroup, zoneNames);

                ZoneListResponse listresponse = dnsClient.Zones.ListZonesInResourceGroup(resourceGroup.Name, new ZoneListParameters { Top = "1" });

                Assert.NotNull(listresponse.NextLink);

                listresponse = dnsClient.Zones.ListNext(listresponse.NextLink);

                Assert.Equal(1, listresponse.Zones.Count);

                ZoneScenarioTests.DeleteZones(dnsClient, resourceGroup, zoneNames);
            }
        }

        [Fact]
        public void UpdateZonePreconditionFailed()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                DnsManagementClient dnsClient = ResourceGroupHelper.GetDnsClient();

                string zoneName = TestUtilities.GenerateName("hydratestdnszone.com");
                string location = ResourceGroupHelper.GetResourceLocation(ResourceGroupHelper.GetResourcesClient(), "microsoft.network/dnszones");
                ResourceGroupExtended resourceGroup = ResourceGroupHelper.CreateResourceGroup();
                ZoneCreateOrUpdateResponse createresponse = ResourceGroupHelper.CreateZone(dnsClient, zoneName, location, resourceGroup);

                ZoneCreateOrUpdateParameters updateParameters = new ZoneCreateOrUpdateParameters { Zone = createresponse.Zone };
                updateParameters.Zone.ETag = "somegibberish";

                // expect Precondition Failed 412
                TestHelpers.AssertThrows<CloudException>(
                    () => dnsClient.Zones.CreateOrUpdate(resourceGroup.Name, zoneName, ifMatch: null, ifNoneMatch: null, parameters: updateParameters),
                    ex => ex.Error.Code == "PreconditionFailed");

                var result = dnsClient.Zones.Delete(resourceGroup.Name, zoneName, ifMatch: null, ifNoneMatch: null);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);

                result = dnsClient.Zones.Delete(resourceGroup.Name, "hiya.com", ifMatch: null, ifNoneMatch: null);
                Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
            }
        }

        [Fact]
        public void CrudZoneSetsTheCurrentAndMaxRecordSetNumbersInResponse()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                DnsManagementClient dnsClient = ResourceGroupHelper.GetDnsClient();

                string zoneName = TestUtilities.GenerateName("hydratestdnszone.com");
                string location = ResourceGroupHelper.GetResourceLocation(ResourceGroupHelper.GetResourcesClient(), "microsoft.network/dnszones");
                ResourceGroupExtended resourceGroup = ResourceGroupHelper.CreateResourceGroup();

                // Create the zone clean
                ZoneCreateOrUpdateResponse createResponse = dnsClient.Zones.CreateOrUpdate(
                    resourceGroup.Name,
                    zoneName,
                    ifMatch: null, 
                    ifNoneMatch: null, 
                    parameters: new ZoneCreateOrUpdateParameters
                        {
                            Zone = new Microsoft.Azure.Management.Dns.Models.Zone
                                {
                                    Location = location,
                                    Name = zoneName,
                                    Properties = new Microsoft.Azure.Management.Dns.Models.ZoneProperties
                                        {
                                            MaxNumberOfRecordSets = 42, // Test that specifying this value does not break Create (it must be ignored on server side).
                                            NumberOfRecordSets = 65,    // Test that specifying this value does not break Create (it must be ignored on server side).
                                        }
                                }
                        });

                // Verify RecordSet numbers in the response.
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // Retrieve the zone after create
                ZoneGetResponse getResponse = dnsClient.Zones.Get(resourceGroup.Name, zoneName);

                // Verify RecordSet numbers in the response.
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.True(getResponse.Zone.Properties.NumberOfRecordSets == 2);

                Zone retrievedZone = getResponse.Zone;
                retrievedZone.Tags = new Dictionary<string, string> { { "tag1", "value1" } };
                retrievedZone.Properties.NumberOfRecordSets = null;
                retrievedZone.Properties.MaxNumberOfRecordSets = null;

                // Update the zone
                ZoneCreateOrUpdateResponse updateResponse = dnsClient.Zones.CreateOrUpdate(resourceGroup.Name, zoneName, ifMatch: null, ifNoneMatch: null, parameters: new ZoneCreateOrUpdateParameters { Zone = retrievedZone });

                // Verify RecordSet numbers in the response.
                Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
                
                // Delete the zone
                AzureOperationResponse deleteResponse = dnsClient.Zones.Delete(resourceGroup.Name, zoneName, ifMatch: null, ifNoneMatch: null);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
            }
        }

        #region Helper methods

        public static void CreateZones(DnsManagementClient dnsClient, ResourceGroupExtended resourceGroup, string[] zoneNames)
        {
            string location = ResourceGroupHelper.GetResourceLocation(ResourceGroupHelper.GetResourcesClient(), "microsoft.network/dnszones");

            foreach (string zoneName in zoneNames)
            {
                ResourceGroupHelper.CreateZone(dnsClient, zoneName, location, resourceGroup);
            }
        }

        public static void DeleteZones(DnsManagementClient dnsClient, ResourceGroupExtended resourceGroup, string[] zoneNames)
        {
            foreach (string zoneName in zoneNames)
            {
                dnsClient.Zones.Delete(resourceGroup.Name, zoneName, ifMatch: null, ifNoneMatch: null);
            }
        }

        #endregion
    }
}