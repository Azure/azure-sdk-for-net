// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Dns.Tests.Scenario
{
    internal class DnsZoneTest : DnsServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private DnsZoneCollection _dnsZoneCollection;

        public DnsZoneTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _dnsZoneCollection = _resourceGroup.GetDnsZones();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _dnsZoneCollection.GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var dnsZone = await CreateDnsZone(dnsZoneName, _resourceGroup);
            Assert.NotNull(dnsZone);
            Assert.AreEqual(dnsZoneName, dnsZone.Data.Name);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var dnsZone = await CreateDnsZone(dnsZoneName, _resourceGroup);
            bool flag = await _dnsZoneCollection.ExistsAsync(dnsZoneName);
            Assert.IsTrue(flag);

            await dnsZone.DeleteAsync(WaitUntil.Completed);
            flag = await _dnsZoneCollection.ExistsAsync(dnsZoneName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreateDnsZone(dnsZoneName, _resourceGroup);
            bool flag = await _dnsZoneCollection.ExistsAsync(dnsZoneName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreateDnsZone(dnsZoneName, _resourceGroup);
            var dnsZone = await _dnsZoneCollection.GetAsync(dnsZoneName);
            Assert.IsNotNull(dnsZone);
            Assert.AreEqual(dnsZoneName, dnsZone.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreateDnsZone(dnsZoneName, _resourceGroup);
            var list = await _dnsZoneCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(dnsZoneName, list.FirstOrDefault().Data.Name);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        [RecordedTest]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreateDnsZone(dnsZoneName, _resourceGroup);
            var dnsZone = await CreateDnsZone(dnsZoneName, _resourceGroup);

            // AddTag
            await dnsZone.AddTagAsync("addtagkey", "addtagvalue");
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(30000);
            }
            dnsZone = await _dnsZoneCollection.GetAsync(dnsZoneName);
            Assert.AreEqual(1, dnsZone.Data.Tags.Count);
            KeyValuePair<string, string> tag = dnsZone.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await dnsZone.RemoveTagAsync("addtagkey");
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(30000);
            }
            dnsZone = await _dnsZoneCollection.GetAsync(dnsZoneName);
            Assert.AreEqual(0, dnsZone.Data.Tags.Count);
        }

        [RecordedTest]
        public async Task GetAllRecords()
        {
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var dnszone = await CreateDnsZone(dnsZoneName, _resourceGroup);

            // Add some aaaaRecord
            var aaaaRecord1 = await dnszone.GetDnsAaaaRecords().CreateOrUpdateAsync(WaitUntil.Completed, "aaaa100", new DnsAaaaRecordData()
            {
                TtlInSeconds = 3600,
                DnsAaaaRecords =
                {
                    new DnsAaaaRecordInfo()
                    {
                        IPv6Address = IPAddress.Parse("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d55")
                    },
                    new DnsAaaaRecordInfo()
                    {
                        IPv6Address = IPAddress.Parse("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d56")
                    },
                }
            });
            var aaaaRecord2 = await dnszone.GetDnsAaaaRecords().CreateOrUpdateAsync(WaitUntil.Completed, "aaaa200", new DnsAaaaRecordData()
            {
                TtlInSeconds = 3600,
                DnsAaaaRecords =
                {
                    new DnsAaaaRecordInfo()
                    {
                        IPv6Address = IPAddress.Parse("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d57")
                    }
                }
            });

            // Add some caaRecord
            var caaRecord1 = await dnszone.GetDnsCaaRecords().CreateOrUpdateAsync(WaitUntil.Completed, "caa100", new DnsCaaRecordData()
            {
                TtlInSeconds = 3600,
                DnsCaaRecords =
                {
                    new DnsCaaRecordInfo()
                    {
                        Flags = 1,
                        Tag = "test1",
                        Value = "caa1.contoso.com"
                    },
                    new DnsCaaRecordInfo()
                    {
                        Flags = 2,
                        Tag = "test2",
                        Value = "caa2.contoso.com"
                    },
                }
            });
            var caaRecord2 = await dnszone.GetDnsCaaRecords().CreateOrUpdateAsync(WaitUntil.Completed, "caa200", new DnsCaaRecordData()
            {
                TtlInSeconds = 3600,
                DnsCaaRecords =
                {
                    new DnsCaaRecordInfo()
                    {
                        Flags = 3,
                        Tag = "test3",
                        Value = "caa3.contoso.com"
                    }
                }
            });

            // Add some MXRecord
            var mxRecord = await dnszone.GetDnsMXRecords().CreateOrUpdateAsync(WaitUntil.Completed, "mx100", new DnsMXRecordData()
            {
                TtlInSeconds = 3600,
                DnsMXRecords =
                {
                    new DnsMXRecordInfo()
                    {
                        Preference = 10,
                        Exchange = "mymail1.contoso.com"
                    }
                }
            });
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(10000);
            }

            var recordSets = await dnszone.GetAllRecordDataAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(recordSets);
            Assert.IsNotNull(recordSets[0].DnsNSRecords);
            Assert.IsNotNull(recordSets[1].DnsSoaRecordInfo);

            Assert.AreEqual(2, recordSets[2].DnsAaaaRecords.Count);
            Assert.AreEqual("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d55", recordSets[2].DnsAaaaRecords.First().IPv6Address.ToString());
            Assert.AreEqual(1, recordSets[3].DnsAaaaRecords.Count);
            Assert.AreEqual("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d57", recordSets[3].DnsAaaaRecords.First().IPv6Address.ToString());

            Assert.AreEqual(2, recordSets[4].DnsCaaRecords.Count);
            Assert.AreEqual("caa1.contoso.com", recordSets[4].DnsCaaRecords.First().Value.ToString());
            Assert.AreEqual(1, recordSets[5].DnsCaaRecords.Count);
            Assert.AreEqual("caa3.contoso.com", recordSets[5].DnsCaaRecords.First().Value.ToString());

            Assert.AreEqual("mymail1.contoso.com", recordSets[6].DnsMXRecords.First().Exchange.ToString());
        }
    }
}
