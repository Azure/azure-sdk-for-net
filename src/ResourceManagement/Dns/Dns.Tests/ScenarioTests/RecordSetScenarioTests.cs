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
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Dns;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Management.Dns.Models;

namespace Microsoft.Azure.Management.Dns.Testing
{
    public class RecordSetScenarioTests
    {
        public class SingleRecordSetTestContext
        {
            public string ZoneName { get; set; }

            public string RecordSetName { get; set; }

            public string Location { get; set; }

            public ResourceGroupExtended ResourceGroup { get; set; }

            public DnsManagementClient DnsClient { get; set; }

            public RecordSetCreateOrUpdateParameters TestRecordSkeleton 
            {
                get { return this.GetNewTestRecordSkeleton(this.RecordSetName); }

            }

            public RecordSetCreateOrUpdateParameters GetNewTestRecordSkeleton(string recordSetName, uint ttl = 42)
            {
                return new RecordSetCreateOrUpdateParameters
                {
                    RecordSet = new RecordSet
                    {
                        Name = recordSetName,
                        Location = this.Location,
                        ETag = null,
                        Properties = new RecordSetProperties
                        {
                            Ttl = ttl,
                        }
                    }
                };
            }
        }

        private static SingleRecordSetTestContext SetupSingleRecordSetTest()
        {
            var testContext = new SingleRecordSetTestContext();
            testContext.ZoneName = TestUtilities.GenerateName("hydratestdnszone.com");
            testContext.RecordSetName = TestUtilities.GenerateName("hydratestdnsrec");
            testContext.Location = ResourceGroupHelper.GetResourceLocation(ResourceGroupHelper.GetResourcesClient(), "microsoft.network/dnszones");
            testContext.ResourceGroup = ResourceGroupHelper.CreateResourceGroup();
            testContext.DnsClient = ResourceGroupHelper.GetDnsClient();
            ResourceGroupHelper.CreateZone(testContext.DnsClient, testContext.ZoneName, testContext.Location, testContext.ResourceGroup);
            return testContext;
        }

        [Fact]
        public void CrudRecordSetFullCycle()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                SingleRecordSetTestContext testContext = SetupSingleRecordSetTest();
                RecordSetCreateOrUpdateParameters createParameters = testContext.TestRecordSkeleton;
                createParameters.RecordSet.Properties.ARecords = new List<ARecord> { new ARecord { Ipv4Address = "123.32.1.0" } };
                createParameters.RecordSet.Properties.Ttl = 60;

                // Create the records clean, verify response
                RecordSetCreateOrUpdateResponse createResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    RecordType.A,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: createParameters);

                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
                Assert.True(
                    TestHelpers.AreEqual(createParameters.RecordSet, createResponse.RecordSet, ignoreEtag: true),
                    "Response body of Create does not match expectations");
                Assert.False(string.IsNullOrWhiteSpace(createResponse.RecordSet.ETag));

                // Retrieve the zone after create, verify response
                var getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name, 
                    testContext.ZoneName, 
                    testContext.RecordSetName, 
                    RecordType.A);

                Assert.Equal(HttpStatusCode.OK, getresponse.StatusCode);
                Assert.True(
                    TestHelpers.AreEqual(createResponse.RecordSet, getresponse.RecordSet, ignoreEtag: false),
                    "Response body of Get does not match expectations");

                // Call Update on the object returned by Create (important distinction from Get below)
                Models.RecordSet createdRecordSet = createResponse.RecordSet;

                createdRecordSet.Properties.Ttl = 120;
                createdRecordSet.Properties.Metadata = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" } };
                createdRecordSet.Properties.ARecords = new List<ARecord> 
                { 
                    new ARecord { Ipv4Address = "123.32.1.0" }, 
                    new ARecord { Ipv4Address = "101.10.0.1" } 
                };

                RecordSetCreateOrUpdateResponse updateResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name, 
                    testContext.ZoneName, 
                    testContext.RecordSetName, 
                    RecordType.A,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: new RecordSetCreateOrUpdateParameters { RecordSet = createdRecordSet });

                Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
                Assert.True(
                    TestHelpers.AreEqual(createdRecordSet, updateResponse.RecordSet, ignoreEtag: true),
                    "Response body of Update does not match expectations");
                Assert.False(string.IsNullOrWhiteSpace(updateResponse.RecordSet.ETag));

                // Retrieve the records after create, verify response
                getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name, 
                    testContext.ZoneName, 
                    testContext.RecordSetName, 
                    RecordType.A);

                Assert.Equal(HttpStatusCode.OK, getresponse.StatusCode);
                Assert.True(
                    TestHelpers.AreEqual(updateResponse.RecordSet, getresponse.RecordSet),
                    "Response body of Get does not match expectations");

                // Call Update on the object returned by Get (important distinction from Create above)
                Models.RecordSet retrievedRecordSet = getresponse.RecordSet;
                retrievedRecordSet.Properties.Ttl = 180;
                retrievedRecordSet.Properties.ARecords = new List<ARecord> 
                { 
                    new ARecord { Ipv4Address = "123.32.1.0" }, 
                    new ARecord { Ipv4Address = "101.10.0.1" },
                    new ARecord { Ipv4Address = "22.33.44.55" },
                };

                updateResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name, 
                    testContext.ZoneName, 
                    testContext.RecordSetName, 
                    RecordType.A,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: new RecordSetCreateOrUpdateParameters { RecordSet = retrievedRecordSet });

                Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
                Assert.True(
                    TestHelpers.AreEqual(retrievedRecordSet, updateResponse.RecordSet, ignoreEtag: true),
                    "Response body of Update does not match expectations");
                Assert.False(string.IsNullOrWhiteSpace(updateResponse.RecordSet.ETag));

                // Delete the record set
                AzureOperationResponse deleteResponse = testContext.DnsClient.RecordSets.Delete(
                    testContext.ResourceGroup.Name, 
                    testContext.ZoneName, 
                    testContext.RecordSetName, 
                    RecordType.A,
                    ifMatch: null,
                    ifNoneMatch: null);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                // Delete the zone
                deleteResponse = testContext.DnsClient.Zones.Delete(
                    testContext.ResourceGroup.Name, 
                    testContext.ZoneName,
                    ifMatch: null, 
                    ifNoneMatch: null);
            }
        }

        [Fact]
        public void CreateGetA()
        {
            Action<RecordSetCreateOrUpdateParameters> setTestRecords = createParams => 
            {
                createParams.RecordSet.Properties.ARecords = new List<ARecord> 
                    { 
                        new ARecord { Ipv4Address = "120.63.230.220" }, 
                        new ARecord { Ipv4Address = "4.3.2.1" },
                    };

                return;
            };

            this.RecordSetCreateGet(RecordType.A, setTestRecords);
        }

        [Fact]
        public void CreateGetAaaa()
        {
            Action<RecordSetCreateOrUpdateParameters> setTestRecords = createParams =>
            {
                createParams.RecordSet.Properties.AaaaRecords = new List<AaaaRecord> 
                    { 
                        new AaaaRecord { Ipv6Address = "0:0:0:0:0:ffff:783f:e6dc" }, 
                        new AaaaRecord { Ipv6Address = "0:0:0:0:0:ffff:403:201" },
                    };

                return;
            };

            this.RecordSetCreateGet(RecordType.AAAA, setTestRecords);
        }

        [Fact]
        public void CreateGetMx()
        {
            Action<RecordSetCreateOrUpdateParameters> setTestRecords = createParams =>
            {
                createParams.RecordSet.Properties.MxRecords = new List<MxRecord> 
                    { 
                        new MxRecord { Exchange = "mail1.scsfsm.com", Preference = 1 }, 
                        new MxRecord { Exchange = "mail2.scsfsm.com", Preference = 2 },

                };

                return;
            };

            this.RecordSetCreateGet(RecordType.MX, setTestRecords);
        }

        [Fact]
        public void CreateGetNs()
        {
            Action<RecordSetCreateOrUpdateParameters> setTestRecords = createParams =>
            {
                createParams.RecordSet.Properties.NsRecords = new List<NsRecord> 
                    { 
                        new NsRecord { Nsdname = "ns1.scsfsm.com" }, 
                        new NsRecord { Nsdname = "ns2.scsfsm.com" },
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.NS, setTestRecords);
        }

        [Fact(Skip = "PTR is not yet supported in the service.")]
        public void CreateGetPtr()
        {
            Action<RecordSetCreateOrUpdateParameters> setTestRecords = createParams =>
            {
                createParams.RecordSet.Properties.PtrRecords = new List<PtrRecord> 
                    { 
                        new PtrRecord { Ptrdname = "www1.scsfsm.com" }, 
                        new PtrRecord { Ptrdname = "www2.scsfsm.com" },
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.PTR, setTestRecords);
        }

        [Fact]
        public void CreateGetSrv()
        {
            Action<RecordSetCreateOrUpdateParameters> setTestRecords = createParams =>
            {
                createParams.RecordSet.Properties.SrvRecords = new List<SrvRecord> 
                    { 
                        new SrvRecord { Target = "bt2.scsfsm.com", Priority = 0, Weight = 2, Port = 44 }, 
                        new SrvRecord { Target = "bt1.scsfsm.com", Priority = 1, Weight = 1, Port = 45 },
                    };

                return;
            };

            this.RecordSetCreateGet(RecordType.SRV, setTestRecords);
        }

        [Fact]
        public void CreateGetTxt()
        {
            Action<RecordSetCreateOrUpdateParameters> setTestRecords = createParams =>
            {
                createParams.RecordSet.Properties.TxtRecords = new List<TxtRecord> 
                    {    
                        new TxtRecord { Value = new[] {"lorem"}.ToList() }, 
                        new TxtRecord { Value = new[] {"ipsum"}.ToList() }, 
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.TXT, setTestRecords);
        }

        [Fact]
        public void CreateGetCname()
        {
            Action<RecordSetCreateOrUpdateParameters> setTestRecords = createParams =>
            {
                createParams.RecordSet.Properties.CnameRecord = new CnameRecord
                {
                    Cname = "www.contoroso.com",
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.CNAME, setTestRecords);
        }

        [Fact]
        public void UpdateSoa()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                SingleRecordSetTestContext testContext = SetupSingleRecordSetTest();

                // SOA for the zone should already exist
                RecordSetGetResponse getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    "@",
                    RecordType.SOA);

                Assert.Equal(HttpStatusCode.OK, getresponse.StatusCode);
                RecordSet soaResource = getresponse.RecordSet;
                Assert.NotNull(soaResource);
                Assert.NotNull(soaResource.Properties.SoaRecord);

                soaResource.Properties.SoaRecord.ExpireTime = 123;
                soaResource.Properties.SoaRecord.MinimumTtl = 1234;
                soaResource.Properties.SoaRecord.RefreshTime = 12345;
                soaResource.Properties.SoaRecord.RetryTime = 123456;

                var updateParameters = new RecordSetCreateOrUpdateParameters { RecordSet = soaResource };

                RecordSetCreateOrUpdateResponse updateResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    "@",
                    RecordType.SOA,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: updateParameters);

                Assert.Equal(HttpStatusCode.OK, getresponse.StatusCode);
                Assert.True(
                    TestHelpers.AreEqual(soaResource, updateResponse.RecordSet, ignoreEtag: true),
                    "Response body of Update does not match expectations");

                getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    "@",
                    RecordType.SOA);

                Assert.Equal(HttpStatusCode.OK, getresponse.StatusCode);
                Assert.True(
                    TestHelpers.AreEqual(updateResponse.RecordSet, getresponse.RecordSet),
                    "Response body of Get does not match expectations");

                // SOA will get deleted with the zone
                testContext.DnsClient.Zones.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    ifMatch: null, 
                    ifNoneMatch: null);
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

        private void ListRecordsInZone(bool isCrossType)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(currentMethodStackDepth: 4);
                SingleRecordSetTestContext testContext = SetupSingleRecordSetTest();

                var recordSetNames = new[] { TestUtilities.GenerateName("hydratestrec"), TestUtilities.GenerateName("hydratestrec"), TestUtilities.GenerateName("hydratestrec") };

                RecordSetScenarioTests.CreateRecordSets(testContext, recordSetNames);

                if (isCrossType)
                {
                    RecordSetListResponse listresponse = testContext.DnsClient.RecordSets.ListAll(
                        testContext.ResourceGroup.Name, 
                        testContext.ZoneName,
                        new RecordSetListParameters());

                    // not checking for the record count as this will return standard SOA and auth NS records as well
                    Assert.NotNull(listresponse);
                    Assert.True(
                        listresponse.RecordSets.Any(recordSetReturned => string.Equals(recordSetNames[0], recordSetReturned.Name))
                        && listresponse.RecordSets.Any(recordSetReturned => string.Equals(recordSetNames[1], recordSetReturned.Name))
                        && listresponse.RecordSets.Any(recordSetReturned => string.Equals(recordSetNames[2], recordSetReturned.Name)),
                        "The returned records do not meet expectations");
                }
                else
                {
                    RecordSetListResponse listresponse = testContext.DnsClient.RecordSets.List(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        RecordType.TXT,
                        new RecordSetListParameters());

                    Assert.NotNull(listresponse);
                    Assert.Equal(2, listresponse.RecordSets.Count);
                    Assert.True(
                        listresponse.RecordSets.Any(recordSetReturned => string.Equals(recordSetNames[0], recordSetReturned.Name))
                        && listresponse.RecordSets.Any(recordSetReturned => string.Equals(recordSetNames[1], recordSetReturned.Name)),
                        "The returned records do not meet expectations");
                }

                RecordSetScenarioTests.DeleteRecordSetsAndZone(testContext, recordSetNames);
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

        private void ListRecordsInZoneWithTop(bool isCrossType)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(currentMethodStackDepth: 4);
                SingleRecordSetTestContext testContext = RecordSetScenarioTests.SetupSingleRecordSetTest();

                var recordSetNames = new[] { TestUtilities.GenerateName("hydratestrec") + ".com", TestUtilities.GenerateName("hydratestrec") + ".con", TestUtilities.GenerateName("hydratestrec") + ".con" };

                RecordSetScenarioTests.CreateRecordSets(testContext, recordSetNames);

                RecordSetListResponse listResponse;

                if (isCrossType)
                {
                    // Using top = 3, it will pick up SOA, NS and the first TXT
                    listResponse = testContext.DnsClient.RecordSets.ListAll(
                        testContext.ResourceGroup.Name, 
                        testContext.ZoneName,
                        new RecordSetListParameters { Top = "3" });
                }
                else
                {
                    // Using top = 3, it will pick up SOA, NS and the first TXT, process it and return just the TXT
                    listResponse = testContext.DnsClient.RecordSets.List(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        RecordType.TXT,
                        new RecordSetListParameters { Top = "3" });
                }

                Assert.NotNull(listResponse);
                Assert.True(
                    listResponse.RecordSets.Any(recordReturned => string.Equals(recordSetNames[0], recordReturned.Name)),
                    "The returned records do not meet expectations");

                RecordSetScenarioTests.DeleteRecordSetsAndZone(testContext, recordSetNames);
            }
        }

        private void ListRecordsInZoneWithFilter(bool isCrossType)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(currentMethodStackDepth: 4);
                SingleRecordSetTestContext testContext = RecordSetScenarioTests.SetupSingleRecordSetTest();

                var recordSetNames = new[] { TestUtilities.GenerateName("hydratestrec"), TestUtilities.GenerateName("hydratestrec"), TestUtilities.GenerateName("hydratestrec") };

                RecordSetScenarioTests.CreateRecordSets(testContext, recordSetNames);

                RecordSetListResponse listResponse;

                if (isCrossType)
                {
                    listResponse = testContext.DnsClient.RecordSets.ListAll(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        new RecordSetListParameters { Filter = string.Format("endswith(Name,'{0}')", recordSetNames[0]) });
                }
                else
                {
                    listResponse = testContext.DnsClient.RecordSets.List(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        RecordType.TXT,
                        new RecordSetListParameters { Filter = string.Format("endswith(Name,'{0}')", recordSetNames[0]) });
                }

                // not checking for the record count as this will return standard SOA and auth NS records as well
                Assert.NotNull(listResponse);
                Assert.Equal(1, listResponse.RecordSets.Count);
                Assert.NotNull(listResponse.RecordSets.FirstOrDefault());
                Assert.Equal(recordSetNames[0], listResponse.RecordSets.FirstOrDefault().Name);

                RecordSetScenarioTests.DeleteRecordSetsAndZone(testContext, recordSetNames);
            }
        }

        [Fact]
        public void ListRecordsInZoneOneTypeWithNext()
        {
            this.ListRecordsInZoneWithNext(isCrossType: false);
        }

        [Fact]
        public void ListRecordsInZoneAcrossTypesWithNext()
        {
            this.ListRecordsInZoneWithNext(isCrossType: true);
        }

        private void ListRecordsInZoneWithNext(bool isCrossType)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(currentMethodStackDepth: 4);
                SingleRecordSetTestContext testContext = RecordSetScenarioTests.SetupSingleRecordSetTest();

                const string suffix = ".com";

                var recordSetNames = new[] { TestUtilities.GenerateName("hydratestrec") + suffix, TestUtilities.GenerateName("hydratestrec") + ".com", TestUtilities.GenerateName("hydratestrec") + ".com" };

                RecordSetScenarioTests.CreateRecordSets(testContext, recordSetNames);

                RecordSetListResponse listResponse;

                if (isCrossType)
                {
                    listResponse = testContext.DnsClient.RecordSets.ListAll(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        new RecordSetListParameters { Top = "3" });
                }
                else
                {
                    listResponse = testContext.DnsClient.RecordSets.List(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        RecordType.TXT,
                        new RecordSetListParameters { Top = "1" });
                }

                listResponse = testContext.DnsClient.RecordSets.ListNext(listResponse.NextLink);

                Assert.NotNull(listResponse);
                Assert.True(
                    listResponse.RecordSets.Any(recordReturned => string.Equals(recordSetNames[1], recordReturned.Name)),
                    "The returned records do not meet expectations");

                RecordSetScenarioTests.DeleteRecordSetsAndZone(testContext, recordSetNames);
            }
        }

        [Fact]
        public void UpdateRecordSetPreconditionFailed()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                SingleRecordSetTestContext testContext = SetupSingleRecordSetTest();
                RecordSetCreateOrUpdateParameters createParameters = testContext.TestRecordSkeleton;
                createParameters.RecordSet.Properties.CnameRecord = new CnameRecord { Cname = "www.contoso.example.com" };

                RecordSetCreateOrUpdateResponse createResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    RecordType.CNAME,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: createParameters);

                RecordSetCreateOrUpdateParameters updateParameters = new RecordSetCreateOrUpdateParameters { RecordSet = createResponse.RecordSet };
                updateParameters.RecordSet.ETag = "somegibberish";

                // expect Precondition Failed 412
                TestHelpers.AssertThrows<CloudException>(
                    () => testContext.DnsClient.RecordSets.CreateOrUpdate(
                        testContext.ResourceGroup.Name, 
                        testContext.ZoneName, 
                        testContext.RecordSetName, 
                        RecordType.CNAME,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: updateParameters),
                    exceptionAsserts: ex => ex.Error.Code == "PreconditionFailed");

                // expect Precondition Failed 412
                TestHelpers.AssertThrows<CloudException>(
                    () => testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.CNAME,
                        ifMatch: null,
                        ifNoneMatch: null),
                    exceptionAsserts: ex => ex.Error.Code == "PreconditionFailed");

                testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.CNAME,
                        ifMatch: null,
                        ifNoneMatch: null);

                testContext.DnsClient.Zones.Delete(testContext.ResourceGroup.Name, testContext.ZoneName, ifMatch: null, ifNoneMatch: null);
            }
        }

        private void RecordSetCreateGet(
            RecordType recordType,
            Action<RecordSetCreateOrUpdateParameters> setRecordsAction)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(currentMethodStackDepth: 4);
                SingleRecordSetTestContext testContext = SetupSingleRecordSetTest();
                RecordSetCreateOrUpdateParameters createParameters = testContext.TestRecordSkeleton;
                setRecordsAction(createParameters);

                RecordSetCreateOrUpdateResponse createResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    recordType,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: createParameters);

                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
                Assert.True(
                    TestHelpers.AreEqual(createParameters.RecordSet, createResponse.RecordSet, ignoreEtag: true),
                    "Response body of Create does not match expectations");
                Assert.False(string.IsNullOrWhiteSpace(createResponse.RecordSet.ETag));

                var getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    recordType);

                Assert.Equal(HttpStatusCode.OK, getresponse.StatusCode);
                Assert.True(
                    TestHelpers.AreEqual(createResponse.RecordSet, getresponse.RecordSet, ignoreEtag: false),
                    "Response body of Get does not match expectations");

                // BUG 2364951: should work without specifying ETag
                AzureOperationResponse deleteResponse = testContext.DnsClient.RecordSets.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    recordType,
                    ifMatch: null,
                    ifNoneMatch: null);  
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                deleteResponse = testContext.DnsClient.Zones.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    ifMatch: null, 
                    ifNoneMatch: null);
            }
        }

        #region Helper methods

        public static void CreateRecordSets(SingleRecordSetTestContext testContext, string[] recordSetNames)
        {
            RecordSetCreateOrUpdateParameters createParameters1 = testContext.GetNewTestRecordSkeleton(recordSetNames[0]);
            createParameters1.RecordSet.Properties.TxtRecords = new List<TxtRecord> { new TxtRecord { Value = new [] { "text1" }.ToList() } };
            RecordSetCreateOrUpdateParameters createParameters2 = testContext.GetNewTestRecordSkeleton(recordSetNames[1]);
            createParameters2.RecordSet.Properties.TxtRecords = new List<TxtRecord> { new TxtRecord { Value = new[] { "text1" }.ToList() } };
            RecordSetCreateOrUpdateParameters createParameters3 = testContext.GetNewTestRecordSkeleton(recordSetNames[2]);
            createParameters3.RecordSet.Properties.AaaaRecords = new List<AaaaRecord> { new AaaaRecord { Ipv6Address = "123::45" } };

            testContext.DnsClient.RecordSets.CreateOrUpdate(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                createParameters1.RecordSet.Name,
                RecordType.TXT,
                ifMatch: null,
                ifNoneMatch: null,
                parameters: createParameters1);

            testContext.DnsClient.RecordSets.CreateOrUpdate(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                createParameters2.RecordSet.Name,
                RecordType.TXT,
                ifMatch: null,
                ifNoneMatch: null,
                parameters: createParameters2);

            testContext.DnsClient.RecordSets.CreateOrUpdate(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                createParameters3.RecordSet.Name,
                RecordType.AAAA,
                ifMatch: null,
                ifNoneMatch: null,
                parameters: createParameters3);
        }

        public static void DeleteRecordSetsAndZone(SingleRecordSetTestContext testContext, string[] recordSetNames)
        {
            testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        recordSetNames[0],
                        RecordType.TXT,
                        ifMatch: null,
                        ifNoneMatch: null);

            testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        recordSetNames[1],
                        RecordType.TXT,
                        ifMatch: null,
                        ifNoneMatch: null);

            testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        recordSetNames[2],
                        RecordType.AAAA,
                        ifMatch: null,
                        ifNoneMatch: null);

            testContext.DnsClient.Zones.Delete(testContext.ResourceGroup.Name, testContext.ZoneName, ifMatch: null, ifNoneMatch: null);
        }

        #endregion
    }
}