// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Dns.Tests;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Management.Dns.Tests
{
    [TestFixture]
    public class ScenarioTestsRecordSets : DnsManagementClientBase
    {
        private string location;
        private string resourceGroup;
        private string zoneNameForList;
        private ChangeTrackingList<AaaaRecord> dummyAaaaRecords;
        private ChangeTrackingList<ARecord> dummyARecords;
        private ChangeTrackingList<MxRecord> dummyMxRecords;
        private ChangeTrackingList<NsRecord> dummyNsRecords;
        private ChangeTrackingList<PtrRecord> dummyPtrRecords;
        private ChangeTrackingList<SrvRecord> dummySrvRecords;
        private ChangeTrackingList<TxtRecord> dummyTxtRecords;
        private ChangeTrackingList<CaaRecord> dummyCaaRecords;
        private Dictionary<string, string> metadata;
        private bool setupRun = false;

        public ScenarioTestsRecordSets()
            : base(true)
        {
            resourceGroup = null;
            location = "West US";
            zoneNameForList = "azure.ameredmond.dns";
            dummyAaaaRecords = new ChangeTrackingList<AaaaRecord>();
            dummyARecords = new ChangeTrackingList<ARecord>();
            dummyMxRecords = new ChangeTrackingList<MxRecord>();
            dummyNsRecords = new ChangeTrackingList<NsRecord>();
            dummyPtrRecords = new ChangeTrackingList<PtrRecord>();
            dummySrvRecords = new ChangeTrackingList<SrvRecord>();
            dummyTxtRecords = new ChangeTrackingList<TxtRecord>();
            dummyCaaRecords = new ChangeTrackingList<CaaRecord>();
            metadata = new Dictionary<string, string>
            {
                {"tag1", "value1"}
            };
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if ((Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback) && !setupRun)
            {
                InitializeClients();
                this.resourceGroup = Recording.GenerateAssetName("Default-Dns-");
                await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, this.location, this.resourceGroup);
                var aZone = new Zone("Global");
                await ZonesOperations.CreateOrUpdateAsync(this.resourceGroup, this.zoneNameForList, aZone);
                setupRun = true;
            }
            else if (setupRun)
            {
                initNewRecord();
            }
        }

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase]
        public async Task DnsCreateARecordDelete()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aRecords = new ChangeTrackingList<ARecord>
            {
              new ARecord {Ipv4Address = "127.0.0.1"}
            };
            var recordName = "a_record";
            var testARecordSet = new RecordSet("test_id", recordName, "A", null, this.metadata, 3600, null, null, null, aRecords, this.dummyAaaaRecords, this.dummyMxRecords,
                                               this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(this.resourceGroup, zoneNameForList, recordName, RecordType.A, testARecordSet);
            Assert.NotNull(createRecordSetResponse);
            Assert.AreEqual(createRecordSetResponse.Value.Name, recordName);
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(this.resourceGroup, zoneNameForList, recordName, RecordType.A);
            Assert.NotNull(deleteRecordSetResponse);
        }
        [TestCase]
        public async Task DnsMultiRecordCreateDelete()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var AaaaRecords = new ChangeTrackingList<AaaaRecord>
            {
                new AaaaRecord {Ipv6Address = "1:1:1:1:1:ffff:783f:e6dc"},
                new AaaaRecord {Ipv6Address = "0:0:0:0:0:ffff:403:201"},
            };

            var recordName = "aaaa_multi_record";
            var testARecordSet = new RecordSet("test_id", recordName, "Aaaa", null, this.metadata, 3600, null, null, null, this.dummyARecords, AaaaRecords,
                                               this.dummyMxRecords, this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.Aaaa, testARecordSet);
            Assert.NotNull(createRecordSetResponse);
            Assert.AreEqual(createRecordSetResponse.Value.Name, recordName);
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.A);
            Assert.NotNull(deleteRecordSetResponse);
        }

        [TestCase]
        public async Task DnsRecordSetListByResourceGroup()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aZone = new Zone("Global");
            var zoneName = "azure.ameredmondlocal2.dns";
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneName, aZone);

            var ipv6Addr = "1:1:1:1:1:ffff:783f:e6dc";
            var AaaaRecords = new ChangeTrackingList<AaaaRecord>
            {
                new AaaaRecord {Ipv6Address = ipv6Addr},
            };
            var recordName = "aaaa_record";
            var testARecordSet = new RecordSet("test_id", recordName, "Aaaa", null, this.metadata, 3600, null, null, null, this.dummyARecords, AaaaRecords, this.dummyMxRecords,
                                               this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(this.resourceGroup, zoneName, recordName, RecordType.Aaaa, testARecordSet);
            Assert.NotNull(createRecordSetResponse);
            var listResponse = RecordSetsOperations.ListAllByDnsZoneAsync(this.resourceGroup, zoneName);
            Assert.NotNull(listResponse);
            var allResults = await listResponse.ToEnumerableAsync();
            Assert.True(allResults.Count == 3); //SOA and NS record should exist
            RecordSet aaaaRecord = null;
            foreach (var arecord in allResults)
            {
                if (arecord.Type == "Microsoft.Network/dnszones/AAAA")
                {
                    aaaaRecord = arecord;
                    break;
                }
            }
            Assert.NotNull(aaaaRecord); ;
            Assert.AreEqual(aaaaRecord.AaaaRecords[0].Ipv6Address, ipv6Addr);
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(this.resourceGroup, zoneName, recordName, RecordType.A);

            var deleteZoneResponse = await ZonesOperations.StartDeleteAsync(resourceGroup, zoneName);
            Assert.NotNull(deleteZoneResponse);
        }
        [TestCase]
        public async Task DnsRecordSetListByResourceGroupTop()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aZone = new Zone("Global");
            var zoneName = "azure.ameredmondlocaltoptest.dns";
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneName, aZone);

            //var ipv6Addr = "1:1:1:1:1:ffff:783f:e6dc";
            var AaaaRecords = new ChangeTrackingList<AaaaRecord>
            {
                new AaaaRecord {Ipv6Address = "1:1:1:1:1:ffff:783f:e6dc"},
                new AaaaRecord {Ipv6Address = "0:0:0:0:0:ffff:403:201"},
            };
            var recordName = "aaaa_record666";
            var testARecordSet = new RecordSet("test_id1", recordName, "Aaaa", null, this.metadata, 3600, null, null, null, this.dummyARecords, AaaaRecords, this.dummyMxRecords,
                                               this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(this.resourceGroup, zoneName, recordName, RecordType.Aaaa, testARecordSet);
            Assert.NotNull(createRecordSetResponse);
            recordName = "aaaa_record2";
            testARecordSet = new RecordSet("test_id2", recordName, "Aaaa", null, this.metadata, 3600, null, null, null, this.dummyARecords, AaaaRecords, this.dummyMxRecords,
                                    this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);
            createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(this.resourceGroup, zoneName, recordName, RecordType.Aaaa, testARecordSet);
            var listResponse = RecordSetsOperations.ListByDnsZoneAsync(this.resourceGroup, zoneName, 1);
            var t = listResponse.AsPages();
            var pageResults = await t.ToEnumerableAsync();
            Assert.True(pageResults.Count > 1);
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(this.resourceGroup, zoneName, recordName, RecordType.A);
            var deleteZoneResponse = await ZonesOperations.StartDeleteAsync(resourceGroup, zoneName);
            Assert.NotNull(deleteZoneResponse);
        }

        [TestCase]
        public async Task DnsRecordSetListByResourceGroupNoTop()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aZone = new Zone("Global");
            var zoneName = "azure.ameredmondlocalNotoptest.dns";
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneName, aZone);

            var AaaaRecords = new ChangeTrackingList<AaaaRecord>
            {
                new AaaaRecord {Ipv6Address = "1:1:1:1:1:ffff:783f:e6dc"},
                new AaaaRecord {Ipv6Address = "0:0:0:0:0:ffff:403:201"},
            };
            var recordName = "aaaa_record66";
            var testARecordSet = new RecordSet("test_id1", recordName, "Aaaa", null, this.metadata, 3600, null, null, null, this.dummyARecords, AaaaRecords, this.dummyMxRecords,
                                               this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(this.resourceGroup, zoneName, recordName, RecordType.Aaaa, testARecordSet);
            Assert.NotNull(createRecordSetResponse);
            recordName = "aaaa_record2";
            testARecordSet = new RecordSet("test_id2", recordName, "Aaaa", null, this.metadata, 3600, null, null, null, this.dummyARecords, AaaaRecords, this.dummyMxRecords,
                                    this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);
            createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(this.resourceGroup, zoneName, recordName, RecordType.Aaaa, testARecordSet);
            var listResponse = RecordSetsOperations.ListByDnsZoneAsync(this.resourceGroup, zoneName);
            var t = listResponse.AsPages();
            var pageResults = await t.ToEnumerableAsync();
            Assert.True(pageResults.Count == 1);
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(this.resourceGroup, zoneName, recordName, RecordType.A);
            var deleteZoneResponse = await ZonesOperations.StartDeleteAsync(resourceGroup, zoneName);
            Assert.NotNull(deleteZoneResponse);
        }

        [TestCase]
        public async Task DnsRecordSetUpdateSoa()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var ipv6Addr = "1:1:1:1:1:ffff:783f:e6dc";
            var AaaaRecords = new ChangeTrackingList<AaaaRecord>
            {
                new AaaaRecord {Ipv6Address = ipv6Addr},
            };
            var recordName = "soa_record";
            var testARecordSet = new RecordSet("test_id", recordName, "Aaaa", null, this.metadata, 3600, null, null, null, this.dummyARecords, AaaaRecords, this.dummyMxRecords,
                                               this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.Aaaa, testARecordSet);
            Assert.NotNull(createRecordSetResponse);
            var getResponseSoa = await RecordSetsOperations.GetAsync(this.resourceGroup, this.zoneNameForList, "@", RecordType.SOA);

            var soaRecord = getResponseSoa.Value;
            soaRecord.SoaRecord.ExpireTime = 123;
            soaRecord.SoaRecord.MinimumTtl = 1234;
            soaRecord.SoaRecord.RefreshTime = 12345;
            soaRecord.SoaRecord.RetryTime = 123456;
            var updateResponse = await RecordSetsOperations.CreateOrUpdateAsync(this.resourceGroup, this.zoneNameForList, "@", RecordType.SOA, soaRecord);
            Assert.True(Helper.AreEqual(updateResponse, soaRecord, ignoreEtag: true));
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.A);
        }

        [TestCase]
        public async Task DnsUpdateARecord()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aRecords = new ChangeTrackingList<ARecord>
            {
              new ARecord {Ipv4Address = "123.32.1.0"}
            };
            var recordName = "a_update_record";
            var testARecordSet = new RecordSet("test_id", recordName, "A", null, this.metadata, 60, null, null, null, aRecords, this.dummyAaaaRecords, this.dummyMxRecords,
                                               this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.A, testARecordSet);
            Assert.True(Helper.AreEqual(createRecordSetResponse, testARecordSet, ignoreEtag: true));
            var getResponseARecord = await RecordSetsOperations.GetAsync(this.resourceGroup, this.zoneNameForList, recordName, RecordType.A);
            var aRecord = getResponseARecord.Value;
            aRecord.TTL = 120; //update TTL from 60 to 120
            var updateResponse = await RecordSetsOperations.CreateOrUpdateAsync(this.resourceGroup, this.zoneNameForList, recordName, RecordType.A, aRecord);
            Assert.AreEqual(updateResponse.Value.TTL, 120);
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.A);
            Assert.NotNull(deleteRecordSetResponse);
        }

        [TestCase]
        public async Task CreateGetMx()
        {
            var mxRecords = new ChangeTrackingList<MxRecord>
                {
                    new MxRecord {Exchange = "mail1.scsfsm.com", Preference = 1},
                    new MxRecord {Exchange = "mail2.scsfsm.com", Preference = 2},
                };
            var recordName = "mx_record";
            var testMxRecordSet = new RecordSet("test_id", recordName, "MX", null, this.metadata, 60, null, null, null, this.dummyARecords, this.dummyAaaaRecords, mxRecords,
                                    this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);
            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.MX, testMxRecordSet);
            Assert.True(Helper.AreEqual(createRecordSetResponse, testMxRecordSet, ignoreEtag: true));
        }

        [TestCase]
        public async Task CreateGetNs()
        {
            var nsRecords = new ChangeTrackingList<NsRecord>
            {
                new NsRecord {Nsdname = "ns1.scsfsm.com"},
                new NsRecord {Nsdname = "ns2.scsfsm.com"},
            };
            var recordName = "ns_record";
            var testNsecordSet = new RecordSet("test_id", recordName, "NS", null, this.metadata, 60, null, null, null, this.dummyARecords, this.dummyAaaaRecords, this.dummyMxRecords,
                        nsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);
            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.NS, testNsecordSet);
            Assert.True(Helper.AreEqual(createRecordSetResponse, testNsecordSet, ignoreEtag: true));
        }

        [TestCase]
        public async Task CreateGetPtr()
        {
            var ptrRecords = new ChangeTrackingList<PtrRecord>
            {
                new PtrRecord {Ptrdname = "www1.scsfsm.com"},
                new PtrRecord {Ptrdname = "www2.scsfsm.com"},
            };
            var recordName = "ptr_record";
            var testPtrRecordSet = new RecordSet("test_id", recordName, "PTR", null, this.metadata, 60, null, null, null, this.dummyARecords, this.dummyAaaaRecords, this.dummyMxRecords,
                        this.dummyNsRecords, ptrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);
            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.PTR, testPtrRecordSet);
            Assert.True(Helper.AreEqual(createRecordSetResponse, testPtrRecordSet, ignoreEtag: true));
        }

        [TestCase]
        public async Task CreateGetSrv()
        {
            var srvRecords = new ChangeTrackingList<SrvRecord>
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

            var recordName = "srv_record";
            var testSrvRecordSet = new RecordSet("test_id", recordName, "SRV", null, this.metadata, 60, null, null, null, this.dummyARecords, this.dummyAaaaRecords, this.dummyMxRecords,
                        this.dummyNsRecords, this.dummyPtrRecords, srvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);
            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.SRV, testSrvRecordSet);
            Assert.True(Helper.AreEqual(createRecordSetResponse, testSrvRecordSet, ignoreEtag: true));
        }

        [TestCase]
        public async Task CreateGetTxt()
        {
            var txtRecords = new ChangeTrackingList<TxtRecord>
            {
                    new TxtRecord(new List<string>{"lorem"}),
                    new TxtRecord(new List<string>{"ipsum"}),
            };
            var recordName = "txt_record";
            var testTxtRecordSet = new RecordSet("test_id", recordName, "TXT", null, this.metadata, 60, null, null, null, this.dummyARecords, this.dummyAaaaRecords, this.dummyMxRecords,
                        this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, txtRecords, null, null, this.dummyCaaRecords);
            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.TXT, testTxtRecordSet);
            Assert.True(Helper.AreEqual(createRecordSetResponse, testTxtRecordSet, ignoreEtag: true));
        }

        [TestCase]
        public async Task DnsUpdateARecordMultiRecord()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aRecords = new ChangeTrackingList<ARecord>
            {
              new ARecord {Ipv4Address = "123.32.1.0"}
            };
            var recordName = "a_multi_record";
            var testARecordSet = new RecordSet("test_id", recordName, "A", null, this.metadata, 60, null, null, null, aRecords, this.dummyAaaaRecords, this.dummyMxRecords,
                                               this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.A, testARecordSet);
            Assert.True(Helper.AreEqual(createRecordSetResponse, testARecordSet, ignoreEtag: true));
            var getResponseARecord = await RecordSetsOperations.GetAsync(this.resourceGroup, this.zoneNameForList, recordName, RecordType.A);
            var aRecord = getResponseARecord.Value;
            aRecord.TTL = 120; //update TTL from 60 to 120
            aRecord.ARecords.Clear();
            var aList = new List<ARecord>
                    {
                        new ARecord {Ipv4Address = "123.32.1.0"},
                        new ARecord {Ipv4Address = "101.10.0.1"},
                        new ARecord {Ipv4Address = "22.33.44.55"},
                    };
            ((List<ARecord>)aRecord.ARecords).AddRange(aList);
            var updateResponse = await RecordSetsOperations.CreateOrUpdateAsync(this.resourceGroup, this.zoneNameForList, recordName, RecordType.A, aRecord);
            var updatedRecords = updateResponse.Value;
            Assert.AreEqual(updatedRecords.TTL, 120);
            for (int i = 0; i < aList.Count; i++)
            {
                Assert.True(updatedRecords.ARecords[i].Ipv4Address == aList[i].Ipv4Address);
            }
            Assert.False(string.IsNullOrWhiteSpace(updatedRecords.Etag));
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.A);
            Assert.NotNull(deleteRecordSetResponse);
        }

        [TestCase]
        public async Task UpdateRecordSetPreconditionFailed()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var cnameRecord = new CnameRecord { Cname = "www.contoso.example.com" };
            var recordName = "cname_record";
            var testCnameRecordSet = new RecordSet("test_id", recordName, "Cname", null, this.metadata, 60, null, null, null, this.dummyARecords, this.dummyAaaaRecords, this.dummyMxRecords,
                                               this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, cnameRecord, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.Cname, testCnameRecordSet);
            bool exceptionCaught = false;
            try
            {
                await RecordSetsOperations.CreateOrUpdateAsync(
                               this.resourceGroup,
                               this.zoneNameForList,
                               recordName,
                               RecordType.Cname,
                               ifMatch: "somegibberish",
                               ifNoneMatch: null,
                               parameters: testCnameRecordSet);
            }
            catch (Azure.RequestFailedException)
            {
                exceptionCaught = true;
            }
            finally
            {
                Assert.True(exceptionCaught);
            }
        }
    }
}
