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

        public DnsZoneTest(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("Dns-RG-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroup = rgLro.Value;

            await StopSessionRecordingAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _resourceGroup.GetDnsZones().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            var dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            Assert.NotNull(dnsZone);
            Assert.Equals(dnsZoneName, dnsZone.Data.Name);
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        [RecordedTest]
        public async Task Delete()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            var dnsZone = await CreateADnsZone(dnsZoneName, _resourceGroup);
            Assert.IsTrue(_resourceGroup.GetDnsZones().Exists(dnsZoneName));

            await dnsZone.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(_resourceGroup.GetDnsZones().Exists(dnsZoneName));
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        [RecordedTest]
        public async Task Exist()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            await CreateADnsZone(dnsZoneName, _resourceGroup);
            Assert.IsTrue(_resourceGroup.GetDnsZones().Exists(dnsZoneName));
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        [RecordedTest]
        public async Task Get()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            await CreateADnsZone(dnsZoneName, _resourceGroup);
            var dnsZone =await _resourceGroup.GetDnsZones().GetAsync(dnsZoneName);
            Assert.IsNotNull(dnsZone);
            Assert.Equals(dnsZoneName, dnsZone.Value.Data.Name);
        }

        [Test]
        [Ignore("Castle.DynamicProxy.Generators.GeneratorException")]
        [RecordedTest]
        public async Task GetAll()
        {
            string dnsZoneName = $"{SessionRecording.GenerateAssetName("sample")}.com";
            await CreateADnsZone(dnsZoneName, _resourceGroup);
            var list = await _resourceGroup.GetDnsZones().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(dnsZoneName, list.FirstOrDefault().Data.Name);
        }
    }
}
