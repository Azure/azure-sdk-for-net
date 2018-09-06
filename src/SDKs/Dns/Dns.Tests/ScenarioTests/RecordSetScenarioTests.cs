// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Dns.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using SubResource = Microsoft.Azure.Management.Dns.Models.SubResource;

namespace Microsoft.Azure.Management.Dns.Testing
{
    public class RecordSetScenarioTests
    {
        public class SingleRecordSetTestContext
        {
            public string ZoneName { get; set; }

            public string RecordSetName { get; set; }

            public string Location { get; set; }

            public ResourceGroup ResourceGroup { get; set; }

            public DnsManagementClient DnsClient { get; set; }

            public NetworkManagementClient NetworkClient { get; set; }

            public RecordedDelegatingHandler DnsHandler { get; set; }

            public RecordedDelegatingHandler ResourcesHandler { get; set; }

            public RecordedDelegatingHandler NetworkHandler { get; set; }

            public IList<VirtualNetwork> RegistationVirtualNetworks { get; set; }

            public IList<VirtualNetwork> ResolutionVirtualNetworks { get; set; }

            public RecordSet TestRecordSkeleton
                => this.GetNewTestRecordSkeleton(this.RecordSetName);

            public RecordSet GetNewTestRecordSkeleton(
                string recordSetName,
                uint ttl = 42)
            {
                return new RecordSet(name: recordSetName)
                {
                    Etag = null,
                    TTL = ttl,
                };
            }
        }

        private static IEnumerable<SingleRecordSetTestContext> SetupSingleRecordSetTestContexts(
            MockContext context)
        {
            return new[]
            {
                SetupSingleRecordSetTestForPublicZone(context),
                SetupSingleRecordSetTestForPrivateZone(context),
            };
        }

        private static SingleRecordSetTestContext SetupSingleRecordSetTestForPublicZone(
            MockContext context)
        {
            var testContext = new SingleRecordSetTestContext();
            testContext.ResourcesHandler = new RecordedDelegatingHandler
            {
                StatusCodeToReturn = System.Net.HttpStatusCode.OK
            };
            testContext.DnsHandler = new RecordedDelegatingHandler
            {
                StatusCodeToReturn = System.Net.HttpStatusCode.OK
            };
            testContext.DnsClient = ResourceGroupHelper.GetDnsClient(
                context,
                testContext.DnsHandler);
            var resourceManagementClient =
                ResourceGroupHelper.GetResourcesClient(
                    context,
                    testContext.ResourcesHandler);
            testContext.ZoneName =
                TestUtilities.GenerateName("hydratest.dnszone.com");
            testContext.RecordSetName =
                TestUtilities.GenerateName("hydratestdnsrec");
            testContext.Location =
                ResourceGroupHelper.GetResourceLocation(
                    resourceManagementClient,
                    "microsoft.network/dnszones");
            testContext.ResourceGroup =
                ResourceGroupHelper.CreateResourceGroup(
                    resourceManagementClient);
            ResourceGroupHelper.CreateZone(
                testContext.DnsClient,
                testContext.ZoneName,
                testContext.Location,
                testContext.ResourceGroup);
            return testContext;
        }

        private static SingleRecordSetTestContext SetupSingleRecordSetTestForPrivateZone(
            MockContext context)
        {
            var testContext = new SingleRecordSetTestContext();
            testContext.ResourcesHandler = new RecordedDelegatingHandler
            {
                StatusCodeToReturn = System.Net.HttpStatusCode.OK
            };
            testContext.DnsHandler = new RecordedDelegatingHandler
            {
                StatusCodeToReturn = System.Net.HttpStatusCode.OK
            };
            testContext.NetworkHandler = new RecordedDelegatingHandler
            {
                StatusCodeToReturn = System.Net.HttpStatusCode.OK
            };

            testContext.DnsClient = ResourceGroupHelper.GetDnsClient(
                context,
                testContext.DnsHandler);
            testContext.NetworkClient = ResourceGroupHelper.GetNetworkClient(
                context,
                testContext.NetworkHandler);
            var resourceManagementClient =
                ResourceGroupHelper.GetResourcesClient(
                    context,
                    testContext.ResourcesHandler);
            testContext.ZoneName =
                TestUtilities.GenerateName("hydratest.dnszone.com");
            testContext.RecordSetName =
                TestUtilities.GenerateName("hydratestdnsrec");
            testContext.Location =
                ResourceGroupHelper.GetResourceLocation(
                    resourceManagementClient,
                    "microsoft.network/dnszones");
            testContext.ResourceGroup =
                ResourceGroupHelper.CreateResourceGroup(
                    resourceManagementClient);
            testContext.RegistationVirtualNetworks = new List<VirtualNetwork>
            {
                ResourceGroupHelper.CreateVirtualNetwork(testContext.ResourceGroup.Name, testContext.NetworkClient)
            };
            testContext.ResolutionVirtualNetworks = new List<VirtualNetwork>
            {
                ResourceGroupHelper.CreateVirtualNetwork(testContext.ResourceGroup.Name, testContext.NetworkClient)
            };
            ResourceGroupHelper.CreatePrivateZone(
                testContext.DnsClient,
                testContext.ZoneName,
                testContext.Location,
                testContext.RegistationVirtualNetworks.Select(vNet => new SubResource { Id = vNet.Id }).ToList(),
                testContext.ResolutionVirtualNetworks.Select(vNet => new SubResource { Id = vNet.Id }).ToList(),
                testContext.ResourceGroup);
            return testContext;
        }

        [Fact]
        public void CrudRecordSetFullCycle()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
                )
            {
                var testContexts = SetupSingleRecordSetTestContexts(context);
                foreach (var testContext in testContexts)
                {
                    var recordSetToBeCreated = testContext.TestRecordSkeleton;
                    recordSetToBeCreated.ARecords = new List<ARecord>
                    {
                        new ARecord {Ipv4Address = "123.32.1.0"}
                    };
                    recordSetToBeCreated.TTL = 60;

                    // Create the records clean, verify response
                    var createResponse = testContext.DnsClient.RecordSets
                        .CreateOrUpdate(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName,
                            testContext.RecordSetName,
                            RecordType.A,
                            ifMatch: null,
                            ifNoneMatch: null,
                            parameters: recordSetToBeCreated);

                    Assert.True(
                        TestHelpers.AreEqual(
                            recordSetToBeCreated,
                            createResponse,
                            ignoreEtag: true),
                        "Response body of Create does not match expectations");
                    Assert.False(string.IsNullOrWhiteSpace(createResponse.Etag));

                    // Retrieve the zone after create, verify response
                    var getresponse = testContext.DnsClient.RecordSets.Get(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.A);

                    Assert.True(
                        TestHelpers.AreEqual(
                            createResponse,
                            getresponse,
                            ignoreEtag: false),
                        "Response body of Get does not match expectations");

                    // Call Update on the object returned by Create (important distinction from Get below)
                    Models.RecordSet createdRecordSet = createResponse;

                    createdRecordSet.TTL = 120;
                    createdRecordSet.Metadata = new Dictionary<string, string>
                    {
                        {"tag1", "value1"},
                        {"tag2", "value2"}
                    };
                    createdRecordSet.ARecords = new List<ARecord>
                    {
                        new ARecord {Ipv4Address = "123.32.1.0"},
                        new ARecord {Ipv4Address = "101.10.0.1"}
                    };

                    var updateResponse = testContext.DnsClient.RecordSets
                        .CreateOrUpdate(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName,
                            testContext.RecordSetName,
                            RecordType.A,
                            ifMatch: null,
                            ifNoneMatch: null,
                            parameters: createdRecordSet);

                    Assert.True(
                        TestHelpers.AreEqual(
                            createdRecordSet,
                            updateResponse,
                            ignoreEtag: true),
                        "Response body of Update does not match expectations");
                    Assert.False(string.IsNullOrWhiteSpace(updateResponse.Etag));

                    // Retrieve the records after create, verify response
                    getresponse = testContext.DnsClient.RecordSets.Get(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.A);

                    Assert.True(
                        TestHelpers.AreEqual(updateResponse, getresponse),
                        "Response body of Get does not match expectations");

                    // Call Update on the object returned by Get (important distinction from Create above)
                    Models.RecordSet retrievedRecordSet = getresponse;
                    retrievedRecordSet.TTL = 180;
                    retrievedRecordSet.ARecords = new List<ARecord>
                    {
                        new ARecord {Ipv4Address = "123.32.1.0"},
                        new ARecord {Ipv4Address = "101.10.0.1"},
                        new ARecord {Ipv4Address = "22.33.44.55"},
                    };

                    updateResponse = testContext.DnsClient.RecordSets.CreateOrUpdate
                    (
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.A,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: retrievedRecordSet);

                    Assert.True(
                        TestHelpers.AreEqual(
                            retrievedRecordSet,
                            updateResponse,
                            ignoreEtag: true),
                        "Response body of Update does not match expectations");
                    Assert.False(string.IsNullOrWhiteSpace(updateResponse.Etag));

                    // Delete the record set
                    testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.A,
                        ifMatch: null);

                    // Delete the zone
                    testContext.DnsClient.Zones.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        ifMatch: null);
                }
            }
        }

        [Fact]
        public void CreateGetA()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.ARecords = new List<ARecord>
                {
                    new ARecord {Ipv4Address = "120.63.230.220"},
                    new ARecord {Ipv4Address = "4.3.2.1"},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.A, setTestRecords, isPrivateZoneEnabled: true);
        }

        [Fact]
        public void CreateGetAliasRecord()
        {
            Action<RecordSet> referencedTestRecords = createParams =>
            {
                //createParams.TargetResource = new SubResource("/subscriptions/726f8cd6-6459-4db4-8e6d-2cd2716904e2/resourceGroups/test/providers/Microsoft.Network/trafficManagerProfiles/testpp2");
                createParams.ARecords = new List<ARecord>
                {
                    new ARecord {Ipv4Address = "120.63.230.220"},
                    new ARecord {Ipv4Address = "4.3.2.1"},
                };

                return;
            };

            this.RecordSetCreateGetAlias(RecordType.A, referencedTestRecords);
        }

        [Fact]
        public void CreateGetAaaa()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.AaaaRecords = new List<AaaaRecord>
                {
                    new AaaaRecord {Ipv6Address = "0:0:0:0:0:ffff:783f:e6dc"},
                    new AaaaRecord {Ipv6Address = "0:0:0:0:0:ffff:403:201"},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.AAAA, setTestRecords, isPrivateZoneEnabled: true);
        }

        [Fact]
        public void CreateGetMx()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.MxRecords = new List<MxRecord>
                {
                    new MxRecord {Exchange = "mail1.scsfsm.com", Preference = 1},
                    new MxRecord {Exchange = "mail2.scsfsm.com", Preference = 2},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.MX, setTestRecords, isPrivateZoneEnabled: true);
        }

        [Fact]
        public void CreateGetNs()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.NsRecords = new List<NsRecord>
                {
                    new NsRecord {Nsdname = "ns1.scsfsm.com"},
                    new NsRecord {Nsdname = "ns2.scsfsm.com"},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.NS, setTestRecords, isPrivateZoneEnabled: false);
        }

        [Fact]
        public void CreateGetPtr()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.PtrRecords = new List<PtrRecord>
                {
                    new PtrRecord {Ptrdname = "www1.scsfsm.com"},
                    new PtrRecord {Ptrdname = "www2.scsfsm.com"},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.PTR, setTestRecords, isPrivateZoneEnabled: true);
        }

        [Fact]
        public void CreateGetSrv()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.SrvRecords = new List<SrvRecord>
                {
                    new SrvRecord
                    {
                        Target = "bt2.scsfsm.com",
                        Priority = 0,
                        Weight = 2,
                        Port = 44
                    },
                    new SrvRecord
                    {
                        Target = "bt1.scsfsm.com",
                        Priority = 1,
                        Weight = 1,
                        Port = 45
                    },
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.SRV, setTestRecords, isPrivateZoneEnabled: true);
        }

        [Fact]
        public void CreateGetTxt()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.TxtRecords = new List<TxtRecord>
                {
                    new TxtRecord {Value = new[] {"lorem"}.ToList()},
                    new TxtRecord {Value = new[] {"ipsum"}.ToList()},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.TXT, setTestRecords, isPrivateZoneEnabled: true);
        }

        [Fact]
        public void CreateGetCaa()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.CaaRecords = new List<CaaRecord>
                {
                    new CaaRecord() { Flags = 0, Tag = "issue", Value = "contoso.com" },
                    new CaaRecord() { Flags = 0, Tag = "issue", Value = "fabrikam.com" },
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.CAA, setTestRecords, isPrivateZoneEnabled: true);
        }

        [Fact]
        public void CreateGetCname()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.CnameRecord = new CnameRecord
                {
                    Cname = "www.contoroso.com",
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.CNAME, setTestRecords, isPrivateZoneEnabled: true);
        }

        [Fact]
        public void UpdateSoa()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
                )
            {
                var testContexts = SetupSingleRecordSetTestContexts(context);
                foreach (var testContext in testContexts)
                {
                    // SOA for the zone should already exist
                    var getresponse = testContext.DnsClient.RecordSets.Get(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        "@",
                        RecordType.SOA);

                    RecordSet soaResource = getresponse;
                    Assert.NotNull(soaResource);
                    Assert.NotNull(soaResource.SoaRecord);

                    soaResource.SoaRecord.ExpireTime = 123;
                    soaResource.SoaRecord.MinimumTtl = 1234;
                    soaResource.SoaRecord.RefreshTime = 12345;
                    soaResource.SoaRecord.RetryTime = 123456;

                    var updateParameters = soaResource;

                    var updateResponse = testContext.DnsClient.RecordSets
                        .CreateOrUpdate(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName,
                            "@",
                            RecordType.SOA,
                            ifMatch: null,
                            ifNoneMatch: null,
                            parameters: updateParameters);

                    Assert.True(
                        TestHelpers.AreEqual(
                            soaResource,
                            updateResponse,
                            ignoreEtag: true),
                        "Response body of Update does not match expectations");

                    getresponse = testContext.DnsClient.RecordSets.Get(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        "@",
                        RecordType.SOA);

                    Assert.True(
                        TestHelpers.AreEqual(updateResponse, getresponse),
                        "Response body of Get does not match expectations");

                    // SOA will get deleted with the zone
                    testContext.DnsClient.Zones.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        ifMatch: null);
                }
            }
        }

        [Fact]
        public void ListRecordsInZoneOneType()
        {
            ListRecordsInZone(isCrossType: false);
        }

        [Fact]
        public void ListRecordsInZoneAcrossTypes()
        {
            ListRecordsInZone(isCrossType: true);
        }

        [Fact]
        public void ListRecordsInZoneWithSuffixAcrossTypes()
        {
            ListRecordsInZoneWithSuffixCrossType(isCrossType: true);
        }

        [Fact]
        public void ListRecordsInZoneWithSuffix()
        {
            ListRecordsInZoneWithSuffixCrossType(isCrossType: false);
        }

        private void ListRecordsInZone(
            bool isCrossType,
            [System.Runtime.CompilerServices.CallerMemberName] string methodName
                = "testframework_failed")
        {
            using (
                MockContext context = MockContext.Start(
                    this.GetType().FullName,
                    methodName))
            {
                var testContexts = SetupSingleRecordSetTestContexts(context);
                foreach (var testContext in testContexts)
                {
                    var recordSetNames = new[]
                    {
                        TestUtilities.GenerateName("hydratestrec"),
                        TestUtilities.GenerateName("hydratestrec"),
                        TestUtilities.GenerateName("hydratestrec")
                    };

                    RecordSetScenarioTests.CreateRecordSets(
                        testContext,
                        recordSetNames);

                    if (isCrossType)
                    {
                        var listresponse1 = testContext.DnsClient.RecordSets
                            .ListByDnsZone(
                                testContext.ResourceGroup.Name,
                                testContext.ZoneName);

                        var listresponse2 = testContext.DnsClient.RecordSets
                            .ListAllByDnsZone(
                                testContext.ResourceGroup.Name,
                                testContext.ZoneName);

                        foreach (var listresponse in new[] { listresponse1, listresponse2 })
                        {
                            // not checking for the record count as this will return standard SOA and auth NS records as well
                            Assert.NotNull(listresponse);
                            Assert.True(
                                listresponse.Any(
                                    recordSetReturned =>
                                        string.Equals(
                                            recordSetNames[0],
                                            recordSetReturned.Name))
                                &&
                                listresponse.Any(
                                    recordSetReturned =>
                                        string.Equals(
                                            recordSetNames[1],
                                            recordSetReturned.Name))
                                &&
                                listresponse.Any(
                                    recordSetReturned =>
                                        string.Equals(
                                            recordSetNames[2],
                                            recordSetReturned.Name)),
                                "The returned records do not meet expectations");
                        }
                    }
                    else
                    {
                        var listresponse = testContext.DnsClient.RecordSets
                            .ListByType(
                                testContext.ResourceGroup.Name,
                                testContext.ZoneName,
                                RecordType.TXT);

                        Assert.NotNull(listresponse);
                        Assert.Equal(2, listresponse.Count());
                        Assert.True(
                            listresponse.Any(
                                recordSetReturned =>
                                    string.Equals(
                                        recordSetNames[0],
                                        recordSetReturned.Name))
                            &&
                            listresponse.Any(
                                recordSetReturned =>
                                    string.Equals(
                                        recordSetNames[1],
                                        recordSetReturned.Name)),
                            "The returned records do not meet expectations");
                    }

                    RecordSetScenarioTests.DeleteRecordSetsAndZone(
                        testContext,
                        recordSetNames);
                }
            }
        }

        private void ListRecordsInZoneWithSuffixCrossType(
            bool isCrossType,
            [System.Runtime.CompilerServices.CallerMemberName] string methodName
                = "testframework_failed")
        {
            using (
                MockContext context = MockContext.Start(
                    this.GetType().FullName,
                    methodName))
            {
                var testContexts = SetupSingleRecordSetTestContexts(context);
                foreach (var testContext in testContexts)
                {
                    string subzoneName = "contoso";

                    var recordSetNames = new[]
                    {
                        TestUtilities.GenerateName("hydratestrec"),
                        TestUtilities.GenerateName("hydratestrec"),
                        TestUtilities.GenerateName("hydratestrec")
                    }.Select(x => x + "." + subzoneName).ToArray();

                    RecordSetScenarioTests.CreateRecordSets(
                        testContext,
                        recordSetNames);

                    if (isCrossType)
                    {
                        var listresponse = testContext.DnsClient.RecordSets
                            .ListByDnsZone(
                                testContext.ResourceGroup.Name,
                                testContext.ZoneName,
                                recordsetnamesuffix: subzoneName);

                        Assert.NotNull(listresponse);
                        Assert.Equal(listresponse.Count(), recordSetNames.Length);
                        Assert.True(
                            listresponse.Any(
                                recordSetReturned =>
                                    string.Equals(
                                        recordSetNames[0],
                                        recordSetReturned.Name))
                            &&
                            listresponse.Any(
                                recordSetReturned =>
                                    string.Equals(
                                        recordSetNames[1],
                                        recordSetReturned.Name))
                            &&
                            listresponse.Any(
                                recordSetReturned =>
                                    string.Equals(
                                        recordSetNames[2],
                                        recordSetReturned.Name)),
                            "The returned records do not meet expectations");
                    }
                    else
                    {
                        var listresponse = testContext.DnsClient.RecordSets
                            .ListByType(
                                testContext.ResourceGroup.Name,
                                testContext.ZoneName,
                                RecordType.TXT,
                                recordsetnamesuffix: subzoneName);

                        Assert.NotNull(listresponse);
                        Assert.Equal(2, listresponse.Count());
                        Assert.True(
                            listresponse.Any(
                                recordSetReturned =>
                                    string.Equals(
                                        recordSetNames[0],
                                        recordSetReturned.Name))
                            &&
                            listresponse.Any(
                                recordSetReturned =>
                                    string.Equals(
                                        recordSetNames[1],
                                        recordSetReturned.Name)),
                            "The returned records do not meet expectations");
                    }

                    RecordSetScenarioTests.DeleteRecordSetsAndZone(
                        testContext,
                        recordSetNames);
                }
            }
        }


        [Fact]
        public void ListRecordsInZoneOneTypeWithTop()
        {
            this.ListRecordsInZoneWithTop(isCrossType: false);
        }

        [Fact]
        public void ListRecordsInZoneAcrossTypesWithTop()
        {
            this.ListRecordsInZoneWithTop(isCrossType: true);
        }

        private void ListRecordsInZoneWithTop(
            bool isCrossType,
            [System.Runtime.CompilerServices.CallerMemberName] string methodName
                = "testframework_failed")
        {
            using (
                MockContext context = MockContext.Start(
                    this.GetType().FullName,
                    methodName))
            {
                var testContexts = SetupSingleRecordSetTestContexts(context);
                foreach (var testContext in testContexts)
                {

                    var recordSetNames = new[]
                    {
                        TestUtilities.GenerateName("hydratestrec") + ".com",
                        TestUtilities.GenerateName("hydratestrec") + ".com",
                        TestUtilities.GenerateName("hydratestrec") + ".com"
                    };

                    RecordSetScenarioTests.CreateRecordSets(
                        testContext,
                        recordSetNames);

                    IPage<RecordSet> listResponse;

                    if (isCrossType)
                    {
                        // Using top = 3, it will pick up SOA, NS and the first TXT
                        listResponse = testContext.DnsClient.RecordSets
                            .ListByDnsZone(
                                testContext.ResourceGroup.Name,
                                testContext.ZoneName,
                                3);
                        // verify if TXT is in the list
                        Assert.True(
                            listResponse.Where(rs => rs.Type == "TXT")
                                .All(
                                    listedRecordSet =>
                                        recordSetNames.Any(
                                            createdName =>
                                                createdName == listedRecordSet.Name)),
                            "The returned records do not meet expectations");
                    }
                    else
                    {
                        // Using top = 3, it will pick up SOA, NS and the first TXT, process it and return just the TXT
                        listResponse = testContext.DnsClient.RecordSets.ListByType(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName,
                            RecordType.TXT,
                            3);
                        Assert.True(
                            listResponse.All(
                                listedRecordSet =>
                                    recordSetNames.Any(
                                        createdName =>
                                            createdName == listedRecordSet.Name)),
                            "The returned records do not meet expectations");
                    }

                    RecordSetScenarioTests.DeleteRecordSetsAndZone(
                        testContext,
                        recordSetNames);
                }
            }
        }

        [Fact]
        public void UpdateRecordSetPreconditionFailed()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
                )
            {
                var testContexts = SetupSingleRecordSetTestContexts(context);
                foreach (var testContext in testContexts)
                {
                    var createParameters = testContext.TestRecordSkeleton;
                    createParameters.CnameRecord = new CnameRecord
                    {
                        Cname = "www.contoso.example.com"
                    };

                    var createResponse = testContext.DnsClient.RecordSets
                        .CreateOrUpdate(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName,
                            testContext.RecordSetName,
                            RecordType.CNAME,
                            ifMatch: null,
                            ifNoneMatch: null,
                            parameters: createParameters);

                    var updateParameters = createResponse;

                    // expect Precondition Failed 412
                    TestHelpers.AssertThrows<CloudException>(
                        () => testContext.DnsClient.RecordSets.CreateOrUpdate(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName,
                            testContext.RecordSetName,
                            RecordType.CNAME,
                            ifMatch: "somegibberish",
                            ifNoneMatch: null,
                            parameters: updateParameters),
                        exceptionAsserts: ex => ex.Body.Code == "PreconditionFailed");

                    // expect Precondition Failed 412
                    TestHelpers.AssertThrows<CloudException>(
                        () => testContext.DnsClient.RecordSets.Delete(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName,
                            testContext.RecordSetName,
                            RecordType.CNAME,
                            ifMatch: "somegibberish"),
                        exceptionAsserts: ex => ex.Body.Code == "PreconditionFailed");

                    testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.CNAME,
                        ifMatch: null);

                    testContext.DnsClient.Zones.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        ifMatch: null);
                }
            }
        }

        private void RecordSetCreateGet(
            RecordType recordType,
            Action<RecordSet> setRecordsAction,
            bool isPrivateZoneEnabled,
            [System.Runtime.CompilerServices.CallerMemberName] string methodName
                = "testframework_failed")
        {
            using (
                MockContext context = MockContext.Start(
                    this.GetType().FullName,
                    methodName))
            {
                var testContexts = isPrivateZoneEnabled 
                    ? SetupSingleRecordSetTestContexts(context) 
                    : new [] { SetupSingleRecordSetTestForPublicZone(context) };

                foreach (var testContext in testContexts)
                {
                    var createParameters = testContext.TestRecordSkeleton;
                    setRecordsAction(createParameters);

                    var createResponse = testContext.DnsClient.RecordSets
                        .CreateOrUpdate(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName,
                            testContext.RecordSetName,
                            recordType,
                            ifMatch: null,
                            ifNoneMatch: null,
                            parameters: createParameters);

                    Assert.True(
                        TestHelpers.AreEqual(
                            createParameters,
                            createResponse,
                            ignoreEtag: true),
                        "Response body of Create does not match expectations");
                    Assert.False(string.IsNullOrWhiteSpace(createResponse.Etag));

                    var getresponse = testContext.DnsClient.RecordSets.Get(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        recordType);

                    Assert.True(
                        TestHelpers.AreEqual(
                            createResponse,
                            getresponse,
                            ignoreEtag: false),
                        "Response body of Get does not match expectations");

                    // BUG 2364951: should work without specifying ETag
                    testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        recordType,
                        ifMatch: null);

                    testContext.DnsClient.Zones.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        ifMatch: null);
                }
            }
        }

        private void RecordSetCreateGetAlias(
            RecordType recordType,
            Action<RecordSet> setRecordsAction,
            [System.Runtime.CompilerServices.CallerMemberName] string methodName
                = "testframework_failed")
        {
            using (
                MockContext context = MockContext.Start(
                    this.GetType().FullName,
                    methodName))
            {
                var testContext =  SetupSingleRecordSetTestForPublicZone(context);

                var createParameters = testContext.TestRecordSkeleton;
                setRecordsAction(createParameters);

                // Create referenced test record
                var createResponse = testContext.DnsClient.RecordSets
                    .CreateOrUpdate(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        recordType,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: createParameters);

                Assert.True(
                    TestHelpers.AreEqual(
                        createParameters,
                        createResponse,
                        ignoreEtag: true),
                    "Response body of Create does not match expectations");
                Assert.False(string.IsNullOrWhiteSpace(createResponse.Etag));

                var aliasParams = new RecordSet();
                aliasParams.TTL = createParameters.TTL;
                aliasParams.TargetResource = new SubResource(createResponse.Id);

                var aliasResponse = testContext.DnsClient.RecordSets
                    .CreateOrUpdate(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName+"alias",
                        recordType,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: aliasParams );

                Assert.True(
                    TestHelpers.AreEqual(
                        aliasParams,
                        aliasResponse,
                        ignoreEtag: true),
                    "Response body of Create does not match expectations");

                var getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    recordType);

                Assert.True(
                    TestHelpers.AreEqual(
                        createResponse,
                        getresponse,
                        ignoreEtag: false),
                    "Response body of Get does not match expectations");

                var reference = testContext.DnsClient.DnsResourceReference.GetByTargetResources(new[] { aliasParams.TargetResource });
                Assert.Equal(1, reference.DnsResourceReferences.Count);


                // BUG 2364951: should work without specifying ETag
                testContext.DnsClient.RecordSets.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    recordType,
                    ifMatch: null);

                testContext.DnsClient.Zones.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    ifMatch: null);
            }
        }

        #region Helper methods

        public static void CreateRecordSets(
            SingleRecordSetTestContext testContext,
            string[] recordSetNames)
        {
            var createParameters1 =
                testContext.GetNewTestRecordSkeleton(recordSetNames[0]);
            createParameters1.TxtRecords = new List<TxtRecord>
            {
                new TxtRecord {Value = new[] {"text1"}.ToList()}
            };
            var createParameters2 =
                testContext.GetNewTestRecordSkeleton(recordSetNames[1]);
            createParameters2.TxtRecords = new List<TxtRecord>
            {
                new TxtRecord {Value = new[] {"text1"}.ToList()}
            };
            var createParameters3 =
                testContext.GetNewTestRecordSkeleton(recordSetNames[2]);
            createParameters3.AaaaRecords = new List<AaaaRecord>
            {
                new AaaaRecord {Ipv6Address = "123::45"}
            };

            testContext.DnsClient.RecordSets.CreateOrUpdate(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                createParameters1.Name,
                RecordType.TXT,
                ifMatch: null,
                ifNoneMatch: null,
                parameters: createParameters1);

            testContext.DnsClient.RecordSets.CreateOrUpdate(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                createParameters2.Name,
                RecordType.TXT,
                ifMatch: null,
                ifNoneMatch: null,
                parameters: createParameters2);

            testContext.DnsClient.RecordSets.CreateOrUpdate(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                createParameters3.Name,
                RecordType.AAAA,
                ifMatch: null,
                ifNoneMatch: null,
                parameters: createParameters3);
        }

        public static void DeleteRecordSetsAndZone(
            SingleRecordSetTestContext testContext,
            string[] recordSetNames)
        {
            testContext.DnsClient.RecordSets.Delete(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                recordSetNames[0],
                RecordType.TXT,
                ifMatch: null);

            testContext.DnsClient.RecordSets.Delete(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                recordSetNames[1],
                RecordType.TXT,
                ifMatch: null);

            testContext.DnsClient.RecordSets.Delete(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                recordSetNames[2],
                RecordType.AAAA,
                ifMatch: null);

            testContext.DnsClient.Zones.Delete(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                ifMatch: null);
        }

        #endregion
    }
}