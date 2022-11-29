// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
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

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var dnsZone = await CreateDnsZone(dnsZoneName, _resourceGroup);
            Assert.NotNull(dnsZone);
            Assert.AreEqual(dnsZoneName, dnsZone.Data.Name);
        }

        [Test]
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

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreateDnsZone(dnsZoneName, _resourceGroup);
            bool flag = await _dnsZoneCollection.ExistsAsync(dnsZoneName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreateDnsZone(dnsZoneName, _resourceGroup);
            var dnsZone = await _dnsZoneCollection.GetAsync(dnsZoneName);
            Assert.IsNotNull(dnsZone);
            Assert.AreEqual(dnsZoneName, dnsZone.Value.Data.Name);
        }

        [Test]
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

        [Test]
        [RecordedTest]
        public async Task GetAllRecords()
        {
            string dnsZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var dnszone = await CreateDnsZone(dnsZoneName, _resourceGroup);
            var recordSets = await dnszone.GetAllRecordDataAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(recordSets);
            Assert.AreEqual(2, recordSets.Count);
        }
    }
}
