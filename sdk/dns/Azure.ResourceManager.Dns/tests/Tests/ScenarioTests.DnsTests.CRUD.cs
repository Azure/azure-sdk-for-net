// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Dns.Tests;
using System.Collections.Generic;
using System;
using Azure.Core;

namespace Azure.Management.Dns.Tests
{

    public partial class ScenarioTests : DnsManagementClientBase
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

        public ScenarioTests(bool isAsync)
            : base(isAsync)
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
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
                this.resourceGroup = Recording.GenerateAssetName("Default-Dns-");
                await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, this.location, this.resourceGroup);
                var aZone = new Zone("Global");
                var tags = new Dictionary<string, string>
                {
                    {"key1", "value1"}
                };
                aZone.ZoneType = ZoneType.Public;
                await ZonesOperations.CreateOrUpdateAsync(this.resourceGroup, this.zoneNameForList, aZone);

            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task DnsCreateARecordDelete()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aZone = new Zone("Global");
            var tags = new Dictionary<string, string>
            {
                {"key1", "value1"}
            };
            aZone.ZoneType = ZoneType.Public;
            var zoneName = "azure.ameredmond.dns";
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneName, aZone);
            var aRecords = new ChangeTrackingList<ARecord>
            {
              new ARecord {Ipv4Address = "127.0.0.1"}
            };
            var recordName = "record1";
            var testARecordSet = new RecordSet("test_id", recordName, "A", null, this.metadata, 3600, null, null, null, aRecords, this.dummyAaaaRecords, this.dummyMxRecords,
                                               this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, zoneName, "record1", RecordType.A, testARecordSet);
            Assert.NotNull(createRecordSetResponse);
            Console.WriteLine(createRecordSetResponse.Value.Name);
            Assert.AreEqual(createRecordSetResponse.Value.Name, recordName);
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(resourceGroup, zoneName, recordName, RecordType.A);
            Assert.NotNull(deleteRecordSetResponse);
            var deleteZoneResponse = await ZonesOperations.StartDeleteAsync(resourceGroup, zoneName);
            Assert.NotNull(deleteZoneResponse);
        }
        [Test]
        public async Task DnsMultiRecordCreateDelete()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aZone = new Zone("Global");
            var tags = new Dictionary<string, string>
            {
                {"key1", "value1"}
            };
            aZone.ZoneType = ZoneType.Public;
            var zoneName = "azure.ameredmond.dns";
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneName, aZone);
            var AaaaRecords = new ChangeTrackingList<AaaaRecord>
            {
                new AaaaRecord {Ipv6Address = "1:1:1:1:1:ffff:783f:e6dc"},
                new AaaaRecord {Ipv6Address = "0:0:0:0:0:ffff:403:201"},
            };

            var recordName = "record2";
            var testARecordSet = new RecordSet("test_id", recordName, "Aaaa", null, this.metadata, 3600, null, null, null, this.dummyARecords, AaaaRecords,
                                               this.dummyMxRecords, this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, zoneName, recordName, RecordType.Aaaa, testARecordSet);
            Assert.NotNull(createRecordSetResponse);
            Console.WriteLine(createRecordSetResponse.Value.Name);
            Assert.AreEqual(createRecordSetResponse.Value.Name, recordName);
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(resourceGroup, zoneName, recordName, RecordType.A);
            Assert.NotNull(deleteRecordSetResponse);
            var deleteZoneResponse = await ZonesOperations.StartDeleteAsync(resourceGroup, zoneName);
            Assert.NotNull(deleteZoneResponse);
        }

        [Test]
        public async Task DnsRecordSetListByResourceGroup()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var ipv6Addr = "1:1:1:1:1:ffff:783f:e6dc";
            var AaaaRecords = new ChangeTrackingList<AaaaRecord>
            {
                new AaaaRecord {Ipv6Address = ipv6Addr},
            };
            var recordName = "record2";
            var testARecordSet = new RecordSet("test_id", recordName, "Aaaa", null, this.metadata, 3600, null, null, null, this.dummyARecords, AaaaRecords, this.dummyMxRecords,
                                               this.dummyNsRecords, this.dummyPtrRecords, this.dummySrvRecords, this.dummyTxtRecords, null, null, this.dummyCaaRecords);

            var createRecordSetResponse = await RecordSetsOperations.CreateOrUpdateAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.Aaaa, testARecordSet);
            Assert.NotNull(createRecordSetResponse);
            var listResponse = RecordSetsOperations.ListAllByDnsZoneAsync(this.resourceGroup, this.zoneNameForList);
            Assert.NotNull(listResponse);
            var allResults = await listResponse.ToEnumerableAsync();
            Console.WriteLine("Count is : " + allResults.Count);
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
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.A);
        }


        [Test]
        public async Task DnsRecordSetUpdateSoa()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var ipv6Addr = "1:1:1:1:1:ffff:783f:e6dc";
            var AaaaRecords = new ChangeTrackingList<AaaaRecord>
            {
                new AaaaRecord {Ipv6Address = ipv6Addr},
            };
            var recordName = "recordSub";
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
            Assert.True(Helper.AreEqual(updateResponse, updateResponse,ignoreEtag: true));
            var deleteRecordSetResponse = await RecordSetsOperations.DeleteAsync(resourceGroup, this.zoneNameForList, recordName, RecordType.A);
        }

    }
}
