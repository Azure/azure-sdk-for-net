// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public DnsZoneTest(bool isAsync) : base(isAsync)
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
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task CreateOrUpdate()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            var dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            Assert.NotNull(dnsZone);
            Assert.Equals(dnsZoneName, dnsZone.Data.Name);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task Delete()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            var dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            bool flag = await _dnsZoneCollection.ExistsAsync(dnsZoneName);
            Assert.IsTrue(flag);

            await dnsZone.DeleteAsync(WaitUntil.Completed);
            flag = await _dnsZoneCollection.ExistsAsync(dnsZoneName);
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task Exist()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            await CreateADnsZone(dnsZoneName, _resourceGroup);
            bool flag = await _dnsZoneCollection.ExistsAsync(dnsZoneName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task Get()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            await CreateADnsZone(dnsZoneName, _resourceGroup);
            var dnsZone = await _dnsZoneCollection.GetAsync(dnsZoneName);
            Assert.IsNotNull(dnsZone);
            Assert.Equals(dnsZoneName, dnsZone.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task GetAll()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            await CreateADnsZone(dnsZoneName, _resourceGroup);
            var list = await _dnsZoneCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(dnsZoneName, list.FirstOrDefault().Data.Name);
        }

        [Test]
        [RecordedTest]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        public async Task GetRecordSets()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            var dnszone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            var recordSets = await dnszone.GetAllRecordDataAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(recordSets);
            Assert.AreEqual(2, recordSets.Count);
        }
    }
}
